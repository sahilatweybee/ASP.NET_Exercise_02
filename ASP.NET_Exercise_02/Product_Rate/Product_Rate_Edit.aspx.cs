using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ASP.NET_Exercise_02
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateOfRate.Text = DateTime.Today.ToShortDateString();
                FillDropDownList();
                if(Request.QueryString["ID"] != null)
                {
                    FillData();
                }
            }
        }
        
        protected void FillDropDownList()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
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
                lblError.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        private void FillData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source =.; database = PartyDB; integrated security = SSPI");
                SqlCommand cm = new SqlCommand($"select product_id,rate, convert(varchar(10),date_of_rate, 105) as date_of_rate from rate where rate_id={Request.QueryString["ID"]}", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                SelectProduct.SelectedValue = sdr["product_id"].ToString();
                Curr_rate.Text = sdr["rate"].ToString();
                DateOfRate.Text = sdr["date_of_rate"].ToString();
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

        protected void UpdateProductRate_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source =.; database=PartyDB; integrated security = SSPI");
                SqlCommand cm = null;
                if (Request.QueryString["ID"] != null)
                {
                    cm = new SqlCommand("PR_Update_Rate", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("Rate_id", Convert.ToInt32(Request.QueryString["ID"]));
                    cm.Parameters.AddWithValue("Product_id", Convert.ToInt32(SelectProduct.SelectedValue));
                    cm.Parameters.AddWithValue("Rate", Convert.ToInt32(Curr_rate.Text));
                    cm.Parameters.AddWithValue("DateOfRate", Convert.ToDateTime(DateOfRate.Text).ToString("yyyy-MM-dd"));
                }
                else
                {
                    cm = new SqlCommand("PR_Add_Rate", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("product_id", Convert.ToInt32(SelectProduct.SelectedValue));
                    cm.Parameters.AddWithValue("rate", Convert.ToInt32(Curr_rate.Text));
                    cm.Parameters.AddWithValue("Date", Convert.ToDateTime(DateOfRate.Text).ToString("yyyy-MM-dd"));
                }
                con.Open();
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string confirmExit = Request.Form["confirm_exit"];
            if (confirmExit == "Yes")
            {
                Response.Redirect("~/Product_Rate/Product_Rate_List.aspx");
            }
        }
    }
}