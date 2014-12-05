#!/usr/bin/env python
# -*- coding:utf-8 -*-


import logging
import setting
from mongo import mongoConn

logger = logging.getLogger(__name__)

def get_ads():
	with mongoConn() as conn:
		return conn.shuyazy.ads.find()
