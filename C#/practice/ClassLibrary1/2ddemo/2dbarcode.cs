﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Windows.Forms;
using ZXing;
using ZXing.Presentation;
using ZXing.Common;

namespace OpenCVDemo
{
    public partial class OpenCVDemoForm : Form
    {
        private VideoCapture capture;
        bool Capturing;
        private readonly IBarcodeReaderImage reader;

        public OpenCVDemoForm()
        {
            InitializeComponent();
            reader = new BarcodeReaderImage();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "TIFF (*.tif,*.tiff)|*.tif;*.tiff| JPG (*.jpg,*.jpeg)|*.jpg *.jpeg|*.*|*.*";
                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var src = new Mat(openFileDialog.FileName);
                        var result = reader.Decode(src);
                        if (result != null)
                        {
                            txtResult.Text = result.Text;
                            txtResultBarcodeType.Text = result.BarcodeFormat.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                try
                {
                    capture = VideoCapture.FromCamera(0);
                }
                catch (NullReferenceException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                catch (OpenCvSharpException exc)
                {
                    MessageBox.Show(
                       "Attention: You have to copy all the assemblies and native libraries from an official release of OpenCV to the directory of the demo." +
                       Environment.NewLine + Environment.NewLine + exc);
                }
            }

            if (capture != null)
            {
                if (Capturing)
                {
                    captureButton.Text = "Start Capturing";
                    Application.Idle -= DoDecoding;
                }
                else
                {
                    captureButton.Text = "Stop Capturing";
                    Application.Idle += DoDecoding;
                }
                Capturing = !Capturing;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (capture != null)
                capture.Dispose();
        }


        private void DoDecoding(object sender, EventArgs args)
        {
            var timerStart = DateTime.Now.Ticks;

            var image = capture.RetrieveMat();
            if (image != null &&
                image.Height > 0)
            {
                using (image)
                {
                    // show it
                    pictureBox1.Image = image.ToBitmap();
                    // decode it
                    var result = reader.Decode(image);
                    // show result
                    if (result != null)
                    {
                        txtResult.Text = result.Text;
                        txtResultBarcodeType.Text = result.BarcodeFormat.ToString();
                    }
                }
            }
            var timerStop = DateTime.Now.Ticks;
            labDuration.Text = new TimeSpan(timerStop - timerStart).Milliseconds.ToString("0 ms");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

