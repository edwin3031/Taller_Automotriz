 use Servicios_de_mantenimiento

 go

 -- Creando Login
--create login AdminMantenimiento with password = 'proyecto123'
sp_addlogin 'AdminMantenimiento','proyecto123','Servicios_de_mantenimiento'

-- Para eliminar login
/*SELECT name, suser_sname(owner_sid) AS DBOwner FROM sys.databases
use Servicios_de_mantenimiento
sp_changedbowner 'sa'
drop login AdminMantenimiento*/

go

--Agregando Rol de Servidor (Administrador)
sp_addsrvrolemember AdminMantenimiento,sysadmin

go

-- Agregando usuario
sp_adduser AdminMantenimiento, AdminMantenimiento

-- Para saber el nombre del servidor
--Select @@SERVERNAME

go


	/*Creedenciales para login:
	Usuario: uni1
	Contraseña: 2022*/

	--Creando Roles
	create role Vendedor

	grant select on database :: Servicios_de_mantenimiento to Vendedor

	drop schema Ventas;

	drop schema Operacion;

	drop schema Empleados;

	alter schema dbo transfer Empleados.Colaborador
	alter schema dbo transfer Empleados.Usuario

	exec Mostrar_Usuarios