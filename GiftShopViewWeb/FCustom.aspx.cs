using System;
using System.Collections.Generic;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace GiftShopViewWeb
{
    public partial class FCustom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    var responseC = APIClient.GetRequest("api/Customer/GetList");
                    if (responseC.Result.IsSuccessStatusCode)
                    {
                        List<CustomerViewModel> list = APIClient.GetElement<List<CustomerViewModel>>(responseC);
                        if (list != null)
                        {
                            DropDownListCustomer.DataSource = list;
                            DropDownListCustomer.DataBind();
                            DropDownListCustomer.DataTextField = "CustomerFIO";
                            DropDownListCustomer.DataValueField = "Id";
                        }
                    }
                    else
                    {
                        throw new Exception(APIClient.GetError(responseC));
                    }
                    var responseP = APIClient.GetRequest("api/Gift/GetList");
                    if (responseP.Result.IsSuccessStatusCode)
                    {
                        List<GiftViewModel> list = APIClient.GetElement<List<GiftViewModel>>(responseP);
                        if (list != null)
                        {
                            DropDownListService.DataSource = list;
                            DropDownListService.DataBind();
                            DropDownListService.DataTextField = "GiftName";
                            DropDownListService.DataValueField = "Id";
                        }
                    }
                    else
                    {
                        throw new Exception(APIClient.GetError(responseP));
                    }
                    Page.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void CalcSum()
        {

            if (DropDownListService.SelectedValue != null && !string.IsNullOrEmpty(TextBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(DropDownListService.SelectedValue);
                    var responseP = APIClient.GetRequest("api/Gift/Get/" + id);
                    if (responseP.Result.IsSuccessStatusCode)
                    {
                        GiftViewModel product = APIClient.GetElement<GiftViewModel>(responseP);
                        int count = Convert.ToInt32(TextBoxCount.Text);
                        TextBoxSum.Text = ((int)(count * product.Price)).ToString();
                    }
                    else
                    {
                        throw new Exception(APIClient.GetError(responseP));
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void DropDownListService_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        protected void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownListCustomer.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите клиента');</script>");
                return;
            }
            if (DropDownListService.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите изделие');</script>");
                return;
            }
            try
            {
                var response = APIClient.PostRequest("api/Main/CreateCustom", new CustomCoverModel
                {
                    CustomerId = Convert.ToInt32(DropDownListCustomer.SelectedValue),
                    GiftId = Convert.ToInt32(DropDownListService.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text),
                    Summa = Convert.ToInt32(TextBoxSum.Text)
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