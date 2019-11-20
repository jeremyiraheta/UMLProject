using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Contenido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] == null)
                Response.Redirect("Default.aspx");
            int id = -1;
            int.TryParse(Request["id"].ToString(), out id);
            if (id == -1)
                Response.Redirect("Default.aspx");
            clases.DBManager db = new clases.DBManager();
            clases.Articulos art = db.getArticulo(id);
            if (art == null)
                Response.Redirect("Default.aspx");
            txtTitulo.Text = art.NOMBRE;
            txtContenido.Text = art.CONTENIDO;
        }
    }
}