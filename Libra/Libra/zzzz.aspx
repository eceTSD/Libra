<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zzzz.aspx.cs" Inherits="zzzz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:DataList id="cdcatalog" gridlines="both" runat="server" width="100%" OnItemCommand="cdcatalog_ItemCommand" OnCancelCommand="cdcatalog_CancelCommand" OnUpdateCommand="cdcatalog_UpdateCommand" OnEditCommand="cdcatalog_EditCommand" OnDeleteCommand="cdcatalog_DeleteCommand" >

 <HeaderTemplate >
                    <tr align="center" style="background-color:yellow">    
                        <th style="width:50px">菜单</th>
                        <th style="width:100px">标题</th>
                        <th style="width:100px">摘要</th>
                        <th style="width:200px">图片</th>
                        <th style="width:200px">文章</th>
                        <th style="width:100px">操作</th>
                    </tr>    
</HeaderTemplate>

<ItemTemplate runat="server">
                <tr>
                    <td><%#Eval("name") %></td>
                    <td><%#Eval("title") %></td>
                    <td><%#Eval("abstract") %></td>
                    <td><%#Eval("picurl") %></td>
                    <td><%#Eval("url") %></td>
                    <td>
                        <asp:LinkButton ID="lbtDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("title") %>'>删除</asp:LinkButton>
                        <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit">编辑</asp:LinkButton>
                        <asp:LinkButton ID="lbtAdd" runat="server" CommandName="Add">添加</asp:LinkButton>
                    </td>
                </tr>
</ItemTemplate>
<EditItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("title") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval("abstract") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("picurl") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval("url") %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="lbtCancel" runat="server" Text="取消" CommandName="Cancel"></asp:LinkButton>
                        <asp:LinkButton ID="lbtUpdate" runat="server" Text="更新" CommandName="Update"></asp:LinkButton>
                    </td>
                </tr>
                
</EditItemTemplate>
<FooterTemplate>
</FooterTemplate>

</asp:DataList>
<asp:Button id="save" Text="保存" runat="server" onclick="save_Click"/>
    </form>
    <p style="color:red;font-size:larger">使用说明：</p>
    <p style="color:red;font-size:medium">“菜单”列下填写微信二级菜单名，“标题”列下填写文章标题，“摘要”列下填写文章摘要，“图片”列下填写图片链接，“文章”列下填写文章内容链接。</p>
    <p style="color:red;font-size:medium">“删除”按钮可删除该行，“编辑”按钮可将该行进入编辑状态可供编辑，“添加”按钮可在该行下方添加新的一行，编辑状态下“取消”按钮可取消当前编辑内容，恢复该行原本内容，编辑状态下“更新”按钮可修改该行原本内容为当前编辑内容。</p>
    <p style="color:red;font-size:medium">完成所有删除、编辑、添加等操作后请点击“保存”按钮，保存当前页面所有数据。不点击“保存”按钮则不会保存当前所有内容，即之前所有操作无效。</p>
    <p style="color:red;font-size:medium">编辑过程中不要删除所有行，至少保留一行，以防止没有操作按钮。</p>
</body>
</html>
