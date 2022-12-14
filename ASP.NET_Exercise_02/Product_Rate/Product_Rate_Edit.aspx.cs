using ASP.NET_Exercise_02.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Exercise_02
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateOfRate.Text = DateTime.Today.ToShortDateString();
                FillDropDownList();
                if (Request.QueryString["ID"] != null)
                {
                    Update.Text = "Update";
                    FillData();
                }
            }
        }

        protected void FillDropDownList()
        {
            string query = "PR_Select_Product";
            DataTable products = Base_Connection_Class.Select_Query(query);
            SelectProduct.DataSource = products;
            SelectProduct.DataTextField = "product_name";
            SelectProduct.DataValueField = "product_id";
            SelectProduct.DataBind();
            SelectProduct.Items.Insert(0, new ListItem("Select Product", "0"));
        }

        private void FillData()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            Dictionary<string, string> str = Base_Connection_Class.Get_Rate_Record(id);
            if (str["error"] == "")
            {
                SelectProduct.SelectedValue = str["value"];
                Curr_rate.Text = Request.QueryString["rate"];
                DateOfRate.Text = Request.QueryString["date"];
            }
            else
            {
                string s = "There is some error in fetching record you selected!!";
                lblMessage.Text = s + str["error"];
            }
        }

        protected void UpdateProductRate_Click(object sender, EventArgs e)
        {
            string query = "";
            string error = "";
            Dictionary<string, string> parameters;
            if (Request.QueryString["ID"] != null)
            {
                parameters = new Dictionary<string, string>();
                query = "PR_Update_Rate";
                parameters.Add("Rate_id", Request.QueryString["ID"]);
                parameters.Add("Product_id", SelectProduct.SelectedValue == "0" ? null : SelectProduct.SelectedValue);
                parameters.Add("Rate", Curr_rate.Text);
                parameters.Add("Date", Convert.ToDateTime(DateOfRate.Text).ToString("yyyy-MM-dd"));
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if (error == "")
                {
                    lblMessage.Text = "Record Updated SuccessFully";
                    SelectProduct.SelectedValue = "0";
                    Curr_rate.Text = "";
                    DateOfRate.Text = DateTime.Today.ToShortDateString();
                }
                else
                {
                    if (error.Contains("was not supplied."))
                    {
                        lblMessage.Text = "Please fill all the fields!!";
                    }
                    else
                    {
                        lblMessage.Text = "Unable to Update Record!!!";
                    }

                }
            }
            else
            {
                parameters = new Dictionary<string, string>();
                query = "PR_Add_Rate";
                parameters.Add("Product_id", SelectProduct.SelectedValue == "0" ? null : SelectProduct.SelectedValue);
                parameters.Add("Rate", Curr_rate.Text.ToString() == "" ? null : Curr_rate.Text);
                parameters.Add("Date", Convert.ToDateTime(DateOfRate.Text).ToString("yyyy-MM-dd"));
                error = Base_Connection_Class.Insert_Update_Query(query, parameters);
                if (error == "")
                {
                    lblMessage.Text = "Record Added SuccessFully";
                    SelectProduct.SelectedValue = "0";
                    Curr_rate.Text = "";
                    DateOfRate.Text = DateTime.Today.ToShortDateString();
                }
                else
                {
                    if (error.Contains("was not supplied."))
                    {
                        lblMessage.Text = "Please fill all the fields!!";
                    }
                    else
                    {
                        lblMessage.Text = "Unable to Add Record!!!\n" + error;
                    }

                }
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            string confirmExit = Request.Form["confirm_exit"];
            if (confirmExit == "Yes")
            {
                Response.Redirect("~/Product_Rate/Product_Rate_List.aspx");
            }
            else
            {
                FillDropDownList();
                if (Request.QueryString["ID"] != null)
                {
                    FillData();
                }
            }
        }

        protected void Show_calander_Click(object sender, ImageClickEventArgs e)
        {
            Calendar.Visible = !Calendar.Visible;
            Calendar.SelectedDate = Convert.ToDateTime(DateOfRate.Text);
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            DateOfRate.Text = Calendar.SelectedDate.ToString("dd-MM-yyyy");
            Calendar.Visible = false;
        }
    }
}