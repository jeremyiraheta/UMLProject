using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lOK_Click(object sender, EventArgs e)
        {
            BackEnd.DBManager db = new BackEnd.DBManager();
            BackEnd.Usuarios user = db.ValidarUsuario(txtusername.Text, txtpassword.Text);
            if (user != null)
            {
                BackEnd.LoginData l = new BackEnd.LoginData(user);                
                Session["user"] = l;
                Response.Redirect("Default.aspx");
            }else
            {
                output.Text = BackEnd.Util.MensajeFracaso("Usuario o password incorrectos!");
            }
        }
    }
}