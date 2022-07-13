Create database Servicios_de_mantenimiento

Use Servicios_de_mantenimiento
go

---creando la tabla cliente
Create table Cliente
(IDCliente int primary key identity(1,1),
 [Primer Nombre] varchar(50) not null,
 [Segundo Nombre] varchar(50) null,
 [Primer Apellido] varchar(50) not null,
 [Segundo Apellido] varchar(50) null,
 Telefono varchar (40),
 Correo varchar (60),
 Direccion varchar (60)
)

---creando la tabla vehículo

create table Vehículo 
(IDVehículo int primary key identity (1,1),
IDCliente int not null,
Marca varchar(50),
Modelo varchar (50),
Año varchar (50))

---creando la tabla servicio

Create table Servicio
(IDServicio int primary key identity (1,1),
Descripción varchar (50),
Precio float,
Tipo_Mantenimiento varchar (50))

---creando la tabla mantenimiento 
Create table Mantenimiento
(IDMantenimiento int primary key identity (1,1),
IDVehículo int not null,
Fecha_Ingreso date not null,
Fecha_Salida date not null,
Estado varchar (50))

---creando la tabla Detalle mantenimiento 
Create table Detalle_Mantenimiento
(IDDetalle_Mantenimiento int primary key identity (1,1),
IDMantenimiento int not null,
IDMecánico int not null,
IDServicio int not null ,
Precio float not null)

 

---crando la tabla repuesto 
Create table Repuesto 
(IDRepuesto int primary key identity (1,1),
Marca varchar(50) not null,
Modelo varchar (50)not null,
Descripcion varchar (60) not null ,
Cantidad int 
)

---crando la tabla Detalle repuesto 
Create table Detalle_Repuesto 
(IDDetalle_Mantenimiento int ,
IDRepuesto int,
Precio float,
Cantidad int 
)

---creando la tabla mecánico
Create table Mecánico 
(IDMecánico int primary key identity (1,1),
 [Primer Nombre] varchar(50) not null,
 [Segundo Nombre] varchar(50) null,
 [Primer Apellido] varchar(50) not null,
 [Segundo Apellido] varchar(50) null,
 Telefono varchar (40),
 Correo varchar (60),
 Direccion varchar (60)

 )
CREATE TABLE Usuarios(
IdUsuario int primary key identity (1,1),
Usuario varchar(50) not null,
Contrasena varchar(MAX) not null,
Rol varchar(50),
Estado varchar(50)
)

CREATE TABLE Colaborador(
IdColaborador int primary key identity(1,1),
IdUsuario int foreign key references Usuarios(IdUsuario),
PrimerNombre varchar (30),
SegundoNombre varchar (30),
PrimerApellido varchar(30),
SegundoApellido varchar(30),
Direccion varchar (80),
Telefono varchar (30)
)


 ---Creando relacion entre tablas cliente y vehiculo
 ALTER TABLE Vehículo
  ADD FOREIGN KEY (IDCliente)
  REFERENCES Cliente(IDCliente)

  ---creando relacion entre la tabla  mantenimiento y vehiculo
  ALTER TABLE Mantenimiento 
  ADD FOREIGN KEY (IDVehículo)
  REFERENCES Vehículo(IDVehículo)

  ---creando relacion entre detallemantenimiento, repuesto en detalle repuesto
  ALTER TABLE Detalle_Repuesto
  ADD FOREIGN KEY (IDDetalle_Mantenimiento)
  REFERENCES Detalle_Mantenimiento(IDDetalle_Mantenimiento)

    ALTER TABLE Detalle_Repuesto
  ADD FOREIGN KEY (IDRepuesto)
  REFERENCES Repuesto(IDRepuesto)

  --creando relacion entre Servicio, mantenimiento, mecanico, y detallerepuesto en detallemantenimiento
    ALTER TABLE Detalle_Mantenimiento
  ADD FOREIGN KEY (IDMantenimiento)
  REFERENCES Mantenimiento(IDMantenimiento)

  ALTER TABLE Detalle_Mantenimiento
  ADD FOREIGN KEY (IDMecánico)
  REFERENCES Mecánico(IDMecánico)

    ALTER TABLE Detalle_Mantenimiento
  ADD FOREIGN KEY (IDServicio)
  REFERENCES Servicio(IDServicio)