using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class GArticulos : System.Web.UI.Page
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
            headers.Add("ID");
            headers.Add("NOMBRE");
            headers.Add("EDICION");
            List<string[]> rows = new List<string[]>();
            foreach (BackEnd.Articulos item in db.getArticulos().Values)
            {
                List<string> row = new List<string>();
                row.Add(item.ID_ARTICULO.ToString());
                row.Add(item.NOMBRE);                
                row.Add($"<a href=\"Crear.aspx?id={item.ID_ARTICULO}&edit=true\">Editar</a>");
                rows.Add(row.ToArray());
            }
            articulos.Text = BackEnd.Util.createTable(headers.ToArray(),rows);
        }
    }
}