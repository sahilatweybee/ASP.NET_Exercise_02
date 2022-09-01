using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Exercise_02
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String ac_page = Request.RawUrl;
            
            if (ac_page.StartsWith("/Party")) 
            {
                btnParty.ForeColor = Color.White;
            }
            if (ac_page.StartsWith("/Product/")) 
            {
                btnProduct.ForeColor = Color.White;
            }
            if (ac_page.StartsWith("/Assign")) 
            { 
                btnAssign.ForeColor = Color.White;
            }
            if (ac_page.StartsWith("/Product_Rate")) 
            { 
                btnRate.ForeColor = Color.White;
            }
            if (ac_page.StartsWith("/Invoice")) 
            { 
                btnInvoice.ForeColor = Color.White;
            }
        }
    }
}