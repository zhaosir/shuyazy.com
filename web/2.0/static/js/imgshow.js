// JavaScript Document
$(function(){
	var height = 0,//容器的高
		width = 0, //容器宽
		thisid = 0,  //
		oldid = 0,   //当前显示的index
		type = 0,    //1为滑动 0为渐隐渐现
		settiem,
		sum = 0,
		speed=5000;  //切换时间间隔
	looppic = function(){
		var newid;
			if( oldid + 1 < sum){
				newid= oldid + 1;
			}
			else if(oldid + 1 == sum){
				newid = 0;
			}
			if(type == 1){
				sliding(newid,sum,width);//滑动变化
			}
			else if(type == 0){
				fide(newid,sum);	
			}
	};
	imgshow(height,width);//设置容器的大小
	function imgshow(height,width){
		sum = $("#imgbox").find("li").length;
		$("#imgbox li:eq("+oldid+")").css({position:"absolute"})
		//$("#imgbox").css({"width":(width*sum) + "px"})
		$("#btnlist").css({"margin-left":(1002-34*sum)/2+"px"})
		genbtnlist(sum);
		settiem = setInterval(looppic,speed);//自动切换	
		$("#btnlist span").click(function(){
			clearInterval(settiem);
			settiem = setInterval(looppic,speed);//自动切换	
			if(thisid!=$(this).index()){
				thisid = $(this).index();
				if(type == 1){
					sliding($(this).index(),sum,width);//滑动变化
				}
				else if(type == 0){
					fide($(this).index(),sum);	
				}
			}
		})
	}
	//滑动切换函数
	function sliding(id,count,width){
		if(id<count){
			$("#imgbox").animate({left:-(width*id)+"px"},800);
		}
		//btnicon(id);
	}
	//渐隐渐现函数
	function fide(id,sum){
		thisd = id;
		$("#imgbox li").each(function() {
            if($(this).index()==thisd){
				//$(this).css({position:"absolute",left:0,top:0, opacity:0})
				$(this).css({position:"absolute",opacity:0})
				$(this).animate({opacity:1},1500);
				$("#imgbox li:eq("+oldid+")").animate({opacity:0},1500);
				oldid = thisd;
			}
        });
		btnicon(thisd);	
	}
	//按钮和icon切换
	function btnicon(id){
		$("#btnlist span").each(function() {
			if($(this).index()==id)
				$(this).addClass("active"); 
			else    $(this).removeClass("active");   
		});
	}
	
	function genbtnlist(sum){
		for(var i=0;i<sum;i++){
			$("#btnlist").append("<span>");
		}
	}
})
