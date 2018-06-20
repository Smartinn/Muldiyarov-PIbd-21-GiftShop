<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FMain.aspx.cs" Inherits="GiftShopViewWeb.FMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu" runat="server" BackColor="White" ForeColor="Black" Height="150px">
            <Items>
                <asp:MenuItem Text="Справочники" Value="Справочники">
                    <asp:MenuItem Text="Клиенты" Value="Клиенты" NavigateUrl="~/FCustomers.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Компоненты" Value="Компоненты" NavigateUrl="~/FElements.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Подарки" Value="Подарки" NavigateUrl="~/FGifts.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Склады" Value="Склады" NavigateUrl="~/FStorages.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Сотрудники" Value="Сотрудники" NavigateUrl="~/FFacilitators.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Пополнить склад" Value="Пополнить склад" NavigateUrl="~/FPutStorage.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Отчеты" Value="Отчеты">
                    <asp:MenuItem NavigateUrl="~/FPrice.aspx" Text="Прайс изделий" Value="Прайс изделий"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/FStorageLoad.aspx" Text="Загруженность складов" Value="Загруженность складов"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/FCustomerCustoms.aspx" Text="Заказы клиентов" Value="Заказы клиентов"></asp:MenuItem>
               </asp:MenuItem>
            </Items>
        </asp:Menu>

        <asp:Button ID="ButtonCreateIndent" runat="server" Text="Создать заказ" OnClick="ButtonCreateIndent_Click" />
        <asp:Button ID="ButtonTakeIndentInWork" runat="server" Text="Отдать на выполнение" OnClick="ButtonTakeIndentInWork_Click" />
        <asp:Button ID="ButtonIndentReady" runat="server" Text="Заказ готов" OnClick="ButtonIndentReady_Click" />
        <asp:Button ID="ButtonIndentPayed" runat="server" Text="Заказ оплачен" OnClick="ButtonIndentPayed_Click" />
        <asp:Button ID="ButtonUpd" runat="server" Text="Обновить список" OnClick="ButtonUpd_Click" />
        <asp:GridView ID="dataGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:CommandField ShowSelectButton="true" SelectText=">>" />
                <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" SortExpression="CustomerId" />
                <asp:BoundField DataField="CustomerFIO" HeaderText="Клиент" SortExpression="CustomerFIO" />
                <asp:BoundField DataField="GiftId" HeaderText="GiftId" SortExpression="GiftId" />
                <asp:BoundField DataField="GiftName" HeaderText="Подарок" SortExpression="GiftName" />
                <asp:BoundField DataField="FacilitatorId" HeaderText="FacilitatorId" SortExpression="FacilitatorId" />
                <asp:BoundField DataField="FacilitatorFIO" HeaderText="Исполнитель" SortExpression="FacilitatorFIO" />
                <asp:BoundField DataField="Count" HeaderText="Количество" SortExpression="Count" />
                <asp:BoundField DataField="Summa" HeaderText="Цена" SortExpression="Summa" />
                <asp:BoundField DataField="Status" HeaderText="Статус" SortExpression="Status" />
                <asp:BoundField DataField="DateCreate" HeaderText="Датасоздания" SortExpression="DateCreate" />
                <asp:BoundField DataField="DateImplement" HeaderText="Датазавершения" SortExpression="DateImplement" />
            </Columns>
            <SelectedRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="GiftShopServiceWeb.CoverModels.CustomCoverModel" DeleteMethod="PayCustom" InsertMethod="CreateCustom" SelectMethod="GetList" TypeName="GiftShopServiceWeb.InventoryDB.MainServiceBD" UpdateMethod="TakeCustom">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
