#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
import tornado
from tornado import gen
from .base import BaseHandler
from control import api,image
import re
#from  control import *

class TestHandler(BaseHandler):
	@gen.coroutine
	def get(self):
		cc = yield api.get_products_top(p=1,size=9)
		print cc
		self.send_json(cc[1])

class ApiCloudFileHandler(BaseHandler):
	@gen.coroutine
	def get(self,picid):
		img =yield image.getImagebyId(picid)
		size = self.get_argument('size',None)
		if img:
			url = img['file']['url']
			url = re.compile(r'http://.*\.com',re.IGNORECASE).sub('http://78rfbc.com2.z0.glb.qiniucdn.com',url)
			if size:
				url = url +'!' + size
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
		p = int(self.get_argument('p',1))
		size = 9
		if tid:
			if tid == 'new':
				products = yield api.get_products_new(p=p,size=size)
			else:
				tid = int(tid)
				products = yield api.get_products_class(cid=tid,p=p,size=size)
		else:
			products = yield api.get_products_top(p=p,size=size)
		self.render('products.html',products=products[1],pagecount=self.get_pagecount(products[0]['count'],size))

class TalkHandler(BaseHandler):
	def get(self):
		self.render('talk.html')

class AboutHandler(BaseHandler):
	def get(self):
		self.render('aboutus.html')

class ContactHandler(BaseHandler):
	def get(self):
		self.render('contact.html')
