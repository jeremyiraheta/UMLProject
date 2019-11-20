using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Crear : System.Web.UI.Page
    {
        clases.LoginData ldata;
        string selected = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (clases.LoginData)Session["user"];
            if (ldata == null)
            {
                output.Text = clases.Util.MensajeFracaso("No es un usuario logueado");
                return;
            }
            else if (!ldata.isAdmin)
            {
                output.Text = clases.Util.MensajeFracaso("No tienes permisos validos");
                return;
            }
        }

        

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            txtPreview.Text = txtContenido.Text;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            clases.DBManager db = new clases.DBManager();
            if(db.AgregarArticulo(txtTitulo.Text, txtContenido.Text))
            {
                output.Text = clases.Util.MensajeExito("Articulo agregado");
                txtPreview.Text = "";
                txtContenido.Text = "";
                txtTitulo.Text = "";
            }else
            {
                output.Text = clases.Util.MensajeFracaso("No se completo la transaccion");
            }
        }

        protected void imgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = imgs.SelectedValue;
            img.ImageUrl = selected;
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/imgs/");
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        hpf.SaveAs(Server.MapPath("MyFiles") + "\\" +
                          Path.GetFileName(hpf.FileName));
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle your exception here
            }
            string ret = filename;
            string ext = filename.Substring(filename.LastIndexOf('.') + 1);
            while (File.Exists(Path.Combine(path, ret)))
                ret = "IMG_" + new Random(DateTime.Now.Millisecond).Next() + "." + ext;
            return ret;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {

        }
    }
}