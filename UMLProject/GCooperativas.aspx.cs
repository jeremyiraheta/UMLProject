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
            bool permit = ldata.isAdmin || ldata.ROL.NOMBRE.ToLower() == "empleado";
            if (ldata == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            else if (!permit)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            List<string> headers = new List<string>();
            headers.Add("NOMBRE");
            headers.Add("TELEFONO");
            headers.Add("TIPO");
            headers.Add("ZONA");
            headers.Add("REFERENTE");
            if(ldata.isAdmin)
                headers.Add("EDICION");
            List<string[]> rows = new List<string[]>();
            foreach (BackEnd.Cooperativa item in db.getCooperativas().Values)
            {
                List<string> row = new List<string>();
                row.Add(item.NOMBRE);
                row.Add(item.TELEFONO);
                row.Add(item.TIPO);
                row.Add(item.ZONA);
                row.Add(item.USUARIO.NOMBRE + " " + item.USUARIO.APELLIDO);
                if(ldata.isAdmin)
                    row.Add($"<a href=\"Cooperativa.aspx?id={item.ID_COOPERATIVA}&edit=true\">Editar</a>");
                rows.Add(row.ToArray());
            }
            List<string> headers2 = new List<string>();
            headers.Add("COOPERATIVA");
            headers.Add("ZONA");
            headers.Add("MAXIMO");
            if (ldata.isAdmin)
                headers.Add("EDICION");
            List<string[]> rows2 = new List<string[]>();
            foreach (BackEnd.Corta item in db.getCortas().Values)
            {
                List<string> row = new List<string>();
                row.Add(item.COOPERATIVA.NOMBRE);
                row.Add(item.ZONA);
                row.Add(item.MAXIMO.ToString());
                if (ldata.isAdmin)
                    row.Add($"<a href=\"Corta.aspx?id={item.ID_CORTA}&edit=true\">Editar</a>");
                rows.Add(row.ToArray());
            }
            List<string> headers3 = new List<string>();
            headers.Add("ID");
            headers.Add("NOMBRE");
            headers.Add("TELEFONO");
            headers.Add("TIPO");
            headers.Add("ZONA");
            headers.Add("REFERENTE");
            if (ldata.isAdmin)
                headers.Add("EDICION");
            List<string[]> rows3 = new List<string[]>();
            foreach (BackEnd.Cooperativa item in db.getCooperativas().Values)
            {
                List<string> row = new List<string>();
                row.Add(item.ID_COOPERATIVA.ToString());
                row.Add(item.NOMBRE);
                row.Add(item.TELEFONO);
                row.Add(item.TIPO);
                row.Add(item.ZONA);
                row.Add(item.USUARIO.NOMBRE + " " + item.USUARIO.APELLIDO);
                if (ldata.isAdmin)
                    row.Add($"<a href=\"Transporte.aspx?id={item.ID_COOPERATIVA}&edit=true\">Editar</a>");
                rows.Add(row.ToArray());
            }
            cooperativas.Text = BackEnd.Util.createTable(headers.ToArray(), rows);
            corta.Text = BackEnd.Util.createTable(headers2.ToArray(), rows2);
            transporte.Text = BackEnd.Util.createTable(headers3.ToArray(), rows3);
        }
    }
}