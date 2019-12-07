using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Factura : System.Web.UI.Page
    {
        BackEnd.LoginData ldata;
        BackEnd.DBManager db = new BackEnd.DBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (BackEnd.LoginData)Session["user"];
            int id=-1;
            if (ldata == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            bool permit = BackEnd.Util.checkRolByName(ldata.ROL, "cliente") || ldata.isAdmin || BackEnd.Util.checkRolByName(ldata.ROL, "empleado");
            if (!permit)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            int.TryParse(Request["id"], out id);
            if(id == -1)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            BackEnd.Facturacion factura;
            List<BackEnd.Pedidos> pedidos;
            try
            {
                factura = db.getFactura(id);
                pedidos = db.getPedidosFactura(factura.ID_FACTURA);
            }catch
            {
                Response.Redirect("Default.aspx");
                return;
            }
            if(!(ldata.isAdmin || BackEnd.Util.checkRolByName(ldata.ROL,"empleado")) && factura.USUARIO.ID_USUARIO != ldata.USERNAME)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            string html = "";
            html += "<table>";
            html += "<tr><td>Tiquet No </td><td>" + factura.ID_FACTURA + "</td></tr>";
            html += "<tr><td>Fecha: </td><td>" + factura.FECHA + "</td></tr>";
            html += "<tr><td>Cliente: </td><td>" + factura.USUARIO.NOMBRE + " " + factura.USUARIO.APELLIDO + "</td></tr>";
            html += "<tr><td>DUI: </td><td>" + factura.USUARIO.DUI + "</td></tr></table>";
            html += "<b>Detalle</b>";
            html += "<table><tr><th>No</th><th>Producto</th><th>Precio</th><th>Cantidad</th><th>Subtotal</th></tr>";
            foreach (BackEnd.Pedidos p in pedidos)
            {
                html += $"<tr><td>{p.NORDEN}</td><td>{p.PRODUCTO.NOMBRE}</td><td>{p.PRODUCTO.PRECIO}</td><td>{p.CANTIDAD}</td><td>{p.SUBTOTAL}</td></tr>";
            }
            html += "</table>";
            html += "<table style=\"border-style:double;border-width:2px;margin-left: 190px;\"><tr><td>Total IVA: </td><td>" + factura.TOTALIVA + "</td></tr>";
            html += "<tr><td>Total: </td><td>" + factura.TOTAL + "</td></tr></table>";
            output.Text = html;
        }
    }
}