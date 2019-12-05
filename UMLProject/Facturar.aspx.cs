using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMLProject
{
    public partial class Facturar : System.Web.UI.Page
    {
        BackEnd.LoginData ldata;
        BackEnd.DBManager db = new BackEnd.DBManager();
        Dictionary<int, BackEnd.Pedidos> fact;
        protected void Page_Load(object sender, EventArgs e)
        {
            ldata = (BackEnd.LoginData)Session["user"];
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
            Dictionary<int, BackEnd.Tipo_Producto> ps = db.getProductos();
            foreach (BackEnd.Tipo_Producto i in ps.Values)
            {
                ddProductos.Items.Add(new ListItem(i.NOMBRE + "(" + i.UNIDAD + ")" + "($" + i.PRECIO + ")", i.ID_PRODUCTO.ToString()));
            }
            if (!IsPostBack)
                fact = new Dictionary<int, BackEnd.Pedidos>();
            else if(Request["remove"] != null)
            {
                int id;
                try
                {
                    id = int.Parse(Request["remove"].ToString());
                    fact.Remove(id);
                }
                catch
                {
                    output.Text = "ID no valida";
                    return;
                }
            }
            string html = "";            
            foreach (BackEnd.Pedidos p in fact.Values)
            {                
                html += $"<tr>{p.NORDEN}<td></td>{p.PRODUCTO.NOMBRE}<td>{p.PRODUCTO.PRECIO}</td><td>{p.CANTIDAD}</td><td>{p.SUBTOTAL}</td><td><a href='Facturar.aspx?remove={p.PRODUCTO.ID_PRODUCTO}'></a></td></tr>";
            }
            tbody.InnerHtml = html;
        }        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BackEnd.Tipo_Producto p = db.getProducto(int.Parse(ddProductos.SelectedValue));
            if (p != null)
            {
                BackEnd.Pedidos pe = new BackEnd.Pedidos();
                pe.PRODUCTO = p;
                pe.NORDEN++;
                pe.CANTIDAD = decimal.Parse(txtCantidad.Text);
                pe.SUBTOTAL = Math.Round(pe.CANTIDAD * p.PRECIO,2);
                fact.Add(p.ID_PRODUCTO, pe);
            }
        }

        protected void lOKs_Click(object sender, EventArgs e)
        {
            if(fact.Count == 0)
            {
                output.Text = BackEnd.Util.MensajeFracaso("Nada que facturar");
                return;
            }
            BackEnd.Facturacion factura =  db.AgregarFacturacion(ldata.USERNAME);
            foreach (BackEnd.Pedidos p in fact.Values)
            {
                db.AgregarPedido(p.NORDEN,p.PRODUCTO.ID_PRODUCTO,factura.ID_FACTURA, p.CANTIDAD, p.SUBTOTAL);
            }

        }
    }
}