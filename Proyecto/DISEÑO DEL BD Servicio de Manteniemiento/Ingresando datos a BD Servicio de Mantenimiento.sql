use Servicios_de_mantenimiento
go

---Insertando datos en la tabla cliente
Insert into Cliente ([Primer Nombre],[Segundo Nombre], [Primer Apellido], [Segundo Apellido], Telefono, Correo, Direccion, Estado)
values ('Juan','José','Barrios','Canales','82181557','juanj@gmail.com','Managua','Habilitado')
Insert into Cliente ([Primer Nombre],[Segundo Nombre], [Primer Apellido], [Segundo Apellido], Telefono, Correo, Direccion, Estado)
values ('Joel','Antonio','Barrios','Mendóza','51455223','jbarrios@gmail.com','Masaya','Habilitado')
Insert into Cliente ([Primer Nombre],[Segundo Nombre], [Primer Apellido], [Segundo Apellido], Telefono, Correo, Direccion, Estado)
values ('Alejandor','','Alvarado','Pérez','57844551','aalvarop@gmail.com','Rivas','Habilitado')
Insert into Cliente ([Primer Nombre],[Segundo Nombre], [Primer Apellido], [Segundo Apellido], Telefono, Correo, Direccion, Estado)
values ('Jeison','José','Suarez','Jiménez','57553832','jeisonsuarez2003@gmail.com','Rivas','Habilitado')
Insert into Cliente ([Primer Nombre],[Segundo Nombre], [Primer Apellido], [Segundo Apellido], Telefono, Correo, Direccion, Estado)
values ('Penélope','Daniela','Aragón','Portocarrero','85256332','penelopearagon12@gmail.com','Managua','Habilitado')
Insert into Cliente ([Primer Nombre],[Segundo Nombre], [Primer Apellido], [Segundo Apellido], Telefono, Correo, Direccion, Estado)
values ('Axel','Karim','Saenz','Juarez','86320554','karimsaenz32@gmail.com','Matagalpa','Habilitado')
Insert into Cliente ([Primer Nombre],[Segundo Nombre], [Primer Apellido], [Segundo Apellido], Telefono, Correo, Direccion, Estado)
values ('Kevin','Antonio','Ortiz','','57105110','kevinoortiz21@gmail.com','Rivas','Habilitado')

go

select * from Cliente

go

--- insertando datos en la tabla mecánico
Insert into Mecánico ([Primer Nombre],[Segundo Nombre],[Primer Apellido],[Segundo Apellido],
Telefono, Especialidad, Correo, Salario, Direccion, Estado) 
values ('Juan','Carlos','Villanueva','Ortiz',
'82181554','Sistema Eléctrico','juanjc@gmail.com',10000,'Managua','Habilitado')
Insert into Mecánico ([Primer Nombre],[Segundo Nombre],[Primer Apellido],[Segundo Apellido],
Telefono, Especialidad, Correo, Salario, Direccion, Estado) 
values ('Danilo','José','Corrales','López',
'82171557','Sistema Refrigeración','josess@gmail.com',12000,'Managua','Habilitado')
Insert into Mecánico ([Primer Nombre],[Segundo Nombre],[Primer Apellido],[Segundo Apellido],
Telefono, Especialidad, Correo, Salario, Direccion, Estado)
values ('Allan','','Zambrana','',
'82923522','Ayudante','zambranaall@gmail.com',11000,'Managua','Habilitado')
Insert into Mecánico ([Primer Nombre],[Segundo Nombre],[Primer Apellido],[Segundo Apellido],
Telefono, Especialidad, Correo, Salario, Direccion, Estado)
values ('Cristopher','','Corrales','Martinez',
'59623214','Ingeniero Mecánico','martincorr@gmail.com',12000,'Managua','Habilitado')
Insert into Mecánico ([Primer Nombre],[Segundo Nombre],[Primer Apellido],[Segundo Apellido],
Telefono, Especialidad, Correo, Salario, Direccion, Estado)
values ('Ebner','Camilo','Ponce','Ramierez',
'82181557','Técnico','ebnercp@gmail.com',10000,'Managua','Habilitado')

go

select * from Mecánico

go
--- insertando datos en la tabla repuesto 
Insert into Repuesto (Marca,Modelo,Descripcion,Cantidad,Precio) values ('Honda','SS101','Banda de distribución',150,250)
Insert into Repuesto (Marca,Modelo,Descripcion,Cantidad,Precio) values ('Yamaha','QWA22','shock block',134,1150)
Insert into Repuesto (Marca,Modelo,Descripcion,Cantidad,Precio) values ('BOSCH','SLA1','Filtro de aceite',300,200)
Insert into Repuesto (Marca,Modelo,Descripcion,Cantidad,Precio) values ('ACDelco','QWS2','Bujía',134,250)
Insert into Repuesto (Marca,Modelo,Descripcion,Cantidad,Precio) values ('VALEO','SOCA1','Filtro de gasolina',300,300)

go

SELECT * FROM Repuesto

go
---insertando datos en la tabla vehículo
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (1,'BMW','X4','2018')
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (1,'BMW','SERIE 3','2010')
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (4,'Audi','X4','2012')
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (3,'Ford','F150','1999')
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (2,'Seat','F50','2018')
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (5,'Lexus','MA10','2014')
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (6,'Seat','F50','2018')
Insert into Vehículo (IDCliente,Marca,Modelo,Año) values (7,'Opel','R50','2020')

go

select * from Vehículo

go

---insertando datos en la tabla Mantenimiento
Insert into Mantenimiento (IDVehículo,Fecha_Ingreso,Fecha_Salida,Estado) values (1,'2020-03-03','2020-03-03','Reparado')
Insert into Mantenimiento (IDVehículo,Fecha_Ingreso,Fecha_Salida,Estado) values (2,'2020-11-12','2020-11-13','Reparado')
Insert into Mantenimiento (IDVehículo,Fecha_Ingreso,Fecha_Salida,Estado) values (3,'2020-12-23','2020-12-23','Reparado')
Insert into Mantenimiento (IDVehículo,Fecha_Ingreso,Fecha_Salida,Estado) values (4,'2020-06-03','2020-06-03','Reparado')
Insert into Mantenimiento (IDVehículo,Fecha_Ingreso,Fecha_Salida,Estado) values (6,'2020-06-12','2020-06-15','Reparado')
Insert into Mantenimiento (IDVehículo,Fecha_Ingreso,Fecha_Salida,Estado) values (5,'2020-03-03','2020-03-03','Reparado')
Insert into Mantenimiento (IDVehículo,Fecha_Ingreso,Fecha_Salida,Estado) values (1,'2020-12-03','2020-12-03','Reparado')

go

select * from Mantenimiento

go

---insertando datos en la tabla servicio
Insert into Servicio (Descripción,Precio,Tipo_Mantenimiento) values ('Cambio de aceite',140,'ORDINARIO')
Insert into Servicio (Descripción,Precio,Tipo_Mantenimiento) values ('Cambio de Bandas del Motor',180,'EXTRAORDINARIO')
Insert into Servicio (Descripción,Precio,Tipo_Mantenimiento) values ('Mantenimiento 10000 km',1800,'ORDINARIO')
Insert into Servicio (Descripción,Precio,Tipo_Mantenimiento) values ('Mantenimiento 5000 km ',1500,'ORDINARIO')
Insert into Servicio (Descripción,Precio,Tipo_Mantenimiento) values ('Revisión del Sistema Eléctrico',400,'EXTRAORDINARIO')
Insert into Servicio (Descripción,Precio,Tipo_Mantenimiento) values ('Reparación de aire acondicionado',2000,'EXTRAORDINARIO')

go

select * from Servicio

go

---insertando datos es detallemantenimiento 
 Insert into Detalle_Mantenimiento (IDMantenimiento,IDMecánico,IDServicio,Precio) values (1,1,1,2700)
 Insert into Detalle_Mantenimiento (IDMantenimiento,IDMecánico,IDServicio,Precio) values (1,2,1,2900)
 Insert into Detalle_Mantenimiento (IDMantenimiento,IDMecánico,IDServicio,Precio) values (1,1,2,2000)
 Insert into Detalle_Mantenimiento (IDMantenimiento,IDMecánico,IDServicio,Precio) values (1,3,2,2000)
 Insert into Detalle_Mantenimiento (IDMantenimiento,IDMecánico,IDServicio,Precio) values (3,2,2,1500)

 go

 select * from Detalle_Mantenimiento

 go

 ---insertando datos en detallerepuesto
 Insert into Detalle_Repuesto (IDDetalle_Mantenimiento,IDRepuesto,Cantidad,Autorizacion) values (1,1,1,'si')
 Insert into Detalle_Repuesto (IDDetalle_Mantenimiento,IDRepuesto,Cantidad,Autorizacion) values (2,2,1,'no')
 Insert into Detalle_Repuesto (IDDetalle_Mantenimiento,IDRepuesto,Cantidad,Autorizacion) values (3,3,1,'no')
 Insert into Detalle_Repuesto (IDDetalle_Mantenimiento,IDRepuesto,Cantidad,Autorizacion) values (1,3,2,'si')
 Insert into Detalle_Repuesto (IDDetalle_Mantenimiento,IDRepuesto,Cantidad,Autorizacion) values (4,4,1,'si')

 go

 select * from Detalle_Repuesto

 go
 --insertando datos de factura
Insert into Factura (IDMantenimiento) values(1)
Insert into Factura (IDMantenimiento) values(2)
Insert into Factura (IDMantenimiento) values(3)
Insert into Factura (IDMantenimiento) values(4)
Insert into Factura (IDMantenimiento) values(6)
Insert into Factura (IDMantenimiento) values(5)
Insert into Factura (IDMantenimiento) values(1)

go
 ----Consultando a todas las tablas
 select * from Detalle_Repuesto
 select * from Cliente
 select * from Detalle_Mantenimiento
 select * from Servicio
 select * from Mantenimiento
 select * from Vehículo
 select * from Mecánico
 select * from Factura
 select * from Mecánico