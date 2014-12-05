#!/usr/bin/env python
# coding:utf-8 -*-

from control import ads

ad_list = ads.get_ads()
for i in ad_list:
	print i
