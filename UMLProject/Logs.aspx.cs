using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Logs : System.Web.UI.Page
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
            List<string> headers = new List<string>();
            headers.Add("FECHA");
            headers.Add("ACCION");
            headers.Add("TABLA");
            headers.Add("USUARIO");
            List<string[]> rows = new List<string[]>();
            foreach (BackEnd.Log item in db.getLogs())
            {
                List<string> row = new List<string>();
                row.Add(item.DATE.ToString());
                row.Add(item.ACTION.ToString());
                row.Add(item.TABLE.ToString());
                row.Add(item.USUARIO.ID_USUARIO);
                rows.Add(row.ToArray());
            }
            logs.Text = BackEnd.Util.createTable(headers.ToArray(),rows);
        }
    }
}