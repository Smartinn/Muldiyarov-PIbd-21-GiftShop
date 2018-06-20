using System;
using System.Collections.Generic;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using Unity;
using GiftShopServiceWeb.CoverModels;

namespace GiftShopViewWeb
{
    public partial class FCustomers : System.Web.UI.Page
    {
        List<CustomerViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var response = APIClient.GetRequest("api/Customer/GetList");
            if (response.Result.IsSuccessStatusCode)
            {
                List<CustomerViewModel> list = APIClient.GetElement<List<CustomerViewModel>>(response);
                if (list != null)
                {
                    list = APIClient.GetElement<List<CustomerViewModel>>(response);
                    dataGridView.Columns[0].Visible = false;
                }
            }
            else
            {
                throw new Exception(APIClient.GetError(response));
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("FCustomer.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = list[dataGridView.SelectedIndex].Id.ToString();
                Session["id"] = index;
                Server.Transfer("FCustomer.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                int id = list[dataGridView.SelectedIndex].Id;
                try
                {
                    var response = APIClient.PostRequest("api/Client/DelElement", new CustomerCoverModel { Id = id });
                    if (!response.Result.IsSuccessStatusCode)
                    {
                        throw new Exception(APIClient.GetError(response));
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                LoadData();
                Server.Transfer("FCustomers.aspx");
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FCustomers.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FMain.aspx");
        }
    }
}