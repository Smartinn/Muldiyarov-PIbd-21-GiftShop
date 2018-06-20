using System;
using System.Collections.Generic;
using System.Linq;
using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using GiftShopService.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Unity;

namespace GiftShopViewWeb
{
    public partial class FGift : System.Web.UI.Page
    {
        private readonly IGiftService service = UnityConfig.Container.Resolve<IGiftService>();

        private int id;

        private List<GiftElementViewModel> productComponents;

        private GiftElementViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    GiftViewModel view = service.GetElement(id);
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
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new GiftCoverModel
                    {
                        Id = id,
                        GiftName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        GiftElements = productComponentBM
                    });
                }
                else
                {
                    service.AddElement(new GiftCoverModel
                    {
                        GiftName = "-0",
                        Price = 0,
                        GiftElements = productComponentBM
                    });
                    Session["id"] = service.GetList().Last().Id.ToString();
                    Session["Change"] = "0";
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
                model = service.GetElement(id).GiftElements[dataGridView.SelectedIndex];
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
                //service.DelElement(service.GetList().Last().Id);
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new GiftCoverModel
                    {
                        Id = id,
                        GiftName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        GiftElements = productComponentBM
                    });
                }
                else
                {
                    service.AddElement(new GiftCoverModel
                    {
                        GiftName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        GiftElements = productComponentBM
                    });
                }
                Session["id"] = null;
                Session["Change"] = null;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FGifts.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (service.GetList().Count != 0 && service.GetList().Last().GiftName == null)
            {
                service.DelElement(service.GetList().Last().Id);
            }
            if (!String.Equals(Session["Change"], null))
            {
                service.DelElement(id);
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