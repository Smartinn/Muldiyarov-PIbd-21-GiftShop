using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Unity;
using System.Web.UI.WebControls;

namespace GiftShopViewWeb
{
    public partial class FFacilitators : System.Web.UI.Page
    {
        private readonly IFacilitatorService service = UnityConfig.Container.Resolve<IFacilitatorService>();

        List<FacilitatorViewModel> list;

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
            Server.Transfer("FFacilitator.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = list[dataGridView.SelectedIndex].Id.ToString();
                Session["id"] = index;
                Server.Transfer("FFacilitator.aspx");
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
                Server.Transfer("FFacilitator.aspx");
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FFacilitators.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FMain.aspx");
        }
    }
}