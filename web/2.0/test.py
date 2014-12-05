#!/usr/bin/env python
# coding:utf-8 -*-

from control import ads,classes

ad_list = classes.get_class_detail('54813ecb40068b45e7e3ec8c')
print ad_list
for i in ad_list:
	print type(i)
	print i
