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
        clases.DBManager db = new clases.DBManager();
        Dictionary<int, clases.Imagenes> imagenes;
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (clases.LoginData)Session["user"];
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
            imagenes = db.getImagenes();
            if (IsPostBack) return;
            imgs.Items.Clear();
            foreach (clases.Imagenes i in imagenes.Values)
            {
                imgs.Items.Add(new ListItem(i.NOMBRE, i.ID_IMAGEN.ToString()));
            }
        }

        

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            txtPreview.Text = txtContenido.Text;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            
            if(db.AgregarArticulo(txtTitulo.Text, Uri.EscapeDataString(txtContenido.Text)))
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
            if (imgs.SelectedIndex != -1)
            {
                img.ImageUrl = imagenes[int.Parse(imgs.SelectedValue)].URL;
                btnCopys.Attributes.Remove("OnClick");
                btnCopys.Attributes.Add("OnClick", $"CopyToClipboard('{img.ImageUrl}')");
            }
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
                        string ret = hpf.FileName;
                        string ext = ret.Substring(ret.LastIndexOf('.') + 1);
                        while (File.Exists(Path.Combine(path, ret)))
                            ret = "IMG_" + new Random(DateTime.Now.Millisecond).Next() + "." + ext;
                        hpf.SaveAs(Path.Combine(path, ret));
                        db.AgregarImagen(ret, "/imgs/" + ret);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error al subir imagen");
                Console.Write(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (imgs.SelectedIndex != -1)
            {
                File.Delete(Server.MapPath(imagenes[int.Parse(imgs.SelectedValue)].URL));
                db.EliminarImagen(int.Parse(imgs.SelectedValue));                
            }
        }
    }
}