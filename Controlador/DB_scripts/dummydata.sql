use DB_TPC

GO

insert into estadoTicket (nombre) values('Ingresado')
insert into estadoTicket (nombre) values('En proceso')
insert into estadoTicket (nombre) values('Aceptado')
insert into estadoTicket (nombre) values('Rechazado')
insert into estadoTicket (nombre) values('Finalizado')

GO

insert into areas(nombre,descripcion) values('Reparacion','Nada mas que agregar')
insert into tipoUsuario(Descripcion) values('admin')
insert into tipoUsuario(Descripcion) values('supervisor')
insert into tipoUsuario(Descripcion) values('tecnico')
insert into tipoUsuario(Descripcion) values('cliente')

GO
select * from tipoUsuario
insert into usuarios(IDTipo,nombre,apellido,DNI) values(3,'juan','perez','111111')
insert into usuarios(IDTipo,nombre,apellido,DNI) values(4,'pedro','pablo','111112')

GO

insert into productos(nombre,numeroSerie,descripcion) values('hearth attack','111111','La mano de killer queen')

insert into ticket(IDTecnico,IDCliente,IDProducto,FechaIngreso) values(1,2,1,GETDATE())

select * from ticket