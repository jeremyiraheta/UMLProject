using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; 

namespace UMLProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btmRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch ( Exception ee)
            {
                lblInfo.Text = "ocurrio un error" + ee; 
            }
        }
    }
}