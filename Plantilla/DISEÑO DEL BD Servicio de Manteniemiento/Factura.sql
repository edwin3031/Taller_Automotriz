ALTER PROCEDURE Factura_Header @IdMantenimiento int
AS
BEGIN
SELECT
m.IdMantenimiento as IdFactura,
c.PrimerNombre + ' ' + c.PrimerApellido as Cliente,
v.Marca as Marca,
v.Modelo as Modelo,
v.Año as Año,
m.FechaIngreso as Entrada,
m.FechaSalida as Salida,
GETDATE() as Impreso,
dbo.Suma_Servicios(@IdMantenimiento) as TotalServicios,
ISNULL(SUM(dr.Cantidad * dr.Precio), 2) as TotalRepuestos,
ROUND(dbo.Suma_Servicios(@IdMantenimiento) + ISNULL(SUM(dr.Cantidad * dr.Precio), 2),2) as SubTotal,
ROUND((dbo.Suma_Servicios(@IdMantenimiento) + ISNULL(SUM(dr.Cantidad * dr.Precio), 2) ) * 0.15 ,2)as IVA,
ROUND((dbo.Suma_Servicios(@IdMantenimiento) + ISNULL(SUM(dr.Cantidad * dr.Precio), 2)) * 1.15,2) as Total

FROM Mantenimiento m
inner join Vehiculo v
on m.IdVehiculo = v.IdVehiculo
inner join Cliente c
on v.IdCliente = c.IdCliente
inner join Detalle_Mantenimiento dm
on m.IdMantenimiento = dm.IdMantenimiento
left join Detalle_Repuesto dr
on dm.IdDetalleMantenimiento = dr.IdDetalleMantenimiento
WHERE m.IdMantenimiento = @IdMantenimiento
GROUP BY m.IdMantenimiento, c.PrimerNombre + ' ' + c.PrimerApellido, v.Marca, v.Modelo, v.Año, m.FechaIngreso, m.FechaSalida
END

CREATE FUNCTION Suma_Servicios(@IdMantenimiento int)
RETURNS money
AS
BEGIN
DECLARE @Suma money
SET @Suma = (SELECT SUM(dm.Precio) FROM Detalle_Mantenimiento dm WHERE dm.IdMantenimiento = @IdMantenimiento)
RETURN @Suma
END

CREATE PROCEDURE Factura_Detalle_Servicios @IdMantenimiento int
AS
BEGIN
SELECT
s.IdServicio as Referencia,
s.Descripcion as Descripcion,
dm.Precio as Importe
FROM Detalle_Mantenimiento dm
inner join Servicio s
on dm.IdServicio = s.IdServicio
WHERE dm.IdMantenimiento = @IdMantenimiento
END

CREATE PROCEDURE Factura_Detalle_Repuestos @IdMantenimiento int
AS
BEGIN
SELECT
r.IdRepuesto as Referencia,
r.Descripcion as Descripcion,
r.Marca as Marca,
r.Modelo as Modelo,
dr.Cantidad as Cantidad,
dr.Precio as C_Unitario,
SUM(dr.Cantidad * dr.Precio) as Importe
FROM Detalle_Mantenimiento dm
left join Detalle_Repuesto dr
on dm.IdDetalleMantenimiento = dr.IdDetalleMantenimiento
inner join Repuesto r
on dr.IdRepuesto = r.IdRepuesto
WHERE dm.IdMantenimiento = @IdMantenimiento
GROUP BY r.IdRepuesto,  r.Descripcion, r.Marca, r.Modelo, dr.Cantidad, dr.Precio
END

EXEC Factura_Header 5
EXEC Factura_Detalle_Servicios 5
EXEC Factura_Detalle_Repuestos 5