using System;
using System.Collections.Generic;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;
using GiftShopServiceWeb.CoverModels;

namespace GiftShopViewWeb
{
    public partial class FMain : System.Web.UI.Page
    {
        List<CustomViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var response = APIClient.GetRequest("api/Main/GetList");
                if (response.Result.IsSuccessStatusCode)
                {
                    list = APIClient.GetElement<List<CustomViewModel>>(response);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
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

        protected void ButtonCreateIndent_Click(object sender, EventArgs e)
        {
            Server.Transfer("FCustom.aspx");
        }

        protected void ButtonTakeIndentInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                string index = list[dataGridView1.SelectedIndex].Id.ToString();
                Session["id"] = index;
                Server.Transfer("FTakeCustom.aspx");
            }
        }

        protected void ButtonIndentReady_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                int id = list[dataGridView1.SelectedIndex].Id;
                try
                {
                    var response = APIClient.PostRequest("api/Main/FinishCustom", new CustomCoverModel
                    {
                        Id = id
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        LoadData();
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
        }

        protected void ButtonIndentPayed_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                int id = list[dataGridView1.SelectedIndex].Id;
                try
                {
                    var response = APIClient.PostRequest("api/Main/PayCustom", new CustomCoverModel
                    {
                        Id = id
                    });
                    if (response.Result.IsSuccessStatusCode)
                    {
                        LoadData();
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
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FMain.aspx");
        }
    }
}