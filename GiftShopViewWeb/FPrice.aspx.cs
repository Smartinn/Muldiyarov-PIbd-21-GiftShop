using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace GiftShopViewWeb
{
    public partial class FPrice : System.Web.UI.Page
    {
        readonly IReportService reportService = UnityConfig.Container.Resolve<IReportService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=Price.docx");
            Response.ContentType = "application/vnd.ms-word";
            try
            {
                var response = APIClient.PostRequest("api/Report/SaveGiftPrice", new ReportCoverModel
                {
                    FileName = "D:\\Price.docx"
                });
                if (response.Result.IsSuccessStatusCode)
                {
                    Response.WriteFile("D:\\Price.docx");
                }
                else
                {
                    throw new Exception(APIClient.GetError(response));
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }
    }
}