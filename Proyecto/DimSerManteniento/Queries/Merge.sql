use DimSerMantenimiento
go

-- Carga de Tabla de Hechos
-------------------------------------------------------------
Merge dbo.HechosMantenimientos Destino
Using

(Select 
df.DimFechaID as DimFechaID,
dc.DimIdCliente as DimClienteID,
dv.DimIdVeh�culo as DimVehiculoID,
ds.DimIdServicio as DimServicioID,
dme.DimIdMec�nico as DimMecanicoID,
dr.DimIdRepuesto as DimRepuestoID,
sdm.Precio as Precio
from Servicios_de_mantenimiento.dbo.Mantenimiento sma
inner join Servicios_de_mantenimiento.dbo.Detalle_Mantenimiento sdm
on sdm.IdMantenimiento = sma.IdMantenimiento
inner join Servicios_de_mantenimiento.dbo.Detalle_Repuesto sdr
on sdr.IdDetalle_Mantenimiento = sdm.IdDetalle_Mantenimiento
inner join  DimFechas df
on df.IDFecha = sma.Fecha_Ingreso
inner join DimVeh�culo dv
on dv.IdVeh�culo = sma.IdVeh�culo
inner join DimCliente dc
on dc.IdCliente = dv.IdCliente
inner join DimMec�nico dme
on dme.IdMec�nico = sdm.IdMec�nico
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
dv.DimIdVeh�culo,
ds.DimIdServicio,
dme.DimIdMec�nico,
dr.DimIdRepuesto) Origen
on
Destino.DimIdCliente = Origen.DimClienteID and
Destino.DimIdVeh�culo = Origen.DimVehiculoID and
Destino.DimIdServicio = Origen.DimServicioID and
Destino.DimIdMec�nico = Origen.DimMecanicoID and
Destino.DimIdRepuesto = Origen.DimRepuestoID and
Destino.DimFechaID = Origen.DimFechaID
when matched and (Destino.Precio <> Origen.Precio)
					then 
					update set
					Destino.Precio = Origen.Precio
when not matched then
			insert (DimIdCliente, DimIdServicio, DimFechaID, DimIdMec�nico, DimIdVeh�culo,
			DimIdRepuesto, Precio)
			values
			(Origen.DimClienteID, Origen.DimServicioID, Origen.DimFechaID, Origen.DimMecanicoID,
			Origen.DimVehiculoID, Origen.DimRepuestoID, Origen.Precio);