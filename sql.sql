/*
dbserver-tcc.database.windows.net / tcc
tcc / puc@2019
*/

--DROP TABLE SENSORES
CREATE TABLE DBO.SENSORES
(
	SensorId int not null identity (1,1),
	AreaId int not null,
	Rotulo varchar(100) not null,
	Nome varchar(100) not null,
)
GO
--DROP TABLE AFETADOS
CREATE TABLE DBO.AFETADOS
(
	AfetadoId int not null identity (1,1),
	AreaId int not null,
	Email varchar(255) not null,
	Celular varchar(20) not null,
)
GO
--DROP TABLE AREAS
CREATE TABLE DBO.AREAS
(
	AreaId int not null identity (1,1),
	Nome varchar(100) not null,
)
GO
--DROP TABLE ATIVIDADES
CREATE TABLE DBO.ATIVIDADES
(
	AtividadeId int not null identity (1,1),
	RotuloSensor varchar(100) not null,
	Nome varchar(100) not null,
	Tipo varchar(100) not null,
	Intensidade int not null,
)
GO
--DROP TABLE INCIDENTES
CREATE TABLE DBO.INCIDENTES
(
	IncidenteId int not null identity (1,1),
	AreaId int not null,
	Data Datetime not null default ((getdate())),
	Nome varchar(100) not null,
	PlanoAcaoId int not null ,
	Classificacao int not null,
)
GO
--DROP TABLE PLANOSACAO
CREATE TABLE DBO.PLANOSACAO
(
	PlanoAcaoId int not null identity (1,1),
	Tipo varchar(100) not null,
	Classificacao int not null,
)
GO