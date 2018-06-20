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
                reportService.SaveStorageLoad(new ReportCoverModel
                {
                    FileName = "D:\\SLoad.xls"
                });
                Response.WriteFile("D:\\SLoad.xls");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }
    }
}