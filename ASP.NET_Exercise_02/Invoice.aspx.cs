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
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                FillParties();
            }
        }

        protected void FillParties()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand party_query = new SqlCommand("select * from party", con);
                SqlDataAdapter party_adapter = new SqlDataAdapter(party_query);
                DataSet parties = new DataSet();
                party_adapter.Fill(parties);
                SelectParty.DataSource = parties;
                SelectParty.DataTextField = "party_name";
                SelectParty.DataValueField = "party_id";
                SelectParty.DataBind();
                SelectParty.Items.Insert(0, new ListItem("--Select Party--", "0"));
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void addInvoice_Click(object sender, EventArgs e)
        {
            int rate = Convert.ToInt32(Curr_rate.Text);
            int quantity = Convert.ToInt32(quantity_txtbox.Text);

            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                con.Open();
                SqlCommand cm = new SqlCommand("PR_Add_invoice", con);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("Party_id", SelectParty.SelectedValue);
                cm.Parameters.AddWithValue("Product_id", SelectProduct.SelectedValue);
                cm.Parameters.AddWithValue("Rate", rate);
                cm.Parameters.AddWithValue("Quantity", quantity);
                cm.Parameters.AddWithValue("Total", rate*quantity);
                cm.ExecuteNonQuery();
                string select_qury = "select top 1 party.party_name as party_name, product.product_name as product_name, rate_of_product as rate, quantity, total from invoice,party,product where invoice.party_id = party.party_id and invoice.product_id = product.product_id order by invoice_id desc";
                SqlCommand display = new SqlCommand(select_qury, con);
                SqlDataAdapter sde = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                Invoice_View.DataSource = ds;
                Invoice_View.DataBind();

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

        protected void SelectParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand product_query = new SqlCommand($"select product.product_id as product_id, product.product_name as product_name from product,assign_party where product.product_id=assign_party.product_id and assign_party.party_id = {Convert.ToInt32(SelectParty.SelectedValue)}", con);
                SqlDataAdapter product_adapter = new SqlDataAdapter(product_query);
                DataSet products = new DataSet();
                product_adapter.Fill(products);
                SelectProduct.DataSource = products;
                SelectProduct.DataTextField = "product_name";
                SelectProduct.DataValueField = "product_id";
                SelectProduct.DataBind();
                SelectProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
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

        protected void SelectProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}