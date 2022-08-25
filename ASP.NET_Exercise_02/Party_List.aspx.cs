﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_Exercise_02
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=PartyDB; integrated security=SSPI");
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
            Response.Redirect("Party_Edit.aspx");
        }
    }
}