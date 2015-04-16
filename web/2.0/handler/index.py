#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
import tornado
from tornado import gen
from .base import BaseHandler
from control import api,image
#from  control import *

class TestHandler(BaseHandler):
	@gen.coroutine
	def get(self):
		cc = yield api.get_products_top(p=1,size=9)
		print len(cc)
		self.send_json(cc)

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
		banner.append({"url":"/products/1","img":"/apicloud/images/552e0f7ad90c83341342b408.jpg"})
		banner.append({"url":"/products/1","img":"/apicloud/images/552e0f9447918c3a13a90e53.jpg"})
		banner.append({"url":"/products/1","img":"/apicloud/images/552e0f9ad90c83341342b409.jpg"})
		banner.append({"url":"/products/1","img":"/apicloud/images/552e0f9e24299e371370a7fd.jpg"})
		banner.append({"url":"/products/1","img":"/apicloud/images/552e0fe724299e371370a7fe.jpg"})
		self.render('index.html',banner=banner)



class ProductsHandler(BaseHandler):
	@gen.coroutine
	def get(self,tid):
		print tid
		products = yield api.get_products_top(p=1,size=9)
		self.render('products.html',products=products)

class TalkHandler(BaseHandler):
	def get(self):
		self.render('talk.html')

class AboutHandler(BaseHandler):
	def get(self):
		self.render('aboutus.html')

class ContactHandler(BaseHandler):
	def get(self):
		self.render('contact.html')
