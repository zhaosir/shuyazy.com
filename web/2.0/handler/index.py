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

class ApiCloudFileHandler(BaseHandler):
	@gen.coroutine
	def get(self,picid):
		img =yield image.getImagebyId(picid)
		if img:
			url = img['file']['url']
			self.redirect(url,permanent=True)

class IndexHandler(BaseHandler):
	def get(self):
		banner = list()
		banner.append({"url":"/products/1","img":"/static/images/banner.jpg?v=e9a67bb4f4c57cb49a2c4d98fb7df462"})
		banner.append({"url":"/products/1","img":"/static/images/banner.jpg?v=e9a67bb4f4c57cb49a2c4d98fb7df462"})
		self.render('index.html',banner=banner)



class ProductsHandler(BaseHandler):
	def get(self,tid):
		print tid
		self.render('products.html')

class TalkHandler(BaseHandler):
	def get(self):
		self.render('talk.html')

class AboutHandler(BaseHandler):
	def get(self):
		self.render('aboutus.html')

class ContactHandler(BaseHandler):
	def get(self):
		self.render('contact.html')
