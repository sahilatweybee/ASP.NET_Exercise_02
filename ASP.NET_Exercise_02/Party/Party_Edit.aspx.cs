using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.NET_Exercise_02.App_Code;

namespace ASP.NET_Exercise_02
{
    public partial class Party_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["ID"] != null)
                {
                    Update.Text = "Update";
                    FillTextBox();
                }
            }
        }

        private void FillTextBox()
        {
            string name = Request.QueryString["name"];
            Party_name.Text = name;
        }

        protected void UpdateParty_Click(object sender, EventArgs e)
        {
            string query = "";
            string error ="";
            Dictionary<string, string> parameters;
            if(Request.QueryString["ID"] != null)
            {
                query = "PR_Update_Party";
                parameters = new Dictionary<string, string>();
                parameters.Add("party_id", Request.QueryString["ID"].ToString());
                parameters.Add("party_name", Party_name.Text.ToString());
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if(error == "")
                {
                    lblMessage.Text = "Party Updated SuccessFully";
                }
                else
                {
                    lblMessage.Text = "Unable to Update this Party!!! There is already a party with the same name.";
                }
            }
            else
            {
                query = "PR_Add_Party";
                parameters = new Dictionary<string, string>();
                parameters.Add("@Party_name", Party_name.Text.ToString());
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if (error == "")
                {
                    lblMessage.Text = "Party Added Successfully";
                }
                else
                {
                    lblMessage.Text = "Unable to add Party!!! There is already a Party with the same name.";
                }
            }   
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string confirmExit = Request.Form["confirm_exit"];
            if (confirmExit == "Yes")
            {
                Response.Redirect("~/Party/Party_List.aspx");
            }
            else
            {
                Page_Load(sender, e);
            }
        }
    }
}