#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
import tornado
from .base import BaseHandler
class IndexHandler(BaseHandler):
	def get(self):
		self.render('index.html')
