pagecount=15;

product = {
	pageclick:function(pageindex){
				$("#jpage").pager({ pagenumber: pageindex, pagecount: pagecount, buttonClickCallback: product.pageclick });
			  }
};
$(function(){
	$("#jpage").pager({ pagenumber: 1, pagecount:pagecount, buttonClickCallback: product.pageclick });
});
