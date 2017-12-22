use master
go

--------------------------
if exists(select * from sysdatabases where name = 'Obligatorio')
begin
	drop database Obligatorio
end
go


--creo la base de datos
create database Obligatorio
go


--selecciono la base de datos
use Obligatorio
go


--creo tablas
create table Vehiculos
(
	letrasMatV varchar(3) not null,
	nrosMatV int not null,
	marcaV varchar(15) not null,
	modeloV varchar(25) not null,
	añoV int not null,
	cantPV bit not null,
	CostoDV int not null,
	primary key(letrasMatV, nrosMatV)
)
go

create table Autos
(
	letrasMatV varchar(3) not null ,
	nrosMatV int not null,
	anclajeA varchar(10) not null,
	primary key(letrasMatV, nrosMatV),
	foreign key (letrasMatV, nrosMatV) references Vehiculos(letrasMatV, nrosMatV)
)
go

create table Utilitarios
(
	letrasMatV varchar(3) not null,
	nrosMatV int not null,
	CapacidadU int not null,
	tipoU varchar(9) not null,
	primary key (letrasMatV, nrosMatV),
	foreign key (letrasMatV, nrosMatV) references Vehiculos(letrasMatV, nrosMatV)
	 
)
go

create table Clientes
(
	ciCli bigint not null primary key,
	TCCli bigint unique not null,
	nombreCli varchar(40) not null,
	dirCli varchar(30) not null,
	FNCli date not null,
	telCli varchar(10) not null
)
go

create table Alquileres
(
	codigoA int not null identity primary key,
	letrasMatV varchar(3) not null,
	nrosMatV int not null,
	foreign key (letrasMatV, nrosMatV) references Vehiculos(letrasMatV, nrosMatV),
	ciCli bigint not null foreign key references Clientes(ciCli),
	fechaIni date not null,
	fechaFin date not null
)
go

