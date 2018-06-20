<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FCustomerCustoms.aspx.cs" Inherits="GiftShopViewWeb.FCustomerCustoms" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="width: 200px; position: absolute; top: 16px; left: 16px;">

            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>

        </div>
        <div style="width: 794px; position: fixed; top: 18px; left: 226px; height: 447px;">
            <asp:Button ID="ButtonMake" runat="server" OnClick="ButtonMake_Click" Text="Сформировать" />
            <asp:Button ID="ButtonToPdf" runat="server" OnClick="ButtonToPdf_Click" Text="Сохранить в PDF" />
            <br />
            <rsweb:reportviewer id="ReportViewer" runat="server" backcolor="" clientidmode="AutoID" highlightbackgroundcolor="" internalbordercolor="204, 204, 204" internalborderstyle="Solid" internalborderwidth="1px" linkactivecolor="" linkactivehovercolor="" linkdisabledcolor="" primarybuttonbackgroundcolor="" primarybuttonforegroundcolor="" primarybuttonhoverbackgroundcolor="" primarybuttonhoverforegroundcolor="" secondarybuttonbackgroundcolor="" secondarybuttonforegroundcolor="" secondarybuttonhoverbackgroundcolor="" secondarybuttonhoverforegroundcolor="" splitterbackcolor="" toolbardividercolor="" toolbarforegroundcolor="" toolbarforegrounddisabledcolor="" toolbarhoverbackgroundcolor="" toolbarhoverforegroundcolor="" toolbaritembordercolor="" toolbaritemborderstyle="Solid" toolbaritemborderwidth="1px" toolbaritemhoverbackcolor="" toolbaritempressedbordercolor="51, 102, 153" toolbaritempressedborderstyle="Solid" toolbaritempressedborderwidth="1px" toolbaritempressedhoverbackcolor="153, 187, 226" width="707px" zoompercent="80">
                <LocalReport ReportPath="Report1.rdlc">
                </LocalReport>
            </rsweb:reportviewer>
        </div>
        <div style="position: absolute; top: 480px; left: 21px;">
            <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Назад" />

        </div>
    </form>
</body>
</html>
