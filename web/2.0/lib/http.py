#! /usr/bin/env python
# -*- coding:utf-8 -*-

import json
import hashlib
import setting
import time
from urllib import quote
from functools import partial
from tornado import gen
from tornado import httpclient
from tornado.httputil import url_concat
from tornado.escape import json_encode


def getApiCloudAppkey():
	now = int(time.time()*1000)
	appkey = setting.APICLOUD['appid'] + 'UZ' + setting.APICLOUD['appkey'] + 'UZ'+ str(now) 
	return hashlib.sha1(appkey).hexdigest() + '.' + str(now)


def make_uri(api_uri,params={}):
	p =json_encode(params) if params else ''
	api_uri = setting.APICLOUD['restapi']+api_uri
	return api_uri+quote(p)


def handle_json_request(response,callback=None,exc_message=None):
	url = response.request.url
	if response.error:
		response.rethrow()
	else:
		res = json.loads(response.body)
		callback(res)

def _ansy_apicloud_request(api_uri,method='GET',params={},callback=None,exc_message=None):
	'''
	requst apicloud
	'''
	if method == "GET":
		body = None
		uri = make_uri(api_uri,params)
	else :
		body = json_encode(params)
		uri = setting.APICLOUD['restapi']+api_uri
	print uri
	handle_req = partial(handle_json_request,callback=callback,exc_message=exc_message)
	http_client = httpclient.AsyncHTTPClient()
	return http_client.fetch(uri,
							method=method,
							connect_timeout=setting.APICLOUD['timeout'],
							request_timeout=setting.APICLOUD['timeout'],
							body=body,
							callback=handle_req,
							headers={
								'X-APICloud-AppId':setting.APICLOUD['appid'],
								'X-APICloud-AppKey':getApiCloudAppkey(),
								'Content-Type':'application/json'
							})

ansy_apicloud_request = partial(gen.Task,_ansy_apicloud_request)
