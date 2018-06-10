using System;
using System.Collections.Generic;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using Unity;

namespace GiftShopViewWeb
{
    public partial class FElements : System.Web.UI.Page
    {
        private readonly IElementService service = UnityConfig.Container.Resolve<IElementService>();

        List<ElementViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                list = service.GetList();
                dataGridView.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("FElement.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = list[dataGridView.SelectedIndex].Id.ToString();
                Session["id"] = index;
                Server.Transfer("FElement.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                int id = list[dataGridView.SelectedIndex].Id;
                try
                {
                    service.DelElement(id);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                LoadData();
                Server.Transfer("FElements.aspx");
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FElements.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FMain.aspx");
        }
    }
}