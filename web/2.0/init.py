#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import sys
import tornado.httpserver
from tornado import web
import tornado.ioloop
from tornado.options import define,options

define("port",default=8900,help="listen port" ,type=int)
define("debug",default = True,help = "debug mode")
define("project_path",default=sys.path[0],help="project path")

options.parse_command_line()

URLS =((r'',
		(r'/?','handler.index.IndexHandler'),
	   ),
)

import setting as _setting

class Application(web.Application):
	def __init__(self):
		settings = {
			"debug":options.debug,
			"gzip":True,
			"static_path":os.path.join(options.project_path,"static"),
			"template_path":os.path.join(options.project_path,"template"),
			"cookie_secret":_setting.COOKIE_SECRET,
			"xsrf_cookies":True
		}
		print settings
		web.Application.__init__(self,**settings)
		for spec in URLS:
			self.add_handlers(spec[0],spec[1:])

if __name__ == "__main__":
	application = Application()
	http_server = tornado.httpserver.HTTPServer(application)
	http_server.listen(options.port)
	tornado.ioloop.IOLoop.instance().start()
