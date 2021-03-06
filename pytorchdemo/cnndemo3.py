# -*- coding: UTF-8 -*-
''''
author: zwzhang
email: zwzhang@colibri.com.cn
Created on: 2019/3/15 14:01
Software: PyCharm Community Edition
'''
import torch
import torch.nn as nn
import torch.nn.functional as F
import numpy
import cv2
import torchvision
import torch.optim as optim
from torchvision import datasets, models, transforms
from torch.autograd import Variable

class CNNnet(torch.nn.Module):
    def __init__(self):
        super(CNNnet, self).__init__()
        self.conv1 = torch.nn.Sequential(
            torch.nn.Conv2d(in_channels=3,    # input 3,16,400,1400
                            out_channels=16, #16个filter，提取16个特征作为输出
                            kernel_size=5,
                            stride=1,
                            padding=2),
            torch.nn.BatchNorm2d(16),  # 是一个filter,提取特征， 特征窗
            torch.nn.ReLU(),
            torch.nn.MaxPool2d(2)  # 池化层 out 16,200,700
        )
        self.conv2 = torch.nn.Sequential(
            torch.nn.Conv2d(16, 32, 5, 1, 2),
            torch.nn.BatchNorm2d(32),
            torch.nn.ReLU(),
            torch.nn.MaxPool2d(2)  # 32,100,350
        )
        self.conv3 = torch.nn.Sequential(
            torch.nn.Conv2d(32, 32, 5, 1, 2),
            torch.nn.BatchNorm2d(32),
            torch.nn.ReLU(),
            torch.nn.MaxPool2d(2)  # 32 50 175
        )
        # self.conv4 = torch.nn.Sequential(
        #
        #     torch.nn.Conv2d(32, 64, 5, 1, 2),  # 2*32*48
        #     torch.nn.BatchNorm2d(64),
        #     torch.nn.ReLU(),
        #     torch.nn.MaxPool2d(2)  # 64,25,87
        # )
        # self.mlp1 = torch.nn.Linear(2*2*2*16*24, 2000)
        self.mlp1 = torch.nn.Linear(32*64*64, 1000)
        self.mlp2 = torch.nn.Linear(1000, 2)

    def forward(self, x):
        x = self.conv1(x)
        x = self.conv2(x)
        x = self.conv3(x)

        # x = self.conv4(x)
        # print(x.shape)
        # t = x.size(0)
        x = self.mlp1(x.view(x.size(0), -1))
        out = self.mlp2(x)
        return out


train_data = torchvision.datasets.ImageFolder('D:/debug/python/pytorchdemo/pic/train',
                                            transform=transforms.Compose([
                                                # transforms.Scale(512,768),
                                                # transforms.Resize((512,768)),
                                                transforms.CenterCrop(512),
                                                transforms.ToTensor()])
                                            )
test_data = torchvision.datasets.ImageFolder('D:/debug/python/pytorchdemo/pic/val',
                                            transform=transforms.Compose([
                                                # transforms.Scale(512,768),
                                                # transforms.Resize((768,512)),
                                                transforms.CenterCrop(512),
                                                transforms.ToTensor()])
                                            )
train_loader = torch.utils.data.DataLoader(train_data, batch_size=2,shuffle=True)
test_loader = torch.utils.data.DataLoader(test_data,batch_size=2, shuffle=True)
# print(train_data.train_data.size())
# x1,x2 = train_data.samples[0]
# # print(x1)


model = CNNnet()
loss_func = nn.CrossEntropyLoss()
optimizer = optim.SGD(model.parameters(), lr=0.001)  # 设置学习方法
# num_epochs = 100 # 设置训练次数
EPOCH = 20
# print(model)

def train_fun():
    # epochs = 0

    loss_list = []
    for epoch in range(EPOCH):
        step = 0
        for data in (train_loader):
            b_x,b_y=data
            b_x,b_y=Variable(b_x),Variable(b_y)
            out_put=model(b_x)
            loss=loss_func(out_put,b_y)
            optimizer.zero_grad()
            loss.backward()
            optimizer.step()
            step += 1
        #
        # if epochs < 20:
        #     epochs += 1
            print('Epoch: ', epoch,'step: ',step,'loss: ', float(loss))
            loss_list.append(float(loss))
        # else:
        #     epochs += 1

    return loss_list


# criterion = nn.MSELoss()  # 设定误差函数
def test_fun():
    eval_loss = 0
    eval_acc = 0
    # for eopch in range(EPOCH):
    for data in (test_loader):
        b_x, b_y = data
        b_x, b_y = Variable(b_x), Variable(b_y)  # b_x 是 img b_y是标签
        out_put = model(b_x)
        loss = loss_func(out_put, b_y)
        eval_loss += loss.data.item() * b_y.size(0)
        _, pred = torch.max(out_put, 1)
        # print("pred",pred,b_y)
        num_correct = (pred == b_y).sum()
        eval_acc += num_correct.item()
        # print(eval_acc)
        print('Test Loss: {:.4f}, Acc: {:.4f}'.format(
        eval_loss / (len(test_data)),
        eval_acc / (len(test_data)), 100. * eval_acc / len(test_data)
    ))


def main():
    print("------starting-------")


if __name__ == '__main__':
    main()
    print("ok")
    # params = list(model.parameters())
    # print(len(params))
    # print(model)
    # print(params[0].size())  # conv1's .weight
    # train_fun()
    # torch.save(model,"mycnn2")
    # test_fun()
    print("model ok")
