<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FElement.aspx.cs" Inherits="GiftShopViewWeb.FElement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:Label ID="asName" runat="server" Width ="120px">Название</asp:Label>
            <asp:TextBox ID="textBoxName" runat="server" Width="160px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Сохранить" OnClick="ButtonSave_Click" />
            <asp:Button ID="Button2" runat="server" Text="Отмена" OnClick="ButtonCancel_Click" />
        </div>
    </form>
</body>
</html>
