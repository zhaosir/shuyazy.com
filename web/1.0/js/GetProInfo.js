// JScript 文件

var prolist;
var currnetIndex;
var temp_dir;
//异步通过名片ID获取名片信息开始
function asynGetProInfo()
{
    if(xhr.readyState==4 && xhr.status == 200)
    {
        var returnValue = xhr.responseText;
        if(returnValue)
        {
            //alert(returnValue);
            prolist=eval(returnValue);
            //alert(prolist.length+":"+prolist[prolist.length-1]);
            //alert(prolist[0].desc);
            //alert(prolist[0].img);
            //alert(prolist[0].title);
            currnetIndex=parseInt(prolist[prolist.length-1]);
            prolist.pop();
            //alert(prolist.length+":"+prolist[prolist.length-1]);
            ShowProInfo(temp_dir);
            for(var i=0;i<prolist.length;i++)
            {
                var temp_img=new Image();
                temp_img.src=prolist[i].img;
            }
        }
        xhr=null; 
    }
}
function getNextProInfo(dir)
{
    temp_dir=dir;
    if(prolist)
    {
        //alert(prolist[prolist.length-1].title);
        //alert(currnetIndex);
        ShowProInfo(dir);
        return;  
    }
    CreatXMLHttpRequest();
    if(xhr)
    {
        var url=document.location.href;
        var proid=url.GetValue("ID");
        var request_url="../controls/GetProInfor.ashx?proid="+proid+"&dir="+dir+"&time="+new Date().getTime();
        xhr.onreadystatechange=asynGetProInfo;
        xhr.open("GET",request_url);  
        xhr.send(null);
    }
}
                        
var  xhr;                      
//创建XHR对象
function CreatXMLHttpRequest() {
    try  {
        xhr=new XMLHttpRequest();
    }
    catch (e)
    {      
        try {
            xhr=new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                xhr=new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e){
                alert("您的浏览器不支持AJAX！");
            }
        }
    }
}


function ShowProInfo(dir)
{
    oImage=null;
    if (dir == "1")//向前
    {
        if(currnetIndex>=prolist.length-1)
        {
            alert("后面没有了");
            return;
        }
        else
            currnetIndex++;
    }
    else if (dir == "0")//向后
    {
        if(currnetIndex<=0)
        {
            alert("前面没有了！");
            return;
        }
        else
            currnetIndex--;
    }
    var proinfo=prolist[currnetIndex];
    var cpName=document.getElementById("cpName");
    pro_img=document.getElementById("pro_img");
    var des_ProDes=document.getElementById("des_ProDes");
    cpName.innerHTML=proinfo.title;
    var imgpath="../ProImg/sy_"+proinfo.img;
    var slImg="../ProImg/s_"+proinfo.img;
    pro_img.setAttribute("src",slImg);
    pro_img.setAttribute("width","400");
    pro_img.setAttribute("height","300");
    pro_img.setAttribute("title",proinfo.title);
    pro_img.setAttribute("alt",proinfo.title);
    var oImage = new Image();//临时图片
//    AddEvent(oImage,"onload",function(){
//        pro_img.src=oImage.src;
//        //pro_img.setAttribute("width","400");
//        //pro_img.setAttribute("height","300");
//    });
    oImage.onload = function(){
       pro_img.src=oImage.src;
    };
    oImage.onreadystatechange = function()
    {
        if ( this.readyState == "complete")
        {
             pro_img.src=oImage.src;
        }
        else
        {
            pro_img.setAttribute("src",slImg);
        }
    }
    AddEvent(oImage,"onerror",function(){
        pro_img.src="../ProImg/sy_default.jpg"
     });
    oImage.src=  imgpath; 
    //pro_img.src="images/loading.gif";
    //pro_img.setAttribute("width","32");
    //pro_img.setAttribute("height","32");
    //pro_img.setAttribute("src",slImg);
    
    des_ProDes.innerHTML=proinfo.desc;
}

//获取URL中的参数
String.prototype.GetValue= function(para) { 
var reg = new RegExp("(^|&)"+ para +"=([^&]*)(&|$)"); 
var r = this.substr(this.indexOf("\?")+1).match(reg); 
if (r!=null) return unescape(r[2]); return null; 
}

//添加事件
function AddEvent(obj, eventName, eventFunc) {
    if (obj) {
        if (obj.attachEvent) {
            obj.attachEvent(eventName, eventFunc);
        }
        if (obj.addEventListener) {
            eventName = eventName.toString().replace(/on(.*)/i, '$1');
            obj.addEventListener(eventName, eventFunc, true);
        }
    }
}
 var pro_img=document.getElementById("pro_img");
 AddEvent(pro_img,"onerror",function(){
    pro_img.src="../ProImg/sy_default.jpg"
 });

