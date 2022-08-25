using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_Exercise_02
{
    public partial class Assign_party : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=PartyDB; integrated security=SSPI");
                string query = "select assign_id, Party.Party_Name as party_name, Product.product_name as product_name from assign_party, party, product where(Party.party_id = assign_party.party_id) and(Product.product_id = assign_party.product_id);";
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                PartyGrid.DataSource = ds;
                PartyGrid.DataBind();

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
            Server.Transfer("Assign_Party_Edit.aspx");
        }
    }
}