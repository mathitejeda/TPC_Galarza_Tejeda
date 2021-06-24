create database DB_TPC

GO

use DB_TPC

GO

create table areas
(
    IDArea int PRIMARY KEY identity(1,1),
    nombre varchar(10) not null,
    descripcion VARCHAR(100) not null
)

GO

create table productos
(
    IDProducto bigint PRIMARY KEY,
    nombre varchar(15) not null,
    numeroSerie varchar(15) not null,
    descripcion varchar(100) not null
)

GO

create table serieProducto
(
	NROSerie bigint primary key identity(1000,1),
	IDProducto bigint foreign key references productos(IDproducto)
)

GO

create table tipoUsuario
(
    IDTipo int PRIMARY KEY,
    Descripcion varchar(30) not null
)

GO

create table usuarios
(
    IDUsuario bigint PRIMARY KEY identity(1,1),
    IDTipo int FOREIGN key REFERENCES tipoUsuario(IDTipo) not null,
    nombre varchar(30) not null,
    apellido varchar(30) not null,
    DNI varchar (10) not null unique,
	domicilio varchar(50) null,
	telefono varchar(50) null,
	celular varchar(50) null,
	mail varchar(50) null
)

GO

CREATE TABLE Autenticaciones
(
    IDUsuario bigint FOREIGN KEY references Usuarios(IDUsuario)not null,
    Contrasenia varchar(100) not null,
	Primary key(IDUsuario)
)

go

create table ticket(
   IDTicket int PRIMARY KEY identity(1,1),
    IDTecnico bigint FOREIGN KEY REFERENCES Usuarios(IDUsuario)not null,
	IDProducto bigint FOREIGN KEY REFERENCES Productos(IDProducto) not null,
	IDEstado int not null,
    Problema varchar(300) null,
	Diagnostico varchar(300) null,
	Solucion varchar(300) null,
    FechaIngreso date not null,
    FechaEgreso date null
)

go

create table estadoTicket(
	IDEstado int primary key references ticket(IDTicket),
	nombre varchar(50) not null
)

GO

create table productosPorCliente(
	IDProducto bigint not null,
	IDCliente bigint not null,
	primary key(IDProducto, IDCliente),
	foreign key (IDProducto) references productos(IDProducto),
	foreign key (IDCliente) references usuarios(IDUsuario)
)

go

create table usuariosPorArea
(
	IDUsuario bigint,
	IDArea int,
	primary key(IDUsuario, IDarea),
	foreign key(IDUsuario) references usuarios(IDUsuario),
	foreign key (IDArea) references areas(IDArea)
)

GO

--Creada la columna cliente en ticket para poder mostrar los datos de manera mas precisa
alter table ticket add IDCliente bigint FOREIGN key references usuarios(IDUsuario)