# Generated by Django 3.0.6 on 2020-06-12 11:54

from django.db import migrations, models
import django.utils.timezone


class Migration(migrations.Migration):

    dependencies = [
        ('blog', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='blog',
            name='creat_date',
            field=models.DateTimeField(default=django.utils.timezone.now),
            preserve_default=False,
        ),
    ]
