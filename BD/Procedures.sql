use Pelicula
Go

/*==============================================================================*/
/*                                  TIPO USUARIO                                */
/*==============================================================================*/

--Insertar
Create proc USP_ADD_TIPOUSUARIO
	@descripcion varchar(40),
	@estado char(1)
As
Begin
	Insert into Tipo_User Values(@descripcion, @estado)
end
go

--Actualizar
Create proc USP_UPDATE_TIPOUSUARIO
	@id int,
	@descripcion varchar(40),
	@estado char(1)
As
Begin
	Update Tipo_User 
	set desc_tipo=@descripcion, 
	estado=@estado
	Where cod_tipo=@id
end
go

--Eliminar
Create proc USP_DELETE_TIPOUSUARIO
	@id int
As
Begin
	Update Tipo_User set estado='I' Where cod_tipo=@id
end
go

--Lista
Create proc USP_LIST_TIPOUSUARIO
As
Begin
	Select * from Tipo_User where estado != 'I'
end
go

/*==============================================================================*/
/*                                       USUARIO                                */
/*==============================================================================*/

--VALIDAR USUARIO
create proc USP_LOGUIN
    @user varchar (50),
    @password varchar(50)
as
    select * from Usuario
    where usuario=@user and password=@password
go

--Insertar
Create proc USP_ADD_USUARIO
	@usuario char(15),
    @nombre varchar(40),
    @telefono char(9),
    @direccion char(100),
    @tipo_usuario int,
    @password varchar(50),
    @estado char(1)
As
Begin
	Insert into Usuario Values(@usuario, @nombre, @telefono, @direccion, @tipo_usuario, @password, @estado)
end
go

--Actualizar
Create proc USP_UPDATE_USUARIO
	@usuario char(15),
    @nombre varchar(40),
    @telefono char(9),
    @direccion char(100),
    @tipo_usuario int,
    @password varchar(50),
    @estado char(1)
As
Begin
	Update Usuario set 
		nombre=@nombre, telefono=@telefono, 
		direccion=@direccion, tipo_usuario=@tipo_usuario, 
		password=@password, estado=@estado 
	where usuario = @usuario;
end
go

--Eliminar
Create proc USP_DELETE_USUARIO
	@usuario char(15)
As
Begin
	Update Usuario set estado = 'I' Where usuario=@usuario
end
go

--Lista
Create proc USP_LIST_USUARIO
As
Begin
	Select * from Usuario
end
go

/*==============================================================================*/
/*                                 TIPO PELICULA                                */
/*==============================================================================*/

--Insertar
Create proc USP_ADD_TIPOPELICULA
	@descripcion varchar(40),
	@estado char(1)
As
Begin
	Insert into Tipo_peli Values(@descripcion, @estado)
end
go

--Actualizar
Create proc USP_UPDATE_TIPOPELICULA
	@codigo int,
	@descripcion varchar(40),
	@estado char(1)
As
Begin
	Update Tipo_peli 
	set desc_tipo=@descripcion, 
	estado=@estado
	Where cod_tipo=@codigo
end
go

--Eliminar
Create proc USP_DELETE_TIPOPELICULA
	@codigo int
As
Begin
	Update Tipo_peli set estado='I' Where cod_tipo=@codigo
end
go

--Lista
Create proc USP_LIST_TIPOPELICULA
As
Begin
	Select * from Tipo_peli where estado != 'I'
end
go

/*==============================================================================*/
/*                               TIPO COMESTIBLE                                */
/*==============================================================================*/

--Insertar
Create proc USP_ADD_TIPOCOMESTIBLE
	@descripcion varchar(50),
	@estado char(1)
As
Begin
	Insert into Tipo_Comest Values(@descripcion, @estado)
end
go

--Actualizar
Create proc USP_UPDATE_TIPOCOMESTIBLE
	@id int,
	@descripcion varchar(50),
	@estado char(1)
As
Begin
	Update Tipo_Comest 
	set descrip=@descripcion, 
	estado=@estado
	Where id=@id
end
go

--Eliminar
Create proc USP_DELETE_TIPOCOMESTIBLE
	@id int
As
Begin
	Update Tipo_Comest set estado='I' Where id=@id
end
go

--Lista
Create proc USP_LIST_TIPOCOMESTIBLE
As
Begin
	Select * from Tipo_Comest where estado != 'I'
end
go

/*==============================================================================*/
/*                                     PROVEEDOR                                */
/*==============================================================================*/

--Insertar
Create proc USP_ADD_PROVEEDOR
    @nombre varchar(50),
    @telf char(9),
    @direc varchar(50),
	@estado char(1)
As
Begin
	Insert into Proveedor Values(@nombre, @telf, @direc, @estado)
end
go

--Actualizar
Create proc USP_UPDATE_PROVEEDOR
	@id int,
    @nombre varchar(50),
    @telf char(9),
    @direc varchar(50),
	@estado char(1)
As
Begin
	Update Proveedor 
	set nombre=@nombre,
	telf=@telf,
	direc=@direc,
	estado=@estado
	Where id=@id
end
go

--Eliminar
Create proc USP_DELETE_PROVEEDOR
	@id int
As
Begin
	Update Proveedor set estado='I' Where id=@id
end
go

--Lista
Create proc USP_LIST_PROVEEDOR
As
Begin
	Select * from Proveedor where estado != 'I'
end
go

/*==============================================================================*/
/*                                     PELICULAS                                */
/*==============================================================================*/

--AUTO GENERAR CODIGO PELICULA
create function dbo.CodGeneratorPeliculas()
	returns char(5)
as
begin
	Declare @num int, @numf char(5)
	select  @num= cast(max(SUBSTRING(cod_peli, 2, 5)) as int) from Peliculas
	if @num is null set @num = 0
	set @num+=1
	set @numf = cast(@num as char(5))
	set @numf = 'P' + replicate('0', 4-len(@numf)) + @numf
	return @numf
end
Go

--Insertar
Create proc USP_ADD_PELICULAS
    @nombre varchar(100),
    @tipo_peli int,
    @fecha_Estreno date,
    @fecha_final date,
	@entradas int,
	@entradasRestantes int,
	@precio float,
    @estado char(1),
	@img varchar(500)
As
Begin
	Insert into Peliculas Values(dbo.CodGeneratorPeliculas(), @nombre, @tipo_peli, @fecha_Estreno, @fecha_final, @entradas, @entradasRestantes, @precio, @estado,@img)
end
go

--Actualizar
Create proc USP_UPDATE_PELICULAS
	@cod_peli char(5),
    @nombre varchar(100),
    @tipo_peli int,
    @fecha_Estreno date,
    @fecha_final date,
	@entradas int,
	@entradasRestantes int,
	@precio float,
    @estado char(1),
	@img varchar(500)
As
Begin
	Update Peliculas 
	set nombre=@nombre,
	tipo_peli=@tipo_peli,
	fecha_Estreno=@fecha_Estreno,
	fecha_final=@fecha_final,
	entradas=@entradas,
	entradasRestante=@entradas,
	precio=@precio,
	estado=@estado,
	img=@img
	Where cod_peli=@cod_peli
end
go

--Eliminar
Create proc USP_DELETE_PELICULAS
	@cod_peli char(5)
As
Begin
	Update Peliculas set estado='I' Where cod_peli=@cod_peli
end
go

--Lista
Create proc USP_LIST_PELICULAS
As
Begin
	Select p.*, t.desc_tipo from Peliculas p
	inner join Tipo_peli t
	on p.tipo_peli = t.cod_tipo
	where p.estado != 'I'
end
go

/*==============================================================================*/
/*                                   COMESTIBLES                                */
/*==============================================================================*/

--AUTO GENERAR CODIGO COMESTIBLES
create function dbo.CodGeneratorComestibles()
	returns char(5)
as
begin
	Declare @num int, @numf char(5)
	select  @num= cast(max(SUBSTRING(cod_Com, 2, 5)) as int) from Comestibles
	if @num is null set @num = 0
	set @num+=1
	set @numf = cast(@num as char(5))
	set @numf = 'C' + replicate('0', 4-len(@numf)) + @numf
	return @numf
end
Go

--Insertar
Create proc USP_ADD_COMESTIBLES
    @descrip varchar(50),
    @precio float,
    @stock_Actual int,
	@id_Tipo int,
	@id_proveedor int,
    @estado char(1),
	@img varchar(500)
As
Begin
	Insert into Comestibles Values(dbo.CodGeneratorComestibles(), @descrip, @precio, @stock_Actual, @id_Tipo, @id_proveedor, @estado,@img)
end
go

--Actualizar
Create proc USP_UPDATE_COMESTIBLES
	@cod_Com char(5),
    @descrip varchar(50),
    @precio float,
    @stock_Actual int,
	@id_Tipo int,
	@id_proveedor int,
    @estado char(1),
	@img varchar(500)
As
Begin
	Update Comestibles 
	set descrip=@descrip,
	precio=@precio,
	stock_Actual=@stock_Actual,
	id_Tipo=@id_Tipo,
	id_proveedor=@id_proveedor,
	estado=@estado,
	img=@img
	Where cod_Com=@cod_Com
end
go

--Eliminar
Create proc USP_DELETE_COMESTIBLES
	@cod_Com char(5)
As
Begin
	Update Comestibles set estado='I' Where cod_Com=@cod_Com
end
go

--Lista
Create proc USP_LIST_COMESTIBLES
As
Begin
	Select c.*, t.descrip, p.nombre from Comestibles c 
	inner join 	Tipo_Comest t 
	on c.id_Tipo = t.id 
	inner join Proveedor p 
	on p.id = c.id_proveedor 
	where c.estado != 'I'
end
go

/*==============================================================================*/
/*                                        BOLETA                                */
/*==============================================================================*/

--AUTO GENERAR CODIGO BOLETA
create function dbo.CodGeneratorBoleta()
	returns char(5)
as
begin
	Declare @num int, @numf char(5)
	select  @num= cast(max(SUBSTRING(cod_bol, 2, 5)) as int) from Boleta
	if @num is null set @num = 0
	set @num+=1
	set @numf = cast(@num as char(5))
	set @numf = 'B' + replicate('0', 4-len(@numf)) + @numf
	return @numf
end
Go

--Insertar
Create proc USP_ADD_BOLETA
    @cod_user char(15),
    @fecha_bol date,
    @prec_total float,
	@codigo char(5) output
As
Begin
	set @codigo = dbo.CodGeneratorBoleta() + '';
	Insert into Boleta Values(@codigo, @cod_user, @fecha_bol, @prec_total);
end
go




/*==============================================================================*/
/*                                DETALLE BOLETA                                */
/*==============================================================================*/

--Insertar
Create proc USP_ADD_DETALLEBOLETA
	@cod_bol char(5),
    @cod_peli char(5) = null,
    @cod_Com char(5) = null,
    @cantidad int,
    @total float
As
Begin
	Insert into DetalleBoleta Values(@cod_bol, @cod_peli, @cod_Com, @cantidad, @total)
end
go

create proc USP_ACTUALIZA_PRODUCTOS
	@codigo char(5),
	@tipo int,
	@cantidad int
AS
Begin
	if @tipo = 1 
		update Peliculas set entradasRestante = (entradasRestante-@cantidad) where cod_peli = @codigo;
	else 
		update Comestibles set stock_Actual = (stock_Actual-@cantidad) where cod_Com = @codigo;
end
Go

/*==============================================================================*/
/*                                      REPORTES                                */
/*==============================================================================*/
