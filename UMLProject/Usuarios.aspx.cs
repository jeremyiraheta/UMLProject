using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Usuarios : System.Web.UI.Page
    {
        BackEnd.DBManager db = new BackEnd.DBManager();
        BackEnd.LoginData ldata;
        protected void Page_Load(object sender, EventArgs e)
        {            
            foreach (BackEnd.Tipos_Usuarios t in db.getTipos_Usuarios())
            {
                if(!(t.NOMBRE.ToLower() == "admin" || t.NOMBRE.ToLower() == "empleado")) ddTipo.Items.Add(new ListItem(t.NOMBRE, t.ID_TIPOUSUARIO.ToString()));
            }
            string id = "";
            BackEnd.Usuarios u;
            if (Request["edit"] == "true")
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
                try
                {
                    id = Request["id"];
                    u = db.getUsuario(id);

                }
                catch
                {
                    output.Text = BackEnd.Util.MensajeFracaso("ID no valida");
                    return;
                }
                recover.Controls.Clear();
                title.Text = "Modificar Usuario";
                lOKs.Text = "EDITAR";
                pass.Controls.Clear();
                txtusername.ReadOnly = true;
                ddTipo.Items.Add(new ListItem("Admin", "1"));
                ddTipo.Items.Add(new ListItem("Empleado", "2"));
                if (!IsPostBack)
                {
                    txtApellido.Text = u.APELLIDO;
                    txtDireccion.Text = u.DIRECCION;
                    txtdui.Text = u.DUI;
                    txtemail.Text = u.CORREO;
                    txtname.Text = u.NOMBRE;
                    txtnit.Text = u.NIT;
                    txttel.Text = u.TELEFONO;
                    txtusername.Text = u.ID_USUARIO;
                    ddTipo.SelectedValue = u.TIPO.ID_TIPOUSUARIO.ToString();
                }
                LinkButton del = new LinkButton();
                del.Text = "ELIMINAR";
                del.OnClientClick = "if ( ! UserDeleteConfirmation()) return false;";
                del.CssClass = "waves-effect waves-light btn-large";
                del.Click += Del_Click;                
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (db.EliminarUsuario(Request["id"]))
            {
                db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ELIMINAR, BackEnd.Tables.USUARIOS);
                Response.Redirect(".");
            }
            else
                output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {
            if(lOKs.Text == "EDITAR")
            {
                if(db.ModificarUsuario(txtusername.Text, int.Parse(ddTipo.SelectedValue),txtname.Text,txtApellido.Text, txtdui.Text, txtnit.Text, txttel.Text, txtemail.Text, txtDireccion.Text))
                {
                    output.Text = BackEnd.Util.MensajeExito("Usuario modificado");
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ACTUALIZAR, BackEnd.Tables.USUARIOS);
                }else
                    output.Text = BackEnd.Util.MensajeFracaso("No se completo la transaccion");
            }
            else
            {
                if (!db.AgregarUsuario(txtusername.Text, txtpassword.Text, int.Parse(ddTipo.SelectedValue.ToString()), txtname.Text, txtApellido.Text, txtdui.Text, txtnit.Text, txttel.Text, txtemail.Text, txtDireccion.Text))
                    output.Text = BackEnd.Util.MensajeFracaso("No se completo la transaccion.<br/>Usuario, DUI, NIT y CORREO deben ser valores unicos");
                else
                {
                    db.CrearPreguntaRecuperacion(txtusername.Text, int.Parse(ddpregunta.SelectedValue.ToString()), txtRespuesta.Text);
                    db.AgregarLog("admin", BackEnd.TipoLog.CREAR, BackEnd.Tables.USUARIOS);
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}