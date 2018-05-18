﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FPutStorage.aspx.cs" Inherits="GiftShopViewWeb.FPutStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="Name" runat="server" Width ="120px">Компонент</asp:Label>
        <asp:DropDownList ID="DropDownListStorage" runat="server" Width="196px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Width ="120px">Склад</asp:Label>
        <asp:DropDownList ID="DropDownListElement" runat="server" Height="17px" Width="194px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Width ="120px">Количество</asp:Label>
        <asp:TextBox ID="TextBoxCount" runat="server" Width="186px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Сохранить" />
        <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Отмена" />
        </div>
    </form>
</body>
</html>
