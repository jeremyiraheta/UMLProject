using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Pesaje : System.Web.UI.Page
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
            if(db.AgregarPesaje(db.getCooperativa(ldata.USERNAME, "Corta").ID_COOPERATIVA, txtZona.Text, txtHorario.Text, decimal.Parse(txtLimite.Text)))
            {
                txtHorario.Text = "";
                txtLimite.Text = "";
                txtZona.Text = "";
                output.Text = clases.Util.MensajeExito("Cooperativa de Corta agregada");
            }else
                output.Text = clases.Util.MensajeFracaso("Ocurrio un error en la transaccion");
        }
    }
}