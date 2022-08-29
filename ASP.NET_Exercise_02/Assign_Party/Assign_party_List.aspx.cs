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
    public partial class Assign_party : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }

        protected void FillData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                string query = "select assign_id, Party.Party_Name as party_name, Product.product_name as product_name from assign_party, party, product where(Party.party_id = assign_party.party_id) and(Product.product_id = assign_party.product_id);";
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                AssignPartyGrid.DataSource = ds;
                AssignPartyGrid.DataBind();

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

        protected void Add_Party_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Assign_Party/Assign_Party_Edit.aspx");
        }

        protected void AssignPartyGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = AssignPartyGrid.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(row.Cells[0].Text);
            if (e.CommandName == "EditAssign")
            {
                Response.Redirect("~/Assign_Party/Assign_Party_Edit.aspx?ID=" + id);
            }
            if (e.CommandName == "DeleteAssign")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);

                    con.Open();
                    SqlCommand cm = new SqlCommand("PR_Delete_Assign", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("Assign_id", id);
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