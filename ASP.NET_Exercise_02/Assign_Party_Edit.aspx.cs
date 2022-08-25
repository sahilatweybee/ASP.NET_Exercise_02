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
    public partial class Assign_Party_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    //-------------------------------------initiaizing parties dataset-------------------------------//
                    con = new SqlConnection("data source =.; database = PartyDB; integrated security = SSPI");
                    SqlCommand party_query = new SqlCommand("select * from party", con);
                    SqlDataAdapter party_adapter = new SqlDataAdapter(party_query);
                    DataSet parties = new DataSet();
                    party_adapter.Fill(parties);

                    //-------------------------------------initiaizing products dataset-------------------------------//
                    SqlCommand product_query = new SqlCommand("select * from product", con);
                    SqlDataAdapter product_adapter = new SqlDataAdapter(product_query);
                    DataSet products = new DataSet();
                    product_adapter.Fill(products);

                    //-------------------------------------binding datasets--------------------------------------------//
                    SelectParty.DataSource = parties;
                    SelectParty.DataTextField = "party_name";
                    SelectParty.DataValueField = "party_id";
                    SelectParty.DataBind();
                    SelectParty.Items.Insert(0, new ListItem("Select Party", "0"));

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

        protected void UpdateAssignParty_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source =.; database=PartyDB; integrated security = SSPI");
                String query = "insert into assign_party(party_id, product_id) values (" + Convert.ToInt32(SelectParty.SelectedValue) + "," + Convert.ToInt32(SelectProduct.SelectedValue) + ")";
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