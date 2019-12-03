using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMLProject.BackEnd
{
    sealed class DBModel
    {
        
    }
    public class Articulos
    {
        public int ID_ARTICULO { get; set; }
        public string NOMBRE { get; set; }
        public string CONTENIDO { get; set; }        
    }
    public class Menus
    {
        public Menus()
        {
            CHILDREN = new List<Menus>();
        }
        public void AddChild(Menus m)
        {
            CHILDREN.Add(m);
        }
        public bool isMain
        {
            get
            {
                return PARENT == null;
            }
        }        
        public int ID_MENU { get; set; }
        public Menus PARENT { get; set; }
        public Articulos ARTICULO { get; set; }
        public string NOMBRE { get; set; }
        public string URL { get; set; }
        public int ORDEN { get; set; }
        public List<Menus> CHILDREN { get; }
    }
    public class Tipos_Usuarios
    {
        public int ID_TIPOUSUARIO { get; set; }
        public string NOMBRE { get; set; }
    }
    public class Menus_Usuarios
    {        
        public Tipos_Usuarios TIPO { get; set; }
        public Menus MENUS { get; set; }
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
        public int NORDEN { get; set; }
        public Tipo_Producto PRODUCTO { get; set; }
        public Facturacion FACTURA { get; set; }        
        public decimal CANTIDAD { get; set; }
        public decimal SUBTOTAL { get; set; }        
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
        public Tipo_Transporte TIPO { get; set; }
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
    public class Imagenes
    {
        public int ID_IMAGEN { get; set; }
        public string NOMBRE { get; set; }
        public string URL { get; set; }
    }
    public class Tipo_Transporte
    {
        public int ID_TIPOTRANSPORTE { get; set; }
        public string NOMBRE { get; set; }
    }
    public class Facturacion
    {
        public int ID_FACTURA { get; set; }
        public Usuarios USUARIO { get; set; }
        public DateTime FECHA { get; set; }
        public decimal TOTALIVA { get; set; }
        public decimal TOTAL { get; set; }
        public bool ACTIVA { get; set; }
    }
    public class Tipo_Producto
    {
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public string UNIDAD { get; set; }
        public decimal PRECIO { get; set; }
    }
    public class Log
    {
        public int ID_LOG { get; set; }
        public Usuarios USUARIO { get; set; }
        public TipoLog ACTION { get; set; }
        public Tables TABLE { get; set; }
        public DateTime DATE { get; set; }
    }
    public enum TipoLog
    {
        CREAR,
        ACTUALIZAR,
        ELIMINAR
    }
    public enum Tables
    {
        ARTICULOS,
        COOPERATIVA,
        CORTA,
        IMAGENES,
        MENUS,
        MENUS_USUARIOS,
        PEDIDOS,
        TIPO_TRANSPORTE,
        TIPOS_USUARIOS,
        TRANSPORTE,
        USUARIOS,
        FACTURACION,
        TIPO_PRODUCTO
    }
    public enum TipoCooperativa
    {
        CORTA,
        TRANSPORTE
    }
}