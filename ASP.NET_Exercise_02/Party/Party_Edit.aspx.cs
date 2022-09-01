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
    public partial class Party_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["ID"] != null)
                {
                    Update.Text = "Update";
                    FillTextBox();
                }
            }
        }

        private void FillTextBox()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand cm = new SqlCommand($"select party_name from party where party_id={Request.QueryString["ID"]}", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                Party_name.Text = sdr["party_name"].ToString();
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

        protected void UpdateParty_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                SqlCommand cm = null;
                if(Request.QueryString["ID"] != null)
                {
                    cm = new SqlCommand("PR_Update_Party", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("party_id", Convert.ToInt32(Request.QueryString["ID"].ToString()));
                    cm.Parameters.AddWithValue("party_name", Party_name.Text.ToString());
                    lblError.Text = "Party Updated SuccessFully";
                }
                else
                {
                    cm = new SqlCommand("PR_Add_Party", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("party_name", Party_name.Text.ToString());
                    lblError.Text = "Party Added SuccessFully";
                }
                con.Open();
                cm.ExecuteNonQuery();
                Response.Redirect("~/Party/Party_List.aspx");
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
                Response.Redirect("~/Party/Party_List.aspx");
            }
            
        }
    }
}