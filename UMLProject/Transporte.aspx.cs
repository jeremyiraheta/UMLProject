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
            bool permit = BackEnd.Util.checkRolByName(ldata.ROL, "cooperativa") || ldata.isAdmin;
            if (!permit)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            Dictionary<int, BackEnd.Tipo_Transporte> trans = db.getTipoTransportes();
            foreach (BackEnd.Tipo_Transporte item in trans.Values)
            {
                ddTipo.Items.Add(new ListItem(item.NOMBRE, item.ID_TIPOTRANSPORTE.ToString()));
            }
            int id = -1;
            BackEnd.Transporte c;
            if (Request["edit"] == "true")
            {
                try
                {
                    id = int.Parse(Request["id"]);
                    c = db.getTransporte(id);

                }
                catch
                {
                    output.Text = BackEnd.Util.MensajeFracaso("ID no valida");
                    return;
                }
                title.Text = "Modificar Transporte";
                lOKs.Text = "EDITAR";
                txtHorario.Text = c.HORARIOS;
                txtLimite.Text = c.LIMITE.ToString();
                txtZona.Text = c.ZONA;
                ddTipo.SelectedValue = c.TIPO.ID_TIPOTRANSPORTE.ToString();
                LinkButton del = new LinkButton();
                del.Text = "ELIMINAR";
                del.OnClientClick = "if ( ! UserDeleteConfirmation()) return false;";
                del.CssClass = "waves-effect waves-light btn-large";
                del.Click += Del_Click;
                buttons.Controls.Add(del);
            }
            
        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (db.EliminarTransporte(int.Parse(Request["id"])))
            {
                db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ELIMINAR, BackEnd.Tables.TRANSPORTE);
                Response.Redirect(".");
            }
            else
                output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
        }

        protected void lOK_Click(object sender, EventArgs e)
        {

            if(lOKs.Text == "EDITAR")
            {
                BackEnd.Cooperativa t = db.getCooperativa(ldata.USERNAME, BackEnd.TipoCooperativa.TRANSPORTE);                
                if(db.ModificarTransporte(int.Parse(Request["id"]), t.ID_COOPERATIVA, int.Parse(ddTipo.SelectedValue), txtZona.Text, txtHorario.Text, decimal.Parse(txtLimite.Text)))
                {
                    output.Text = BackEnd.Util.MensajeExito("Cooperativa de Transporte Modificada");
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ACTUALIZAR, BackEnd.Tables.TRANSPORTE);
                }
                else
                    output.Text = BackEnd.Util.MensajeExito("Ocurrio un error en la transaccion");
            }
            else
            {
                if (db.AgregarTransporte(db.getCooperativa(ldata.USERNAME, BackEnd.TipoCooperativa.TRANSPORTE).ID_COOPERATIVA, int.Parse(ddTipo.SelectedValue), txtZona.Text, txtHorario.Text, decimal.Parse(txtLimite.Text)))
                {
                    txtHorario.Text = "";
                    txtLimite.Text = "";
                    txtZona.Text = "";
                    output.Text = BackEnd.Util.MensajeFracaso("Cooperativa de Transporte Agregado");
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.CREAR, BackEnd.Tables.TRANSPORTE);
                }
                else
                {
                    output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
                }
            }
        }
    }
}