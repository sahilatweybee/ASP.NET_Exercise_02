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
    public partial class WebForm1 : System.Web.UI.Page
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
                con.Open();
                SqlCommand cm = new SqlCommand("PR_Select_Party", con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sde = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                PartyGrid.DataSource = ds;
                PartyGrid.DataBind();

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

        protected void Add_Party_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Party/Party_Edit.aspx");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(PartyGrid.Rows[rowindex].Cells[0].Text);
            string confirmDelete = Request.Form["confirm_delete"];
            SqlConnection con = null;
            if (confirmDelete == "Yes")
            {
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                    SqlCommand cm = new SqlCommand("PR_Delete_Party", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@Party_id", id);
                    con.Open();
                    cm.ExecuteNonQuery();
                    display_Data();
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
            else
            {
                display_Data();
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(PartyGrid.Rows[rowindex].Cells[0].Text);
            Response.Redirect("~/Party/party_Edit.aspx?ID=" + id);
        }
    }
}