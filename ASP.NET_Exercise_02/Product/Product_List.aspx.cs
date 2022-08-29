﻿using System;
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
    public partial class Product_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);
                String query = "select * from product order by product_name";
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                ProductGrid.DataSource = ds;
                ProductGrid.DataBind();
                con.Close();
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
            Response.Redirect("Product_Edit.aspx");
        }

        protected void ProductGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = ProductGrid.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(row.Cells[0].Text);
            if (e.CommandName == "EditProduct")
            {
                Response.Redirect("Product_Edit.aspx?ID=" + id);
            }
            if (e.CommandName == "DeleteProduct")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyDB"].ConnectionString);

                    con.Open();
                    SqlCommand cm = new SqlCommand("PR_Delete_Product", con);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("Product_id", id);
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