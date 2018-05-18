using System;
using System.Collections.Generic;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiftShopViewWeb
{
    public partial class FMain : System.Web.UI.Page
    {
        private readonly IMainService service = new MainServiceList();

        List<CustomViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                list = service.GetList();
                dataGridView1.Columns[0].Visible = false;
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
                    service.FinishCustom(id);
                    LoadData();
                    Server.Transfer("FMain.aspx");
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
                    service.PayCustom(id);
                    LoadData();
                    Server.Transfer("FMain.aspx");
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