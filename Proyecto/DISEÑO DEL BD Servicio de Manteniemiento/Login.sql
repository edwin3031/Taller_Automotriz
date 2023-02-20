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
create login Vendedor with password ='vende123'

create user Derian34 from login Vendedor

grant select, update, delete on Cliente to Derian34
grant select, update, delete on Repuesto to Derian34
grant select, update, delete on Proveedor to Derian34
grant select, update, delete on Vehículo to Derian34

grant execute on database :: Servicios_de_mantenimiento to Derian34
grant create procedure on database :: Servicios_de_mantenimiento to Derian34
grant select on Repuesto to Derian34
grant select on Proveedor to Derian34
grant select on Vehículo to Derian34


go
create login Jefe_Mecanico with password ='meca123'

create user JaviRo from login Jefe_Mecanico


grant select, update, delete on Repuesto to JaviRo
grant select, update, delete on Detalle_Repuesto to JaviRo
grant select, update, delete on Proveedor to JaviRo
grant select, update, delete on Mantenimiento to JaviRo
grant select, update, delete on Detalle_Mantenimiento to JaviRo
grant select, update, delete on Mecánico to JaviRo

grant execute on database :: Servicios_de_mantenimiento to JaviRo
grant create procedure on database :: Servicios_de_mantenimiento to JaviRo
grant select on Repuesto to Derian34
grant select on Proveedor to Derian34
grant select on Vehículo to Derian34


create login Bodeguero with password ='bode123'

create user Luisao from login Bodeguero


grant select, update, delete on Repuesto to Luisao
grant select, update, delete on Detalle_Repuesto to Luisao
grant select, update, delete on Proveedor to Luisao


grant execute on database :: Servicios_de_mantenimiento to Luisao
grant create procedure on database :: Servicios_de_mantenimiento to Luisao

go

sp_adduser Vendedor, Vendedor



	/*Creedenciales para login:
	Usuario: uni1
	Contraseña: 2022*/

	--Creando Roles
	/*create role Vendedor

	grant select on database :: Servicios_de_mantenimiento to Vendedor

	drop schema Ventas;

	drop schema Operacion;

	drop schema Empleados;

	alter schema dbo transfer Empleados.Colaborador
	alter schema dbo transfer Empleados.Usuario

	exec Mostrar_Usuarios*/

	SELECT * FROM Usuario