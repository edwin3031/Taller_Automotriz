create database Servicios_de_mantenimiento

go

Use Servicios_de_mantenimiento

go

---creando la tabla cliente
create table Cliente
(IdCliente int primary key identity(1,1),
 [Primer Nombre] varchar(50) not null,
 [Segundo Nombre] varchar(50) null,
 [Primer Apellido] varchar(50) not null,
 [Segundo Apellido] varchar(50) null,
 Telefono varchar (40),
 Correo varchar (60),
 Direccion varchar (60),
 Estado varchar(60) null
)

go

---creando la tabla vehículo

create table Vehículo 
(IdVehículo int primary key identity (1,1),
IdCliente int not null,
Marca varchar(50),
Modelo varchar (50),
Año varchar (50))

go

---creando la tabla servicio

Create table Servicio
(IdServicio int primary key identity (1,1),
Descripción varchar (50),
Precio float,
Tipo_Mantenimiento varchar (50))

go

---creando la tabla mantenimiento 
Create table Mantenimiento
(IdMantenimiento int primary key identity (1,1),
IdVehículo int not null,
Fecha_Ingreso date not null,
Fecha_Salida date not null,
Estado varchar (60))

go

---creando la tabla Detalle mantenimiento 
Create table Detalle_Mantenimiento
(IdDetalle_Mantenimiento int primary key identity (1,1),
IdMantenimiento int not null,
IdMecánico int not null,
IdServicio int not null ,
Precio float not null)

 go

---crando la tabla repuesto 
Create table Repuesto 
(IdRepuesto int primary key identity (1,1),
Marca varchar(50) not null,
Modelo varchar (50)not null,
Descripcion varchar (60) not null ,
Cantidad int,
Precio float,
)

go

---crando la tabla Detalle repuesto 
create table Detalle_Repuesto 
(IdDetalle_Repuesto int primary key identity (1,1),
IdDetalle_Mantenimiento int ,
IdRepuesto int,
Cantidad int,
Autorizacion char(2) 
)

go

---creando la tabla mecánico
Create table Mecánico
(IdMecánico int primary key identity (1,1),
 [Primer Nombre] varchar(50) not null,
 [Segundo Nombre] varchar(50) null,
 [Primer Apellido] varchar(50) not null,
 [Segundo Apellido] varchar(50) null,
 Especialidad varchar(50) null,
 Telefono varchar (40),
 Correo varchar (60),
 Salario money,
 Direccion varchar (60),
 Estado varchar(60)

 )

 go

create TABLE Usuario(
IdUsuario int primary key identity (1,1),
Usuario varchar(50) not null,
Contrasenia varchar(MAX) not null,
Rol varchar(50),
Estado varchar(60)
)

go

CREATE TABLE Colaborador(
IdColaborador int primary key identity(1,1),
IdUsuario int foreign key references Usuario(IdUsuario),
PrimerNombre varchar (30),
SegundoNombre varchar (30),
PrimerApellido varchar(30),
SegundoApellido varchar(30),
Direccion varchar (80),
Telefono varchar (30)
)

go

create table Factura(
No_Factura int identity(1,1) primary key not null,
IDMantenimiento int foreign key references Mantenimiento(IDMantenimiento) not null,

)

go

 ---Creando relacion entre tablas cliente y vehiculo
 ALTER TABLE Vehículo
  ADD FOREIGN KEY (IdCliente)
  REFERENCES Cliente(IdCliente)

  ---creando relacion entre la tabla  mantenimiento y vehiculo
  ALTER TABLE Mantenimiento 
  ADD FOREIGN KEY (IdVehículo)
  REFERENCES Vehículo(IdVehículo)

  ---creando relacion entre detallemantenimiento, repuesto en detalle repuesto
  ALTER TABLE Detalle_Repuesto
  ADD FOREIGN KEY (IdDetalle_Mantenimiento)
  REFERENCES Detalle_Mantenimiento(IdDetalle_Mantenimiento)

    ALTER TABLE Detalle_Repuesto
  ADD FOREIGN KEY (IdRepuesto)
  REFERENCES Repuesto(IdRepuesto)

  --creando relacion entre Servicio, mantenimiento, mecanico, y detallerepuesto en detallemantenimiento
    ALTER TABLE Detalle_Mantenimiento
  ADD FOREIGN KEY (IdMantenimiento)
  REFERENCES Mantenimiento(IdMantenimiento)

  ALTER TABLE Detalle_Mantenimiento
  ADD FOREIGN KEY (IdMecánico)
  REFERENCES Mecánico(IdMecánico)

    ALTER TABLE Detalle_Mantenimiento
  ADD FOREIGN KEY (IdServicio)
  REFERENCES Servicio(IdServicio)