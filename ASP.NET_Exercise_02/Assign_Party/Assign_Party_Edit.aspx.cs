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

                FillDropDownLists();
                if (Request.QueryString["ID"] != null)
                {
                    FillData();
                }
            }
        }

        protected void FillDropDownLists()
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
                SqlCommand cm = new SqlCommand($"select * from assign_party where assign_id = {Request.QueryString["ID"]}", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                SelectParty.SelectedValue = sdr["party_id"].ToString();
                SelectProduct.SelectedValue = sdr["product_id"].ToString();
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

        protected void UpdateAssignParty_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source =.; database=PartyDB; integrated security = SSPI");
                SqlCommand cm = null;
                if (Request.QueryString["ID"] != null)
                {
                    cm = new SqlCommand("PR_Update_Assign_Party", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("assign_id", Request.QueryString["ID"]);
                    cm.Parameters.AddWithValue("party_id", SelectParty.SelectedValue);
                    cm.Parameters.AddWithValue("product_id", SelectProduct.SelectedValue);
                }
                else
                {
                    cm = new SqlCommand("PR_Assign_Party", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("party_id", SelectParty.SelectedValue);
                    cm.Parameters.AddWithValue("product_id", SelectProduct.SelectedValue);
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
                Response.Redirect("~/Assign_Party/Assign_Party_List.aspx");
            }
        }
    }
}