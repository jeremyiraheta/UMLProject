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
        clases.DBManager db = new clases.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (clases.Tipos_Usuarios t in db.getTipos_Usuarios())
            {
                ddTipo.Items.Add(new ListItem(t.NOMBRE, t.ID_TIPOUSUARIO.ToString()));
            }
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {
            if (!db.AgregarUsuario(txtusername.Text, txtpassword.Text, int.Parse(ddTipo.SelectedValue.ToString()), txtname.Text, txtApellido.Text, txtdui.Text, txtnit.Text, txttel.Text, txtemail.Text, txtDireccion.Text))
                output.Text = "<div class=\"alert-box alert-box--error hideit\">" +
                                "<p>Ocurrio un error</p>" +
                                "<i class=\"fa fa-times alert-box__close\" aria-hidden=\"true\"></i></div>";
        }
    }
}