USE inlock_games_tarde;
GO

INSERT INTO TiposUsuarios (permissao) 
values 
('administrador'),
('comum')
GO

INSERT INTO Usuarios (email, senha, idTipoUsuario)
values
('admin@admin.com','admin', 1),
('cliente@cliente', 'cliente', 2)
GO

INSERT INTO Estudios (nomeEstudio)
values
('Blizzard'),
('Rockstar Studios'),
('Square Enix')
GO

INSERT INTO Jogos (nomeJogo, descricao, dataLancamento, valor, idEstudio)
values
('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', '2012-05-15', 99 , 1),
('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western.', '2018-10-26', 120, 2)
GO
