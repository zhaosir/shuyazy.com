// 导航栏配置文件
var outlookbar=new outlook();
var t;
t=outlookbar.addtitle('基本设置','网站设置',1)
outlookbar.additem('网站信息设置',t,'site/Profile.aspx')
outlookbar.additem('首页优化设置',t,'site/SEO.aspx')



t=outlookbar.addtitle('分类管理','内容管理',1)
outlookbar.additem('网站栏目管理',t,'document/Category.aspx')

t=outlookbar.addtitle('文档管理','内容管理',1)
outlookbar.additem('组合搜索文档',t,'document/Document.aspx')
outlookbar.additem('撰写最新文档',t,'document/DocumentInfo.aspx')




t=outlookbar.addtitle('生成网站','生成管理',1)
outlookbar.additem('生成网站信息', t, 'build/Default.aspx')
outlookbar.additem('生成[网站首页]',t,'build/Default.aspx')
outlookbar.additem('生成[栏目页面]',t,'build/CatePage.aspx')
outlookbar.additem('生成[详细页面]',t,'build/InfoPage.aspx')



t=outlookbar.addtitle('账号管理','安全管理',1)
outlookbar.additem('用户列表',t,'user/Default.aspx')
outlookbar.additem('修改本账号密码',t,'user/UserInfo.aspx')


t=outlookbar.addtitle('数据库管理','安全管理',1)
outlookbar.additem('备份数据库',t,'Data/Default.aspx')
outlookbar.additem('统计信息',t,'System/Default.aspx')


t=outlookbar.addtitle('动画广告','广告管理',1)
outlookbar.additem('广告列表',t,'ad/ADS.aspx')



