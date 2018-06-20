using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace GiftShopViewWeb
{
    public partial class FTakeCustom : System.Web.UI.Page
    {
        private readonly IFacilitatorService serviceP = UnityConfig.Container.Resolve<IFacilitatorService>();

        private readonly IMainService serviceM = UnityConfig.Container.Resolve<IMainService>();

        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Int32.TryParse((string)Session["id"], out id))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Не указан заказ');</script>");
                    Server.Transfer("FMain.aspx");
                }
                List<FacilitatorViewModel> listI = serviceP.GetList();
                if (listI != null)
                {
                    DropDownListPerformer.DataSource = listI;
                    DropDownListPerformer.DataBind();
                    DropDownListPerformer.DataTextField = "FacilitatorFIO";
                    DropDownListPerformer.DataValueField = "Id";
                    DropDownListPerformer.SelectedIndex = -1;
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
            if (DropDownListPerformer.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите исполнителя');</script>");
                return;
            }
            try
            {
                serviceM.TakeCustom(new CustomCoverModel
                {
                    Id = id,
                    FacilitatorId = Convert.ToInt32(DropDownListPerformer.SelectedValue)
                });
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Session["id"] = null;
                Server.Transfer("FMain.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FMain.aspx");
        }
    }
}