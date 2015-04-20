#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
from tornado import gen
from .base import BaseHandler
import tornado.web
from control import api

class ConfHandler(BaseHandler):
	@gen.coroutine
	def get(self):
		conf = yield api.get_conf()
		self.send_json(conf)

