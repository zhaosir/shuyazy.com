(function($) {
	$.get_argument = function (name,defaultvalue=null) {
		var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
		var r = window.location.search.substr(1).match(reg);
		if (r != null) return unescape(r[2]); return defaultvalue;
	}
})(jQuery);
