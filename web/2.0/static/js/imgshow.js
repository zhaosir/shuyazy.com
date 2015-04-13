// JavaScript Document
$(function(){
	var height = 370,//容器的高
		width = 560, //容器宽
		thisid = 0,  //
		oldid = 0,   //当前显示的index
		type = 0,    //1为滑动 0为渐隐渐现
		settiem,
		speed=5000;  //切换时间间隔
	imgshow(height,width);//设置容器的大小

	function imgshow(height,width){
		var sum = $("#imgbox").find("li").length;
		$("#imgbox").css({"width":(width*sum) + "px"})
		$("#btnlist").css({"margin-left":(1200-22*sum)/2+"px"})
		settiem = setInterval(function(){
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
		},speed);//自动切换	
		$("#btnlist li").click(function(){
			clearInterval(settiem);
			settiem = setInterval(function(){
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
			},speed);//自动切换
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
		btnicon(id);
	}
	//渐隐渐现函数
	function fide(id,sum){
		thisd = id;
		$("#imgbox li").each(function() {
            if($(this).index()==thisd){
				$(this).css({position:"absolute",left:0,top:0, opacity:0})
				$(this).animate({opacity:1},1500);
				$("#imgbox li:eq("+oldid+")").animate({opacity:0},1500);
				oldid = thisd;
			}
        });
		btnicon(thisd);	
	}
	//按钮和icon切换
	function btnicon(id){
		$("#btnlist li").each(function() {
			if($(this).index()==id)
				$(this).addClass("active"); 
			else    $(this).removeClass("active");   
		});
		$("#ixonlist li").each(function(){
			if($(this).index()==id)
				$(this).show();
			else $(this).hide();	
		});
		$(".right_t li").each(function(){
			if($(this).index()==id)
				$(this).show();
			else $(this).hide();	
		});
	}
})