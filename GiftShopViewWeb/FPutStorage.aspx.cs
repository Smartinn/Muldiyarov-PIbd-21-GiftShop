using System;
using System.Collections.Generic;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiftShopViewWeb
{
    public partial class FPutStorage : System.Web.UI.Page
    {
        private readonly IStorageService serviceS = new StorageServiceList();

        private readonly IElementService serviceE = new ElementServiceList();

        private readonly IMainService serviceM = new MainServiceList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<ElementViewModel> listE = serviceE.GetList();
                if (listE != null)
                {
                    DropDownListStorage.DataSource = listE;
                    DropDownListStorage.DataBind();
                    DropDownListStorage.DataTextField = "ElementName";
                    DropDownListStorage.DataValueField = "Id";
                }
                List<StorageViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    DropDownListElement.DataSource = listS;
                    DropDownListElement.DataBind();
                    DropDownListElement.DataTextField = "StorageName";
                    DropDownListElement.DataValueField = "Id";
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
                serviceM.PutElementInStorage(new StorageElementCoverModel
                {
                    ElementId = Convert.ToInt32(DropDownListElement.SelectedValue),
                    StorageId = Convert.ToInt32(DropDownListStorage.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text)
                });
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FMain.aspx");
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