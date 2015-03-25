#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
import tornado
from tornado import gen
from .base import BaseHandler
from control import ads,classes,image
#from  control import *

class TestHandler(BaseHandler):
	@gen.coroutine
	def get(self):
		cc = yield ads.get_ads()
		print cc
		self.write('ok')

class ImageHandler(BaseHandler):
	@gen.coroutine
	def get(self,picid):
		img =yield image.getImagebyId(picid)
		if img:
			url = img['file']['url']
			self.redirect(url,permanent=True)

class IndexHandler(BaseHandler):
	def get(self):
		self.render('index.html')


