using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Crear : System.Web.UI.Page
    {
        clases.LoginData ldata;
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (clases.LoginData)Session["user"];
            if (ldata == null)
            {
                output.Text = clases.Util.MensajeFracaso("No es un usuario logueado");
                return;
            }
            else if (!ldata.isAdmin)
            {
                output.Text = clases.Util.MensajeFracaso("No tienes permisos validos");
                return;
            }
        }

        

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            txtPreview.Text = txtContenido.Text;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            clases.DBManager db = new clases.DBManager();
            if(db.AgregarArticulo(txtTitulo.Text, txtContenido.Text))
            {
                output.Text = clases.Util.MensajeExito("Articulo agregado");
                txtPreview.Text = "";
                txtContenido.Text = "";
                txtTitulo.Text = "";
            }else
            {
                output.Text = clases.Util.MensajeFracaso("No se completo la transaccion");
            }
        }
    }
}