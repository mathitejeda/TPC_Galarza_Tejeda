create database DB_TPC

GO

create table areas
(
    IDArea int PRIMARY KEY,
    nombre varchar(10) not null,
    descripcion VARCHAR(100) not null
)

GO

create table tecnicos
(
    IDTecnico bigint PRIMARY KEY,
    IDArea int FOREIGN key REFERENCES areas(IDArea) not null,
    nombre varchar(30) not null,
    apellido varchar(30) not null,
    DNI varchar (10) null unique,
    telefono varchar(15) null,
    celular varchar(15) null,
    mail varchar(50) null
)

GO

create table supervisores
(
    IDSupervisor bigint PRIMARY KEY,
    IDArea int FOREIGN KEY REFERENCES areas(IDArea) not null,
    nombre varchar(30) not null,
    apellido VARCHAR(30) not null,
    dni varchar(10) not null,
    telefono varchar(15) null,
    celular varchar(15) null,
    mail varchar(50) null
)

GO

create table clientes
(
    IDCliente bigint PRIMARY KEY,
    razonSocial varchar(10) not null,
    telefono varchar(15) null,
    celular varchar(15) null,
    mail varchar(50) null
)

GO

create table productos
(
    IDProducto int PRIMARY KEY,
    nombre varchar(15) not null,
    numeroSerie varchar(15) not null,
    descripcion varchar(100) not null
)

GO

create table incidencias
(
    IDIncidencia int PRIMARY KEY,
    IDProducto int FOREIGN KEY references productos(IDProducto),
    IDCliente bigint FOREIGN KEY references clientes(IDCliente),
    IDTecnico bigint FOREIGN KEY REFERENCES tecnicos(IDtecnico),
    detalle varchar(100),
    estado char not null,
    fechaIngreso date not null,
    fechaEgreso date null
)