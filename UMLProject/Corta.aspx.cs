using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    
    public partial class Corta : System.Web.UI.Page
    {
        BackEnd.LoginData ldata;
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (BackEnd.LoginData)Session["user"];
            if (ldata == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            else if (!BackEnd.Util.checkRolByName(ldata.ROL, "cooperativa"))
            {
                Response.Redirect("Default.aspx");
                return;
            }
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {
            BackEnd.DBManager db = new BackEnd.DBManager();
            BackEnd.Cooperativa c = db.getCooperativa(ldata.USERNAME, "Corta");
            if (db.AgregarCorta(c.ID_COOPERATIVA, txtZona.Text, decimal.Parse(txtCantidad.Text)))
            {
                output.Text = BackEnd.Util.MensajeExito("Agregada Correctamente");
                txtCantidad.Text = "";
                txtZona.Text = "";
            }
            else
                output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");

        }
    }
}