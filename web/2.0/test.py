#!/usr/bin/env python
# coding:utf-8 -*-

from control import ads,classes
import time
def test():
	print 'test...'
	ad = yield ads.get_ads()
	print 'ads',ad
test()
while True:
	print 'sleep'
	time.sleep(1)
