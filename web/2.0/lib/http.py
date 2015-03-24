#! /usr/bin/env python
# -*- coding:utf-8 -*-

import json
import hashlib
import setting
import time
from tornado import httpclient
from tornado.httputil import url_concat
from tornado.escape import json_encode


def getApiCloudAppkey():
	now = int(time.time()*1000)
	appkey = setting.APICLOUD['appid'] + 'UZ' + setting.APICLOUD['appkey'] + 'UZ'+ str(now) 
	return hashlib.sha1(appkey).hexdigest() + '.' + str(now)


def make_uri(api_uri,params={}):
	return url_concat(setting.APICLOUD['restapi'],api_uri,json_encode(params))

def _ansy_apicloud_request(api_uri,method='GET',params={},classback=None,exc_message=None):
	'''
	requst apicloud
	'''
	if method == "GET":
		uri = make_uri(api_uri,params)
	else :
		body = json_encode(params)
		uri = url_concat(setting.APICLOUD['restapi'],api_uri)
	
	httpclient = httpclient.AnsycHTTPClient()
	return httpclient.fetch(uri,
							method=method,
							connect_timeout=setting.APICLOUD['timeout'],
							request_timeout=setting.APICLOUD['timeout'],
							body=body,
							callback=None,
							headers={
								'X-APICloud-AppId':setting.APICLOUD['appid'],
								'X-APICloud-AppKey',getApiCloudAppkey(),
								'Content-Type':'application/json'
							})
