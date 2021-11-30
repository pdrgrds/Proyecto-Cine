-- borra la bd si existe
use master
Go

if db_id('Pelicula') is not null
drop database Pelicula
go  
-- creamos la bd
CREATE DATABASE Pelicula
go
-- activamos la bd
USE Pelicula
go

create table Tipo_User(
	cod_tipo int identity(1,1) not null PRIMARY KEY,
    desc_tipo varchar(40) not null,
	estado char(1) not null
)
go

create table Usuario(
	usuario char(15) not null,
    nombre varchar(40) not null,
    telefono char(9) null,
    direccion char(100) null,
    tipo_usuario int null,
    password varchar(50) not null,
    estado char(1) not null,
    primary key(usuario),
    foreign key (tipo_usuario) references Tipo_User(cod_tipo)
)
go

create table Tipo_peli(
	cod_tipo int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    desc_tipo varchar(40) not null,
	estado char(1) not null
)
GO

create table Tipo_Comest(
	id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descrip varchar(50) not null,
	estado char(1) not null
)
GO

create table Proveedor(
	id int IDENTITY(100,1) NOT NULL,
    nombre varchar(50) not null,
    telf char(9) not null,
    direc varchar(50),
	estado char(1) not null,
    primary key(id)
)
GO

create table Peliculas(
	cod_peli char(5) not null PRIMARY KEY,
    nombre varchar(100) not null,
    tipo_peli int not null,
    fecha_Estreno date not null,
    fecha_final date null,
	precio float not null,
	entradas int not null,
	entradasRestante int not null,
    estado char(1),
	img varchar(500),
	foreign key (tipo_peli) references Tipo_peli(cod_tipo)
)
GO

create table Comestibles(
	cod_Com char(5) not null PRIMARY KEY,
    descrip varchar(50) not null,
    precio float not null,
    stock_Actual int not null,
	id_Tipo int not null,
	id_proveedor int not null,
    estado char(1),
	img varchar(500),
	foreign key (id_Tipo) references Tipo_Comest(id),
    foreign key (id_proveedor) references Proveedor(id)
)
GO

create table Boleta(
	cod_bol char(5) not null PRIMARY KEY,
    cod_user char(15) not null,
    fecha_bol date not null,
    prec_total float not null,
    foreign key (cod_user) references Usuario(usuario),
)
GO

create table DetalleBoleta(
	cod_body int IDENTITY(10000,1) NOT NULL PRIMARY KEY,
	cod_bol char(5) not null,
    cod_peli char(5) null,
    cod_Com char(5) null,
    cantidad int not null,
    total float not null,
    foreign key (cod_bol) references Boleta(cod_bol),
    foreign key (cod_peli) references Peliculas(cod_peli),
    foreign key (cod_Com) references Comestibles(cod_Com)
)
GO

insert into Tipo_User values('Admin', 'A');
insert into Tipo_User values('Cliente', 'A');
SELECT * FROM Tipo_User
GO

insert into Usuario values('UPablo', 'Pablo', 978879789, 'San Luis', 2, '1234', 'A');
insert into Usuario values('ADMIN', 'Administrador', 999999999, 'San Borja', 1, '@DM1N', 'A');
SELECT * FROM Usuario
GO

insert into Tipo_peli values('Anime', 'A');
insert into Tipo_peli values('Terror', 'A');
insert into Tipo_peli values('Dibujos', 'A');
insert into Tipo_peli values('Romantica', 'A');
SELECT * FROM Tipo_peli
GO

insert into Tipo_Comest values('BEBIDAS', 'A');
insert into Tipo_Comest values('DULCES', 'A');
insert into Tipo_Comest values('GOMITAS', 'A');
GO

insert into Proveedor values ('EMP.BEBI', 55566565, 'SAN LUIS', 'A');
insert into Proveedor values ('EMP.DULC', 87687689, 'SURCO', 'A');
insert into Proveedor values ('EMP.JUGE', 98756776, 'MIRAFLORES', 'A');
insert into Proveedor values ('EMP.GOMI', 56756765, 'SAN BORJA', 'A');
select*from Proveedor 
GO

insert into Peliculas values ('P0001', 'Boku no Hero', 1, '2020/12/12', '2021/01/10', 16.50, 100, 50, 'A','~/FOTOS/P0001.jpg');
insert into Peliculas values ('P0002', 'Your Name', 1, '2020/11/1', '2021/12/1', 12.50, 100, 50, 'A','~/FOTOS/P0002.jpg');
insert into Peliculas values ('P0003', 'kimetsu no yaiba', 1, '2020/12/4', '2021/01/28', 20.50, 100, 50, 'A','~/FOTOS/P0003.jpg');
insert into Peliculas values ('P0004', 'Cadáver', 2, '2020/12/10', '2021/01/10', 13.50, 100, 50, 'A','~/FOTOS/P0004.jpg');
insert into Peliculas values ('P0005', 'Anabelle', 2, '2020/11/1', '2021/12/1', 21.50, 100, 50, 'A','~/FOTOS/P0005.jpg');
insert into Peliculas values ('P0006', 'Eli', 2, '2020/12/4', '2021/01/28', 9.5, 100, 20, 'A','~/FOTOS/P0006.jpg');
insert into Peliculas values ('P0007', 'Toy Story', 3, '2020/12/10', '2021/01/10', 24.50,  100, 50, 'A','~/FOTOS/P0007.jpg');
insert into Peliculas values ('P0008', 'Mascotas', 3, '2020/11/1', '2021/12/1', 16.50, 100, 40, 'A','~/FOTOS/P0008.jpg');
insert into Peliculas values ('P0009', 'Scooby Doo!', 3, '2020/12/4', '2021/01/28', 12.50, 100, 50, 'A','~/FOTOS/P0009.jpg');
insert into Peliculas values ('P0010', 'Zero', 4, '2020/12/10', '2021/01/10', 16.50, 100, 50, 'A','~/FOTOS/P0010.jpg');
insert into Peliculas values ('P0011', 'Titanic', 4, '2020/11/1', '2021/12/1', 12.50, 100, 50, 'A','~/FOTOS/P0011.jpg');
insert into Peliculas values ('P0012', 'Violet y Finch', 4, '2020/12/4', '2021/01/28', 21, 100, 50, 'A','~/FOTOS/P0012.jpg');
SELECT * FROM Peliculas
GO

insert into Comestibles values ('C0001', 'CARAMELOS X 15', 10.40, 400, 1, 102, 'A','~/FOTOS/C0001.jpg');
insert into Comestibles values ('C0002', 'COCA-COLA 750 ml.', 3.20, 450, 1, 102, 'A','~/FOTOS/C0002.jpg');
insert into Comestibles values ('C0003', 'GOMITAS 500 gr.', 3.40, 400, 2, 101, 'A','~/FOTOS/C0003.jpg');
insert into Comestibles values ('C0005', 'MENTOS', 2.40, 400, 1, 100, 'A','~/FOTOS/C0005.jpg');
insert into Comestibles values ('C0006', 'INKA KOLA 750 ml.', 3.20, 300, 1, 103, 'A','~/FOTOS/C0005.jpg');
insert into Comestibles values ('C0004', 'OSITOS 500 gr.', 2.40, 400, 2, 103, 'A','~/FOTOS/C0004.jpg');
SELECT * FROM Comestibles
GO

insert into Boleta values('B0001', 'UPablo', getdate(), 2.40);
insert into Boleta values('B0002', 'ADMIN', getdate(), 204.0);
SELECT * FROM Boleta
GO

insert into DetalleBoleta values('B0001', null, 'C0004', 1, 2.40);
insert into DetalleBoleta values('B0002', null, 'C0004', 100, 204.0);
SELECT * FROM DetalleBoleta
GO
