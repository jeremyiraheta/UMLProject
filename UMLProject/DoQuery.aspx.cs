using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace UMLProject
{
    public partial class DoQuery : System.Web.UI.Page
    {
        BackEnd.LoginData ldata;
        BackEnd.DBManager db = new BackEnd.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (BackEnd.LoginData)Session["user"];
            if (ldata == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            else if (!ldata.isAdmin)
            {
                Response.Redirect("Default.aspx");
                return;
            }
        }

        protected void btnDo_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (txtQuery.Text.Trim().ToLower() == "show tables")
                ds = db.DoQuery("SELECT name FROM SYSOBJECTS WHERE xtype = 'U'; ");
            else
                ds = db.DoQuery(txtQuery.Text);
            if (ds==null)
            {
                output.Text = "Ocurrio un error";
            }
            else if(ds.Tables.Count > 0 || !ds.HasErrors)
            {
                gridoutput.DataSource = ds;
                gridoutput.DataBind();              
                output.Text = "Ejecutado";
            }
            else
            {
                output.Text = "Ocurrio un error";
            }
        }
    }
}