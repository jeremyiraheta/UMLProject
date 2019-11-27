using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Cooperativa : System.Web.UI.Page
    {
        clases.LoginData ldata;
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (clases.LoginData)Session["user"];
            if (ldata == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            else if (!clases.Util.checkRolByName(ldata.ROL, "cooperativa"))
            {
                Response.Redirect("Default.aspx");
                return;
            }
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {
            clases.DBManager db = new clases.DBManager();
            string tipo = "";
            if (rbtCorte.Checked) tipo = "Corta";
            if (rbtPesaje.Checked) tipo = "Pesaje";
            if (rbtTransporte.Checked) tipo = "Transporte";
            if (db.AgregarCooperativa(ldata.USERNAME, txtNombre.Text, txtZona.Text, txtTel.Text, tipo))
            {
                output.Text = clases.Util.MensajeExito("Cooperativa agregada");
                txtNombre.Text = "";
                txtTel.Text = "";
                txtZona.Text = "";
            }
            else
                output.Text = clases.Util.MensajeFracaso("Ocurrio un error en la transaccion");
        }
    }
}