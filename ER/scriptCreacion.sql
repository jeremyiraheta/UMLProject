/*==============================================================*/
/* Table: ARTICULOS                                             */
/*==============================================================*/
create table ARTICULOS (
   ID_ARTICULO          int                  identity,
   NOMBRE               varchar(200)         not null,
   CONTENIDO            text                 null,
   constraint PK_ARTICULOS primary key (ID_ARTICULO)
)
go

/*==============================================================*/
/* Table: TIPOS_USUARIOS                                        */
/*==============================================================*/
create table TIPOS_USUARIOS (
   ID_TIPOUSUARIO       int                  identity,
   NOMBRE               varchar(100)         not null,
   constraint PK_TIPOS_USUARIOS primary key (ID_TIPOUSUARIO)
)
go

/*==============================================================*/
/* Table: USUARIOS                                              */
/*==============================================================*/
create table USUARIOS (
   ID_USUARIO           varchar(50)          not null,
   ID_TIPOUSUARIO       int                  null,
   PASSWORD             varchar(32)          not null,
   NOMBRE               varchar(200)         not null,
   APELLIDO             varchar(200)         not null,
   DUI                  varchar(10)          not null,
   NIT                  varchar(50)          null,
   TELEFONO             varchar(10)          null,
   CORREO               varchar(200)         not null,
   DIRECCION            varchar(200)         null,
   constraint PK_USUARIOS primary key (ID_USUARIO),
   constraint FK_USUARIOS_REFERENCE_TIPOS_US foreign key (ID_TIPOUSUARIO)
      references TIPOS_USUARIOS (ID_TIPOUSUARIO)
)
go

/*==============================================================*/
/* Table: COOPERATIVA                                           */
/*==============================================================*/
create table COOPERATIVA (
   ID_COOPERATIVA       int                  identity,
   ID_USUARIO           varchar(50)          null,
   NOMBRE               varchar(200)         not null,
   ZONA                 varchar(200)         not null,
   TELEFONO             varchar(10)          not null,
   TIPO                 varchar(20)          not null,
   constraint PK_COOPERATIVA primary key (ID_COOPERATIVA),
   constraint FK_COOPERAT_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: CORTA                                                 */
/*==============================================================*/
create table CORTA (
   ID_CORTA             int                  identity,
   ID_COOPERATIVA       int                  null,
   ZONA                 varchar(200)         not null,
   MAXIMO               decimal(5,2)         not null,
   constraint PK_CORTA primary key (ID_CORTA),
   constraint FK_CORTA_REFERENCE_COOPERAT foreign key (ID_COOPERATIVA)
      references COOPERATIVA (ID_COOPERATIVA)
)
go

/*==============================================================*/
/* Table: FACTURACION                                           */
/*==============================================================*/
create table FACTURACION (
   ID_FACTURA           int                  identity,
   ID_USUARIO           varchar(50)          null,
   FECHA                datetime             not null,
   TOTALIVA             decimal(5,2)         null,
   TOTAL                decimal(5,2)         null,
   ACTIVA               bit                  not null,
   constraint PK_FACTURACION primary key (ID_FACTURA),
   constraint FK_FACTURAC_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: IMAGENES                                              */
/*==============================================================*/
create table IMAGENES (
   ID_IMAGEN            int                  identity,
   NOMBRE               varchar(50)          not null,
   URL                  varchar(200)         not null,
   constraint PK_IMAGENES primary key (ID_IMAGEN)
)
go

/*==============================================================*/
/* Table: LOGS                                                  */
/*==============================================================*/
create table LOGS (
   ID_LOG               int                  identity,
   ID_USUARIO           varchar(50)          null,
   ACTION               varchar(10)          not null,
   "TABLE"              varchar(10)          not null,
   DATE                 datetime             not null,
   constraint PK_LOGS primary key (ID_LOG),
   constraint FK_LOGS_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: MENUS                                                 */
/*==============================================================*/
create table MENUS (
   ID_MENU              int                  identity,
   ID_PARENT            int                  null,
   ID_ARTICULO          int                  null,
   NOMBRE               varchar(100)         not null,
   URL                  varchar(200)         null,
   ORDEN                int                  not null,
   constraint PK_MENUS primary key (ID_MENU),
   constraint FK_MENUS_REFERENCE_MENUS foreign key (ID_PARENT)
      references MENUS (ID_MENU),
   constraint FK_MENUS_REFERENCE_ARTICULO foreign key (ID_ARTICULO)
      references ARTICULOS (ID_ARTICULO)
)
go

/*==============================================================*/
/* Table: MENUS_USUARIOS                                        */
/*==============================================================*/
create table MENUS_USUARIOS (
   ID_TIPOUSUARIO       int                  not null,
   ID_MENU              int                  not null,
   constraint PK_MENUS_USUARIOS primary key (ID_TIPOUSUARIO, ID_MENU),
   constraint FK_MENUS_US_REFERENCE_TIPOS_US foreign key (ID_TIPOUSUARIO)
      references TIPOS_USUARIOS (ID_TIPOUSUARIO),
   constraint FK_MENUS_US_REFERENCE_MENUS foreign key (ID_MENU)
      references MENUS (ID_MENU)
)
go

/*==============================================================*/
/* Table: TIPO_PRODUCTO                                         */
/*==============================================================*/
create table TIPO_PRODUCTO (
   ID_PRODUCTO          int                  identity,
   NOMBRE               varchar(200)         not null,
   UNIDAD               varchar(200)         null,
   PRECIO               decimal(5,2)         not null,
   constraint PK_TIPO_PRODUCTO primary key (ID_PRODUCTO)
)
go

/*==============================================================*/
/* Table: PEDIDOS                                               */
/*==============================================================*/
create table PEDIDOS (
   ID_PEDIDO            int                  identity,
   NORDEN               int                  not null,
   ID_PRODUCTO          int                  null,
   ID_FACTURA           int                  null,
   CANTIDAD             decimal(5,2)         not null,
   SUBTOTAL             decimal(5,2)         not null,
   constraint PK_PEDIDOS primary key (ID_PEDIDO, NORDEN),
   constraint FK_PEDIDOS_REFERENCE_TIPO_PRO foreign key (ID_PRODUCTO)
      references TIPO_PRODUCTO (ID_PRODUCTO),
   constraint FK_PEDIDOS_REFERENCE_FACTURAC foreign key (ID_FACTURA)
      references FACTURACION (ID_FACTURA)
)
go

/*==============================================================*/
/* Table: RECUPERACION                                          */
/*==============================================================*/
create table RECUPERACION (
   ID_USUARIO           varchar(50)          not null,
   IDPREGUNTA           int                  not null,
   RESPUESTA            varchar(200)         not null,
   constraint PK_RECUPERACION primary key (ID_USUARIO),
   constraint FK_RECUPERA_REFERENCE_USUARIOS foreign key (ID_USUARIO)
      references USUARIOS (ID_USUARIO)
)
go

/*==============================================================*/
/* Table: TIPO_TRANSPORTE                                       */
/*==============================================================*/
create table TIPO_TRANSPORTE (
   ID_TIPOTRANSPORTE    int                  identity,
   NOMBRE               varchar(50)          not null,
   constraint PK_TIPO_TRANSPORTE primary key (ID_TIPOTRANSPORTE)
)
go

/*==============================================================*/
/* Table: TRANSPORTE                                            */
/*==============================================================*/
create table TRANSPORTE (
   ID_TRANSPORTE        int                  identity,
   ID_COOPERATIVA       int                  null,
   ID_TIPOTRANSPORTE    int                  null,
   ZONA                 varchar(200)         not null,
   HORARIOS             varchar(200)         not null,
   LIMITE               decimal(5,2)         not null,
   constraint PK_TRANSPORTE primary key (ID_TRANSPORTE),
   constraint FK_TRANSPOR_REFERENCE_COOPERAT foreign key (ID_COOPERATIVA)
      references COOPERATIVA (ID_COOPERATIVA),
   constraint FK_TRANSPOR_REFERENCE_TIPO_TRA foreign key (ID_TIPOTRANSPORTE)
      references TIPO_TRANSPORTE (ID_TIPOTRANSPORTE)
)
go

create trigger tPedidos
on PEDIDOS
after UPDATE, INSERT, DELETE
as
begin
	declare @id int
	declare @avg float
	if Exists(select * from inserted)
		select @id=ID_FACTURA from inserted
	if Exists(select * from deleted)
		select @id=ID_FACTURA from deleted
	select @avg=SUM(SUBTOTAL) from PEDIDOS where ID_PEDIDO = @id
	update FACTURACION set TOTALIVA = @avg * 0.13  where ID_FACTURA = @id
	update FACTURACION set TOTAL = TOTALIVA + @avg where ID_FACTURA = @id
end

alter table usuarios add unique (dui)
alter table usuarios add unique (nit)
alter table usuarios add unique (correo)

insert into TIPOS_USUARIOS(NOMBRE) values('Admin'),('Empleado'),('Cliente'),('Cooperativa')
insert into TIPO_TRANSPORTE(NOMBRE) values('Remolque vagones'),('Camion'),('Trailer'),('Rabones'),('Rastra')
insert into TIPO_PRODUCTO(NOMBRE,UNIDAD,PRECIO) values('Bolsa Azucar Estandar','Bolsa','5.5'),('Saco Azucar Estandar','Saco','100')
insert into usuarios values('admin',1,'21232f297a57a5a743894a0e4a801fc3','admin','admin','','','','admin@hotmail.com','')