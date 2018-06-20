using System;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiftShopViewWeb
{
    public partial class FCustomer : System.Web.UI.Page
    {

        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                var response = APIClient.GetRequest("api/Customer/Get/" + id);
                if (response.Result.IsSuccessStatusCode)
                {
                    var client = APIClient.GetElement<CustomerViewModel>(response);
                    if (!Page.IsPostBack)
                    {
                        TextBox1.Text = client.CustomerFIO;
                    }
                }
                else
                {
                    throw new Exception(APIClient.GetError(response));
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
                Task<HttpResponseMessage> response;
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    response = APIClient.PostRequest("api/Customer/UpdElement", new CustomerCoverModel
                    {
                        Id = id,
                        CustomerFIO = TextBox1.Text
                    });
                }
                else
                {
                    response = APIClient.PostRequest("api/Customer/AddElement", new CustomerCoverModel
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