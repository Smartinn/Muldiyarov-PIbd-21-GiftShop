using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace GiftShopViewWeb
{
    public partial class FElement : System.Web.UI.Page
    {
        public int Id { set { id = value; } }

        private readonly IElementService service = UnityConfig.Container.Resolve<IElementService>();

        private int id;

        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    ElementViewModel view = service.GetElement(id);
                    if (view != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            textBoxName.Text = view.ElementName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            try
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new ElementCoverModel
                    {
                        Id = id,
                        ElementName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new ElementCoverModel
                    {
                        ElementName = textBoxName.Text
                    });
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FElements.aspx");
            }
            Session["id"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            Server.Transfer("FElements.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FElements.aspx");
        }
    }
}