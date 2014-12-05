#!/usr/bin/env python
# -*- coding:utf-8 -*-

import logging
import pymongo
import setting

class mongoConn:
	def __init__(self):
		self.conn=None

	def __enter__(self):
		self.conn=pymongo.Connection(setting.mongo['host'],setting.mongo['port'])
		return self.conn

	def __exit__(self,*args):
		self.conn.disconnect()
