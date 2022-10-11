using ASP.NET_Exercise_02.App_Code;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Exercise_02
{
    public partial class Assign_party : System.Web.UI.Page
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
            try
            {
                string query = "PR_Select_Assign";
                DataTable ds = Base_Connection_Class.Select_Query(query);
                AssignPartyGrid.DataSource = ds;
                AssignPartyGrid.DataBind();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void Add_Party_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Assign_Party/Assign_Party_Edit.aspx");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(AssignPartyGrid.Rows[rowindex].Cells[0].Text);
            string confirmDelete = Request.Form["confirm_delete"];
            if (confirmDelete == "Yes")
            {
                try
                {
                    string query = "PR_Delete_Assign";
                    string param_name = "@Assign_id";
                    Base_Connection_Class.Delete_Query(query, param_name, id);
                    display_Data();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "There Was Some Problem In Fetching Data from the server.\n" + ex.Message;
                }
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(AssignPartyGrid.Rows[rowindex].Cells[0].Text);
            Response.Redirect($"~/Assign_Party/Assign_Party_Edit.aspx?ID={id}");
        }
    }
}