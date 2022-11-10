use Servicios_de_mantenimiento

go

create view DimVeh�culo
as
select v.IdVeh�culo,
v.Marca,
v.Modelo,
c.[Primer Nombre] + ' ' + c.[Primer Apellido] as [Nombre de Cliente] 
from Veh�culo v
inner join Cliente c
on v.IdCliente = c.IdCliente

-- select * from DimVeh�culoActualizado
go

create view DimFecha
as 
select distinct m.Fecha_Ingreso,
YEAR(m.Fecha_Ingreso) as A�o,
MONTH(m.Fecha_Ingreso) as NoMes,
DAY(m.Fecha_Ingreso) as NoD�a,
DATEPART(qq, m.Fecha_Ingreso) as Trimestre
from Mantenimiento m

-- select * from DimFecha

go

create view DimMec�nico
as
select m.IdMec�nico,
m.[Primer Nombre] + ' ' + m.[Primer Apellido] as [Nombre de Mec�nico],
m.Salario,
m.Especialidad,
m.Estado
from Mec�nico m

-- select * from DimMec�nico
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
v.Marca + ' ' + v.Modelo as [Veh�culo],
m.Fecha_Ingreso as [Fecha de Ingreo],
m.Fecha_Salida as [Fecha de Salida],
COUNT(dm.IdDetalle_Mantenimiento) as [Cantidad de Servicios],
(select COUNT(*) from Detalle_Repuesto dr
where dr.IdDetalle_Mantenimiento = dm.IdDetalle_Mantenimiento) as [Cantidad de Respuestos],
dm.Precio as [Precio Total]
from Detalle_Mantenimiento dm
inner join Mantenimiento m
on m.IdMantenimiento = dm.IdMantenimiento
inner join Veh�culo v
on m.IdVeh�culo = v.IdVeh�culo
inner join Cliente c
on c.IdCliente = v.IdCliente
inner join Mec�nico me
on dm.IdMec�nico = me.IdMec�nico
inner join Servicio s
on dm.IdServicio = s.IdServicio
group by
m.IdVeh�culo,
v.Marca,
v.Modelo,
c.[Primer Nombre],
c.[Primer Apellido],
m.Fecha_Ingreso,
m.Fecha_Salida,
m.IdMantenimiento,
dm.IdDetalle_Mantenimiento,
c.IdCliente,
dm.IdMec�nico,
dm.IdServicio,
dm.Precio

--select * from FactMateniminto