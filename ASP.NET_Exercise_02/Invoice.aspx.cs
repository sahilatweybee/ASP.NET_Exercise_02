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
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source =.; database = PartyDB; integrated security = SSPI");

                    //-------------------------------------initiaizing parties dataset-------------------------------//
                    SqlCommand party_query = new SqlCommand("select * from party", con);
                    SqlDataAdapter party_adapter = new SqlDataAdapter(party_query);
                    DataSet parties = new DataSet();
                    party_adapter.Fill(parties);
                    SelectParty.DataSource = parties;
                    SelectParty.DataTextField = "party_name";
                    SelectParty.DataValueField = "party_id";
                    SelectParty.DataBind();
                    SelectParty.Items.Insert(0, new ListItem("Select Party", "0"));

                    //-------------------------------------initiaizing products dataset-------------------------------//
                    SqlCommand product_query = new SqlCommand($"select product_name from product,assign_party where assign_party.product_id=product.product_id and assign_party.party_id = {SelectParty.SelectedValue}", con);
                    SqlDataAdapter product_adapter = new SqlDataAdapter(product_query);
                    DataSet products = new DataSet();
                    product_adapter.Fill(products);
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

        protected void addInvoice_Click(object sender, EventArgs e)
        {
        //    string insert_query = $"insert into invoice(party_name, product_name, rate_of_product, quantity, total) " +
        //                          $"select {} as party_name, {} as product_name, {} as rate,{} as quantity, {} as total from assign_party " +
        //                          $"inner join party on assign_party.party_id = party.party_id " +
        //                          $"inner join product on assign_party.product_id = product.product_id" +
        //                          $"inner join rate on assign_party.product_id = rate.product_id " +
        //                          $"where party.party_id = 7 and product.product_id = 9;";
        }
    }
}