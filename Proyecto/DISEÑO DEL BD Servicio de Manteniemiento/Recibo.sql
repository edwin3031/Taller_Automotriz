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

CREATE PROCEDURE Recibo_Detalle_Servicios
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

-- exec Recibo_Detalle_Servicios 1
-- select * from Detalle_Mantenimiento
-- select * from Servicio

go

CREATE PROCEDURE Recibo_Detalle_Repuestos @IdMantenimiento int
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

-- exec Recibo_Detalle_Repuestos 1

/*select * from Detalle_Repuesto
select * from Repuesto
select * from Detalle_Mantenimiento*/

go

create PROCEDURE Recibo_Header
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

-- EXEC Recibo_Header 1


go

-- Stored Procedures original backup

create PROCEDURE [dbo].[Recaudacion_Servicio]
@Año int, @Mes int
AS
IF exists (
           SELECT 
           Fecha_Salida
           FROM Mantenimiento
           WHERE YEAR(Fecha_Salida) = @Año and MONTH(Fecha_Salida) = @Mes
           )
SELECT
s.IdServicio as IdServicio,
s.Descripción as Servicio,
s.Tipo_Mantenimiento as [Tipo de Mantenimiento],
COUNT(dm.IdServicio) as [Aplicaciones],
ROUND(SUM(dm.Precio),2) as [Total del servicio],
ROUND((SUM(dm.Precio) / 
                      (SELECT 
                      SUM(dm2.Precio) as TotalServicio
                      FROM Mantenimiento m2
                      inner join Detalle_Mantenimiento dm2
                      on m2.IdMantenimiento = dm2.IdMantenimiento
                      WHERE YEAR(m2.Fecha_Salida) = @Año and MONTH(m2.Fecha_Salida) = @Mes)) * 100
  ,2) as [% Total]FROM Detalle_Mantenimiento dm
inner join Servicio s
on dm.IdServicio = s.IdServicio
inner join Mantenimiento m
on dm.IdMantenimiento = m.IdMantenimiento
WHERE YEAR(m.Fecha_Salida) = @Año and MONTH(m.Fecha_Salida) = @Mes and m.Estado = 'Facturado'
GROUP BY dm.IdMantenimiento, s.IdServicio, s.Descripción, s.Tipo_Mantenimiento

ELSE
BEGIN
   IF not exists (
           SELECT 
           Fecha_Salida
           FROM Mantenimiento
           WHERE YEAR(Fecha_Salida) = @Año 
           )
	BEGIN
	SELECT 'Año no encontrado' as Mensaje
	END
	ELSE
	BEGIN
	SELECT 'Mes no encontrado' as Mensaje
	END
END

/*select * from Detalle_Repuesto
select * from repuesto
select * from Mantenimiento
select * from Detalle_Mantenimiento
-- @Anio, @Mes
exec Recaudacion_Servicio 2021,11
*/

GO
	create procedure [dbo].[Recaudacion_Repuesto]
	@Año int, @Mes int
	as
	declare @total decimal
	set @total=(select sum((drs.Cantidad * rs.Precio)) from Detalle_Repuesto drs
	inner join Repuesto rs on rs.IdRepuesto = drs.IdRepuesto
	inner join Detalle_Mantenimiento dms on 
	dms.IdDetalle_Mantenimiento=drs.IdDetalle_Mantenimiento
	inner join Mantenimiento ms on 
	ms.IdMantenimiento=dms.IdMantenimiento
	where 
	ms.Estado = 'Facturado' and YEAR(ms.Fecha_Salida) = @Año and MONTH(ms.Fecha_Salida) = @Mes
	)

	select 
	r.Descripcion ,
	r.Marca,
	r.Modelo,
	Count( dr.IdRepuesto)Aplicaciones,
	sum(dr.Cantidad * r.Precio) Recaudacion,

	cast( round (sum( ((dr.Cantidad * r.Precio) * 100)/@total),2) as varchar)+'%' as Porcentaje

	from Detalle_Repuesto dr 

	inner join Detalle_Mantenimiento dm on 
	dm.IdDetalle_Mantenimiento=dr.IdDetalle_Mantenimiento
	inner join Mantenimiento m on 
	m.IdMantenimiento=dm.IdMantenimiento
	inner join Repuesto r 
	on dr.IdRepuesto=r.IdRepuesto
	where 
	m.Estado = 'Facturado' and YEAR(m.Fecha_Salida) = @Año and MONTH(m.Fecha_Salida) = @Mes
	group by  r.Descripcion,r.Marca,r.Modelo

GO

/*
select * from Mantenimiento
select * from Detalle_Mantenimiento
select * from Repuesto
-- @anio, @mes
exec Recaudacion_Repuesto 2021, 11
*/


create PROCEDURE [dbo].[Recaudacion_Mantenimientos]
@Año int, @Mes int
AS
IF exists (
           SELECT 
           Fecha_Salida
           FROM Mantenimiento
           WHERE YEAR(Fecha_Salida) = @Año and MONTH(Fecha_Salida) = @Mes
           )
			SELECT 
			v.Marca as Marca,
			v.Modelo as Modelo,
			m.Fecha_Ingreso,
			m.Fecha_Salida,
			count(dm.IdServicio) as Servicio,
			isnull(SUM(dr.Cantidad),0) as Repuestos,
			isnull( SUM( dr.Cantidad * r.Precio) + SUM(dm.Precio) , SUM(dm.Precio))as TOTAL
			FROM Detalle_Repuesto dr
			inner join Repuesto r
			on dr.IdRepuesto = r.IdRepuesto
			inner join  Detalle_Mantenimiento dm
			on dr.IdDetalle_Mantenimiento = dm.IdDetalle_Mantenimiento
			inner join Mantenimiento m
			on dm.IdMantenimiento = m.IdMantenimiento
			inner join Vehículo v
			on m.IdVehículo = v.IdVehículo
			WHERE YEAR(m.Fecha_Salida) = @Año and MONTH(m.Fecha_Salida) = @Mes and m.Estado = 'Facturado'
			GROUP BY dm.IdMantenimiento,v.Marca,v.Modelo,m.Fecha_Ingreso,m.Fecha_Salida --, dm.IdDetalleMantenimiento

ELSE
		SELECT 'Mes no encontrado'


/*select * from Mantenimiento
select * from Detalle_Mantenimiento
select * from Repuesto
Select * from Vehículo
@anio, @mes
exec Recaudacion_Mantenimientos 2021,11*/