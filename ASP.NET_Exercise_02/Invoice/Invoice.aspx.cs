using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ASP.NET_Exercise_02.App_Code;

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
            DataTable parties = Base_Connection_Class.Select_Query("PR_Select_Party");
            SelectParty.DataSource = parties;
            SelectParty.DataTextField = "party_name";
            SelectParty.DataValueField = "party_id";
            SelectParty.DataBind();
            SelectParty.Items.Insert(0, new ListItem("--Select Party--", "0"));
        }

        protected void SelectParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(SelectParty.SelectedValue);
            DataTable products = Base_Connection_Class.Get_Products_By_party(id);
            SelectProduct.DataSource = products;
            SelectProduct.DataTextField = "product_name";
            SelectProduct.DataValueField = "product_id";
            SelectProduct.DataBind();
            SelectProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
        }

        protected void SelectProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            Curr_rate.Enabled = false;
            int id = Convert.ToInt32(SelectProduct.SelectedValue);
            string rate = Base_Connection_Class.Get_Rate(id);
            Curr_rate.Text = rate;
            quantity_txtbox.Focus();
        }

        protected void addInvoice_Click(object sender, EventArgs e)
        {
            int rate = Curr_rate.Text == "" ? 0 : Convert.ToInt32(Curr_rate.Text);
            int quantity = quantity_txtbox.Text == "" ? 0 : Convert.ToInt32(quantity_txtbox.Text);
            string query = "PR_Add_invoice";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@Party_id", SelectParty.SelectedValue == "0" ? null : SelectParty.SelectedValue);
            parameters.Add("@Product_id", SelectProduct.SelectedValue == "0" ? null : SelectProduct.SelectedValue);
            parameters.Add("@Rate", Curr_rate.Text == "" ? null : Curr_rate.Text);
            parameters.Add("@Quantity", quantity_txtbox.Text == "" ? null : quantity_txtbox.Text);
            parameters.Add("@Total", (rate * quantity).ToString());
            string error = Base_Connection_Class.Insert_Update_Query(query, parameters);

            if (error == "")
            {
                Display_Invoice();
                SelectProduct.SelectedValue = "0";
                Curr_rate.Text = "";
                quantity_txtbox.Text = "";
                lblMessage.Text = "";
            }
            else
            {
                if (error.Contains("was not supplied."))
                {
                    lblMessage.Text = "Please fill all the fields!!";
                }
                else
                {
                    lblMessage.Text = error;
                }
                
            }
        }

        protected void Display_Invoice()
        {
            SelectParty.Enabled = false;
            string query = "PR_Select_Invoice";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@party_id", SelectParty.SelectedValue);
            DataTable ds = Base_Connection_Class.Show_Invoice(query, parameters);
            Invoice_View.DataSource = ds;
            Invoice_View.DataBind();
            lbltotal.Text = ds.AsEnumerable().Sum(x => Convert.ToInt32(x["total"])).ToString();

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