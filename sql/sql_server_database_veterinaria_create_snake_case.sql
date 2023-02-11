USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Veterinaria') DROP DATABASE [Veterinaria]
GO
CREATE DATABASE [Veterinaria];
GO
USE [Veterinaria];
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Chat')
CREATE TABLE [dbo].[Chat] (
    [Id_Chat]                           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Remitente]                         INT                     NULL DEFAULT NULL,
    [Receptor]                          INT                     NULL DEFAULT NULL,
    [Mensaje]                           TEXT                    NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT GETDATE(),
    [Estado]                            INT                     NULL DEFAULT NULL,
    [Id_Chat_Detalle]                   BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Chat_Detalle')
CREATE TABLE [dbo].[Chat_Detalle] (
    [Id_Chat_Detalle]                   BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Persona]                        BIGINT                  NULL DEFAULT NULL,
    [Ultima]                            DATETIME                NULL DEFAULT GETDATE(),
    [Escribiendo]                       VARCHAR                 NULL DEFAULT NULL CHECK (escribiendo in ('No', 'Si'))
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Foto')
CREATE TABLE [dbo].[Foto] (
    [Id_Foto]                           BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Mascota]                        BIGINT                  NULL DEFAULT NULL,
    [Imagen]                            VARCHAR(8000)           NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mascota')
CREATE TABLE [dbo].[Mascota] (
    [Id_Mascota]                        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Id_Persona]                        BIGINT                  NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(100)            NULL DEFAULT NULL,
    [Edad]                              VARCHAR(3)              NULL DEFAULT NULL,
    [Ubicacion]                         VARCHAR(100)            NULL DEFAULT NULL,
    [Raza]                              VARCHAR(2000)           NULL DEFAULT NULL,
    [Tipo]                              VARCHAR(100)            NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Persona')
CREATE TABLE [dbo].[Persona] (
    [Id_Persona]                        BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Nombres]                           VARCHAR(200)            NULL DEFAULT NULL,
    [Celular]                           VARCHAR(30)             NULL DEFAULT NULL,
    [Email]                             VARCHAR(100)            NULL DEFAULT NULL,
    [Usuario]                           VARCHAR(20)             NULL DEFAULT NULL,
    [Clave]                             VARCHAR(20)             NULL DEFAULT NULL
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Chat]
    ADD CONSTRAINT [Fk_Chat_Id_Chat_Detalle]
        FOREIGN KEY ([Id_Chat_Detalle])
        REFERENCES [Chat_Detalle] ([Id_Chat_Detalle])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Chat_Detalle]
    ADD CONSTRAINT [Fk_Chat_Detalle_Id_Persona]
        FOREIGN KEY ([Id_Persona])
        REFERENCES [Persona] ([Id_Persona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Foto]
    ADD CONSTRAINT [Fk_Foto_Id_Mascota]
        FOREIGN KEY ([Id_Mascota])
        REFERENCES [Mascota] ([Id_Mascota])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Mascota]
    ADD CONSTRAINT [Fk_Mascota_Id_Persona]
        FOREIGN KEY ([Id_Persona])
        REFERENCES [Persona] ([Id_Persona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
