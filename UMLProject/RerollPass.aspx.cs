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
        BackEnd.DBManager db = new BackEnd.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {           
            BackEnd.Usuarios u=null;
            try
            {
                u = db.getUsuario(Request["id"]);
            }
            catch { }
            if(u == null)
            {
                output.Text = BackEnd.Util.MensajeFracaso("No existe ese usuario <a href='Login.aspx'>Regresar</a>");
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