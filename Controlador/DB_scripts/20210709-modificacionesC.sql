select * from usuarios
select * from tipoUsuario
select * from Autenticaciones
insert into usuarios (IDTipo, nombre, apellido, DNI, domicilio, telefono, celular, mail, codigoPostal)
values (2, 'Alberto', 'juarez', '19876543', 'pavon', '41326789', '11456789', 'supervisor@gmail.com','1345')

update usuarios set mail='tecnico@gmail.com' where IDUsuario=1
update usuarios set mail='cliente@gmail.com' where IDUsuario=2

insert into Autenticaciones (IDUsuario, Contrasenia) values (1,'tecnico')
insert into Autenticaciones (IDUsuario, Contrasenia) values (2,'cliente')
insert into Autenticaciones (IDUsuario, Contrasenia) values (3,'supervisor')

CREATE PROCEDURE PR_Autenticacion (
@MAIL VARCHAR(50),
@CONTRASENIA VARCHAR(100)
)
AS
BEGIN
SELECT U.IDTipo FROM Autenticaciones AS A
INNER JOIN usuarios AS U ON A.IDUsuario=U.IDUsuario
WHERE U.mail = @MAIL AND A.Contrasenia= @CONTRASENIA
END

