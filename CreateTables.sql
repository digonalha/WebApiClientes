﻿IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Cliente')
BEGIN
	CREATE TABLE Cliente(
		Id INT NOT NULL IDENTITY(1,1) UNIQUE CLUSTERED,
		Nome VARCHAR(30) NOT NULL,
		Cpf VARCHAR(11) NOT NULL,
		DataNascimento DATETIME NOT NULL,
	CONSTRAINT [PK_Id_Cliente] PRIMARY KEY ([Id] ASC))
END

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Endereco')
BEGIN
	CREATE TABLE Endereco(
		Id INT NOT NULL IDENTITY(1,1) UNIQUE CLUSTERED,
		Logradouro VARCHAR(50) NOT NULL,
		Bairro VARCHAR(40) NOT NULL,
		Cidade VARCHAR(40) NOT NULL,
		Estado VARCHAR(40) NOT NULL,
	CONSTRAINT [PK_Id_Endereco] PRIMARY KEY ([Id] ASC))
END