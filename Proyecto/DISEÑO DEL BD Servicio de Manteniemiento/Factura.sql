use Servicios_de_mantenimiento

go

CREATE FUNCTION Suma_Servicios(@IdMantenimiento int)
RETURNS money
AS
BEGIN
DECLARE @Suma money
SET @Suma = (SELECT SUM(dm.Precio) FROM Detalle_Mantenimiento dm WHERE dm.IdMantenimiento = @IdMantenimiento)
RETURN @Suma
END

go

CREATE PROCEDURE Factura_Detalle_Servicios
@IdMantenimiento int
AS
BEGIN
	SELECT
	s.IdServicio as Referencia,
	s.Descripción as Descripcion,
	dm.Precio as Importe
	FROM Detalle_Mantenimiento dm
	inner join Servicio s
	on dm.IdServicio = s.IdServicio
	WHERE dm.IdMantenimiento = @IdMantenimiento
END

-- exec Factura_Detalle_Servicios 3
-- select * from Detalle_Mantenimiento
-- select * from Servicio

go

CREATE PROCEDURE Factura_Detalle_Repuestos @IdMantenimiento int
AS
BEGIN
	SELECT
	r.IdRepuesto as Referencia,
	r.Descripcion as Descripcion,
	r.Marca as Marca,
	r.Modelo as Modelo,
	dr.Cantidad as Cantidad,
	r.Precio as C_Unitario,
	SUM(dr.Cantidad * r.Precio) as Importe
	FROM Detalle_Mantenimiento dm
	left join Detalle_Repuesto dr
	on dm.IDDetalle_Mantenimiento = dr.IDDetalle_Mantenimiento
	inner join Repuesto r
	on dr.IdRepuesto = r.IdRepuesto
	WHERE dm.IdMantenimiento = @IdMantenimiento
	GROUP BY r.IdRepuesto,  r.Descripcion, r.Marca, r.Modelo, dr.Cantidad, r.Precio
END

-- exec Factura_Detalle_Repuestos 1

/*select * from Detalle_Repuesto
select * from Repuesto
select * from Detalle_Mantenimiento*/

go

create PROCEDURE Factura_Header
@IdMantenimiento int

AS
BEGIN
	SELECT
	m.IdMantenimiento as IdFactura,
	c.[Primer Nombre] + ' ' + c.[Primer Apellido] as Cliente,
	v.Marca as Marca,
	v.Modelo as Modelo,
	v.Año as Año,
	m.Fecha_Ingreso as Entrada,
	m.Fecha_Salida as Salida,
	GETDATE() as Impreso,
	dbo.Suma_Servicios(@IdMantenimiento) as TotalServicios,
	ISNULL(SUM(dr.Cantidad * r.Precio), 2) as TotalRepuestos,
	ROUND(dbo.Suma_Servicios(@IdMantenimiento) + ISNULL(SUM(dr.Cantidad * r.Precio), 2),2) as SubTotal,
	ROUND((dbo.Suma_Servicios(@IdMantenimiento) + ISNULL(SUM(dr.Cantidad * r.Precio), 2) ) * 0.15 ,2)as IVA,
	ROUND((dbo.Suma_Servicios(@IdMantenimiento) + ISNULL(SUM(dr.Cantidad * r.Precio), 2)) * 1.15,2) as Total

	FROM Mantenimiento m
	inner join Vehículo v
	on m.IDVehículo = v.IDVehículo
	inner join Cliente c
	on v.IdCliente = c.IdCliente
	inner join Detalle_Mantenimiento dm
	on m.IdMantenimiento = dm.IdMantenimiento
	left join Detalle_Repuesto dr
	on dm.IDDetalle_Mantenimiento = dr.IDDetalle_Mantenimiento
	left join Repuesto r
	on dr.IDRepuesto = r.IDRepuesto
	WHERE m.IdMantenimiento = @IdMantenimiento
	GROUP BY m.IdMantenimiento, c.[Primer Nombre] + ' ' + c.[Primer Apellido], v.Marca, v.Modelo, v.Año, m.Fecha_Ingreso, m.Fecha_Salida
END

-- EXEC Factura_Header 1