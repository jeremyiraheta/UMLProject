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
                        db.ModificarFacturacion(int.Parse(activar), true);
                    }
                    catch
                    {
                        return;
                    }
                }
                TextBox src = new TextBox();
                Button btn = new Button();
                btn.Text = "Buscar";
                btn.Click += (object s, EventArgs ee) =>
                {
                    try
                    {
                        int.Parse(src.Text);
                    }catch
                    {
                        Response.Redirect("GFacturas.aspx");
                        return;
                    }
                    BackEnd.Facturacion x = db.BuscarFactura(int.Parse(src.Text));
                    List<string> iheaders = new List<string>();
                    iheaders.Add("NO");
                    iheaders.Add("FECHA");
                    iheaders.Add("TOTAL($)");
                    iheaders.Add("ESTADO");
                    iheaders.Add("EDICION");
                    List<string[]> irows = new List<string[]>();
                    List<string> row = new List<string>();
                    row.Add(x.ID_FACTURA.ToString());
                    row.Add(x.FECHA.ToShortTimeString());
                    row.Add(x.TOTAL.ToString());
                    row.Add(x.ACTIVA ? "Activa" : "Procesada");
                    if (!isClient)
                        row.Add(x.ACTIVA ? $"<a href=\"GFacturas.aspx?procesar={x.ID_FACTURA}\">Procesar</a> <a href=\"Factura.aspx?id={x.ID_FACTURA}\" target=\"_BLANK\">Comprobar</a>" : $"<a href=\"GFacturas.aspx?activar={x.ID_FACTURA}\">Activar</a>  <a href=\"Factura.aspx?id={x.ID_FACTURA}\" target=\"_BLANK\">Comprobar</a>");
                    else
                        row.Add($"<a href=\"Factura.aspx?id={x.ID_FACTURA}\" target=\"_BLANK\">Imprimir</a>");
                    irows.Add(row.ToArray());
                    facturas.Text = BackEnd.Util.createTable(iheaders.ToArray(), irows);
                };
                search.Controls.Add(src);
                search.Controls.Add(btn);
            }
            List<string> headers = new List<string>();
            headers.Add("NO");
            headers.Add("FECHA");
            headers.Add("TOTAL");
            headers.Add("ESTADO");            
            headers.Add("EDICION");
            List<string[]> rows = new List<string[]>();
            var facts= db.getFacturas(true).Values.Where(o => o.USUARIO.ID_USUARIO == ldata.USERNAME);
            if (!isClient)
                facts = db.getFacturas().Values;
            foreach (BackEnd.Facturacion item in facts)
            {
                List<string> row = new List<string>();
                row.Add(item.ID_FACTURA.ToString());
                row.Add(item.FECHA.ToShortTimeString());
                row.Add(item.TOTAL.ToString());
                row.Add(item.ACTIVA ? "Activa" : "Procesada");
                if (!isClient)
                    row.Add(item.ACTIVA ? $"<a href=\"GFacturas.aspx?procesar={item.ID_FACTURA}\">Procesar</a> <a href=\"Factura.aspx?id={item.ID_FACTURA}\" target=\"_BLANK\">Comprobar</a>" : $"<a href=\"GFacturas.aspx?activar={item.ID_FACTURA}\">Activar</a>  <a href=\"Factura.aspx?id={item.ID_FACTURA}\" target=\"_BLANK\">Comprobar</a>");
                else
                    row.Add($"<a href=\"Factura.aspx?id={item.ID_FACTURA}\" target=\"_BLANK\">Imprimir</a>");
                rows.Add(row.ToArray());
            }
            facturas.Text = BackEnd.Util.createTable(headers.ToArray(), rows);
        }
    }
}