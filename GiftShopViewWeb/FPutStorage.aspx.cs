using System;
using System.Collections.Generic;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using Unity;
using System.Web.UI.WebControls;

namespace GiftShopViewWeb
{
    public partial class FPutStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var responseC = APIClient.GetRequest("api/Element/GetList");
                if (responseC.Result.IsSuccessStatusCode)
                {
                    List<ElementViewModel> list = APIClient.GetElement<List<ElementViewModel>>(responseC);
                    if (list != null)
                    {
                        DropDownListElement.DataSource = list;
                        DropDownListElement.DataBind();
                        DropDownListElement.DataTextField = "ElementName";
                        DropDownListElement.DataValueField = "Id";
                    }
                }
                else
                {
                    throw new Exception(APIClient.GetError(responseC));
                }
                var responseS = APIClient.GetRequest("api/Storage/GetList");
                if (responseS.Result.IsSuccessStatusCode)
                {
                    List<StorageViewModel> list = APIClient.GetElement<List<StorageViewModel>>(responseS);
                    if (list != null)
                    {
                        DropDownListStorage.DataSource = list;
                        DropDownListStorage.DataBind();
                        DropDownListStorage.DataTextField = "StorageName";
                        DropDownListStorage.DataValueField = "Id";
                    }
                }
                else
                {
                    throw new Exception(APIClient.GetError(responseC));
                }
                Page.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownListElement.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите компонент');</script>");
                return;
            }
            if (DropDownListStorage.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите склад');</script>");
                return;
            }
            try
            {
                var response = APIClient.PostRequest("api/Main/PutElementInStorage", new StorageElementCoverModel
                {
                    ElementId = Convert.ToInt32(DropDownListElement.SelectedValue),
                    StorageId = Convert.ToInt32(DropDownListStorage.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text)
                });
                if (response.Result.IsSuccessStatusCode)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                    Server.Transfer("FMain.aspx");
                }
                else
                {
                    throw new Exception(APIClient.GetError(response));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FMain.aspx");
        }
    }
}