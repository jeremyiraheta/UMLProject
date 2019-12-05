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
            bool permit = BackEnd.Util.checkRolByName(ldata.ROL, "cliente") || ldata.isAdmin;
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
            try
            {
                factura = db.getFactura(id);
            }catch
            {
                Response.Redirect("Default.aspx");
                return;
            }
            if(!ldata.isAdmin && factura.USUARIO.ID_USUARIO != ldata.USERNAME)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            string html = "";
            html += "Tiquet No " + factura.ID_FACTURA;
            html += "Fecha: " + factura.FECHA;
            html += "Cliente: " + factura.USUARIO.NOMBRE + " " + factura.USUARIO.APELLIDO;
            html += "DUI: " + factura.USUARIO.DUI;
            html += "<b>Detalle</b>";
            html += "<table><tr><th>No</th><th>Producto</th><th>Precio</th><th>Cantidad</th><th>Subtotal</th></tr>";
            foreach (BackEnd.Pedidos p in factura.PEDIDOS.Values)
            {
                html += $"<tr><td>{p.NORDEN}</td><td>{p.PRODUCTO.NOMBRE}</td><td>{p.PRODUCTO.PRECIO}</td><td>{p.CANTIDAD}</td><td>{p.SUBTOTAL}</td></tr>";
            }
            html += "</table>";
            html += "Total IVA: " + factura.TOTALIVA;
            html += "Total: " + factura.TOTAL;
            output.Text = html;
        }
    }
}