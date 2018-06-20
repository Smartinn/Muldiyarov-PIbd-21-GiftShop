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
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (!Int32.TryParse((string)Session["id"], out id))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Не указан заказ');</script>");
                        Server.Transfer("FMain.aspx");
                    }
                    var response = APIClient.GetRequest("api/Facilitator/GetList");
                    if (response.Result.IsSuccessStatusCode)
                    {
                        List<FacilitatorViewModel> list = APIClient.GetElement<List<FacilitatorViewModel>>(response);
                        if (list != null)
                        {
                            DropDownListPerformer.DataSource = list;
                            DropDownListPerformer.DataBind();
                            DropDownListPerformer.DataTextField = "FacilitatorFIO";
                            DropDownListPerformer.DataValueField = "Id";
                        }
                        Page.DataBind();
                    }
                    else
                    {
                        throw new Exception(APIClient.GetError(response));
                    }
                }
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
                var response = APIClient.PostRequest("api/Main/TakeCustom", new CustomCoverModel
                {
                    Id = id,
                    FacilitatorId = Convert.ToInt32(DropDownListPerformer.SelectedValue)
                });
                if (response.Result.IsSuccessStatusCode)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                    Session["id"] = null;
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
            Session["id"] = null;
            Server.Transfer("FMain.aspx");
        }
    }
}