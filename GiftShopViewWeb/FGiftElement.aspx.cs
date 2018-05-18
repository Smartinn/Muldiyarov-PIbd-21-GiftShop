using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiftShopViewWeb
{
    public partial class FGiftElement : System.Web.UI.Page
    {
        private readonly IElementService service = new ElementServiceList();

        private GiftElementViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<ElementViewModel> list = service.GetList();
                if (list != null)
                {
                    DropDownListElement.DataSource = list;
                    DropDownListElement.DataValueField = "Id";
                    DropDownListElement.DataTextField = "ElementName";
                    DropDownListElement.SelectedIndex = 0;
                    Page.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
            if (Session["SEId"] != null)
            {
                DropDownListElement.Enabled = false;
                DropDownListElement.SelectedValue = (string)Session["SEElementId"];
                TextBoxCount.Text = (string)Session["SECount"];
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
            try
            {
                if (Session["SEId"] == null)
                {
                    model = new GiftElementViewModel
                    {
                        ElementId = Convert.ToInt32(DropDownListElement.SelectedValue),
                        ElementName = DropDownListElement.SelectedItem.Text,
                        Count = Convert.ToInt32(TextBoxCount.Text)
                    };
                    Session["SEId"] = model.Id;
                    Session["SEGiftId"] = model.GiftId;
                    Session["SEElementId"] = model.ElementId;
                    Session["SEElementName"] = model.ElementName;
                    Session["SECount"] = model.Count;
                }
                else
                {
                    model.Count = Convert.ToInt32(TextBoxCount.Text);
                    Session["SEId"] = model.Id;
                    Session["SEGiftId"] = model.GiftId;
                    Session["SEElementId"] = model.ElementId;
                    Session["SEElementName"] = model.ElementName;
                    Session["SECount"] = model.Count;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FGift.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FGift.aspx");
        }
    }
}