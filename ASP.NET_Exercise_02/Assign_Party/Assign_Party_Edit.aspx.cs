using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using ASP.NET_Exercise_02.App_Code;

namespace ASP.NET_Exercise_02
{
    public partial class Assign_Party_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillDropDownLists();
                if (Request.QueryString["ID"] != null)
                {
                    Update.Text = "Update";
                    FillData();
                }
            }
        }

        protected void FillDropDownLists()
        {
            string party_query = "PR_Select_Party";
            DataTable parties = Base_Connection_Class.Select_Query(party_query);
            SelectParty.DataSource = parties;
            SelectParty.DataTextField = "party_name";
            SelectParty.DataValueField = "party_id";
            SelectParty.DataBind();
            SelectParty.Items.Insert(0, new ListItem("Select Party", "0"));

            string product_query = "PR_Select_Product";
            DataTable products = Base_Connection_Class.Select_Query(product_query);
            SelectProduct.DataSource = products;
            SelectProduct.DataTextField = "product_name";
            SelectProduct.DataValueField = "product_id";
            SelectProduct.DataBind();
            SelectProduct.Items.Insert(0, new ListItem("Select Product", "0"));
            
        }

        private void FillData()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            Dictionary<string, string> str = Base_Connection_Class.Get_Assigned_Record(id);
            if(str["error"] == "")
            {
                SelectParty.SelectedValue = str["party"];
                SelectProduct.SelectedValue = str["product"];
            }
            else
            {
                lblMessage.Text = "There is some error in fetching record you selected!!" + str["error"];
            }
            
        }

        protected void UpdateAssignParty_Click(object sender, EventArgs e)
        {
            string query = "";
            string error = "";
            Dictionary<string, string> parameters;
            if (Request.QueryString["ID"] != null)
            {
                query = "PR_Update_Assign_Party";
                parameters = new Dictionary<string, string>();
                parameters.Add("assign_id", Request.QueryString["ID"]);
                parameters.Add("party_id", SelectParty.SelectedValue == "0" ? null : SelectParty.SelectedValue);
                parameters.Add("product_id", SelectProduct.SelectedValue == "0" ? null : SelectProduct.SelectedValue);
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if (error == "")
                {
                    lblMessage.Text = "Assigned Party Updated SuccessFully";
                }
                else
                {
                    if (error.Contains("was not supplied."))
                    {
                        lblMessage.Text = "Please fill all the fields!!";
                    }
                    else
                    {
                        lblMessage.Text = "Unable to update this Record!!!\n" + error;
                    }
                    
                }
            }
            else
            {
                query = "PR_Add_Assign_Party";
                parameters = new Dictionary<string, string>();
                parameters.Add("party_id", SelectParty.SelectedValue == "0" ? null : SelectParty.SelectedValue);
                parameters.Add("product_id", SelectProduct.SelectedValue == "0" ? null : SelectProduct.SelectedValue);
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if (error == "")
                {
                    lblMessage.Text = "Party Assigned SuccessFully";
                }
                else
                {
                    if (error.Contains("was not supplied."))
                    {
                        lblMessage.Text = "Please fill all the fields!!";
                    }
                    else
                    {
                        lblMessage.Text = "Unable to Add Product!!!\n" + error;
                    }
                    
                }
            }      
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string confirmExit = Request.Form["confirm_exit"];
            if (confirmExit == "Yes")
            {
                Response.Redirect("~/Assign_Party/Assign_Party_List.aspx");
            }
            else
            {
                FillDropDownLists();
            }
        }
    }
}