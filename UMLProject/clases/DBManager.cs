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
                DoQuery($"update {table} set {field}='{value}' where {where}");
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
        public void AgregarUsuario(string user, string pass)
        {
            string md5p = MD5Hash(pass);
        }
        public bool ValidarUsuario(string user, string pass)
        {
            string md5p = MD5Hash(pass);
            List<object[]> list = DoQueryNonDS($"select * from usuarios where id_usuario='{user}' and password='{md5p}'");
            return list.Count != 0;
        }
        public static string MD5Hash(string text)
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
    class LoginDate
    {
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public int ROL { get; set; }
    }
}