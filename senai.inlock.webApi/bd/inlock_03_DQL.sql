USE inlock_games_tarde;

SELECT * FROM Usuarios
GO

SELECT * FROM Estudios
GO

SELECT * FROM Jogos
GO

SELECT Usuarios.idUsuario, Usuarios.email, Usuarios.senha, Usuarios.idTipoUsuario, TiposUsuarios.permissao FROM Usuarios
INNER JOIN TiposUsuarios ON Usuarios.idTipoUsuario = TiposUsuarios.idTipoUsuario
WHERE Usuarios.email = 'admin@admin.com' AND Usuarios.senha = 'admin'
