using System;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiftShopViewWeb
{
    public partial class FFacilitator : System.Web.UI.Page
    {
        private readonly IFacilitatorService service = new FacilitatorServiceList();

        private int id;

        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    FacilitatorViewModel view = service.GetElement(id);
                    if (view != null)
                    {
                        name = view.FacilitatorFIO;
                        service.UpdElement(new FacilitatorCoverModel
                        {
                            Id = id,
                            FacilitatorFIO = ""
                        });
                        if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(TextBoxFIO.Text))
                        {
                            TextBoxFIO.Text = name;
                        }
                        service.UpdElement(new FacilitatorCoverModel
                        {
                            Id = id,
                            FacilitatorFIO = name
                        });
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
            if (string.IsNullOrEmpty(TextBoxFIO.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ФИО');</script>");
                return;
            }
            try
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new FacilitatorCoverModel
                    {
                        Id = id,
                        FacilitatorFIO = TextBoxFIO.Text
                    });
                }
                else
                {
                    service.AddElement(new FacilitatorCoverModel
                    {
                        FacilitatorFIO = TextBoxFIO.Text
                    });
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FFacilitators.aspx");
            }
            Session["id"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            Server.Transfer("FFacilitators.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FFacilitators.aspx");
        }
    }
}