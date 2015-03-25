#! /usr/bin/env python
# -*- coding:utf-8 -*-

import os
import os
import setting
from lib.http import ansy_apicloud_request as apicloud
from tornado import gen
import time

@gen.coroutine
def getImagebyId(imgid):
	img = yield apicloud('images/'+imgid+'?',
			method='GET',
			params={'_t':time.time()},
			exc_message='获取图片失败')
	raise gen.Return(img)
