using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; //no se para que sirve esto si no sirve para nada eliminalo

namespace UMLProject
{
    public partial class login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        }

        protected void txtNombreU_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ee)
            {
                lblInfo.Text = "ocurrio un error" + ee;
            }
        }
    }
}