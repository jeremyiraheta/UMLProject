using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Main : System.Web.UI.MasterPage
    {
        clases.LoginData ldata;
        clases.DBManager db = new clases.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata= (clases.LoginData)Session["user"];
            if (ldata != null)
            {
                string html = "";
                html += $"<a href=\"#0\" title=\"\">{ldata.USERNAME}</a>";
                html += "<ul class=\"sub-menu\">";
                html += "<li><a href=\"Crear.aspx\" title=\"\">Crear Articulo</a></li>";
                html += "<li><a href=\"Menus.aspx\" title=\"\">Crear Menus</a></li>";
                html += "<li><a href=\"GArticulos.aspx\" title=\"\">Gestionar Articulos</a></li>";
                html += "<li><a href=\"GMenus.aspx\" title=\"\">Gestionar Menus</a></li>";
                html += "<li><a href=\"GUsuarios.aspx\" title=\"\">Gestionar Usuarios</a></li>";
                html += "<li><a href=\"GArticulos.aspx\" title=\"\">Gestionar Cooperativas</a></li>";
                html += "<li><a href=\"Logs.aspx\" title=\"\">Ver Historial</a></li>";
                html += "</ul>";
                userid.InnerHtml = html;
                userid.Attributes.Add("class", "has-children");
                menu.Text = LoadMenus(ldata.ROL);                
            }
            menu.Text += LoadMenus();

        }
        private string LoadMenus(clases.Tipos_Usuarios tipo = null)
        {
            string html = "";
            List<clases.Menus> mns;
            List<clases.Menus> mlist = new List<clases.Menus>();
            if (tipo == null)
                mns = db.getMenuATodos();
            else
                mns = db.getMenuAUsuario(tipo);
            foreach (clases.Menus item in mns.OrderBy(u=>u.ORDEN).ToArray())
            {
                if (!item.isMain) continue;
                if (item.CHILDREN.Count == 0)
                {
                    if(item.ARTICULO != null)
                    {
                        html += $"<li><a href=\"Contenido.aspx?id={item.ARTICULO.ID_ARTICULO}\" title=\"\">{item.NOMBRE}</a></li>";
                    }
                    else
                    {
                        html += $"<li><a href=\"{item.URL}\" title=\"\">{item.NOMBRE}</a></li>";
                    }
                }else
                {
                    html += "<li class=\"has-children\">";
                    html += $"<a href=\"#0\" title=\"\">{item.NOMBRE}</a>";
                    html += "<ul class=\"sub-menu\">";
                    foreach (clases.Menus sitem in item.CHILDREN.OrderBy(o=>o.ORDEN).ToArray())
                    {
                        if (sitem.ARTICULO != null)
                        {
                            html += $"<li><a href=\"Contenido.aspx?id={sitem.ARTICULO.ID_ARTICULO}\" title=\"\">{sitem.NOMBRE}</a></li>";
                        }
                        else
                        {
                            html += $"<li><a href=\"{sitem.URL}\" title=\"\">{sitem.NOMBRE}</a></li>";
                        }                        
                    }
                    html += "</ul></li>";
                }
            }
            return html;
        }       
    }
}