product = {
	pageclick:function(pageindex){
				window.location =  window.location.pathname+'?p='+pageindex
				//$("#jpage").pager({ pagenumber: pageindex, pagecount: pagecount, buttonClickCallback: product.pageclick });
			  }
};
$(function(){
	$("#jpage").pager({ pagenumber: pageindex, pagecount:pagecount, buttonClickCallback: product.pageclick });
});
