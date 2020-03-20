<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="HelloWebForms.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>你好 ASP.NET Web Forms</title>
</head>
<body>
    <form id="form1" runat="server">
        姓名: <asp:TextBox ID="YourName" runat="server"></asp:TextBox>
        &nbsp;<br />
        <asp:Button ID="btnPost" runat="server" Text="問安" />
        <br />
    </form>
    <asp:Label ID="MyAnswer" runat="server" Text="Label"></asp:Label>
</body>
</html>
