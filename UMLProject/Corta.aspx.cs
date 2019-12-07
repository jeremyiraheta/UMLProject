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
            BackEnd.Corta c;
            if (Request["edit"] == "true")
            {
                try
                {
                    id = int.Parse(Request["id"]);
                    c = db.getCorta(id);

                }
                catch
                {
                    output.Text = BackEnd.Util.MensajeFracaso("ID no valida");
                    return;
                }
                title.Text = "Modificar Corta";
                lOKs.Text = "EDITAR";
                if(!IsPostBack)
                {
                    txtCantidad.Text = c.MAXIMO.ToString();
                    txtZona.Text = c.ZONA;
                }
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
            if (db.EliminarCorta(int.Parse(Request["id"])))
            {
                db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ELIMINAR, BackEnd.Tables.CORTA);
                Response.Redirect(".");
            }
            else
                output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {            
            BackEnd.Cooperativa c = db.getCooperativa(ldata.USERNAME, BackEnd.TipoCooperativa.CORTA);
            if (lOKs.Text == "EDITAR")
            {
                BackEnd.Cooperativa t = db.getCooperativa(ldata.USERNAME, BackEnd.TipoCooperativa.CORTA);
                if (db.ModificarCorta(int.Parse(Request["id"]), c.ID_COOPERATIVA, txtZona.Text, decimal.Parse(txtCantidad.Text)))
                {
                    output.Text = BackEnd.Util.MensajeExito("Cooperativa de Corte Modificada");
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ACTUALIZAR, BackEnd.Tables.CORTA);
                }
                else
                    output.Text = BackEnd.Util.MensajeExito("Ocurrio un error en la transaccion");
            }
            else
            { 
                if (db.AgregarCorta(c.ID_COOPERATIVA, txtZona.Text, decimal.Parse(txtCantidad.Text)))
                {
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.CREAR, BackEnd.Tables.CORTA);
                    Response.Redirect("Default.aspx");
                }
                else
                    output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
            }
        }
    }
}