use DB_TPC

GO

alter table productos drop column numeroSerie
create table servicios(
    IDServicio int PRIMARY KEY IDENTITY (1,1),
    Nombre varchar(30) not null
)
alter table ticket add IDservicio int not null FOREIGN key REFERENCES servicios(IDServicio) default(1)
