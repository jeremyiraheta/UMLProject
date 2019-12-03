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
            int id = -1;
            BackEnd.Cooperativa c;
            if (Request["edit"] == "true")
            {
                try
                {
                    id = int.Parse(Request["id"]);
                    c = db.getCooperativa(id);

                }
                catch {
                    output.Text = BackEnd.Util.MensajeFracaso("ID no valida");
                    return;
                }
                Label1.Text = "Modificar Cooperativa";
                lOKs.Text = "EDITAR";
                txtNombre.Text = c.NOMBRE;
                txtTel.Text = c.TELEFONO;
                txtZona.Text = c.ZONA;
                if (c.TIPO.ToLower() == "corta")
                    rbtCorte.Checked = true;
                else
                    rbtTransporte.Checked = true;
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
            if (db.EliminarCooperativa(int.Parse(Request["id"])))
            {
                db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ELIMINAR, BackEnd.Tables.COOPERATIVA);
                Response.Redirect(".");
            }
            else
                output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {
            
            BackEnd.TipoCooperativa tipo= BackEnd.TipoCooperativa.CORTA;
            if (rbtCorte.Checked) tipo = BackEnd.TipoCooperativa.CORTA;
            if (rbtTransporte.Checked) tipo = BackEnd.TipoCooperativa.TRANSPORTE;
            if(lOKs.Text=="EDITAR")
            {
                if(db.ModificarCooperativa(int.Parse(Request["id"]), ldata.USERNAME, txtNombre.Text,txtZona.Text, txtTel.Text, tipo))
                {
                    output.Text = BackEnd.Util.MensajeExito("Cooperativa modificada");
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ACTUALIZAR, BackEnd.Tables.COOPERATIVA);
                }else
                    output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
            }
            else
            {
                if (db.AgregarCooperativa(ldata.USERNAME, txtNombre.Text, txtZona.Text, txtTel.Text, tipo))
                {
                    output.Text = BackEnd.Util.MensajeExito("Cooperativa agregada");
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.CREAR, BackEnd.Tables.COOPERATIVA);
                    txtNombre.Text = "";
                    txtTel.Text = "";
                    txtZona.Text = "";
                }
                else
                    output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
            }
        }
    }
}