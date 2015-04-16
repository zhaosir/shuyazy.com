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
	raise gen.Return(ads)

@gen.coroutine
def get_banners():
	params = {'where':{'state':True,'order':'updateAt DESC','skip':0,'limit':5}}
	banners = yield _http.ansy_apicloud_request('banners?filter=',
			method='GET',
			params=params,
			exc_message='')
	raise gen.Return(banners)

@gen.coroutine
def get_conf():
	params = {}
	conf = yield _http.ansy_apicloud_request('conf?filter=',
			method='GET',
			params=params,
			exc_message='')
	raise gen.Return(conf)

@gen.coroutine
def get_products_class(cid,p,size):
	params = {'where':{'state':True,'class_id':cid},'order':'hot DESC','skip':(p-1)*size,'limit':size}
	products =yield get_products(params=params)
	count = yield get_products_count(params=params)
	raise gen.Return((count,products))

@gen.coroutine
def get_products_new(p,size):
	params = {'where':{'state':True},'order':'createdAt DESC','skip':(p-1)*size,'limit':size}
	products =yield  get_products(params=params)
	count = yield get_products_count(params=params)
	raise gen.Return((count,products))

@gen.coroutine
def get_products_top(p,size):
	params = {'where':{'state':True},'order':'hot DESC','skip':(p-1)*size,'limit':size}
	products =yield get_products(params=params)
	count = yield get_products_count(params=params)
	raise gen.Return((count,products))

@gen.coroutine
def update_product_hot(pid):
	params = {'$inc':{'hot':1},'_method':'PUT'}
	result = yield _http.ansy_apicloud_request('products/'+pid,
			method='POST',
			params=params,
			exc_message='')
	raise gen.Return(result)


def get_products_count(params):
	return _http.ansy_apicloud_request('products/count?filter=',
			method='GET',
			params=params,
			exc_message='')

def get_products(params):
	return  _http.ansy_apicloud_request('products?filter=',
			method='GET',
			params=params,
			exc_message='')


