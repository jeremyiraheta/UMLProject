using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace UMLProject.clases
{
    public class DBManager
    {
        const string conexion = "Data Source=localhost; Initial Catalog=UML;Integrated Security=true;";
        public DBManager()
        {

        }

        public DataSet DoQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        public List<object[]> DoQueryNonDS(string query)
        {
            DataSet ds = DoQuery(query);
            List<object[]> ret = new List<object[]>();
            if (ds.Tables.Count == 0) return ret;
            foreach (object[] r in ds.Tables[0].Rows)
            {
                ret.Add(r);
            }
            return ret;
        }
        public bool Update(string table, string field,object value, string where)
        {
            bool ret = false;
            try
            {
                DoQuery($"update {table} set {field}='{value.ToString()}' where {where}");
                ret = true;
            }
            catch(Exception ex) { Console.Write(ex.Message); }
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
            return isValid(DoQuery($"update Articulos set nombre='{nombre}', contenido='{text} where id_articulo='{id}''"));
        }
        public bool DeleteArticulo(int id)
        {
            return isValid(DoQuery($"delete Articulo where id_articulo={id}"));
        }
        public Dictionary<int,Articulos> getArticulos()
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
                    n.URL = r["URL"].ToString();
                    l.Add(n.ID_ARTICULO,n);
                }
            }
            return l;
        }
        public Articulos getArticulo(int id)
        {
            return getArticulos()[id];
        }
        public bool AgregarMenu(string nombre, Menus parent=null, Articulos articulo=null, string url="")
        {
            return isValid(DoQuery("insert into Menus(id_parent,id_articulo,nombre,url) values ("+
                (parent == null ? "null":parent.ID_MENU.ToString()) + "," + (articulo == null ? "null" : articulo.ID_ARTICULO.ToString()) + $",'{nombre}','{url}')"));
        }
        public bool ModificarMenu(int id, string nombre, Menus parent = null, Articulos articulo=null, string url="")
        {
            if (parent != null) Update("Menus","id_parent",parent.ID_MENU,"id_menu=" + id.ToString());
            if (articulo != null) Update("Menus", "id_articulo", articulo.ID_ARTICULO, "id_menu=" + id.ToString());
            if (url != "") Update("Menus", "url", url, "id_menu=" + id.ToString());
            return isValid(DoQuery($"update Menus set nombre='{nombre}' where id_menu={id}"));
        }
        public bool DeleteMenu(int id)
        {
            return Delete("Menus", "id_menu=" + id.ToString());
        }
        public Dictionary<int,Menus> getMenus()
        {
            DataSet ds = DoQuery("select * from Menus");
            Dictionary<int, Menus> l = new Dictionary<int, Menus>();
            if (isValid(ds))
            {
                foreach (DataRow r in getDataRows(ds))
                {
                    Menus n = new Menus();
                    n.ARTICULO = getArticulo(int.Parse(r["ID_ARTICULO"].ToString()));
                    n.ID_MENU = int.Parse(r["ID_MENU"].ToString());
                    n.NOMBRE = r["NOMBRE"].ToString();
                    n.ORDEN = int.Parse(r["ORDEN"].ToString());
                    n.PARENT = getMenu(int.Parse(r["ID_PARENT"].ToString()));
                    n.URL = r["URL"].ToString();
                }
            }
            return l;
        }
        public Menus getMenu(int id)
        {
            return getMenus()[id];
        }
        public bool AgregarUsuario(string user, string pass, Tipos_Usuarios tipo, string nombre, string apellido, string dui, string nit, string telefono, string correo, string direccion)
        {
            string md5p = MD5Hash(pass);
            return isValid(DoQuery($"insert into Usuarios values ('{user}',{tipo.ID_TIPOUSUARIO},'{md5p}','{nombre}','{apellido}','{dui}','{nit}','{telefono}','{correo}','{direccion}')"));
        }
        public bool EliminarUsuario(string user)
        {
            return isValid(DoQuery($"delete from Usuarios where id_usuario='{user}'"));
        }
        public Usuarios getUsuario(string user)
        {
            return getUsuarios()[user];
        }
        public Dictionary<string,Usuarios> getUsuarios()
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
                    l.Add(u.ID_USUARIO,u);
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
        public bool ValidarUsuario(string user, string pass)
        {
            string md5p = MD5Hash(pass);
            List<object[]> list = DoQueryNonDS($"select * from usuarios where id_usuario='{user}' and password='{md5p}'");
            return list.Count != 0;
        }
        private bool isValid(DataSet ds)
        {
            return ds.Tables.Count != 0;
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
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public int ROL { get; set; }
    }
}