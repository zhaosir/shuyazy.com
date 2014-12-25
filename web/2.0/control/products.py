#!/usr/bin/env python
# -*- coding:utf-8 -*-

from mongo import mongoConn
from bson.objectid import ObjectId


def get_products(p,size,classid):
	with mongoConn() as conn:
		conn.shuyazy.products.find({'classid':classid}).limit(size).skip((p-1)*size+1)
