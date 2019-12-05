using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class GFacturas : System.Web.UI.Page
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
            bool permit = ldata.isAdmin || ldata.ROL.NOMBRE.ToLower() == "empleado" || ldata.ROL.NOMBRE.ToLower() == "cliente";
            if (!permit)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            bool isClient = BackEnd.Util.checkRolByName(ldata.ROL, "Cliente");
            if(!isClient)
            {
                string procesar = Request["procesar"];
                string activar = Request["activar"];
                if (procesar != null)
                {
                    try
                    {
                        db.ModificarFacturacion(int.Parse(procesar), false);
                    }
                    catch
                    {
                        return;
                    }
                }
                if (activar != null)
                {
                    try
                    {
                        db.ModificarFacturacion(int.Parse(procesar), true);
                    }
                    catch
                    {
                        return;
                    }
                }
            }
            List<string> headers = new List<string>();
            headers.Add("NO");
            headers.Add("FECHA");
            headers.Add("TOTAL");
            headers.Add("ESTADO");
            if(!isClient)headers.Add("EDICION");
            List<string[]> rows = new List<string[]>();
            foreach (BackEnd.Facturacion item in db.getFacturas().Values.Where(o => o.USUARIO.ID_USUARIO == ldata.USERNAME))
            {
                List<string> row = new List<string>();
                row.Add(item.ID_FACTURA.ToString());
                row.Add(item.FECHA.ToShortTimeString());
                row.Add(item.TOTAL.ToString());
                row.Add(item.ACTIVA ? "Activa" : "Procesada");
                if(!isClient)row.Add(item.ACTIVA ? $"<a href=\"GFacturas.aspx?procesar={item.ID_FACTURA}\">Procesar</a>" : $"<a href=\"GFacturas.aspx?activar={item.ID_FACTURA}\">Activar</a>");
                rows.Add(row.ToArray());
            }
            facturas.Text = BackEnd.Util.createTable(headers.ToArray(), rows);
        }
    }
}