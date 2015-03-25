#!/usr/bin/env python
# -*- coding:utf-8 -*-


import logging
import setting
import lib.http as _http
from tornado import gen

logger = logging.getLogger(__name__)

@gen.coroutine
def get_ads():
	params = {'where':{'state':True},'order':'updatedAt DESC','skip':0,'limit':20}
	ads =yield _http.ansy_apicloud_request('ads?filter=',
			method='GET',
			params = params,
			exc_message='获取广告数据失败')
#return ads
	raise gen.Return(ads)
