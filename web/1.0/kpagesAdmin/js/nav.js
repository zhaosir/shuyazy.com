// �����������ļ�
var outlookbar=new outlook();
var t;
t=outlookbar.addtitle('��������','��վ����',1)
outlookbar.additem('��վ��Ϣ����',t,'site/Profile.aspx')
outlookbar.additem('��ҳ�Ż�����',t,'site/SEO.aspx')



t=outlookbar.addtitle('�������','���ݹ���',1)
outlookbar.additem('��վ��Ŀ����',t,'document/Category.aspx')

t=outlookbar.addtitle('�ĵ�����','���ݹ���',1)
outlookbar.additem('��������ĵ�',t,'document/Document.aspx')
outlookbar.additem('׫д�����ĵ�',t,'document/DocumentInfo.aspx')




t=outlookbar.addtitle('������վ','���ɹ���',1)
outlookbar.additem('������վ��Ϣ', t, 'build/Default.aspx')
outlookbar.additem('����[��վ��ҳ]',t,'build/Default.aspx')
outlookbar.additem('����[��Ŀҳ��]',t,'build/CatePage.aspx')
outlookbar.additem('����[��ϸҳ��]',t,'build/InfoPage.aspx')



t=outlookbar.addtitle('�˺Ź���','��ȫ����',1)
outlookbar.additem('�û��б�',t,'user/Default.aspx')
outlookbar.additem('�޸ı��˺�����',t,'user/UserInfo.aspx')


t=outlookbar.addtitle('���ݿ����','��ȫ����',1)
outlookbar.additem('�������ݿ�',t,'Data/Default.aspx')
outlookbar.additem('ͳ����Ϣ',t,'System/Default.aspx')


t=outlookbar.addtitle('�������','������',1)
outlookbar.additem('����б�',t,'ad/ADS.aspx')



