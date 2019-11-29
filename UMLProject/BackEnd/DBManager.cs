using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace UMLProject.BackEnd
{
    public class DBManager
    {
#if DEBUG
        const bool PRODUCCION = false;
#else
        const bool PRODUCCION = true;
#endif
        string conexion = (PRODUCCION) ? "Server=tcp:utecproyecto.database.windows.net,1433;Initial Catalog=UML;Persist Security Info=False;User ID=jeremy.iraheta;Password=R4damantis;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" : "Data Source=localhost; Initial Catalog=UML;Integrated Security=true;";
        
        public DBManager()
        {

        }

        public DataSet DoQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch(Exception ex) {
                Console.WriteLine("ERROR QUERY:" + query + (char)13 + ex.Message);
                ds = null;
            }
            return ds;
        }        
        public bool Update(string table, string field, object value, string where)
        {
            bool ret = false;
            try
            {
                DoQuery($"update {table} set {field}='{value.ToString()}' where {where}");
                ret = true;
            }
            catch (Exception ex) { Console.Write(ex.Message); }
            return ret;
        }
        public bool Update(string table, string field, object value)
        {
            bool ret = false;
            try
            {
                DoQuery($"update {table} set {field}='{value}'");
                ret = true;
            }
            catch (Exception ex) { Console.Write(ex.Message); }
            return ret;
        }
        public bool Delete(string table, string where)
        {
            bool ret = false;
            try
            {
                DoQuery($"delete {table} where {where}");
                ret = true;
            }
            catch (Exception ex) { Console.Write(ex.Message); }
            return ret;
        }
        public bool Delete(string table)
        {
            bool ret = false;
            try
            {
                DoQuery($"delete {table}");
                ret = true;
            }
            catch (Exception ex) { Console.Write(ex.Message); }
            return ret;
        }
        public bool AgregarArticulo(string nombre, string text)
        {
            return isValid(DoQuery($"insert into Articulos(nombre,contenido) values ('{nombre}','{text}')"));
        }
        public bool ModificarArticulo(int id, string nombre, string text)
        {
            return isValid(DoQuery($"update Articulos set nombre='{nombre}', contenido='{text}' where id_articulo={id}"));
        }
        public bool EliminarArticulo(int id)
        {
            return isValid(DoQuery($"delete Articulos where id_articulo={id}"));
        }
        public Dictionary<int, Articulos> getArticulos()
        {
            DataSet ds = DoQuery("select * from Articulos");
            Dictionary<int, Articulos> l = new Dictionary<int, Articulos>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Articulos n = new Articulos();
                    n.CONTENIDO = r["CONTENIDO"].ToString();
                    n.ID_ARTICULO = int.Parse(r["ID_ARTICULO"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                    l.Add(n.ID_ARTICULO, n);
                }
            }
            return l;
        }
        public Articulos getArticulo(int id)
        {
            return getArticulos()[id];
        }
        public bool AgregarMenu(string nombre, int orden, Menus parent = null, Articulos articulo = null, string url = "")
        {
            return isValid(DoQuery("insert into Menus(id_parent,id_articulo,nombre,url, orden) values (" +
                (parent == null ? "null" : parent.ID_MENU.ToString()) + "," + (articulo == null ? "null" : articulo.ID_ARTICULO.ToString()) + $",'{nombre}','{url}',{orden})"));
        }
        public bool ModificarMenu(int id, string nombre, int orden,Menus parent = null, Articulos articulo = null, string url = "")
        {
            if (parent != null) Update("Menus", "id_parent", parent.ID_MENU, "id_menu=" + id.ToString());
            if (articulo != null) Update("Menus", "id_articulo", articulo.ID_ARTICULO, "id_menu=" + id.ToString());
            if (url != "") Update("Menus", "url", url, "id_menu=" + id.ToString());
            return isValid(DoQuery($"update Menus set nombre='{nombre}',orden={orden} where id_menu={id}"));
        }
        public bool DeleteMenu(int id)
        {
            return Delete("Menus", "id_menu=" + id.ToString());
        }
        public Dictionary<int, Menus> getMenus()
        {
            DataSet ds = DoQuery("select * from Menus");
            Dictionary<int, Menus> l = new Dictionary<int, Menus>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Menus n = new Menus();
                    try
                    {
                        n.ARTICULO = getArticulo(int.Parse(r["ID_ARTICULO"].ToString()));
                    }
                    catch { }
                    n.ID_MENU = int.Parse(r["ID_MENU"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                    n.ORDEN = int.Parse(r["ORDEN"].ToString());
                    try
                    {
                        n.PARENT = l[int.Parse(r["ID_PARENT"].ToString())];
                    }
                    catch { };
                    n.URL = r["URL"].ToString();
                    if (n.PARENT != null)
                        n.PARENT.AddChild(n);
                    l.Add(n.ID_MENU, n);
                }
            }
            return l;
        }        
        public Menus getMenu(int id)
        {           
            return getMenus()[id];
        }
        public bool AgregarUsuario(string user, string pass, int tipo, string nombre, string apellido, string dui, string nit, string telefono, string correo, string direccion)
        {
            string md5p = MD5Hash(pass);
            return isValid(DoQuery($"insert into Usuarios values ('{user}',{tipo},'{md5p}','{nombre}','{apellido}','{dui}','{nit}','{telefono}','{correo}','{direccion}')"));
        }
        public bool ModificarUsuario(string user, int tipo, string nombre, string apellido, string dui, string nit, string telefono, string correo, string direccion)
        {
            return isValid(DoQuery($"update Usuarios set ID_TIPOUSUARIO={tipo},nombre='{nombre}',apellido='{apellido}',dui='{dui}',nit='{nit}',telefono='{telefono}',correo='{correo}',direccion='{direccion}' where id_usuario='{user}'"));
        }
        public bool EliminarUsuario(string user)
        {
            return isValid(DoQuery($"delete from Usuarios where id_usuario='{user}'"));
        }
        public Usuarios getUsuario(string user)
        {
            return getUsuarios()[user];
        }
        public Dictionary<string, Usuarios> getUsuarios()
        {
            DataSet ds = DoQuery("select * from Usuarios");
            Dictionary<string, Usuarios> l = new Dictionary<string, Usuarios>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Usuarios u = new Usuarios();
                    u.APELLIDO = r["APELLIDO"].ToString();
                    u.CORREO = r["CORREO"].ToString();
                    u.DIRECCION = r["DIRECCION"].ToString();
                    u.DUI = r["DUI"].ToString();
                    u.ID_USUARIO = r["ID_USUARIO"].ToString();
                    u.NIT = r["NIT"].ToString();
                    u.NOMBRE = r["NOMBRE"].ToString();
                    u.PASSWORD = r["PASSWORD"].ToString();
                    u.TELEFONO = r["TELEFONO"].ToString();
                    u.TIPO = getTipo_Usuario(int.Parse(r["ID_TIPOUSUARIO"].ToString()));
                    l.Add(u.ID_USUARIO, u);
                }
            }
            return l;
        }
        public Tipos_Usuarios getTipo_Usuario(int id)
        {
            List<Tipos_Usuarios> list = getTipos_Usuarios();
            foreach (Tipos_Usuarios t in list)
            {
                if (t.ID_TIPOUSUARIO == id) return t;
            }
            return null;
        }
        public List<Tipos_Usuarios> getTipos_Usuarios()
        {
            DataSet ds = DoQuery("select * from tipos_usuarios");
            List<Tipos_Usuarios> l = new List<Tipos_Usuarios>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Tipos_Usuarios n = new Tipos_Usuarios();
                    n.ID_TIPOUSUARIO = int.Parse(r["ID_TIPOUSUARIO"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                    l.Add(n);
                }
            }
            return l;
        }
        public bool AgregarMenuAUsuario(Menus menu, Tipos_Usuarios tipo)
        {
            return isValid(DoQuery($"insert into Menus_Usuarios values({tipo.ID_TIPOUSUARIO},{menu.ID_MENU})"));
        }
        public bool ActualizarMenuAUsuario(Menus frommenu, Tipos_Usuarios fromtipo, Menus tomenu, Tipos_Usuarios totipo)
        {
            return isValid(DoQuery($"update Menus_Usuarios set id_tipousuario={totipo.ID_TIPOUSUARIO}, id_menu={tomenu.ID_MENU} where id_tipousuario={fromtipo.ID_TIPOUSUARIO} and id_menu={frommenu.ID_MENU}"));
        }
        public bool DeleteMenuAUsuario(Menus menu, Tipos_Usuarios tipo)
        {
            return isValid(DoQuery($"delete from Menus_Usuarios where id_tipousuario={tipo.ID_TIPOUSUARIO} and id_menu={menu.ID_MENU}"));
        }
        public Dictionary<int, List<Menus>> getMenusAUsuario()
        {
            DataSet ds = DoQuery("select * from Menus_Usuarios");
            Dictionary<int, List<Menus>> l = new Dictionary<int, List<Menus>>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Menus m = getMenu(int.Parse(r["ID_MENU"].ToString()));
                    int t = int.Parse(r["ID_TIPOUSUARIO"].ToString());
                    if (l.ContainsKey(t))
                        l[t].Add(m);
                    else
                        l.Add(t, new List<Menus>(new Menus[] { m }));
                }
            }            
            ds = DoQuery("select * from Menus where ID_MENU not in (select distinct ID_MENU from Menus_Usuarios)");
            if(isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Menus m = getMenu(int.Parse(r["ID_MENU"].ToString()));                    
                    if (l.ContainsKey(-1))
                        l[-1].Add(m);
                    else
                        l.Add(-1, new List<Menus>(new Menus[] { m }));
                }
            }
            return l;
        }
        public List<Menus> getMenuAUsuario(int t)
        {

            Dictionary<int, List<Menus>> list = getMenusAUsuario();
            if (list.ContainsKey(t))
                return list[t];
            else
                return new List<Menus>();
        }
        public List<Menus> getMenuATodos()
        {
            Dictionary<int,List<Menus>> list = getMenusAUsuario();
            if (list.Keys.Contains(-1))
                return list[-1];
            else
                return new List<Menus>();
        }
        public bool checkMenuAUsuario(int menu, int tipousuario)
        {
            DataSet ds = DoQuery($"select * from MENUS_USUARIOS where ID_MENU = {menu} and ID_TIPOUSUARIO = {tipousuario}");
            if (isValid(ds))
                return ds.Tables[0].Rows.Count != 0;
            else
                return false;
        }
        
        public bool AgregarPedido(string user, decimal cantidad, decimal total, bool procesado)
        {
            return isValid(DoQuery($"insert into Pedidos(id_usuario,cantidad,total,procesado) values('{user}',{cantidad},{total},{procesado})"));
        }
        public bool ModificarPedido(int id, string user, decimal cantidad, decimal total, bool procesado)
        {
            return isValid(DoQuery($"update Pedidos set id_usuario='{user}', cantidad={cantidad},total={total},procesado={procesado} where id_pedido={id}"));
        }
        public Dictionary<int, Pedidos> getPedidos()
        {
            DataSet ds = DoQuery("select * from Pedidos");
            Dictionary<int, Pedidos> l = new Dictionary<int, Pedidos>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Pedidos n = new Pedidos();
                    n.CANTIDAD = decimal.Parse(r["CANTIDAD"].ToString());
                    n.ID_PEDIDO = int.Parse(r["ID_PEDIDO"].ToString());
                    n.NORDEN = int.Parse(r["NORDEN"].ToString());
                    n.FACTURA = getFactura(int.Parse(r["ID_FACTURA"].ToString()));
                    n.PRODUCTO = getProducto(int.Parse(r["ID_PRODUCTO"].ToString()));
                    n.SUBTOTAL = decimal.Parse(r["SUBTOTAL"].ToString());
                    l.Add(n.ID_PEDIDO, n);
                }
            }
            return l;
        }
        public bool AgregarFacturacion(string user)
        {
            return isValid(DoQuery($"insert into Facturacion(id_usuario,fecha,activa) values('{user}',GETDATE(),1)"));
        }
        public bool ModificarFacturacion(int id, bool activa)
        {
            return isValid(DoQuery($"update facturacion set activa={Convert.ToInt32(activa)}"));
        }
        public Dictionary<int, Facturacion> getFacturas()
        {
            DataSet ds = DoQuery("select * from Facturacion");
            Dictionary<int, Facturacion> l = new Dictionary<int, Facturacion>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Facturacion n = new Facturacion();
                    n.TOTALIVA = decimal.Parse(r["TOTALIVA"].ToString());
                    n.TOTAL = decimal.Parse(r["TOTAL"].ToString());
                    n.ID_FACTURA = int.Parse(r["ID_FACTURA"].ToString());
                    n.ACTIVA = bool.Parse(r["ACTIVA"].ToString());
                    n.USUARIO = getUsuario(r["ID_USUARIO"].ToString());
                    n.FECHA = DateTime.Parse(r["FECHA"].ToString());                    
                    l.Add(n.ID_FACTURA, n);
                }
            }
            return l;
        }
        public Facturacion getFactura(int id)
        {
            return getFacturas()[id];
        }
        public Dictionary<int, Tipo_Producto> getProductos()
        {
            DataSet ds = DoQuery("select * from Tipo_Producto");
            Dictionary<int, Tipo_Producto> l = new Dictionary<int, Tipo_Producto>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Tipo_Producto n = new Tipo_Producto();
                    n.PRECIO = decimal.Parse(r["PRECIO"].ToString());
                    n.UNIDAD = r["UNIDAD"].ToString();
                    n.ID_PRODUCTO = int.Parse(r["ID_PRODUCTO"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                    l.Add(n.ID_PRODUCTO, n);
                }
            }
            return l;
        }
        public Tipo_Producto getProducto(int id)
        {
            return getProductos()[id];
        }
        public bool AgregarCooperativa(string user, string nombre, string zona, string telefono, string tipo)
        {
            return isValid(DoQuery($"insert into Cooperativa(id_usuario,nombre,zona,telefono,tipo) values('{user}','{nombre}','{zona}','{telefono}','{tipo}')"));
        }
        public bool ModificarCooperativa(int id, string user, string nombre, string zona, string telefono, string tipo)
        {
            return isValid(DoQuery($"update Cooperativa set id_usuario='{user}',nombre='{nombre}',zona='{zona}',telefono='{telefono}',tipo='{tipo}' where id_cooperativa={id}"));
        }
        public bool EliminarCooperativa(int id)
        {
            return Delete("Cooperativa", "id_cooperativa=" + id);
        }
        public Dictionary<int, Cooperativa> getCooperativas()
        {
            DataSet ds = DoQuery("select * from Cooperativa");
            Dictionary<int, Cooperativa> l = new Dictionary<int, Cooperativa>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Cooperativa n = new Cooperativa();
                    n.ID_COOPERATIVA = int.Parse(r["ID_COOPERATIVA"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                    n.TELEFONO = r["TELEFONO"].ToString();
                    n.TIPO = r["TIPO"].ToString();
                    n.USUARIO = getUsuario(r["ID_USUARIO"].ToString());
                    n.ZONA = r["ZONA"].ToString();
                    l.Add(n.ID_COOPERATIVA, n);
                }
            }
            return l;
        }
        public Cooperativa getCooperativa(int id)
        {
            return getCooperativas()[id];
        }
        public Cooperativa getCooperativa(string username, string tipo)
        {
            Dictionary<int, Cooperativa> c = getCooperativas();
            foreach (Cooperativa i in c.Values)
            {
                if (i.USUARIO.ID_USUARIO == username && tipo.ToLower() == i.TIPO.ToLower())
                    return i;
            }
            return null;
        }
        public bool AgregarTransporte(int cooperativa, string tipo, string zona, string horarios, decimal limite)
        {
            return isValid(DoQuery($"insert into Transporte(id_cooperativa,tipo,zona,horarios,limite) values({cooperativa},'{tipo}','{zona}','{horarios}','{limite}')"));
        }
        public bool ModificarTransporte(int id, int cooperativa, string tipo, string zona, string horarios, decimal limite)
        {
            return isValid(DoQuery($"update Transporte set id_cooperativa={cooperativa},tipo='{tipo}',zona='{zona}',horarios='{horarios}',limite={limite} where id_transporte={id}"));
        }
        public bool EliminarTransporte(int id)
        {
            return Delete("Transporte", "id_transporte=" + id);
        }
        public Dictionary<int, Transporte> getTransportes()
        {
            DataSet ds = DoQuery("select * from Transporte");
            Dictionary<int, Transporte> l = new Dictionary<int, Transporte>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Transporte n = new Transporte();
                    n.COOPERATIVA = getCooperativa(int.Parse(r["ID_COOPERATIVA"].ToString()));
                    n.HORARIOS = r["HORARIOS"].ToString();
                    n.ID_TRANSPORTE = int.Parse(r["ID_TRANSPORTE"].ToString());
                    n.LIMITE = decimal.Parse(r["LIMITE"].ToString());
                    n.TIPO = getTipoTransporte(int.Parse(r["ID_TIPOTRANSPORTE"].ToString()));
                    n.ZONA = r["ZONA"].ToString();
                    l.Add(n.ID_TRANSPORTE, n);
                }
            }
            return l;
        }
        public Transporte getTransporte(int id)
        {
            return getTransportes()[id];
        }
        public Dictionary<int, Tipo_Transporte> getTipoTransportes()
        {
            DataSet ds = DoQuery("select * from tipo_transporte");
            Dictionary<int, Tipo_Transporte> l = new Dictionary<int, Tipo_Transporte>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Tipo_Transporte n = new Tipo_Transporte();
                    n.ID_TIPOTRANSPORTE = int.Parse(r["ID_TIPOTRANSPORTE"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                }
            }
            return l;
        }
        public Tipo_Transporte getTipoTransporte(int id)
        {
            return getTipoTransportes()[id];
        }        
        public bool AgregarCorta(int cooperativa, string zona, decimal maximo)
        {
            return isValid(DoQuery($"insert into Corta(id_cooperativa,zona,maximo) values({cooperativa},'{zona}',{maximo})"));
        }
        public bool ModificarCorta(int id, int cooperativa, string zona, decimal maximo)
        {
            return isValid(DoQuery($"update Corta set id_cooperativa={cooperativa},zona='{zona}',maximo={maximo}"));
        }
        public bool EliminarCorta(int id)
        {
            return Delete("Corta", "id_corta=" + id);
        }
        public Dictionary<int, Corta> getCortas()
        {
            DataSet ds = DoQuery("select * from Pesaje");
            Dictionary<int, Corta> l = new Dictionary<int, Corta>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Corta n = new Corta();
                    n.COOPERATIVA = getCooperativa(int.Parse(r["ID_COOPERATIVA"].ToString()));
                    n.MAXIMO = decimal.Parse(r["MAXIMO"].ToString());
                    n.ZONA = r["ZONA"].ToString();
                    n.ID_CORTA = int.Parse(r["ID_CORTA"].ToString());
                    l.Add(n.ID_CORTA, n);
                }
            }
            return l;
        }
        public Corta getCorta(int id)
        {
            return getCortas()[id];
        }
        public bool AgregarImagen(string nombre, string url)
        {
            return isValid(DoQuery($"insert into Imagenes(nombre,url) values ('{nombre}','{url}')"));
        }
        public bool ModificarImagen(int id, string nombre, string url)
        {
            return isValid(DoQuery($"update Imagenes set nombre='{nombre}',url='{url}' where id_imagen={id}"));
        }
        public bool EliminarImagen(int id)
        {
            return isValid(DoQuery($"delete from Imagenes where id_imagen=" + id));
        }
        public Dictionary<int, Imagenes> getImagenes()
        {
            DataSet ds = DoQuery("select * from Imagenes order by id_imagen desc");
            Dictionary<int, Imagenes> l = new Dictionary<int, Imagenes>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Imagenes n = new Imagenes();
                    n.ID_IMAGEN = int.Parse(r["ID_IMAGEN"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                    n.URL = r["URL"].ToString();
                    l.Add(n.ID_IMAGEN, n);
                }
            }
            return l;
        }
        public Imagenes getImagen(int id)
        {
            return getImagenes()[id];
        }
        public bool AgregarLog(string userid, TipoLog tipo, Tables table)
        {
            return isValid(DoQuery($"insert into logs(id_usuario,[action],[table],[date]) values('{userid}','{tipo.ToString()}','{table.ToString()}',GETDATE())"));
        }
        public List<Log> getLogs()
        {
            DataSet ds = DoQuery("select * from logs order by [date] desc");
            List<Log> l = new List<Log>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Log n = new Log();
                    n.ID_LOG= int.Parse(r["ID_LOG"].ToString());
                    n.USUARIO = getUsuario(r["ID_USUARIO"].ToString());
                    n.TABLE = (Tables)Enum.Parse(typeof(Tables), r["TABLE"].ToString());
                    n.ACTION = (TipoLog)Enum.Parse(typeof(TipoLog), r["ACTION"].ToString());
                    n.DATE = DateTime.Parse(r["DATE"].ToString());
                    l.Add(n);
                }
            }
            return l;
        }
        public Usuarios ValidarUsuario(string user, string pass)
        {
            string md5p = MD5Hash(pass);
            Usuarios u=null;
            DataSet ds = DoQuery($"select * from usuarios where id_usuario='{user}' and password='{md5p}'");
            if (isValid(ds))
                if (ds.Tables.Count > 0)
                    u = getUsuario(user);
            return u;
        }
        private bool isValid(DataSet ds)
        {
            if (ds == null) return false;
            return !ds.HasErrors;
        }
        private DataRow getFirstDataRow(DataSet ds)
        {
            return ds.Tables[0].Rows[0];
        }
        private DataRow[] getDataRows(DataSet ds)
        {
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                rows.Add(r);
            }
            return rows.ToArray();
        }
        private static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

    }
    class LoginData
    {
        string user, pass;
        Tipos_Usuarios t;     
        public LoginData(Usuarios u)
        {
            user = u.ID_USUARIO;
            pass = u.PASSWORD;
            t = u.TIPO;
        }
        public string USERNAME
        {
            get
            {
                return user;
            }
        }       
        public Tipos_Usuarios ROL
        {
            get
            {
                return t;
            }
        }
        public bool isAdmin
        {
            get
            {
                return t.NOMBRE.ToLower() == "admin";
            }
        }
    }
}