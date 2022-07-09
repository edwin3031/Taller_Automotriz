 use Servicios_de_mantenimiento

 go

 -- Creando Login
create login AdminMantenimiento with password = 'proyecto123'

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