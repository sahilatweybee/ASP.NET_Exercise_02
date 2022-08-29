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
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                String query = "select * from party order by party_name";
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                PartyGrid.DataSource = ds;
                PartyGrid.DataBind();
                
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
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

        protected void Alter_Party(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = PartyGrid.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(row.Cells[0].Text);
            if (e.CommandName == "EditParty")
            {
                Response.Redirect("~/Party/party_Edit.aspx?ID=" + id);
            } 
            if (e.CommandName == "DeleteParty")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                    
                    con.Open();
                    SqlCommand cm = new SqlCommand("PR_Delete_Party", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("party_id", id);
                    cm.ExecuteNonQuery();
                    Page_Load(sender, e);
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
}