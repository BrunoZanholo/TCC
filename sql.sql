/*
dbserver-tcc.database.windows.net / tcc
tcc / puc@2019
*/

select * from SENSORES

--DROP TABLE SENSORES
CREATE TABLE DBO.SENSORES
(
	SensorId int not null identity (1,1),
	AreaId int not null,
	Rotulo varchar(100) not null,
	Nome varchar(100) not null,
)

insert into SENSORES values (1, 'x10', 'teste')
GO
--DROP TABLE AFETADOS

insert into AFETADOS values (1, 'Bruno Zanholo' ,'bruno@zanholo.com.br', '18991156050')
insert into AFETADOS values (1, 'Viviane Zanholo', 'viviane@zanholo.com.br', '18991113561')

select * from AFETADOS
CREATE TABLE DBO.AFETADOS
(
	AfetadoId int not null identity (1,1),
	AreaId int not null,
	Nome varchar(255) not null,
	Email varchar(255) not null,
	Celular varchar(20) not null,
)
GO

insert AREAS values ('�rea 2')

--DROP TABLE AREAS
select * from areas
CREATE TABLE DBO.AREAS
(
	AreaId int not null identity (1,1),
	Nome varchar(100) not null,
)
GO
--DROP TABLE ATIVIDADES
select * from ATIVIDADES
CREATE TABLE DBO.ATIVIDADES
(
	AtividadeId int not null identity (1,1),
	RotuloSensor varchar(100) not null,
	Tipo varchar(100) not null,
	Intensidade int not null,
	Data datetime2 not null default((getdate()))
)
GO

alter table ATIVIDADES add Data datetime not null default((getdate()))

--DROP TABLE INCIDENTES

select * from INCIDENTES
CREATE TABLE DBO.INCIDENTES
(
	IncidenteId int not null identity (1,1),
	AreaId int not null,
	Data Datetime not null default ((getdate())),
	PlanoAcaoId int null ,
	Classificacao int not null,
)
GO
--DROP TABLE PLANOSACAO
select * from PLANOSACAO
CREATE TABLE DBO.PLANOSACAO
(
	PlanoAcaoId int not null identity (1,1),
	Tipo varchar(100) not null,
	Nome varchar(100) not null,
	Classificacao int not null,
	Mensagem varchar(100) not null
)
GO

INSERT INTO PLANOSACAO VALUES ('SMS', 'ALERTA 10', 10, 'Alerta classifica��o 10')
INSERT INTO PLANOSACAO VALUES ('SMS', 'ALERTA 20', 20, 'Alerta classifica��o 20')
INSERT INTO PLANOSACAO VALUES ('SMS', 'ALERTA 30', 30, 'Alerta classifica��o 30')

INSERT INTO PLANOSACAO VALUES ('SMS', 'EVACUA��O 90', 90, 'Evacua��o classifica��o 90')
INSERT INTO PLANOSACAO VALUES ('SMS', 'EVACUA��O 100', 100, 'Evacua��o classifica��o 100')

INSERT INTO PLANOSACAO VALUES ('EMAIL', 'EVACUA��O 60', 60, 'Evacua��o classifica��o 60')
INSERT INTO PLANOSACAO VALUES ('EMAIL', 'EVACUA��O 70', 70, 'Evacua��o classifica��o 70')
INSERT INTO PLANOSACAO VALUES ('EMAIL', 'EVACUA��O 80', 80, 'Evacua��o classifica��o 80')

INSERT INTO PLANOSACAO VALUES ('EMAIL', 'ALERTA 40', 40, 'Alerta classifica��o 40')
INSERT INTO PLANOSACAO VALUES ('EMAIL', 'ALERTA 50', 50, 'Alerta classifica��o 50')