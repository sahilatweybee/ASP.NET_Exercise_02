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
        //private DataTable ds = new DataTable();
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

        protected void SelectParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand product_query = new SqlCommand($"select distinct product.product_id as product_id, product.product_name as product_name from product,assign_party,rate where product.product_id=assign_party.product_id and rate.product_id=product.product_id and assign_party.party_id = {Convert.ToInt32(SelectParty.SelectedValue)}", con);
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
            Curr_rate.Enabled = false;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand cm = new SqlCommand($"select top 1 rate from rate where product_id = {SelectProduct.SelectedValue} order by date_of_rate desc", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                Curr_rate.Text = sdr["rate"].ToString();
                quantity_txtbox.Focus();
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
                cm.Parameters.AddWithValue("@Total", rate * quantity);
                cm.ExecuteNonQuery();
                Display_Invoice();
                SelectProduct.SelectedValue = "0";
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

        protected void Display_Invoice()
        {
            SelectParty.Enabled = false;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                con.Open();
                SqlCommand display = new SqlCommand("PR_Select_Invoice", con);
                display.CommandType = CommandType.StoredProcedure;
                display.Parameters.AddWithValue("@party_id", SelectParty.SelectedValue);
                SqlDataAdapter sde = new SqlDataAdapter(display);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                Invoice_View.DataSource = ds;
                Invoice_View.DataBind();
                lbltotal.Text = ds.Tables[0].AsEnumerable().Sum(x => Convert.ToInt32(x["total"])).ToString();
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

        protected void btnCloseInvoice_Click(object sender, EventArgs e)
        {
            Invoice_View.DataSource = null;
            Invoice_View.DataBind();
            lbltotal.Text = "";
            SelectParty.SelectedValue = "0";
            SelectProduct.SelectedValue = "0";
            Invoice_View.Visible = SelectParty.Enabled = true;
            Invoice_View.Visible = Curr_rate.Enabled = true;
            quantity_txtbox.Text = "";
        }
    }
}