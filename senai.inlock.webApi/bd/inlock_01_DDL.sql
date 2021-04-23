CREATE DATABASE inlock_games_tarde;
GO

USE inlock_games_tarde;
GO

CREATE TABLE Estudios
(
   idEstudio int primary key identity,
   nomeEstudio varchar(250)
);
GO

CREATE TABLE Jogos
(
   idJogo int primary key identity,
   nomeJogo varchar(250),
   descricao varchar(250),
   dataLancamento date,
   valor decimal(18,2),
   idEstudio int foreign key references estudios(idEstudio)
);
GO

CREATE TABLE TiposUsuarios
(
   idTipoUsuario int primary key identity,
   permissao varchar(250)
);
GO

CREATE TABLE Usuarios
(
   idUsuario int primary key identity,
   email varchar(250),
   senha varchar(250),
   idTipoUsuario int foreign key references tiposUsuarios(idTipoUsuario)
);
GO