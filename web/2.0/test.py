#!/usr/bin/env python
# coding:utf-8 -*-

from control import ads,classes

#classes.add_class_detail('湿巾')
ad_list = classes.get_class_detail('54814f23a88dd64d595d5e7b')
print ad_list
for i in ad_list:
	print type(i)
	print i
