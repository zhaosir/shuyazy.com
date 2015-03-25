#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
import tornado
from tornado import gen
from .base import BaseHandler
from control import ads,classes

class TestHandler(BaseHandler):
	@gen.coroutine
	def get(self):
		cc = yield ads.get_ads()
		print cc
		self.write('ok')

class ImageHandler(BaseHandler):
	def get(self,picid):
		print picid
		self.redirect('http://img0.bdstatic.com/img/image/4a75a05f8041bf84df4a4933667824811426747915.jpg',permanent=True)

class IndexHandler(BaseHandler):
	def get(self):
		self.render('index.html')


