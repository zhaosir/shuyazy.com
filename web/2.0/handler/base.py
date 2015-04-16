#! /usr/bin/env python
# -*- coding:utf-8 -*-

import logging
from tornado import web,gen
import json
import re
from math import floor  

class BaseHandler(web.RequestHandler):
	def send_json(self,response):
		date2str = lambda obj:obj.isoformat() if isinstance(obj,datetime.datetime) else None
		resp = json.dumps(response,default = date2str)
		callback = self.get_argument('callback',None)
		if callback:
			callback = re.sub(r'[^\w\.]', '', callback)
			self.set_header('Content-Type', 'text/javascript; charet=UTF-8')
			resp = '%s(%s)' % (callback, resp)
		else:
			self.set_header('Content-Type', 'application/json')
		self.write(resp)
		self.finish()

	def get_pagecount(self,total,size):
		if total > size:
			pagecount =  int(floor(total/float(size)))
			if pagecount * size < total:
				return pagecount +1
			return pagecount
		else:
			return 1
