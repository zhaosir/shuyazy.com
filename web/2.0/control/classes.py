#!/usr/bin/env python
# -*- coding:utf-8 -*-

from mongo import mongoConn
import logging
from bson.objectid import ObjectId
import datetime

logger=logging.getLogger(__name__)

def get_classes():
	with mongoConn() as conn:
		return conn.shuyazy.classes.find()

def get_class_detail(classid):
	with mongoConn() as conn:
		return conn.shuyazy.classes.find_one({'_id':ObjectId(classid)})

def add_class_detail(classname):
	with mongoConn() as conn:
		return conn.shuyazy.classes.insert({'name':classname,'date':datetime.datetime.now()})
