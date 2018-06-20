using System;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;
using System.Threading.Tasks;
using System.Net.Http;

namespace GiftShopViewWeb
{
    public partial class FFacilitator : System.Web.UI.Page
    {

        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                var response = APIClient.GetRequest("api/Facilitator/Get/" + id);
                if (response.Result.IsSuccessStatusCode)
                {
                    var implementer = APIClient.GetElement<FacilitatorViewModel>(response);
                    if (implementer != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            TextBoxFIO.Text = implementer.FacilitatorFIO;
                        }
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
            if (string.IsNullOrEmpty(TextBoxFIO.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ФИО');</script>");
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    response = APIClient.PostRequest("api/Facilitator/UpdElement", new FacilitatorCoverModel
                    {
                        Id = id,
                        FacilitatorFIO = TextBoxFIO.Text
                    });
                }
                else
                {
                    response = APIClient.PostRequest("api/Facilitator/AddElement", new FacilitatorCoverModel
                    {
                        FacilitatorFIO = TextBoxFIO.Text
                    });
                }
                if (response.Result.IsSuccessStatusCode)
                {
                    Session["id"] = null;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                    Server.Transfer("FFacilitators.aspx");
                }
                else
                {
                    throw new Exception(APIClient.GetError(response));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FFacilitators.aspx");
            }
        }          

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FFacilitators.aspx");
        }
    }
}