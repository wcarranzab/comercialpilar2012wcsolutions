create database BDComercialPilar
on primary
(
	name=BDCOMERCIALPILAR, 
	filename='C:\BDComercialPilar.mdf',
	size=5mb,
	maxsize=600mb,
	filegrowth=5%
),
(
	name=BDCOMERCIALPILARSec,
	filename='C:\BBDComercialPilarSec.ndf',
	size=3mb,
	maxsize= unlimited
)
Log on(
	name=BDCOMERCIALPILARLog,
	filename='C:\BDComercialPilarLog.ldf',
	size=3mb,
	maxsize=200mb,
    filegrowth=10mb
)
go


USE BDComercialPilar
go

set dateformat ymd
go

CREATE TABLE tb_paises (
  Idpais char(3) primary key,
  NombrePais varchar(40) not null
  )
go

INSERT tb_paises VALUES('001','Perú')
INSERT tb_paises VALUES('002','Estados Unidos')
INSERT tb_paises VALUES('003','España')
INSERT tb_paises VALUES('004','Argentina')
INSERT tb_paises VALUES('005','Colombia')
go

Select * from tb_paises
go

create table tb_departamento(
Idpais char(3) not null references tb_paises,
codDpto char(4) not null,
nomDpto varchar(30)
)
go

alter table tb_departamento add primary key(Idpais,codDpto)
go

INSERT tb_departamento VALUES('001','P001','Lima')
go
INSERT tb_departamento VALUES('001','P002','Arequipa')
go
INSERT tb_departamento VALUES('001','P003','Cuzco')
go
INSERT tb_departamento VALUES('001','P004','Piura')
go
INSERT tb_departamento VALUES('001','P005','La Libertad')
go

Select * from tb_departamento
go

create table tb_provincia(
Idpais char(3) not null,
codDpto char(4) not null,
codProv char(4) not null,
nomProv varchar(30)
)
go



alter table tb_provincia add primary key(Idpais,codDpto,codProv)
go
alter table tb_provincia add foreign key(Idpais,codDpto) references tb_departamento
go

INSERT tb_provincia VALUES('001','P001','PR01','Lima')
go
INSERT tb_provincia VALUES('001','P001','PR02','Chosica')
go

Select * from tb_provincia order by nomProv asc
go

create table tb_distrito(
Idpais char(3) not null,
codDpto char(4) not null,
codProv char(4) not null,
codDis char(4) not null,
nomDis varchar(30)
)
go

alter table tb_distrito add primary key(Idpais,codDpto,codProv,codDis)
go
alter table tb_distrito add foreign key(Idpais,codDpto,codProv) references tb_provincia
go

INSERT tb_distrito VALUES('001','P001','PR01','PD01','Magdalena del Mar')
go
INSERT tb_distrito VALUES('001','P001','PR01','PD02','Jesús María')
go
INSERT tb_distrito VALUES('001','P001','PR01','PD03','San Miguel')
go
INSERT tb_distrito VALUES('001','P001','PR01','PD04','Lurín')
go
INSERT tb_distrito VALUES('001','P001','PR01','PD05','Pueblo Libre')
go

Select * from tb_distrito
go

create table tb_usuario(
	codUsu char(10) primary key,
	NomUsu varchar(20) not null,
	apePat varchar(20) not null,
	apeMat varchar(20) not null,
	FechaNac date,
	Domicilio varchar(150),
	telefono char(11),
	DNI char(9) not null,
	tipoUsu varchar(15) not null,
	Idpais char(3) not null,
	codDpto char(4) not null,
	codProv char(4) not null,
	codDis char(4) not null,
	clave varchar(100)
	)
go

alter table tb_usuario add foreign key(Idpais,codDpto,codProv,codDis) references tb_distrito
go

INSERT tb_usuario VALUES('ygomez','Yoana','Gómez','Cantuarias','1988-06-28','Jr. José Gálvez 419 2do Piso','997942040','45107551','Administrador','001','P001','PR01','PD01','yoanita')
go

create table tb_Area(
codArea char(6) not null primary key,
Descrip varchar(30) not null 
)
go

INSERT tb_Area VALUES('A01','Ventas')
go

INSERT tb_Area VALUES('A02','Almacén')
go

INSERT tb_Area VALUES('A03','Logística')
go

Select * from tb_Area
go

create table tb_Admin(
codUsu_Admin char(10) not null primary key references tb_usuario,
codArea char(6) references tb_Area
)
go

INSERT tb_Admin VALUES('ygomez','A02')
GO

Select * from tb_Admin
go

create table tb_Kardex(
NroKardex char(10) not null primary key,
fechaEmision datetime,
codUsu_Admin char(10) not null references tb_Admin,
Descrip text,
)
go

alter table tb_Kardex add unique (NroKardex)
go

create table tb_Empleado(
codUsu_Emp char (10)not null primary key references tb_usuario,
sueldo money not null,
turno varchar(10),
tipoEmp varchar(10),
codUsu_Admin char(10) references tb_Admin,
codArea char(6) references tb_Area
)
go

create table tb_Cliente(
codUsu_Cli char(10)not null primary key references tb_usuario,
RUC char(12)
)
go

Select * from tb_Cliente
go

create table TipoTarjeta(
codTipoTarj char(10) primary key,
DescripTarj varchar(20)
)
go

create table tb_Tarjeta(
NroTarj char(16) not null primary key,
Descrip varchar(20) not null,
codTipoTarj char(10) references TipoTarjeta,
codUsu_Cli char(10)not null references tb_Cliente
)
go

create table tb_Vendedor(
codUsu_Emp_Vend char (10)not null primary key references tb_Empleado,
comision money not null
)
go

create table tb_EncargadoAlmacen(
codUsu_Emp_Alm char (10)not null primary key references tb_Empleado,
tarifa money not null
)
go

create table tb_Chofer(
codUsu_Emp_Chof char (10)not null primary key references tb_Empleado,
gastosAdmin money,
movilidad varchar(10),
)
go

CREATE TABLE tb_categorias (
  IdCategoria int primary key ,
  NombreCategoria varchar(15) not null,
  Descripcion text
)
go

create table tb_Producto(
codProd int not null primary key,
descrip varchar(30) not null,
precio money,
stock int,
codUsu_Emp_Alm char (10)not null references tb_EncargadoAlmacen,
codCategoria int not null references tb_categorias
)
go

create table tb_HojaPedido(
NroPedido int not null primary key,
codUsu_Cli char(10)not null references tb_Cliente,
codUsu_Emp_Vend char(10) not null references tb_Vendedor,
tipoComprobante varchar(10) not null,
fechaPedido datetime,
fechaEntrega datetime,
formaPago varchar(10),
tipoTarjeta varchar(10),
estadoPedido varchar(10),
Idpais char(3) not null,
codDpto char(4) not null,
codProv char(4) not null,
codDis char(4) not null
)
go

alter table tb_HojaPedido add foreign key(Idpais,codDpto,codProv,codDis) references tb_distrito
go

create table tb_DetallePedProd(
NroPedido int not null references tb_HojaPedido,
codProd int not null references tb_Producto,
NroKardex char(10) not null references tb_Kardex,
importe money,
cantidad int,
descuento money,
precioUnidad money not null,
importeTotal money not null
)
go

alter table tb_DetallePedProd add primary key(NroPedido,codProd)
go

create table tb_Comprobante(
NroComprobante char(8) not null primary key,
fechaEmision datetime not null,
CodUsu_Cli char(10) not null references tb_Cliente,
NroPedido int not null references tb_HojaPedido,
tipo varchar(7) not null,
estado varchar(10) not null,
Idpais char(3) not null,
codDpto char(4) not null,
codProv char(4) not null,
codDis char(4) not null
)
go

alter table tb_Comprobante add foreign key(Idpais,codDpto,codProv,codDis) references tb_distrito
go


--alter table tb_Comprobante add foreign key(CodUsu_Cli,NroPedido) references tb_DetallePedProd
--go

create table tb_Boleta(
NroBoleta char(8) not null primary key references tb_Comprobante
)
go

create table tb_Factura(
NroBoleta char(8) not null primary key references tb_Comprobante,
igv money
)
go

create table tb_Proveedor(
  codProveedor char(5) not null primary key,
  NombreCia varchar(40) not null,
  NombreContacto varchar(30) not null,
  CargoContacto varchar(30) not null,
  Direccion varchar(60) not null,
  Telefono varchar(24) not null,
  Idpais char(3) not null,
  codDpto char(4) not null,
  codProv char(4) not null,
  codDis char(4) not null
)
go

alter table tb_Proveedor add foreign key(Idpais,codDpto,codProv,codDis) references tb_distrito
go

create table tb_OrdenSalida(
NroOrdSalida char(8) not null primary key,
fechaEmision datetime not null,
codUsu_Admin char(10) not null references tb_Admin,
codUsu_Emp_Chof char(10) not null references tb_Chofer,
codUsu_Emp_Vend char(10) not null references tb_Vendedor,
estado varchar(10) not null,
direccion varchar(10) not null,
Idpais char(3) not null,
codDpto char(4) not null,
codProv char(4) not null,
codDis char(4) not null
)
go

alter table tb_OrdenSalida add foreign key(Idpais,codDpto,codProv,codDis) references tb_distrito
go

create table tb_OrdenCompra(
NroOrdCompra char(8) not null primary key,
fechaComprobante datetime not null,
NroComprobante char(8) not null references tb_comprobante,
fechaOrden datetime not null,
codUsu_Admin char(10) not null references tb_Admin,
codProveedor char(5) not null references tb_Proveedor
)
go


create table tb_GuiaRemision(
NroGuia char(8) not null primary key,
fechaEmision datetime not null,
codUsu_Emp_Alm char(10) not null references tb_EncargadoAlmacen,
NroOrdCompra char(8) not null references tb_OrdenCompra,
NroKardex char(10) not null references tb_Kardex,
direccion varchar(50) not null,
Idpais char(3) not null,
codDpto char(4) not null,
codProv char(4) not null,
codDis char(4) not null
)
go

alter table tb_GuiaRemision add foreign key(Idpais,codDpto,codProv,codDis) references tb_distrito
go


---------PROCEDURES-------------
----MANTENIMIENTO DE USUARIOS
--procedure que inserte
create procedure usp_add_usuario
@cod char(10),@nom varchar(20),
@apePat varchar(20),@apeMat varchar(20),
@fechaNac date,@domi varchar(150),
@fono char(11),@dni char(9),
@tipoUsu varchar(15),@pais char(3),
@depa char(4),@provi char(4),
@dist char(4),@clave varchar(100)
As Insert tb_usuario Values(@cod,@nom,@apePat,@apeMat,@fechaNac,@domi,@fono,@dni,@tipoUsu,@pais,@depa,@provi,@dist,@clave)
go

--procedure que actualice por idUsuario
create procedure usp_update_usuario
@cod char(10),@nom varchar(20),
@apePat varchar(20),@apeMat varchar(20),
@fechaNac date,@domi varchar(150),
@fono char(11),@dni char(9),
@tipoUsu varchar(15),@pais char(3),
@depa char(4),@provi char(4),
@dist char(4),@clave varchar(100)
As
Update tb_usuario set NomUsu=@nom,apePat=@apePat,apeMat=@apeMat,FechaNac=@fechaNac,Domicilio=@domi,telefono=@fono,DNI=@dni,tipoUsu=@tipoUsu,Idpais=@pais,codDpto=@depa,codProv=@provi,codDis=@dist,clave=@clave Where codUsu = @cod
go

--procedure que elimina por idUsuario
create procedure usp_delete_usuario
@cod char(10)
As
Delete tb_usuario Where codUsu = @cod
go

----MANTENIMIENTO DE CLIENTES
--procedure que inserte
create procedure usp_add_cliente
@cod char(10),
@ruc char(12)
As
Insert tb_Cliente Values(@cod,@ruc)
go

--procedure que actualice por idCliente
create procedure usp_update_cliente
@cod char(10),
@ruc char(12)
As
Update tb_Cliente set RUC=@ruc Where codUsu_Cli=@cod
go

--procedure que elimina por idCliente
create procedure usp_delete_cliente
@cod char(10)
As
Delete tb_Cliente Where codUsu_Cli=@cod
go

-----Validacion de Usuario
CREATE PROCEDURE usp_buscaUsuario
@cod char(10)
As
Select count(*) from tb_usuario Where codUsu=@cod
go

CREATE PROCEDURE usp_validaUsuario
@cod char(10),
@clave varchar(100)
As
Select count(*) from tb_usuario Where codUsu=@cod and clave=@clave
go

CREATE PROCEDURE usp_validaIngreso
@cod char(10)
As
Select count(*) from tb_Cliente Where codUsu_Cli=@cod
go

Create PROCEDURE usp_validaUsuFecha
@cod char(10),
@fecha date
As
Select count(*) from tb_usuario Where codUsu=@cod and FechaNac=@fecha
go

Create Procedure usp_actualizaClave
@cod char(10),
@clave Varchar(100)
As
Update tb_usuario set clave=@clave Where codUsu = @cod
go

--------------------------------------------------------------
create procedure listaPais
as 
select * from  tb_paises
go

create procedure listaOrdenes
as 
select * from  tb_OrdenCompra
go

create procedure listaProveedor
as 
select * from  tb_Proveedor
go

create procedure listaComprobante
as 
select * from  tb_Comprobante
go

create procedure listaOrdenCompra
as 
select * from tb_ordenCompra
go

create procedure listaDistrito
as 
select * from  tb_distrito
go

create procedure listaDepartamento
as 
select * from  tb_departamento
go

create procedure listaProvincia
as 
select * from  tb_provincia
go


create procedure listaAreas
as 
select * from  tb_Area
go



create procedure listaUsu
as 
select * from  tb_usuario
go

create procedure agregaOrden
@id char(8),
@idComp char(8),
@fechaCom datetime,
@montoTot money,
@fechaOrd datetime,
@idProv char(5)
as
insert tb_OrdenCompra values(@id,@idComp,@fechaCom,@montoTot,@fechaOrd,@idProv)
go

select * from tb_usuario
go

------------------------------------------------------------

insert into tb_categorias values(1,'Mesa de noche','Madera Caoba')
go

insert tb_usuario values('rtapara','Roly','Tapara','Huamani','1992-07-13','San Camilo','2526279','47313043','Vendedor','001','P001','PR01','PD01','12345')
go
insert tb_usuario values('wcarranza','Walter','Carranza','Bustamante','1993-05-10','Universitaria','2896521','26565634','Vendedor','001','P001','PR01','PD01','1234')
go
insert tb_usuario values('dlopez','Damaso','Lopez','Aragon','1980-06-10','Sucre','2256984','47986325','Cliente','001','P001','PR01','PD01','1234')
go

insert tb_Cliente values('dlopez','123456789123')
go

insert tb_Empleado values('rtapara',200,'Tarde','Part-Time','ygomez','A01')
go
insert tb_Empleado values('wcarranza',1400,'Tarde','Part-Time','ygomez','A01')
go
insert tb_Empleado values('ygomez',1400,'Tarde','Part-Time','ygomez','A01')
go
insert tb_Vendedor values('rtapara',200)
go
INSERT tb_Kardex VALUES('10','2012-05-28','ygomez','Ventas')
go





insert tb_EncargadoAlmacen values('wcarranza',1200)
go
insert tb_EncargadoAlmacen values('ygomez',1200)
go

--insert tb_Area values('V','Ventas')
--insert tb_Admin values('rtapara','V')

alter table tb_Tarjeta add codSeguridad char(4) null;
go

insert tb_Producto values('1','Mesa de Noche',250,100,'wcarranza',1)
go
insert tb_Producto values('2','Mesa Blanca',250,0,'wcarranza',1)
go
insert TipoTarjeta values('100','Visa')
go
insert TipoTarjeta values('200','MasterCard')
go
insert tb_Tarjeta values('1234567890','Debito','100','dlopez','1234')
go
insert tb_Tarjeta values('9876543210','Credito','200','dlopez','4567')
go
select *from tb_Tarjeta
go



Select codProd,descrip,precio,stock,codUsu_Emp_Alm,codCategoria from tb_Producto
go

-----------PROCEDURES-----------
create proc usp_lista_prod
as
	select p.codProd,p.descrip,p.precio,p.stock,p.codCategoria, c.NombreCategoria from tb_Producto p, tb_categorias c
	where p.codCategoria = c.IdCategoria
go



create proc usp_lista_filtro
@filtro varchar(100)
as
	select p.codProd,p.descrip,p.precio,p.stock,p.codCategoria, c.NombreCategoria from tb_Producto p, tb_categorias c 
	where p.codCategoria = c.IdCategoria and stock >0 and codProd like '%'+@filtro+'%'
go



create proc usp_lista_filtro_sin_stock
@filtro varchar(100)
as
	select p.codProd,p.descrip,p.precio,p.stock,p.codCategoria, c.NombreCategoria from tb_Producto p, tb_categorias c  
	where p.codCategoria = c.IdCategoria and stock=0 and codProd like '%'+@filtro+'%' 
go


create proc usp_autogenera_hoja_pedido
as
	Select count(*) from tb_HojaPedido
go


create proc usp_insertar_hoja_pedido
@cod int,
@cod_cli char(10),
@cod_ven char(10),
@tipoCompro varchar(10),
@fechaPedido datetime,
@fechaEntrega datetime,
@formaPago varchar(10),
@tipoTarjeta varchar(10),
@estado varchar(10),
@idPais char(3),
@codDpto char(4),
@codProv char(4),
@codDis char(4)
as
	insert tb_HojaPedido values(@cod,@cod_cli,@cod_ven,@tipoCompro,@fechaPedido,@fechaEntrega,@formaPago,@tipoTarjeta,@estado,@idPais,@codDpto,@codProv,@codDis)
go

create proc usp_insertar_detalle_ped
@nroPed int,
@codProd int,
@nroKardex char(10),
@importe money,
@cant int,
@desc money,
@preUni money,
@impTotal money
as
	insert tb_DetallePedProd values(@nroPed,@codProd,@nroKardex,@importe,@cant,@desc,@preUni,@impTotal)
go

select * from tb_usuario
go

create proc usp_mostrar_datos_usuario
@usu char(10)
as
	select NomUsu,apePat+','+apeMat as apellidos,telefono,Domicilio,codUsu from tb_usuario where codUsu=@usu;
go




--------------------------------
create proc usp_max_pedido
@cod char(10)
as
	Select MAX(NroPedido) from tb_HojaPedido where estadoPedido='Pendiente' and codUsu_Cli=@cod
go



create proc usp_datos_cli_pago
@usu char(10),
@codPed int
as
Select u.NomUsu,hp.tipoComprobante,pd.importeTotal,hp.NroPedido,tipoComprobante,u.Idpais,u.codDpto,u.codProv,u.codDis from tb_HojaPedido hp join tb_usuario u on hp.codUsu_Cli=u.codUsu join tb_DetallePedProd pd on pd.NroPedido=hp.NroPedido where hp.codUsu_Cli= @usu and hp.NroPedido=@codPed
go


create proc validar_nro_tarjeta
@nro char(16),
@usu char(10),
@codSeg char(4)
as
	Select COUNT(*) from tb_Tarjeta where NroTarj=@nro and codUsu_Cli=@usu and codSeguridad=@codSeg
go


create proc usp_inserta_comprobante
@nroCom char(8),
@fecha  datetime,
@usu    char(10),
@nroPed  int,
@tipo	varchar(7),
@estado		varchar(10),
@idp		char(3),
@codDept char(4),
@codProv char(4),
@codDis char(4)
as
	insert tb_Comprobante values(@nroCom,@fecha,@usu,@nroPed,@tipo,@estado,@idp,@codDept,@codProv,@codDis)
go

create proc usp_inserta_boleta
@nroComp char(8)
as
	insert tb_Boleta values(@nroComp)
go

create proc usp_inserta_factura
@nroComp char(8)
as
	insert tb_Factura values(@nroComp,0.18)
go

create proc usp_autogenera_Comprobante
as
	select COUNT(1) from tb_Comprobante
go

create proc usp_actualizar_stock
@codProd int,
@cant int
as
	update tb_Producto set stock = stock - @cant
	where codProd= @codProd
go


-----------------------------------------------------
insert into tb_categorias values(2,'De Sala','Muebles de Sala')
go
insert into tb_categorias values(3,'De Comedor','Muebles de Comedor')
go
insert into tb_categorias values(4,'De Baño','Muebles de Baño')
go
insert into tb_categorias values(5,'De Cocina','Muebles de Cocina')
go
insert into tb_categorias values(6,'De Dormitorio','Muebles de Dormitorio')
go
insert into tb_categorias values(7,'De Oficina','Muebles de Oficina')
go
insert into tb_categorias values(8,'De Jardín','Muebles de Jardín')
go
insert into tb_categorias values(9,'Modernos','Muebles de Estilos Modernos')
go
insert into tb_categorias values(10,'Otros','Otra Categoría de Muebles')
go


----PROCEDURES DE PRODUCTO----
--procedure que inserte
create procedure usp_add_producto
@id int,@nom varchar(30),
@pre money,@cant int,
@codEmp char(10),@codCate int
As
Insert tb_Producto Values(@id,@nom,@pre,@cant,@codEmp,@codCate)
go

--procedure que actualice por IdProducto
create procedure usp_update_producto
@id int,@nom varchar(30),
@pre money,@cant int,
@codEmp char(10),@codCate int
As
Update tb_Producto set descrip=@nom,precio=@pre,stock=@cant,codUsu_Emp_Alm=@codEmp,codCategoria=@codCate Where codProd=@id
go

--procedure que elimina por IdProducto
create procedure usp_delete_producto
@id int
As
Delete tb_Producto Where codProd=@id
go

---autogenera
Select * from tb_Producto
Select max(codProd) from tb_Producto


CREATE PROCEDURE usp_add_Tarjeta
	@NroTarj char(16),
	@Descrip varchar(20),
	@codTipoTarj char(10),
	@codUsu_Cli char(10),
	@codSeguridad char(4)
AS
INSERT INTO tb_Tarjeta
	(
	NroTarj,
	Descrip,
	codTipoTarj,
	codUsu_Cli,
	codSeguridad
	)
	VALUES
	(
	@NroTarj,
	@Descrip,
	@codTipoTarj,
	@codUsu_Cli,
	@codSeguridad
	)
GO

create proc usp_actualizar_estado
@cod int
as
	update tb_HojaPedido set estadoPedido = 'Cancelado'
	where nroPedido=@cod
go


