﻿using GiftShopServiceWeb.Interfaces;
using System;
using Unity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using GiftShopServiceWeb.CoverModels;
using GiftShopServiceWeb.ViewModels;

namespace GiftShopViewWeb
{
    public partial class FCustomerCustoms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonMake_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate >= Calendar2.SelectedDate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertDate", "<script>alert('Дата начала должна быть меньше даты окончания');</script>");
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                                            "c " + Calendar1.SelectedDate.ToShortDateString() +
                                            " по " + Calendar2.SelectedDate.ToShortDateString());
                ReportViewer.LocalReport.SetParameters(parameter);

                var response = APIClient.PostRequest("api/Report/SaveCustomerCustoms", new ReportCoverModel
                {
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });
                var dataSource = APIClient.GetElement<List<CustomerCustomsModel>>(response);
                ReportDataSource source = new ReportDataSource("DataSetIndents", dataSource);
                ReportViewer.LocalReport.DataSources.Add(source);
                ReportViewer.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonToPdf_Click(object sender, EventArgs e)
        {
            Session["DateFrom"] = Calendar1.SelectedDate.ToString();
            Session["DateTo"] = Calendar2.SelectedDate.ToString();
            Server.Transfer("FCustomerCustomsSave.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FMain.aspx");
        }
    }
}