using ASP.NET_Exercise_02.App_Code;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Exercise_02
{
    public partial class Product_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_Data();
            }
        }

        private void display_Data()
        {

            try
            {
                string query = "PR_Select_Product";
                DataTable ds = Base_Connection_Class.Select_Query(query);
                ProductGrid.DataSource = ds;
                ProductGrid.DataBind();

            }
            catch (Exception ex)
            {
                lblMessage.Text = "There Was Some Problem In Fetching Data from the server.\n" + ex.Message; ;
            }

        }

        protected void Add_Party_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Edit.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(ProductGrid.Rows[rowindex].Cells[0].Text);
            string confirmDelete = Request.Form["confirm_delete"];
            if (confirmDelete == "Yes")
            {
                string query = "PR_Delete_Product";
                string param_name = "@Product_id";
                string error = Base_Connection_Class.Delete_Query(query, param_name, id);
                display_Data();
                if (error == "")
                {
                    lblMessage.Text = error;
                }
                else
                {
                    lblMessage.Text = "Unable to delete!!! This Product is assigned to a Party. Refer assign party page";
                }
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(ProductGrid.Rows[rowindex].Cells[0].Text);
            string name = ProductGrid.Rows[rowindex].Cells[1].Text;
            Response.Redirect($"Product_Edit.aspx?ID={id}&name={name}");
        }
    }
}