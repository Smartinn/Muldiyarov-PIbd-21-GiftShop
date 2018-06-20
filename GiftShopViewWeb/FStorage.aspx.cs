using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.Interfaces;
using System;
using System.Web.UI;
using GiftShopServiceWeb.ViewModels;
using GiftShopServiceWeb.CoverModels;
using Unity;
using System.Threading.Tasks;
using System.Net.Http;

namespace GiftShopViewWeb
{
    public partial class FStorage : System.Web.UI.Page
    {
        private int id;       

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var response = APIClient.GetRequest("api/Storage/Get/" + id);
                if (response.Result.IsSuccessStatusCode)
                {
                    var view = APIClient.GetElement<StorageViewModel>(response);
                    if (view != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            textBoxName.Text = view.StorageName;
                        }
                        dataGridView.DataSource = view.StorageElements;
                        dataGridView.DataBind();
                        dataGridView.ShowHeaderWhenEmpty = true;
                    }
                    Page.DataBind();
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

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            try
            {
                Task<HttpResponseMessage> response;
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    
                    response = APIClient.PostRequest("api/Storage/UpdElement", new StorageCoverModel
                    {
                        Id = id,
                        StorageName = textBoxName.Text
                    });
                }
                else
                {
                    response = APIClient.PostRequest("api/Storage/AddElement", new StorageCoverModel
                    {
                        StorageName = textBoxName.Text
                    });
                }
                if (response.Result.IsSuccessStatusCode)
                {
                    Session["id"] = null;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                    Server.Transfer("FStorages.aspx");
                }
                else
                {
                    throw new Exception(APIClient.GetError(response));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FStorages.aspx");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FStorages.aspx");
        }
    }
}