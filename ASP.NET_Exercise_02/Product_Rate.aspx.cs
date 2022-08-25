using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_Exercise_02
{
    public partial class Produce_Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=PartyDB; integrated security=SSPI");
                string query = "select rate_id, product.product_name as product_name, rate, date_of_rate from rate, product where (product.product_id = rate.product_id);";
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
    }
}