using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ASP.NET_Exercise_02
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=.; database=PartyDB; integrated security=SSPI");
                    String query = "select * from product";
                    SqlCommand display_products = new SqlCommand(query, con);
                    SqlDataAdapter producrAdptr = new SqlDataAdapter(display_products);
                    DataSet products = new DataSet();
                    producrAdptr.Fill(products);
                    SelectProduct.DataSource = products;
                    SelectProduct.DataTextField = "product_name";
                    SelectProduct.DataValueField = "product_id";
                    SelectProduct.DataBind();
                    SelectProduct.Items.Insert(0, new ListItem("Select Product", "0"));
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

        protected void UpdateProductRate_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source =.; database=PartyDB; integrated security = SSPI");
                String query = $"insert rate(product_id, rate, date_of_rate) values({Convert.ToInt32(SelectProduct.SelectedValue)}, {Convert.ToInt32(Curr_rate.Text)}, getdate())";
                SqlCommand AssignParty = new SqlCommand(query, con);
                con.Open();
                AssignParty.ExecuteNonQuery();
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