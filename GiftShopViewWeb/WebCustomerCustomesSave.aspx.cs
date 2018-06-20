using GiftShopService.CoverModels;
using GiftShopService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace GiftShopViewWeb
{
    public partial class WebCustomerCustomesSave : System.Web.UI.Page
    {
        readonly IReportService reportService = UnityConfig.Container.Resolve<IReportService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=CustomerCustoms.pdf");
            Response.ContentType = "application/vnd.ms-word";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            try
            {
                reportService.SaveCustomerCustoms(new ReportCoverModel
                {
                    FileName = "D:\\CustomerCustoms.pdf",
                    DateFrom = DateTime.Parse(Session["DateFrom"].ToString()),
                    DateTo = DateTime.Parse(Session["DateTo"].ToString())
                });
                Response.WriteFile("D:\\CustomerCustoms.pdf");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }
    }
}