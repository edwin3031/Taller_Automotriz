use Servicios_de_mantenimiento

go

create view DimVehículo
as
select v.IdVehículo,
v.Marca,
v.Modelo,
c.[Primer Nombre] + ' ' + c.[Primer Apellido] as [Nombre de Cliente] 
from Vehículo v
inner join Cliente c
on v.IdCliente = c.IdCliente

-- select * from DimVehículoActualizado
go

create view DimFecha
as 
select distinct m.Fecha_Ingreso,
YEAR(m.Fecha_Ingreso) as Año,
MONTH(m.Fecha_Ingreso) as NoMes,
DAY(m.Fecha_Ingreso) as NoDía,
DATEPART(qq, m.Fecha_Ingreso) as Trimestre
from Mantenimiento m

-- select * from DimFecha

go

create view DimMecánico
as
select m.IdMecánico,
m.[Primer Nombre] + ' ' + m.[Primer Apellido] as [Nombre de Mecánico],
m.Salario,
m.Especialidad,
m.Estado
from Mecánico m

-- select * from DimMecánico
go

create view DimRepuesto
as
select * from Repuesto

--select * from DimRepuesto
go

create view FactMateniminto
as
select m.IdMantenimiento as [No Factura],
c.[Primer Nombre] + ' ' + c.[Primer Apellido] as [Cliente],
v.Marca + ' ' + v.Modelo as [Vehículo],
m.Fecha_Ingreso as [Fecha de Ingreo],
m.Fecha_Salida as [Fecha de Salida],
COUNT(dm.IdDetalle_Mantenimiento) as [Cantidad de Servicios],
(select COUNT(*) from Detalle_Repuesto dr
where dr.IdDetalle_Mantenimiento = dm.IdDetalle_Mantenimiento) as [Cantidad de Respuestos],
dm.Precio as [Precio Total]
from Detalle_Mantenimiento dm
inner join Mantenimiento m
on m.IdMantenimiento = dm.IdMantenimiento
inner join Vehículo v
on m.IdVehículo = v.IdVehículo
inner join Cliente c
on c.IdCliente = v.IdCliente
inner join Mecánico me
on dm.IdMecánico = me.IdMecánico
inner join Servicio s
on dm.IdServicio = s.IdServicio
group by
m.IdVehículo,
v.Marca,
v.Modelo,
c.[Primer Nombre],
c.[Primer Apellido],
m.Fecha_Ingreso,
m.Fecha_Salida,
m.IdMantenimiento,
dm.IdDetalle_Mantenimiento,
c.IdCliente,
dm.IdMecánico,
dm.IdServicio,
dm.Precio

--select * from FactMateniminto