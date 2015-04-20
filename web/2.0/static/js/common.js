var App = App || {};

(function(ns){
	var conf={
		companyname:'漯河舒雅纸业',
		address:'河南省漯河市黄河路中段劳动局西邻版权所有',
		mobile:'13849499216',
		email:'shuya@shuyazy.com',
		taobao_url:'http://shop111925822.taobao.com',
		qq:'13849499216',
		wxname:'舒雅纸业'
	};
	ns.siteconf = function(){
		$(".companyname").text(conf.companyname);
		$('.address').text(conf.address);
		$('.mobile').text(conf.mobile);
		$('.email').text(conf.email);
		$('.taobao_url').text(conf.taobao_url);
		$('.taobao_url').attr('href',conf.taobao_url);
		$('.wxname').text(conf.wxname);
	};
	(function(){
		$.ajax({
			type:'GET',
			url : 'api/conf',
			success:function(data){
				conf=data;
				ns.siteconf()
			},
			error:function(xhr,errorType,error){
				//alert(error);
			}
		})
	}());
}(App));

$(function(){
	App.siteconf();		
});
