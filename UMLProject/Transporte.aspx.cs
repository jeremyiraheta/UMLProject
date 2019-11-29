using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Transporte : System.Web.UI.Page
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
            else if (!BackEnd.Util.checkRolByName(ldata.ROL, "cooperativa"))
            {
                Response.Redirect("Default.aspx");
                return;
            }
            Dictionary<int, BackEnd.Tipo_Transporte> trans = db.getTipoTransportes();
            foreach (BackEnd.Tipo_Transporte item in trans.Values)
            {
                ddTipo.Items.Add(new ListItem(item.NOMBRE, item.ID_TIPOTRANSPORTE.ToString()));
            }
        }

        protected void lOK_Click(object sender, EventArgs e)
        {

            if (db.AgregarTransporte(db.getCooperativa(ldata.USERNAME, "Transporte").ID_COOPERATIVA, ddTipo.SelectedValue, txtZona.Text, txtHorario.Text, decimal.Parse(txtLimite.Text)))
            {
                txtHorario.Text = "";
                txtLimite.Text = "";
                txtZona.Text = "";
                output.Text = BackEnd.Util.MensajeFracaso("Cooperativa de Transporte Agregado");
            }
            else
            {
                output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
            }
        }
    }
}