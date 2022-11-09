CREATE DATABASE DimSerMantenimiento

GO

USE DimSerMantenimiento

GO

-- Tablas

CREATE TABLE [dbo].[DimVehículo](
	[DimIdVehículo] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[IdVehículo] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Año] [int] NULL,
	FechaInicio date,
	FechaFinal date
	)

GO

CREATE TABLE [dbo].[DimServicio](
	[DimIdServicio] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NOT NULL,
	[Descripción] [varchar](50) NULL,
	[Precio] [float] NULL,
	[Tipo_Mantenimiento] [varchar](50) NULL,
	FechaInicio date,
	FechaFinal date
	)

GO

CREATE TABLE [dbo].[DimMecánico](
	[DimIdMecánico] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[IdMecánico] [int] NOT NULL,
	[Primer Nombre] [varchar](50) NOT NULL,
	[Segundo Nombre] [varchar](50) NULL,
	[Primer Apellido] [varchar](50) NOT NULL,
	[Segundo Apellido] [varchar](50) NULL,
	[Especialidad] [varchar](50) NULL,
	[Telefono] [varchar](40) NULL,
	[Correo] [varchar](60) NULL,
	[Salario] [money] NULL,
	[Direccion] [varchar](60) NULL,
	[Estado] [varchar](60) NULL,
	FechaInicio date,
	FechaFinal date
	)

GO

CREATE TABLE [dbo].[DimCliente](
	[DimIdCliente] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Primer Nombre] [varchar](50) NOT NULL,
	[Segundo Nombre] [varchar](50) NULL,
	[Primer Apellido] [varchar](50) NOT NULL,
	[Segundo Apellido] [varchar](50) NULL,
	[Telefono] [varchar](40) NULL,
	[Correo] [varchar](60) NULL,
	[Direccion] [varchar](60) NULL,
	[Estado] [varchar](60) NULL,
	FechaInicio date,
	FechaFinal date
	)

	GO

	CREATE TABLE [dbo].[DimRepuesto](
	[DimIdRepuesto] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[IdRepuesto] [int] NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[Cantidad] [int] NULL,
	[Precio] [float] NULL,
	FechaInicio date,
	FechaFinal date
	)

	GO

CREATE TABLE [dbo].[DimFechas](
	[DimFechaID] [int] PRIMARY KEY IDENTITY (1,1) not null,
	[IDFecha] [date] null,
	[Año] [int] null,
	[NoMes] [int] null,
	[NombreMes] [nvarchar] (50) null,
	[Dia] [int] null,
	[NombreDia] [nvarchar] (50) null,
	[Trimestre] [int] null
)

GO
/*
USE Servicios_de_mantenimiento

GO

Select distinct m.Fecha_Ingreso as IdFecha,
				YEAR(m.Fecha_Ingreso) as Año,
				MONTH(m.Fecha_Ingreso) as noMes,
				DAY(m.Fecha_Ingreso) as Dia,
				DATENAME(WEEKDAY, m.Fecha_Ingreso) as NombreDia,
				DATENAME(MONTH, m.Fecha_Ingreso) as NombreMes,
				DATEPART(QQ, m.Fecha_Ingreso) as Trimestre
			from Servicios_de_mantenimiento.dbo.Mantenimiento m
*/

CREATE TABLE [dbo].[HechosMantenimientos](
	[DimIdCliente] [int] NOT NULL,
	[DimIdServicio] [int] NOT NULL,
	[DimFechaID] [int] NOT NULL,
	[DimIdMecánico] [int] NOT NULL,
	[DimIdVehículo] [int] NOT NULL,
	[DimIdRepuesto] [int] NOT NULL,
	[Precio] [float] NOT NULL,
)

GO

-- Agregando Foreign Keys

  ALTER TABLE  HechosMantenimientos
  ADD FOREIGN KEY (DimIdCliente)
  REFERENCES  DimCliente(DimIdCliente)

  ALTER TABLE  HechosMantenimientos
  ADD FOREIGN KEY (DimIdServicio)
  REFERENCES  DimServicio(DimIdServicio)

  ALTER TABLE  HechosMantenimientos
  ADD FOREIGN KEY (DimFechaID)
  REFERENCES  DimFechas(DimFechaID)

  ALTER TABLE  HechosMantenimientos
  ADD FOREIGN KEY (DimIdMecánico)
  REFERENCES  DimMecánico(DimIdMecánico)

  ALTER TABLE  HechosMantenimientos
  ADD FOREIGN KEY (DimIdVehículo)
  REFERENCES  DimVehículo(DimIdVehículo)

  ALTER TABLE  HechosMantenimientos
  ADD FOREIGN KEY (DimIdRepuesto)
  REFERENCES  DimRepuesto(DimIdRepuesto)

  GO
/*
Merge dbo.HechosVentas Destino
Using
(Select 
df.DimfechaID as DimFechaID,
de.DimProductID as DimProductID,
dc.DimSupplierID as DimSupplierID ,
ee.DimCategoryID as DimCategoryID,
count(Distinct o.OrderID) as Cantidad,
round (sum(od.Quantity),2) as CantidadOrdenes,
round (sum(od.Discount),2) as Descuento,
round (sum((od.Quantity)- (od.Quantity * od.Discount)),2) as CantidadDescuento
from Northwind.dbo.Orders o
inner join Northwind.dbo.[Order Details] od
on od.OrderID = o.OrderID
inner join DimFechas df
on df.IdFecha = o.OrderDate
inner join DimProducts de
on de.ProductID = od.ProductID
inner join DimSuppliers dc
on dc.SupplierID = de.SupplierID
inner join DimCategories ee
on ee.CategoryID = de.CategoryID
WHERE de.FechaFinal='9999/12/31' AND 
	  dc.FechaFinal='9999/12/31' AND 
	  ee.FechaFinal='9999/12/31' 
Group by
df.DimFechaID,
de.DimProductID,
dc.DimSupplierID,
ee.DimCategoryID) Origen
on
Destino.DimProductID = Origen.DimProductID and
Destino.DimCategoryID = Origen.DimCategoryID and
Destino.DimSupplierID = Origen.DimSupplierID and
Destino.DimFechaID = Origen.DimFechaID
WHEN MATCHED AND (Destino.Cantidad <> Origen.Cantidad or
                  Destino.Descuento <> Origen.Descuento or
				  Destino.CantidadDescuento <> Origen.CantidadDescuento or
				  Destino.CantidadOrdenes <> Origen.CantidadOrdenes)
				  Then
				  Update set
				  Destino.Cantidad = Origen.Cantidad,
                  Destino.Descuento = Origen.Descuento,
				  Destino.CantidadDescuento = Origen.CantidadDescuento,
				  Destino.CantidadOrdenes =Origen.CantidadOrdenes
WHEN NOT MATCHED THEN 
            INSERT
			(DimFechaID, DimProductID, DimSupplierID, DimCategoryID,
			 Cantidad, Descuento, CantidadDescuento, CantidadOrdenes)
			 Values
			 (Origen.DimFechaID,Origen.DimProductID, Origen.DimSupplierID,
			 Origen.DimCategoryID,Origen.Cantidad, Origen.Descuento, Origen.CantidadDescuento, Origen.CantidadOrdenes);

			 -- Verificación
			 select * from HechosVentas*/