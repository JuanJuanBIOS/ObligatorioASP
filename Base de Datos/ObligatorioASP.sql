use master
go

--------------------------
if exists(select * from sysdatabases where name = 'Alquileres_Vehiculos')
begin
	drop database Alquileres_Vehiculos
end
go

--creo la base de datos
create database Alquileres_Vehiculos
go


--selecciono la base de datos
use Alquileres_Vehiculos
go



-- ------------------------------------------------------------------------------------------------
-- CREACIÓN DE TABLAS 
-- ------------------------------------------------------------------------------------------------

-- Se crea la tabla de clientes
create table Clientes(
documento int not null primary key,
tarjeta bigint not null unique,
nombre varchar(30) not null,
direccion varchar(50),
telefono varchar(30),
fechanac datetime not null,
)

-- Se crea la tabla vehículos
create table Vehiculos(
matricula varchar(7) not null primary key,
marca varchar(30),
modelo varchar(30),
anio int,
cant_puertas int,
costodiario int,
categoria varchar(10),
)

--Se crea la tabla Autos
create table Autos(
matricula varchar(7) not null foreign key references Vehiculos(matricula),
anclaje varchar(8),
)

-- Se crea la tabla utilitarios
create table Utilitarios(
matricula varchar(7) not null foreign key references Vehiculos(matricula),
capacidad int,
tipo varchar(9),
)

-- Se crea la tabla alquileres
create table Alquileres(
idAlquiler int identity(1,1) NOT NULL PRIMARY KEY,
vehiculo varchar(7) not null foreign key references Vehiculos(matricula),
cliente int not null foreign key references Clientes(documento),
fechainicio datetime not null,
fechafin datetime not null,
costo int not null,
)

-- -----------------------------------------------------------------------------------------------
-- CARGA DE DATOS INICIALES PARA PRUEBAS
-- -----------------------------------------------------------------------------------------------

-- Se agregan datos a la tabla Clientes
INSERT INTO Clientes VALUES
(3155160,4967296361175687,'Juan Perez','Avenida Italia 1548','45863458','12/15/1988'),
(4167344,3393430860568847,'Maria Gonzalez','Garibaldi 2453','098321548','01/24/1968'),
(3809175,375659812386472,'Santiago Rodriguez','Bvar Artigas 1483','26138597','07/14/1957'),
(4598108,6248315518673216,'Nicolas Lopez','Rivera 5427', '091653287','04/03/1984'),
(1914310,5019021263067369,'Valeria Rodriguez','Sarandi 254','52376981','09/18/1954'),
(2548635,6372326355114261,'Ana Martinez','18 de Julio 1236','095634888','10/14/1990'),
(1248963,6901506975192728,'Pedro Artigas','Sarandi 126','096324657','03/05/1975'),
(2586951,5380502970150763,'Julio Sanchez','8 de Octubre 5498','26138597','09/04/1945')


-- Se agregan datos a la tabla Vehículos
INSERT INTO Vehiculos VALUES
('AAA1111','Suzuki','Alto',2014,4,21.3,'Auto'),
('BBB2222','Chevrolet','Onix',2015,4,20,'Auto'),
('CCC3333','ByD','F0',2016,4,18.5,'Auto'),
('DDD4444','VW','Up',2014,4,21.3,'Auto'),
('EEE5555','VW','Up',2016,4,21.3,'Auto'),
('FFF6666','Ford','Fiesta',2014,4,21.3,'Auto'),
('GGG7777','Citroen','Berlingo',2009,5,25,'Utilitario'),
('HHH8888','Fiat','Fiorino',2010,5,23.2,'Utilitario'),
('III9999','Chevrolet','S10',2013,2,26.4,'Utilitario'),
('JJJ1010','Ford','Ranger',2014,4,27.8,'Utilitario'),
('KKK1111','Ford','Ranger',2016,2,27.8,'Utilitario'),
('LLL1212','Toyota','Hilux',2009,4,27.8,'Utilitario')

-- Se agregan datos a la tabla Autos
INSERT INTO Autos VALUES
('AAA1111','ISOFIX'),
('BBB2222','Cinturón'),
('CCC3333','ISOFIX'),
('DDD4444','Latch'),
('EEE5555','Latch'),
('FFF6666','ISOFIX')

-- Se agregan datos a la tabla Utilitarios
INSERT INTO Utilitarios VALUES
('GGG7777',500,'Furgoneta'),
('HHH8888',450,'Furgoneta'),
('III9999',1050,'Pickup'),
('JJJ1010',1200,'Pickup'),
('KKK1111',1100,'Pickup'),
('LLL1212',1250,'Pickup')

-- Se agregan datos a la tabla Alquileres
INSERT INTO Alquileres VALUES
('CCC3333',3155160,'12/01/2017','12/15/2017',380),
('AAA1111',4598108,'10/02/2017','10/08/2017',150)

go

-- -----------------------------------------------------------------------------------------------
-- CREACIÓN DE STORED PROCEDURES
-- -----------------------------------------------------------------------------------------------

-- ***********************************************************************************************
-- CLIENTES
-- ***********************************************************************************************

CREATE PROCEDURE Buscar_Cliente
--Se define la variable de entrada para la consulta
@documento varchar(15)
as
begin
--Se verifica que existe cliente
if not exists(select * from Clientes where documento=@documento)
	begin
	return -1
	end
else
	begin
	select * from Clientes where documento=@documento
	end
End
go

 --Creo procedimiento para crear cliente
CREATE PROCEDURE Crear_Cliente @documento int ,@tarjeta bigint, @nombre varchar(30), @direccion varchar(50), @telefono varchar(30),
                                     @fechanac datetime AS
Begin
	if (EXISTS(Select * From Clientes Where documento = @documento))
		return -1
		
	--si llego aca puedo crear
	INSERT Clientes (documento, tarjeta, nombre, direccion, telefono, fechanac) VALUES(@documento, @tarjeta, @nombre, @direccion, @telefono, @fechanac) 
	IF(@@Error=0)
		RETURN 1
	else
		RETURN -2
End
go

--Prueba de procedimiento
 Crear_Cliente 4167345, 4967296361175688, 'Juan Manuel Perez','Avenida Italia 1548','45863458','2/1/1988'
 go

create procedure Modificar_Cliente	@documento int ,@tarjeta bigint, @nombre varchar(30), @direccion varchar(50), @telefono varchar(30),
                                     @fechanac datetime AS
begin 
	if Not(EXISTS (SELECT * FROM Clientes WHERE documento=@documento))
	begin
		return -1
		print 'El cliente no existe'
	end
	--Si se encontró cliente:
	UPDATE Clientes 
	SET tarjeta = @tarjeta, nombre = @nombre, direccion = @direccion, telefono = @telefono, fechanac=@fechanac
	WHERE documento = @documento
	
	IF(@@Error=0)
	begin
		print 'Se realizo correctamente la modificacion'
		RETURN 1
	end
	ELSE
	begin
		print 'No se realizo la modificacion'
		RETURN 0
	end

End
go
--Prueba de procedimiento
 --Modificar_Cliente 4167344, 4967296361175688, 'Juan Manuel Perez','Avenida Italia 1548','45863458','2/1/1988'




 --Creo procedimiento para eliminación de Cliente
 CREATE PROCEDURE Eliminar_Cliente @documento int ,@tarjeta bigint, @nombre varchar(30), @direccion varchar(50), @telefono varchar(30),
                                     @fechanac datetime AS
Begin
	if (EXISTS(Select * From Clientes Where documento = @documento))
	begin
		return -1
		print 'El cliente ya existe'
	end
		
INSERT INTO Clientes VALUES (@documento, @tarjeta, @nombre, @direccion, @telefono, @fechanac)
	
	IF(@@Error=0)
		RETURN 1
	ELSE
		RETURN -3
End

--Prueba de procedimiento
 --Eliminar_Cliente 4167344





-- ***********************************************************************************************
-- AUTOS
-- ***********************************************************************************************


--Se crea procedimiento para búsqueda de Auto
create procedure Buscar_Auto
@matricula varchar(7)
as
begin
if not exists(select * from Vehiculos where matricula=@matricula)
	begin
	return -1
	end
else
	begin
	select Vehiculos.*, Autos.anclaje from Vehiculos, Autos
where (Vehiculos.matricula=@matricula and Vehiculos.matricula=Autos.matricula)
	end
end
go

-- Se crea procedimiento para crear auto
create procedure Crear_Auto
@matricula varchar(7), @marca varchar(30), @modelo varchar(30),@anio int, @cant_puertas int,
@costodiario int,@categoria varchar(10),@anclaje varchar(8)
as
begin
if exists (select * from Vehiculos where matricula = @matricula)
	return -1

begin tran
insert Vehiculos values (@matricula, @marca, @modelo, @anio, @cant_puertas, @costodiario, @categoria)

insert Autos values (@matricula, @anclaje)

if @@ERROR<>0
	begin
		rollback transaction
		return -2
	end
else
	begin
		commit transaction
		return 1
	end
end
go

-- Se crea procedimiento para modificar auto
create procedure Modificar_Auto
@matricula varchar(7), @marca varchar(30), @modelo varchar(30),@anio int, @cant_puertas int,
@costodiario int,@categoria varchar(10),@anclaje varchar(8)
as
begin
if not exists (select * from Vehiculos where matricula = @matricula)
	return -1

if not exists (select * from Autos where matricula = @matricula)
	return -2
	
begin tran
update Autos
set anclaje = @anclaje
where matricula = @matricula;

update Vehiculos
set marca = @marca, modelo = @modelo, anio = @anio, cant_puertas = @cant_puertas, 
	costodiario = @costodiario
where matricula = @matricula;

if @@ERROR<>0
	begin
		rollback transaction
		return -3
	end
else
	begin
		commit transaction
		return 1
	end
end
go


-- Se crea procedimiento para eliminar Auto
create procedure Eliminar_Auto
-- Se define la variable de entrada al proceso, la cual va a ser la matrícula del vehículo
@matricula varchar(7)
as
-- Se chequea que exista la matrícula en la base de datos, y si no existe se muestra el error
if not exists(select * from Vehiculos where matricula=@matricula)
	return -1
-- Se chequea qeu el vehículo que se desea almacenar no posea ningún alquiler asociado, si lo posee se muestra el error
if exists(select * from Alquileres where vehiculo=@matricula)
	return -2

begin transaction
	-- Se elimina el registro de la tabla Autos
	delete from Autos where Autos.matricula=@matricula
	--Se elimina el registro de la tabla vehículos
	delete from Vehiculos where Vehiculos.matricula=@matricula
	-- Si se produce algún error al hacer lo anterior se hace el rollback
if @@ERROR<>0
begin
	rollback transaction
	return -3
end
else
begin
	commit transaction
	return 1
end
go



-- ***********************************************************************************************
-- UTILITARIOS
-- ***********************************************************************************************


--Se crea procedimiento para búsqueda de Utilitario
create procedure Buscar_Utilitario
@matricula varchar(7)
as
begin
if not exists(select * from Vehiculos where matricula=@matricula)
	begin
	return -1
	end
else
	begin
	select Vehiculos.*, Utilitarios.capacidad, Utilitarios.tipo from Vehiculos, Utilitarios
where (Vehiculos.matricula=@matricula and Vehiculos.matricula=Utilitarios.matricula)
	end
end
go


-- Se crea procedimiento para crear utilitario
create procedure Crear_Utilitario
@matricula varchar(7), @marca varchar(30), @modelo varchar(30),@anio int, @cant_puertas int,
@costodiario int,@categoria varchar(10),@capacidad int, @tipo varchar(9)
as
begin
if exists (select * from Vehiculos where matricula = @matricula)
	return -1

begin tran
insert Vehiculos values (@matricula, @marca, @modelo, @anio, @cant_puertas, @costodiario, @categoria)

insert Utilitarios values (@matricula, @capacidad, @tipo)

if @@ERROR<>0
	begin
		rollback transaction
		return -2
	end
else
	begin
		commit transaction
		return 1
	end
end
go

-- Se crea procedimiento para modificar utilitario
create procedure Modificar_Utilitario
@matricula varchar(7), @marca varchar(30), @modelo varchar(30),@anio int, @cant_puertas int,
@costodiario int,@categoria varchar(10),@capacidad int, @tipo varchar(9)
as
begin
if not exists (select * from Vehiculos where matricula = @matricula)
	return -1

if not exists (select * from Utilitarios where matricula = @matricula)
	return -2
	
begin tran
update Utilitarios
set capacidad = @capacidad, tipo = @tipo
where matricula = @matricula;

update Vehiculos
set marca = @marca, modelo = @modelo, anio = @anio, cant_puertas = @cant_puertas, 
	costodiario = @costodiario
where matricula = @matricula;

if @@ERROR<>0
	begin
		rollback transaction
		return -3
	end
else
	begin
		commit transaction
		return 1
	end
end
go


-- Se crea procedimiento para eliminar Utilitario
create procedure Eliminar_Utilitario
-- Se define la variable de entrada al proceso, la cual va a ser la matrícula del vehículo
@matricula varchar(7)
as
-- Se chequea que exista la matrícula en la base de datos, y si no existe se muestra el error
if not exists(select * from Vehiculos where matricula=@matricula)
	return -1
-- Se chequea qeu el vehículo que se desea almacenar no posea ningún alquiler asociado, si lo posee se muestra el error
if exists(select * from Alquileres where vehiculo=@matricula)
	return -2

begin transaction
	-- Se elimina el registro de la tabla Utilitarios
	delete from Utilitarios where Utilitarios.matricula=@matricula
	--Se elimina el registro de la tabla vehículos
	delete from Vehiculos where Vehiculos.matricula=@matricula
	-- Si se produce algún error al hacer lo anterior se hace el rollback
if @@ERROR<>0
begin
	rollback transaction
	return -3
end
else
begin
	commit transaction
	return 1
end
go


-- ***********************************************************************************************
-- ALQUILERES
-- ***********************************************************************************************


-- Se crea procedimiento para consultar posibles errores al realizar un alquiler
create procedure Consultar_Alquiler
-- Se definen las variables de entrada al proceso
@matricula varchar(7),
@cedula varchar(15),
@fechainicio datetime,
@fechafin datetime,
@costo int
as
-- Se chequea que exista la matrícula en la base de datos, y si no existe se muestra el error
if not exists(select * from Vehiculos where matricula=@matricula)
	begin
		return -1
	end
-- Se chequea que exista el cliente en la base de datos, y si no existe se muestra el error
else if not exists(select * from Clientes where documento=@cedula)
	begin
		return -2
	end
-- Se chequea que la fecha de inicio no sea anterior al dia de hoy
else if (@fechainicio<convert(date,GETDATE()))
	begin
		return -3
	end
-- Se chequea que la fecha de fin sea posterior a la fecha de inicio
else if (@fechainicio>=@fechafin)
	begin
		return -4
	end
-- Se chequea que el vehículo que se desea alquilar no se encuentre alquilado en las fechas solicitadas
else if	(exists (select * from Alquileres where (Alquileres.vehiculo=@matricula and @fechafin<=Alquileres.fechafin and @fechafin>=Alquileres.fechainicio)) or
	exists (select * from Alquileres where (Alquileres.vehiculo=@matricula and @fechainicio<=Alquileres.fechafin and @fechainicio>=Alquileres.fechainicio)) or
	exists (select * from Alquileres where (Alquileres.vehiculo=@matricula and @fechainicio<=Alquileres.fechainicio and @fechafin>=Alquileres.fechafin)))
	begin
		return -5
	end
else
	return 1
go


-- Se crea procedimiento para confirmar un alquiler
create procedure Confirmar_Alquiler
-- Se definen las variables de entrada al proceso
@matricula varchar(7),
@cedula varchar(15),
@fechainicio datetime,
@fechafin datetime,
@costo int
as
-- Se chequea que exista la matrícula en la base de datos, y si no existe se muestra el error
if not exists(select * from Vehiculos where matricula=@matricula)
	begin
		print 'Error -1'
		return -1
	end
-- Se chequea que exista el cliente en la base de datos, y si no existe se muestra el error
else if not exists(select * from Clientes where documento=@cedula)
	begin
		print 'Error -2'
		return -2
	end
-- Se chequea que la fecha de inicio no sea anterior al dia de hoy
else if (@fechainicio<convert(date,GETDATE()))
	begin
		print 'Error -3'
		return -3
	end
-- Se chequea que la fecha de fin sea posterior a la fecha de inicio
else if (@fechainicio>=@fechafin)
	begin
		print 'Error -4'
		return -4
	end
-- Se chequea que el vehículo que se desea alquilar no se encuentre alquilado en las fechas solicitadas
else if	(exists (select * from Alquileres where (Alquileres.vehiculo=@matricula and @fechafin<=Alquileres.fechafin and @fechafin>=Alquileres.fechainicio)) or
	exists (select * from Alquileres where (Alquileres.vehiculo=@matricula and @fechainicio<=Alquileres.fechafin and @fechainicio>=Alquileres.fechainicio)) or
	exists (select * from Alquileres where (Alquileres.vehiculo=@matricula and @fechainicio<=Alquileres.fechainicio and @fechafin>=Alquileres.fechafin)))
	begin
		print 'Error -5'
		return -5
	end
else
	begin
	begin transaction
	insert into Alquileres values (@matricula,@cedula,@fechainicio,@fechafin,@costo)
	if @@ERROR<>0
			begin
				rollback transaction
				print 'Error -6'
				return -6				
			end
	commit transaction
	print 'ok'
	return 1
	end
go


-- Se crea procedimiento para obtener el total recaudado de un vehículo
create procedure Total_Vehiculo
-- Se define la variable de entrada al proceso, la cual va a ser la matrícula del vehículo
@vehiculo varchar(7)
as
-- Se chequea que exista la matrícula en la base de datos, y si no existe se muestra el error
if not exists(select * from Vehiculos where matricula=@vehiculo)
	begin
	print 'El vehículo no existe en la base de datos'
	return -1
	end
else
	begin
	begin transaction
	declare @marca varchar(30)
	declare @modelo varchar(30)
	declare @recaudado float
	select @marca = Vehiculos.marca from Vehiculos where Vehiculos.matricula=@vehiculo
	select @modelo = Vehiculos.modelo from Vehiculos where Vehiculos.matricula=@vehiculo
	select @recaudado = SUM(Alquileres.costo) from Alquileres where Alquileres.vehiculo=@vehiculo
	if @@ERROR<>0
			begin
				rollback transaction
				print 'No se pudo realizar el alquiler del vehículo'
				return -2
			end
	commit transaction
	print 'El vehículo '+@marca+' '+@modelo+', matrícula '+@vehiculo+' ha recaudado un total de $'+CONVERT(varchar(10),@recaudado)
	return 1
	end;

go

-- Se crea procedimiento para ver vehículos disponibles por período
create procedure Disponibles_por_periodo
-- Se definen las variables de entrada al proceso
@fechainicio datetime,
@fechafin datetime
as
-- Se chequea que la fecha de fin sea posterior a la fecha de inicio
if (@fechainicio>=@fechafin)
	begin
	print 'La fecha de fin debe ser posterior a la fecha de inicio'
	return -1
	end
else
	begin
	-- Se copian en una tabla temporal aquellos vehículos que están alquilados dentro del período seleccionado
	-- y se seleccionan aquellos vehículos que no se encuentran en dicha tabla
	select Vehiculos.* into #TablaAux from Vehiculos where Vehiculos.matricula not in 
		(select Alquileres.vehiculo from Alquileres 
		where ((@fechainicio<=Alquileres.fechafin and @fechainicio>=Alquileres.fechainicio) or
				(@fechafin<=Alquileres.fechafin and @fechafin>=Alquileres.fechainicio) or
				(@fechainicio<=Alquileres.fechainicio and @fechafin>=Alquileres.fechafin)))
	-- Se traen los datos de las tablas Autos y Utilitarios para completar la consulta
	select TablaAux2.*, Utilitarios.tipo, Utilitarios.capacidad, Utilitarios.vehiculosimilar as utilitario_similar
	from (select #TablaAux.*, Autos.anclaje, Autos.vehiculosimilar as auto_similar from #TablaAux left join Autos on #TablaAux.matricula=Autos.matricula)
	as TablaAux2 left join Utilitarios on TablaAux2.matricula=Utilitarios.matricula
	end

go

-- Se crea procedimiento para encontrar el vehículo más rentable
create procedure Mas_Rentable
as
begin
-- Se selecciona de la tabla vehículos el vehículo más rentable
select Vehiculos.matricula, Vehiculos.Marca, Vehiculos.modelo, Mayorreacudacion.total from Vehiculos 
inner join (select top 1 vehiculo as matricula, sum(costo) as total from Alquileres group by vehiculo order by sum(costo) desc) as Mayorreacudacion 
on Vehiculos.matricula = Mayorreacudacion.matricula
end