using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class PurchaseOrderView1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PO_ID"] != null)
            {
                if (!IsPostBack)
                {
                    BindPuchaseOrder();
                }
            }
            else
            {
                Response.Redirect("~/PurchaseOrderView.aspx");
            }
        }

        private void BindPuchaseOrder()
        {
            Int64 PO_Id = Convert.ToInt64(Request.QueryString["PO_ID"]);
            Response.Write("<script> alert'"+PO_Id+"'  </script>");
        }

    }
}