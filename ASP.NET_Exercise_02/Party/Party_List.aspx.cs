using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ASP.NET_Exercise_02.App_Code;

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
            try
            {
                string Query = "PR_Select_Party";
                DataTable ds = Base_Connection_Class.Select_Query(Query);
                PartyGrid.DataSource = ds;
                PartyGrid.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "There Was Some Problem In Fetching Data from the server.\n" + ex.Message ;
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
            if (confirmDelete == "Yes")
            {
                string query = "PR_Delete_Party";
                string param_name = "@Party_id";
                string error = Base_Connection_Class.Delete_Query(query, param_name, id);
                display_Data();
                if(error == "")
                {
                    lblMessage.Text = error;
                }
                else
                {
                    lblMessage.Text = "Unable to delete this Party has a Product assigned to it. Refer assign party page";
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
            string name = PartyGrid.Rows[rowindex].Cells[1].Text;
            Response.Redirect($"~/Party/party_Edit.aspx?ID={id}&name={name}");
        }
    }
}