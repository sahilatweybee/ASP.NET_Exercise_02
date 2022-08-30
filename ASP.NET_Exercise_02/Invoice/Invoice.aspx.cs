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
                display_Data();
            }
        }

        protected void display_Data()
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
                cm.Parameters.AddWithValue("@Party_id", SelectParty.SelectedValue);
                cm.Parameters.AddWithValue("@Product_id", SelectProduct.SelectedValue);
                cm.Parameters.AddWithValue("@Rate", rate);
                cm.Parameters.AddWithValue("@Quantity", quantity);
                cm.Parameters.AddWithValue("@Total", rate*quantity);
                cm.ExecuteNonQuery();
                string select_qury = "select top 1 invoice.invoice_id as invoice_id, party.party_name as party_name, product.product_name as product_name, invoice.rate_of_product as rate, invoice.quantity as quantity, invoice.total as total from invoice,party,product where invoice.party_id = party.party_id and invoice.product_id = product.product_id order by invoice_id desc";
                SqlCommand display = new SqlCommand(select_qury, con);
                SqlDataAdapter sde = new SqlDataAdapter(display);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                Invoice_View.DataSource = ds;
                Invoice_View.DataBind();
                lbltotal.Text = ds.Tables[0].Compute("sum(total)", string.Empty).ToString();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
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
                LblError.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void SelectProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand cm = new SqlCommand($"select top 1 rate from rate where product_id = {SelectProduct.SelectedValue} order by date_of_rate desc", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                Curr_rate.Text = sdr["rate"].ToString();
                Curr_rate.Enabled = false;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}