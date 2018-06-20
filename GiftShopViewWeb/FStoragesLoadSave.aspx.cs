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
    public partial class FStoragesLoadSave : System.Web.UI.Page
    {
        readonly IReportService reportService = UnityConfig.Container.Resolve<IReportService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", " filename=SLoad.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            try
            {
                var response = APIClient.PostRequest("api/Report/SaveStorageLoad", new ReportCoverModel
                {
                    FileName = "D:\\SLoad.xls"
                });
                if (response.Result.IsSuccessStatusCode)
                {
                    Response.WriteFile("D:\\SLoad.xls");
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