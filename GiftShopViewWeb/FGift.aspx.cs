using System;
using System.Collections.Generic;
using System.Linq;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.InventoryLIst;
using GiftShopServiceWeb.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Unity;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiftShopViewWeb
{
    public partial class FGift : System.Web.UI.Page
    {
        private int id;

        private List<GiftElementViewModel> productComponents;

        private GiftElementViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    var response = APIClient.GetRequest("api/Gift/Get/" + id);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var view = APIClient.GetElement<GiftViewModel>(response);
                        if (view != null)
                        {
                            if (!Page.IsPostBack)
                            {
                                textBoxName.Text = view.GiftName;
                                textBoxPrice.Text = ((int)view.Price).ToString();
                            }
                            productComponents = view.GiftElements;
                            LoadData();
                        }
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
            else
            {
                productComponents = new List<GiftElementViewModel>();
            }
            if (Session["SEId"] != null)
            {
                if (Session["SEIs"] != null)
                {
                    model = new GiftElementViewModel
                    {
                        Id = (int)Session["SEId"],
                        GiftId = (int)Session["SEGiftId"],
                        ElementId = (int)Session["SEElementId"],
                        ElementName = (string)Session["SEElementName"],
                        Count = (int)Session["SECount"]
                    };
                    productComponents[(int)Session["SEIs"]] = model;
                }
                else
                {
                    model = new GiftElementViewModel
                    {
                        GiftId = (int)Session["SEGiftId"],
                        ElementId = (int)Session["SEElementId"],
                        ElementName = (string)Session["SEElementName"],
                        Count = (int)Session["SECount"]
                    };
                    productComponents.Add(model);
                }
                Session["SEId"] = null;
                Session["SEGiftId"] = null;
                Session["SEElementId"] = null;
                Session["SEElementName"] = null;
                Session["SECount"] = null;
                Session["SEIs"] = null;
            }
            List<GiftElementCoverModel> productComponentBM = new List<GiftElementCoverModel>();
            for (int i = 0; i < productComponents.Count; ++i)
            {
                productComponentBM.Add(new GiftElementCoverModel
                {
                    Id = productComponents[i].Id,
                    GiftId = productComponents[i].GiftId,
                    ElementId = productComponents[i].ElementId,
                    Count = productComponents[i].Count
                });
            }
            if (productComponentBM.Count != 0)
            {
                bool flag = true;
                Task < HttpResponseMessage > response;
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    response = APIClient.PostRequest("api/Gift/UpdElement", new GiftCoverModel
                    {
                        Id = id,
                        GiftName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        GiftElements = productComponentBM
                    });
                }
                else
                {
                    response = APIClient.PostRequest("api/Gift/AddElement", new GiftCoverModel
                    {
                        GiftName = "-0",
                        Price = 0,
                        GiftElements = productComponentBM
                    });

                    if (response.Result.IsSuccessStatusCode && flag)
                    {
                        response = APIClient.GetRequest("api/Gift/GetList");
                        Session["id"] = APIClient.GetElement<List<GiftViewModel>>(response).Last().Id.ToString();
                        Session["Change"] = "0";
                    }
                    else
                    {
                        throw new Exception(APIClient.GetError(response));
                    }
                }
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (productComponents != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = productComponents;
                    dataGridView.DataBind();
                    dataGridView.ShowHeaderWhenEmpty = true;
                    dataGridView.SelectedRowStyle.BackColor = Color.Silver;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("FGiftElement.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                var response = APIClient.GetRequest("api/Gift/Get/" + id);
                model = APIClient.GetElement<GiftViewModel>(response).GiftElements[dataGridView.SelectedIndex];
                Session["SEId"] = model.Id.ToString();
                Session["SEGiftId"] = model.GiftId.ToString();
                Session["SEElementId"] = model.ElementId.ToString();
                Session["SEElementName"] = model.ElementName;
                Session["SECount"] = model.Count.ToString();
                Session["SEIs"] = dataGridView.SelectedIndex.ToString();
                Session["Change"] = "0";
                Server.Transfer("FGiftElement.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                try
                {
                    productComponents.RemoveAt(dataGridView.SelectedIndex);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                LoadData();
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните цену');</script>");
                return;
            }
            if (productComponents == null || productComponents.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните компоненты');</script>");
                return;
            }
            try
            {
                List<GiftElementCoverModel> productComponentBM = new List<GiftElementCoverModel>();
                for (int i = 0; i < productComponents.Count; ++i)
                {
                    productComponentBM.Add(new GiftElementCoverModel
                    {
                        Id = productComponents[i].Id,
                        GiftId = productComponents[i].GiftId,
                        ElementId = productComponents[i].ElementId,
                        Count = productComponents[i].Count
                    });
                }
                Task<HttpResponseMessage> response;
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    response = APIClient.PostRequest("api/Gift/UpdElement", new GiftCoverModel
                    {
                        Id = id,
                        GiftName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        GiftElements = productComponentBM
                    });
                }
                else
                {
                    response = APIClient.PostRequest("api/Gift/AddElement", new GiftCoverModel
                    {
                        GiftName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        GiftElements = productComponentBM
                    });
                }
                if (response.Result.IsSuccessStatusCode)
                {
                    Session["id"] = null;
                    Session["Change"] = null;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                    Server.Transfer("FGifts.aspx");
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

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            var response = APIClient.GetRequest("api/Gift/GetList");
            var view = APIClient.GetElement<List<GiftViewModel>>(response);
            if (view.Count != 0 && view.Last().GiftName == null)
            {
                response = APIClient.PostRequest("api/Servise/DelElement", new GiftCoverModel { Id = view.Last().Id });
                if (!response.Result.IsSuccessStatusCode)
                {
                    throw new Exception(APIClient.GetError(response));
                }
            }
            if (!String.Equals(Session["Change"], null))
            {
                response = APIClient.PostRequest("api/Servise/DelElement", new GiftCoverModel { Id = id });
                if (!response.Result.IsSuccessStatusCode)
                {
                    throw new Exception(APIClient.GetError(response));
                }
            }
            Session["id"] = null;
            Session["Change"] = null;
            Server.Transfer("FGifts.aspx");
        }

        protected void dataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }
    }
}