use DimSerMantenimiento
go

-- Carga de Tabla de Hechos
-------------------------------------------------------------
Merge dbo.HechosMantenimientos Destino
Using

(Select 
df.DimFechaID as DimFechaID,
dc.DimIdCliente as DimClienteID,
dv.DimIdVehículo as DimVehiculoID,
ds.DimIdServicio as DimServicioID,
dme.DimIdMecánico as DimMecanicoID,
dr.DimIdRepuesto as DimRepuestoID,
sdm.Precio as Precio
from Servicios_de_mantenimiento.dbo.Mantenimiento sma
inner join Servicios_de_mantenimiento.dbo.Detalle_Mantenimiento sdm
on sdm.IdMantenimiento = sma.IdMantenimiento
inner join Servicios_de_mantenimiento.dbo.Detalle_Repuesto sdr
on sdr.IdDetalle_Mantenimiento = sdm.IdDetalle_Mantenimiento
inner join  DimFechas df
on df.IDFecha = sma.Fecha_Ingreso
inner join DimVehículo dv
on dv.IdVehículo = sma.IdVehículo
inner join DimCliente dc
on dc.IdCliente = dv.IdCliente
inner join DimMecánico dme
on dme.IdMecánico = sdm.IdMecánico
inner join DimServicio ds
on ds.IdServicio = sdm.IdServicio
inner join DimRepuesto dr
on dr.IdRepuesto = sdr.IdRepuesto
where dc.FechaFinal='9999/12/31' AND 
	  dv.FechaFinal='9999/12/31' AND 
	  ds.FechaFinal='9999/12/31' AND 
	  dme.FechaFinal='9999/12/31' AND 
	  dr.FechaFinal='9999/12/31'

group by
df.DimFechaID,
dc.DimIdCliente,
dv.DimIdVehículo,
ds.DimIdServicio,
dme.DimIdMecánico,
dr.DimIdRepuesto) Origen
on
Destino.DimIdCliente = Origen.DimClienteID and
Destino.DimIdVehículo = Origen.DimVehiculoID and
Destino.DimIdServicio = Origen.DimServicioID and
Destino.DimIdMecánico = Origen.DimMecanicoID and
Destino.DimIdRepuesto = Origen.DimRepuestoID and
Destino.DimFechaID = Origen.DimFechaID
when matched and (Destino.Precio <> Origen.Precio)
					then 
					update set
					Destino.Precio = Origen.Precio
when not matched then
			insert (DimIdCliente, DimIdServicio, DimFechaID, DimIdMecánico, DimIdVehículo,
			DimIdRepuesto, Precio)
			values
			(Origen.DimClienteID, Origen.DimServicioID, Origen.DimFechaID, Origen.DimMecanicoID,
			Origen.DimVehiculoID, Origen.DimRepuestoID, Origen.Precio);