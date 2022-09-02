using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ASP.NET_Exercise_02.App_Code;

namespace ASP.NET_Exercise_02
{
    public partial class Produce_Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_Data();
            }
        }

        private void display_Data()
        {
            try
            {
                string query = "PR_Select_Rate";
                DataTable ds = Base_Connection_Class.Select_Query(query);
                RateGrid.DataSource = ds;
                RateGrid.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "There Was Some Problem In Fetching Data from the server.\n" + ex.Message;
            }
        }

        protected void Add_Party_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Rate_Edit.aspx");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(RateGrid.Rows[rowindex].Cells[0].Text);
            string confirmDelete = Request.Form["confirm_delete"];
            if (confirmDelete == "Yes")
            {
                string query = "PR_Delete_Rate";
                string param_name = "@Rate_id";
                Base_Connection_Class.Delete_Query(query, param_name, id);
                display_Data();
            }
            else
            {
                display_Data();
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(RateGrid.Rows[rowindex].Cells[0].Text);
            int rate = Convert.ToInt32(RateGrid.Rows[rowindex].Cells[2].Text);
            string date = RateGrid.Rows[rowindex].Cells[3].Text;
            Response.Redirect($"Product_Rate_Edit.aspx?ID={id}&rate={rate}&date={date}");
        }
    }
}