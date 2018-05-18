using System;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GiftShopViewWeb
{
    public partial class FCustomer : System.Web.UI.Page
    {
        public int Id { set { id = value; } }

        private readonly ICustomerService service = new CustomerServiceList();

        private int id;

        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    CustomerViewModel view = service.GetElement(id);
                    if (view != null)
                    {
                        name = view.CustomerFIO;
                        service.UpdElement(new CustomerCoverModel
                        {
                            Id = id,
                            CustomerFIO = ""
                        });
                        if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(TextBox1.Text))
                        {
                            TextBox1.Text = name;
                        }
                        service.UpdElement(new CustomerCoverModel
                        {
                            Id = id,
                            CustomerFIO = name
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
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ФИО');</script>");
                return;
            }
            try
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new CustomerCoverModel
                    {
                        Id = id,
                        CustomerFIO = TextBox1.Text
                    });
                }
                else
                {
                    service.AddElement(new CustomerCoverModel
                    {
                        CustomerFIO = TextBox1.Text
                    });
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FCustomers.aspx");
            }
            Session["id"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            Server.Transfer("FCustomers.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FCustomers.aspx");
        }
    }
}