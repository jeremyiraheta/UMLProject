using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMLProject.clases
{
    sealed class DBModel
    {
        
    }
    public class Articulos
    {
        public int ID_ARTICULO { get; set; }
        public string NOMBRE { get; set; }
        public string CONTENIDO { get; set; }
        public string URL { get; set; }
    }
    public class Menus
    {
        public int ID_MENU { get; set; }
        public Menus PARENT { get; set; }
        public Articulos ARTICULO { get; set; }
        public string NOMBRE { get; set; }
        public string URL { get; set; }
        public int ORDEN { get; set; }
    }
    public class Tipos_Usuarios
    {
        public int ID_TIPOUSUARIO { get; set; }
        public string NOMBRE { get; set; }
    }
    public class Menus_Usuarios
    {
        public Menus_Usuarios()
        {
            MENUS = new List<Menus>();
        }
        public Tipos_Usuarios TIPO { get; set; }
        public List<Menus> MENUS { get; }
    }
    public class Usuarios
    {
        public string ID_USUARIO { get; set; }
        public Tipos_Usuarios TIPO { get; set; }
        public string PASSWORD { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }
    }
    public class Pedidos
    {
        public int ID_PEDIDO { get; set; }
        public Usuarios USUARIO { get; set; }
        public decimal CANTIDAD { get; set; }
        public decimal TOTAL { get; set; }
        public bool PROCESADO { get; set; }
    }
    public class Cooperativa
    {
        public int ID_COOPERATIVA { get; set; }
        public Usuarios USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string ZONA { get; set; }
        public string TELEFONO { get; set; }
        public string TIPO { get; set; }
    }
    public class Transporte
    {
        public int ID_TRANSPORTE { get; set; }
        public Cooperativa COOPERATIVA { get; set; }
        public string TIPO { get; set; }
        public string ZONA { get; set; }
        public string HORARIOS { get; set; }
        public decimal LIMITE { get; set; }
    }
    public class Pesaje
    {
        public int ID_PESAJE { get; set; }
        public Cooperativa COOPERATIVA { get; set; }
        public string ZONA { get; set; }
        public string HORARIOS { get; set; }
        public decimal LIMITE { get; set; }
    }
    public class Corta
    {
        public int ID_CORTA { get; set; }
        public Cooperativa COOPERATIVA { get; set; }
        public string ZONA { get; set; }
        public decimal MAXIMO { get; set; }
    }
}