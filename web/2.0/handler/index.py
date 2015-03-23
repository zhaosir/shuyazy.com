#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
from tornado import web
from .base import BaseHandler

class IndexHandler(BaseHandler):
	def get(self):
		print 'xxxx'
		self.render('index.html')
