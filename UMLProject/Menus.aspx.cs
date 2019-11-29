using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Menus : System.Web.UI.Page
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
            else if (!ldata.isAdmin)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            if (IsPostBack) return;
            loadMenus();
            Dictionary<int, BackEnd.Articulos> arts = db.getArticulos();
            listarticulo.Items.Clear();
            foreach (BackEnd.Articulos item in arts.Values)
            {
                listarticulo.Items.Add(new ListItem(item.NOMBRE,item.ID_ARTICULO.ToString()));
            }
            List<BackEnd.Tipos_Usuarios> tu = db.getTipos_Usuarios();
            listTUsers.Items.Clear();
            foreach (BackEnd.Tipos_Usuarios item in tu)
            {
                listTUsers.Items.Add(new ListItem(item.NOMBRE, item.ID_TIPOUSUARIO.ToString()));
            }
        }
        private void loadMenus()
        {
            Dictionary<int, BackEnd.Menus> mnus = db.getMenus();
            listmenu.Items.Clear();
            foreach (BackEnd.Menus item in mnus.Values)
            {
                if (item.isMain) listmenu.Items.Add(new ListItem(item.NOMBRE, item.ID_MENU.ToString()));
            }
        }
        protected void listmenu_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if(listmenu.SelectedIndex!=-1)
            {
                listsubmenu.Items.Clear();
                foreach (BackEnd.Menus item in db.getMenu(int.Parse(listmenu.SelectedValue)).CHILDREN)
                {
                    listsubmenu.Items.Add(new ListItem(item.NOMBRE, item.ID_MENU.ToString()));
                }
                listsubmenu.Enabled = true;
                listarticulo.Enabled = true;
                btnBorrar.Enabled = true;
                btnVincular.Enabled = true;
                foreach (BackEnd.Tipos_Usuarios item in db.getTipos_Usuarios())
                {
                    string tu = "";
                    if (db.checkMenuAUsuario(int.Parse(listmenu.SelectedValue), item.ID_TIPOUSUARIO))
                        tu = item.NOMBRE;
                    for (int i = 0; i < listTUsers.Items.Count; i++)
                    {
                        if(listTUsers.Items[i].Value == tu)
                        {
                            listTUsers.Items[i].Selected = true;
                            break;
                        }
                    }
                }
                if(listTUsers.SelectedIndex!=-1)
                {
                    btnUsuarioVincular.Enabled = true;
                    btnDesvincular.Enabled = true;
                }
                btnCrear.Text = "Modificar";
                txtMnombre.Text = listmenu.SelectedItem.Text;
            }
            else
            {
                listsubmenu.Enabled = false;
                listarticulo.Enabled = false;
                btnBorrar.Enabled = false;
                btnVincular.Enabled = false;
                btnUsuarioVincular.Enabled = false;
                btnDesvincular.Enabled = false;
                btnCrear.Text = "Crear";
                txtMnombre.Text = "";
            }
        }

        protected void btnVincular_Click(object sender, EventArgs e)
        {
            int id = -1;
            int c = -1;
            if(listarticulo.SelectedIndex == -1 && url.Text.Trim() == string.Empty)
            {
                output.Text = BackEnd.Util.MensajeFracaso("Nada que vincular");
                return;
            }
            if (listsubmenu.SelectedIndex != -1)
            {
                id = int.Parse(listsubmenu.SelectedValue);
                c=listsubmenu.SelectedIndex;
            }
            else
            {
                id = int.Parse(listmenu.SelectedValue);
                c = listmenu.SelectedIndex;
            }
            if(listarticulo.SelectedIndex != -1)
                db.ModificarMenu(id,db.getMenu(id).NOMBRE, c, articulo: db.getArticulo(int.Parse(listarticulo.SelectedValue)));
            else
                db.ModificarMenu(id, db.getMenu(id).NOMBRE, c,url: url.Text);
            output.Text = BackEnd.Util.MensajeExito("Menu Vinculado");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            if(listsubmenu.SelectedIndex!=-1)
            {
                db.DeleteMenu(int.Parse(listsubmenu.SelectedValue));
            }
            else
            {
                db.DeleteMenu(int.Parse(listmenu.SelectedValue));
            }
            output.Text = BackEnd.Util.MensajeExito("Menu Eliminado");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtMnombre.Text.Trim() == string.Empty) return;
            if(btnCrear.Text=="Crear")
            {
                if (listmenu.SelectedIndex == -1)
                {
                    db.AgregarMenu(txtMnombre.Text, listmenu.Items.Count);
                }
                else
                {
                    db.AgregarMenu(txtMnombre.Text, listsubmenu.Items.Count, db.getMenu(int.Parse(listmenu.SelectedValue)));
                }
                output.Text = BackEnd.Util.MensajeExito("Menu Creado");
            }else
            {
                if(listsubmenu.SelectedIndex != -1)
                {
                    db.ModificarMenu(int.Parse(listsubmenu.SelectedValue), txtMnombre.Text,listsubmenu.SelectedIndex);
                    listsubmenu.SelectedItem.Text = txtMnombre.Text;
                }
                else
                {
                    db.ModificarMenu(int.Parse(listmenu.SelectedValue), txtMnombre.Text, listmenu.SelectedIndex);
                    listmenu.SelectedItem.Text = txtMnombre.Text;
                }
                output.Text = BackEnd.Util.MensajeExito("Menu Modificado");                
            }
            loadMenus();
        }

        protected void btnUsuarioVincular_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (listsubmenu.SelectedIndex != -1)
                id = int.Parse(listsubmenu.SelectedValue);
            else
                id = int.Parse(listmenu.SelectedValue);
            BackEnd.Menus m = db.getMenu(id);
            BackEnd.Tipos_Usuarios t = db.getTipo_Usuario(int.Parse(listTUsers.SelectedValue));
            if(m.PARENT != null)
                db.AgregarMenuAUsuario(m.PARENT, t);
            else
                db.AgregarMenuAUsuario(m, t);
            output.Text = BackEnd.Util.MensajeExito("Menu Vinculado Al Rol");
        }

        protected void btnDesvincular_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (listsubmenu.SelectedIndex != -1)
                id = int.Parse(listsubmenu.SelectedValue);
            else
                id = int.Parse(listmenu.SelectedValue);
            BackEnd.Menus m = db.getMenu(id);
            BackEnd.Tipos_Usuarios t = db.getTipo_Usuario(int.Parse(listTUsers.SelectedValue));
            if (m.PARENT != null)
                db.DeleteMenuAUsuario(m.PARENT, t);
            else
                db.DeleteMenuAUsuario(m, t);
            output.Text = BackEnd.Util.MensajeExito("Menu Desvinculado Al Rol");
        }

        protected void listTUsers_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (listTUsers.SelectedIndex != -1)
            {
                btnUsuarioVincular.Enabled = true;
                btnDesvincular.Enabled = true;                
            }
            else
            {
                btnUsuarioVincular.Enabled = false;
                btnDesvincular.Enabled = false;                
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtMnombre.Text = "";
            btnCrear.Text = "Crear";
        }

        protected void listsubmenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMnombre.Text = listsubmenu.SelectedItem.Text;            
        }
    }
}