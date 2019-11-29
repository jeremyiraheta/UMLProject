﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Main : System.Web.UI.MasterPage
    {
        BackEnd.LoginData ldata;
        BackEnd.DBManager db = new BackEnd.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata= (BackEnd.LoginData)Session["user"];
            if (ldata != null && ldata.isAdmin)
            {
                string html = "";
                html += $"<a href=\"#0\" title=\"\">{ldata.USERNAME}</a>";
                html += "<ul class=\"sub-menu\">";
                html += "<li><a href=\"Crear.aspx\" title=\"\">Crear Articulo</a></li>";
                html += "<li><a href=\"Menus.aspx\" title=\"\">Crear Menus</a></li>";
                html += "<li><a href=\"GArticulos.aspx\" title=\"\">Gestionar Articulos</a></li>";                
                html += "<li><a href=\"GUsuarios.aspx\" title=\"\">Gestionar Usuarios</a></li>";
                html += "<li><a href=\"GCooperativas.aspx\" title=\"\">Gestionar Cooperativas</a></li>";
                html += "<li><a href=\"Logs.aspx\" title=\"\">Ver Historial</a></li>";
                html += "<li><a href=\"DoQuery.aspx\" title=\"\">Peticiones Directas</a></li>";
                html += "<li><a href=\"Default.aspx?logout=true\" title=\"\">Cerrar Session</a></li>";
                html += "</ul>";
                userid.InnerHtml = html;
                userid.Attributes.Add("class", "has-children");
                menu.Text = LoadMenus(ldata.ROL.ID_TIPOUSUARIO);                
            }else if(ldata != null && BackEnd.Util.checkRolByName(ldata.ROL,"Cooperativa"))
            {
                string html = "";
                html += $"<a href=\"#0\" title=\"\">{ldata.USERNAME}</a>";
                html += "<ul class=\"sub-menu\">";
                html += "<li><a href=\"Cooperativa.aspx\" title=\"\">Crear Cooperativa</a></li>";
                html += "<li><a href=\"Cooperativas.aspx\" title=\"\">Gestionar Cooperativa</a></li>";
                BackEnd.Cooperativa corta = db.getCooperativa(ldata.USERNAME, "Corta");
                if (corta != null)
                {
                    html += "<li><a href=\"Corta.aspx\" title=\"\">Crear Corta</a></li>";
                    html += $"<li><a href=\"Corta.aspx?edit=true\" title=\"\">Modificar Corta</a></li>";
                }
                BackEnd.Cooperativa transporte = db.getCooperativa(ldata.USERNAME, "Transporte");
                if (transporte != null)
                {
                    html += "<li><a href=\"Transporte.aspx\" title=\"\">Crear Transporte</a></li>";
                    html += "<li><a href=\"Transporte.aspx?edit=true\" title=\"\">Modificar Transporte</a></li>";
                }
                html += "<li><a href=\"Default.aspx?logout=true\" title=\"\">Cerrar Session</a></li>";
                html += "</ul>";
                userid.InnerHtml = html;
                userid.Attributes.Add("class", "has-children");
                menu.Text = LoadMenus(ldata.ROL.ID_TIPOUSUARIO);
            }else if (ldata != null && BackEnd.Util.checkRolByName(ldata.ROL, "Cliente"))
            {
                string html = "";
                html += $"<a href=\"#0\" title=\"\">{ldata.USERNAME}</a>";
                html += "<ul class=\"sub-menu\">";
                html += "<li><a href=\"Pedido.aspx\" title=\"\">Realizar Pedido</a></li>";
                html += "<li><a href=\"Pedidos.aspx\" title=\"\">Gestionar Pedidos</a></li>";
                html += "<li><a href=\"Default.aspx?logout=true\" title=\"\">Cerrar Session</a></li>";
                html += "</ul>";
                userid.InnerHtml = html;
                userid.Attributes.Add("class", "has-children");
                menu.Text = LoadMenus(ldata.ROL.ID_TIPOUSUARIO);
            }
            menu.Text += LoadMenus();            

        }
        private string LoadMenus(int tipo = -1)
        {
            string html = "";
            List<BackEnd.Menus> mns;
            List<BackEnd.Menus> mlist = new List<BackEnd.Menus>();
            if (tipo == -1)
                mns = db.getMenuATodos();
            else
                mns = db.getMenuAUsuario(tipo);
            foreach (BackEnd.Menus item in mns.OrderBy(u=>u.ORDEN).ToArray())
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
                    foreach (BackEnd.Menus sitem in item.CHILDREN.OrderBy(o=>o.ORDEN).ToArray())
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