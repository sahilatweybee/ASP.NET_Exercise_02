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
    public partial class Product_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    Update.Text = "Update";
                    FillTextBox();
                }
            }
        }

        private void FillTextBox()
        {
            Product_name.Text = Request.QueryString["name"];
        }
        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            string query = "";
            string error = "";
            Dictionary<string, string> parameters;
            if (Request.QueryString["ID"] != null)
            {
                query = "PR_Update_Product";
                parameters = new Dictionary<string, string>();
                parameters.Add("@product_id", Request.QueryString["ID"]);
                parameters.Add("@product_name", Product_name.Text.ToString());
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if(error == "")
                {
                    lblMessage.Text = "Product Updated SuccessFully";
                }
                else
                {
                    lblMessage.Text = "Unable to update Product!!!";
                }
            }
            else
            {
                query = "PR_Add_Product";
                parameters = new Dictionary<string, string>();;
                parameters.Add("@product_name", Product_name.Text.ToString());
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if (error == "")
                {
                    lblMessage.Text = "Product Added SuccessFully";
                }
                else
                {
                    lblMessage.Text = "Unable to Add Product!!!";
                }
            }
            
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string confirmExit = Request.Form["confirm_exit"];
            if (confirmExit == "Yes")
            {
                Response.Redirect("~/Product/Product_List.aspx");
            }
            else
            {
                Page_Load(sender, e);
            }
        }
    }
}