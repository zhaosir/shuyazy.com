#!/usr/bin/env python
# -*- coding:utf-8 -*-


import logging
import setting
import lib.http as _http

logger = logging.getLogger(__name__)

def get_ads():
	print _http.getApiCloudAppkey()
