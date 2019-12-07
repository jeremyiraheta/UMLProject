using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class RerollPass : System.Web.UI.Page
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
            else if (ldata.isAdmin)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            BackEnd.Usuarios u=null;
            try
            {
                u = db.getUsuario(Request["id"]);
            }
            catch { }
            if(u == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            ddpregunta.SelectedValue = db.getPregunta(u.ID_USUARIO).ToString();
            ddpregunta.Enabled = false;
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {
            if (db.IsValidRespuesta(Request["id"], txtRespuesta.Text))
            {
                if (db.ModificarPass(Request["id"], txtpassword.Text))
                    Response.Redirect("Login.aspx");
                else
                    output.Text = BackEnd.Util.MensajeFracaso("No se pudo cambiar el password debido a un error");
            }
            else
                output.Text = BackEnd.Util.MensajeFracaso("La respuesta no es la correcta");
        }
    }
}