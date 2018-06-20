using GiftShopServiceWeb.Interfaces;
using GiftShopServiceWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace GiftShopViewWeb
{
    public partial class FStorageLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Table.Rows.Add(new TableRow());
                Table.Rows[0].Cells.Add(new TableCell());
                Table.Rows[0].Cells[0].Text = "Склад";
                Table.Rows[0].Cells.Add(new TableCell());
                Table.Rows[0].Cells[1].Text = "Компонент";
                Table.Rows[0].Cells.Add(new TableCell());
                Table.Rows[0].Cells[2].Text = "Количество";
                var response = APIClient.GetRequest("api/Report/GetStorageLoad");
                var dict = new List<StorageLoadViewModel>();
                if (response.Result.IsSuccessStatusCode)
                {
                    dict = APIClient.GetElement<List<StorageLoadViewModel>>(response);
                }
                else
                {
                    throw new Exception(APIClient.GetError(response));
                }
                if (dict != null)
                {
                    int i = 1;
                    foreach (var elem in dict)
                    {
                        Table.Rows.Add(new TableRow());
                        Table.Rows[i].Cells.Add(new TableCell());
                        Table.Rows[i].Cells[0].Text = elem.StorageName;
                        Table.Rows[i].Cells.Add(new TableCell());
                        Table.Rows[i].Cells[1].Text = "";
                        Table.Rows[i].Cells.Add(new TableCell());
                        Table.Rows[i].Cells[2].Text = "";
                        i++;
                        foreach (var listElem in elem.Elements)
                        {
                            Table.Rows.Add(new TableRow());
                            Table.Rows[i].Cells.Add(new TableCell());
                            Table.Rows[i].Cells[0].Text = "";
                            Table.Rows[i].Cells.Add(new TableCell());
                            Table.Rows[i].Cells[1].Text = listElem.ElementName;
                            Table.Rows[i].Cells.Add(new TableCell());
                            Table.Rows[i].Cells[2].Text = listElem.Count.ToString();
                            i++;
                        }
                        Table.Rows.Add(new TableRow());
                        Table.Rows[i].Cells.Add(new TableCell());
                        Table.Rows[i].Cells[0].Text = "Итого";
                        Table.Rows[i].Cells.Add(new TableCell());
                        Table.Rows[i].Cells[1].Text = "";
                        Table.Rows[i].Cells.Add(new TableCell());
                        Table.Rows[i].Cells[2].Text = elem.TotalCount.ToString();
                        i++;
                        Table.Rows.Add(new TableRow());
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertCreateTable", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonSaveExcel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FStoragesLoadSave.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}