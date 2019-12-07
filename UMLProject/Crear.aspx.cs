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
        BackEnd.LoginData ldata;
        BackEnd.DBManager db = new BackEnd.DBManager();
        Dictionary<int, BackEnd.Imagenes> imagenes;
        protected void Page_Load(object sender, EventArgs e)
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
            int id = -1;
            BackEnd.Articulos a;
            if (Request["edit"] == "true")
            {
                try
                {
                    id = int.Parse(Request["id"]);
                    a = db.getArticulo(id);

                }
                catch
                {
                    output.Text = BackEnd.Util.MensajeFracaso("ID no valida");
                    return;
                }
                title.Text = "Modificar Articulo";
                btnOk.Text = "EDITAR";
                if (!IsPostBack)
                {
                    txtTitulo.Text = a.NOMBRE;                 
                    txtContenido.Text = Uri.UnescapeDataString(a.CONTENIDO);
                    txtPreview.Text = txtContenido.Text;
                }
                LinkButton del = new LinkButton();
                del.Text = "ELIMINAR";
                del.OnClientClick = "if ( ! UserDeleteConfirmation()) return false;";
                del.CssClass = "waves-effect waves-light btn-large";
                del.Click += Del_Click;
                buttons.Controls.Add(del);
            } 
                       
            if(!IsPostBack) LoadImages();

        }

        private void Del_Click(object sender, EventArgs e)
        {
            if(db.EliminarArticulo(int.Parse(Request["id"])))
            {
                db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ELIMINAR, BackEnd.Tables.ARTICULOS);
                Response.Redirect(".");
            }
            else
                output.Text = BackEnd.Util.MensajeFracaso("Ocurrio un error en la transaccion");
        }

        private void LoadImages()
        {
            imagenes = db.getImagenes();
            imgs.Items.Clear();
            foreach (BackEnd.Imagenes i in imagenes.Values)
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
            
            if(btnOk.Text == "EDITAR")
            {
                if(db.ModificarArticulo(int.Parse(Request["id"]), txtTitulo.Text, Uri.EscapeDataString(txtContenido.Text)))
                {
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ACTUALIZAR, BackEnd.Tables.ARTICULOS);
                    output.Text = BackEnd.Util.MensajeExito("Articulo modificado");
                }
                else
                {
                    output.Text = BackEnd.Util.MensajeFracaso("No se completo la transaccion");
                }
            }
            else
            {
                if (db.AgregarArticulo(txtTitulo.Text, Uri.EscapeDataString(txtContenido.Text)))
                {
                    output.Text = BackEnd.Util.MensajeExito("Articulo agregado");
                    db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.CREAR, BackEnd.Tables.ARTICULOS);
                    txtPreview.Text = "";
                    txtContenido.Text = "";
                    txtTitulo.Text = "";
                }
                else
                {
                    output.Text = BackEnd.Util.MensajeFracaso("No se completo la transaccion");
                }
            }
        }

        protected void imgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (imgs.SelectedIndex != -1)
            {
                if(imagenes == null)
                    imagenes = db.getImagenes();
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
                        db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.CREAR, BackEnd.Tables.IMAGENES);
                    }
                }
                LoadImages();
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
                if (imagenes == null)
                    imagenes = db.getImagenes();
                File.Delete(Server.MapPath(imagenes[int.Parse(imgs.SelectedValue)].URL));
                db.EliminarImagen(int.Parse(imgs.SelectedValue));
                db.AgregarLog(ldata.USERNAME, BackEnd.TipoLog.ELIMINAR, BackEnd.Tables.IMAGENES);
                LoadImages();             
            }
        }
    }
}