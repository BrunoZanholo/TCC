/*
dbserver-tcc.database.windows.net / tcc
tcc / puc@2019
*/

CREATE TABLE DBO.SENSORES
(
	SensorId int not null identity (1,1),
	Rotulo varchar(100) not null,
	Nome varchar(100) not null,
)

