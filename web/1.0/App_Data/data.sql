SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[k_File]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[k_File](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[url] [varchar](200) NOT NULL,
	[type] [int] NOT NULL CONSTRAINT [DF_k_File_type]  DEFAULT ((0)),
	[sort] [int] NOT NULL CONSTRAINT [DF_k_File_sort]  DEFAULT ((0)),
 CONSTRAINT [PK_k_File] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_File', N'COLUMN',N'DocID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属文档ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_File', @level2type=N'COLUMN',@level2name=N'DocID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_File', N'COLUMN',N'title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_File', @level2type=N'COLUMN',@level2name=N'title'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_File', N'COLUMN',N'url'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_File', @level2type=N'COLUMN',@level2name=N'url'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_File', N'COLUMN',N'type'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文件类型(0:图像,1:下载)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_File', @level2type=N'COLUMN',@level2name=N'type'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_File', N'COLUMN',N'sort'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同文档排序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_File', @level2type=N'COLUMN',@level2name=N'sort'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[k_Document]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[k_Document](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NOT NULL,
	[cateID] [int] NOT NULL,
	[contents] [text] NOT NULL,
	[post] [int] NOT NULL CONSTRAINT [DF_k_Document_post]  DEFAULT ((0)),
	[postDate] [datetime] NOT NULL CONSTRAINT [DF_k_Document_postDate]  DEFAULT (getdate()),
	[seoTitle] [varchar](50) NULL,
	[keys] [varchar](100) NULL,
	[descr] [varchar](200) NULL,
	[sort] [int] NOT NULL CONSTRAINT [DF_k_Document_sort]  DEFAULT ((0)),
	[state] [int] NOT NULL CONSTRAINT [DF_k_Document_state]  DEFAULT ((0)),
	[builded] [int] NOT NULL CONSTRAINT [DF_k_Document_builded]  DEFAULT ((0)),
 CONSTRAINT [PK_k_Document] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'title'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'cateID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'cateID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'contents'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'contents'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'post'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'post'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'postDate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发表日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'postDate'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'seoTitle'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'seo 标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'seoTitle'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'keys'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'keys'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'descr'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'descr'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'sort'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同栏目排序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'sort'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'state'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控制状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'state'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Document', N'COLUMN',N'builded'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生成状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Document', @level2type=N'COLUMN',@level2name=N'builded'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[k_UserInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[k_UserInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[regDate] [datetime] NOT NULL CONSTRAINT [DF_k_UserInfo_regDate]  DEFAULT (getdate()),
	[sex] [int] NOT NULL,
	[birthday] [datetime] NOT NULL,
	[mail] [varchar](100) NOT NULL,
	[type] [int] NOT NULL,
	[tel] [varchar](20) NOT NULL,
 CONSTRAINT [PK_k_UserInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'userName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名，不能重复' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'userName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'password'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'password'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'regDate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'regDate'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'sex'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别(0:男,1:女)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'sex'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'birthday'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'birthday'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'mail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'mail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'type'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 权限(0:普通用户,1:管理员)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'type'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_UserInfo', N'COLUMN',N'tel'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_UserInfo', @level2type=N'COLUMN',@level2name=N'tel'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecordByPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2010-3-13 9:49:33
------------------------------------
Create PROCEDURE [dbo].[GetRecordByPage]
    @tblName      varchar(255),       -- 表名
    @fldName      varchar(255),       -- 主键字段名
    @PageSize     int = 10,           -- 页尺寸
    @PageIndex    int = 1,            -- 页码
    @IsReCount    bit = 0,            -- 返回记录总数, 非 0 值则返回
    @OrderType    bit = 0,            -- 设置排序类型, 非 0 值则降序
    @strWhere     varchar(1000) = '''' -- 查询条件 (注意: 不要加 where)
AS

declare @strSQL   varchar(6000)       -- 主语句
declare @strTmp   varchar(1000)        -- 临时变量(查询条件过长时可能会出错，可修改100为1000)
declare @strOrder varchar(400)        -- 排序类型

if @OrderType != 0
begin
    set @strTmp = ''<(select min''
    set @strOrder = '' order by ['' + @fldName +''] desc''
end
else
begin
    set @strTmp = ''>(select max''
    set @strOrder = '' order by ['' + @fldName +''] asc''
end

set @strSQL = ''select top '' + str(@PageSize) + '' * from [''
    + @tblName + ''] where ['' + @fldName + '']'' + @strTmp + ''([''
    + @fldName + '']) from (select top '' + str((@PageIndex-1)*@PageSize) + '' [''
    + @fldName + ''] from ['' + @tblName + '']'' + @strOrder + '') as tblTmp)''
    + @strOrder

if @strWhere != ''''
    set @strSQL = ''select top '' + str(@PageSize) + '' * from [''
        + @tblName + ''] where ['' + @fldName + '']'' + @strTmp + ''([''
        + @fldName + '']) from (select top '' + str((@PageIndex-1)*@PageSize) + '' [''
        + @fldName + ''] from ['' + @tblName + ''] where '' + @strWhere + '' ''
        + @strOrder + '') as tblTmp) and '' + @strWhere + '' '' + @strOrder

if @PageIndex = 1
begin
    set @strTmp =''''
    if @strWhere != ''''
        set @strTmp = '' where '' + @strWhere

    set @strSQL = ''select top '' + str(@PageSize) + '' * from [''
        + @tblName + '']'' + @strTmp + '' '' + @strOrder
end

if @IsReCount != 0
    set @strSQL = ''select count(*) as Total from ['' + @tblName + '']''+'' where '' + @strWhere

exec (@strSQL)


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[k_Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[k_Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](100) NOT NULL,
	[upID] [int] NOT NULL,
	[linkType] [int] NOT NULL CONSTRAINT [DF_k_Category_linkType]  DEFAULT ((0)),
	[type] [int] NOT NULL CONSTRAINT [DF_k_Category_type]  DEFAULT ((0)),
	[link] [varchar](100) NULL,
	[sort] [int] NOT NULL CONSTRAINT [DF_k_Category_sort]  DEFAULT ((0)),
 CONSTRAINT [PK_k_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Category', N'COLUMN',N'ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'唯一标记' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Category', @level2type=N'COLUMN',@level2name=N'ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Category', N'COLUMN',N'category'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Category', @level2type=N'COLUMN',@level2name=N'category'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Category', N'COLUMN',N'upID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Category', @level2type=N'COLUMN',@level2name=N'upID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Category', N'COLUMN',N'linkType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接类型(0,到文档;1,到指定Link)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Category', @level2type=N'COLUMN',@level2name=N'linkType'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Category', N'COLUMN',N'type'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目文档类型(0,新闻;1,产品;2,相册)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Category', @level2type=N'COLUMN',@level2name=N'type'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Category', N'COLUMN',N'link'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'指定栏目链接地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Category', @level2type=N'COLUMN',@level2name=N'link'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'k_Category', N'COLUMN',N'sort'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同父级排序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'k_Category', @level2type=N'COLUMN',@level2name=N'sort'
