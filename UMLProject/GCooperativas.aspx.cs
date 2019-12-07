using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class GCooperativas : System.Web.UI.Page
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
            bool permit = ldata.isAdmin || ldata.ROL.NOMBRE.ToLower() == "empleado";
            if (!permit)
            {
                Response.Redirect("Default.aspx");
                return;
            }            
            List<string> headers = new List<string>();
            headers.Add("COOPERATIVA");
            headers.Add("TIPO");
            headers.Add("TELEFONO");
            headers.Add("REFERENTE");
            headers.Add("ZONA");
            headers.Add("MAXIMO");
            if(ldata.isAdmin)
                headers.Add("EDICION");
            List<string[]> rows = new List<string[]>();
            foreach (BackEnd.Corta item in db.getCortas().Values)
            {
                List<string> row = new List<string>();
                row.Add(item.COOPERATIVA.NOMBRE);
                row.Add(item.COOPERATIVA.TIPO);
                row.Add(item.COOPERATIVA.TELEFONO);
                row.Add(item.COOPERATIVA.USUARIO.NOMBRE + " " + item.COOPERATIVA.USUARIO.APELLIDO);
                row.Add(item.ZONA);
                row.Add(item.MAXIMO.ToString());
                if (ldata.isAdmin)
                    row.Add($"<a href=\"Corta.aspx?id={item.ID_CORTA}&edit=true\">Editar Corta</a><br/><a href=\"Cooperativa.aspx?id={item.COOPERATIVA.ID_COOPERATIVA}&edit=true\">Editar Cooperativa</a>");
                rows.Add(row.ToArray());
            }
            List<string> headers2 = new List<string>();
            headers2.Add("COOPERATIVA");
            headers2.Add("TIPO");
            headers2.Add("TELEFONO");            
            headers2.Add("REFERENTE");
            headers2.Add("HORARIOS");
            headers2.Add("TIPO TRANSPORTE");
            headers2.Add("ZONA");
            headers2.Add("LIMITE");
            if(ldata.isAdmin)
                headers2.Add("EDICION");
            List<string[]> rows2 = new List<string[]>();
            foreach (BackEnd.Transporte item in db.getTransportes().Values)
            {
                List<string> row = new List<string>();
                row.Add(item.COOPERATIVA.NOMBRE);
                row.Add(item.COOPERATIVA.TIPO);
                row.Add(item.COOPERATIVA.TELEFONO);
                row.Add(item.COOPERATIVA.USUARIO.NOMBRE + " " + item.COOPERATIVA.USUARIO.APELLIDO);
                row.Add(item.HORARIOS);
                row.Add(item.TIPO.NOMBRE);
                row.Add(item.ZONA);
                row.Add(item.LIMITE.ToString());
                if (ldata.isAdmin)
                    row.Add($"<a href=\"Transporte.aspx?id={item.ID_TRANSPORTE}&edit=true\">Editar Transporte</a><br/><a href=\"Cooperativa.aspx?id={item.COOPERATIVA.ID_COOPERATIVA}&edit=true\">Editar Cooperativa</a>");
                rows2.Add(row.ToArray());
            }
            corta.Text = BackEnd.Util.createTable(headers.ToArray(), rows);
            transporte.Text = BackEnd.Util.createTable(headers2.ToArray(), rows2);
        }
    }
}