using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ASP.NET_Exercise_02
{
    public partial class Produce_Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                string query = "select rate_id, product.product_name as product_name, rate, CONVERT(VARCHAR(10),date_of_rate,105) as date_of_rate from rate, product where (product.product_id = rate.product_id)";
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                RateGrid.DataSource = ds;
                RateGrid.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void Add_Party_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Rate_Edit.aspx");
        }

        protected void RateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = RateGrid.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(row.Cells[0].Text);
            if (e.CommandName == "EditRate")
            {
                
                Response.Redirect("Product_Rate_Edit.aspx?ID=" + id);
            }
            if (e.CommandName == "DeleteRate")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);

                    con.Open();
                    SqlCommand cm = new SqlCommand("PR_Delete_Rate", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("Rate_id", id);
                    cm.ExecuteNonQuery();
                    Page_Load(sender, e);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}