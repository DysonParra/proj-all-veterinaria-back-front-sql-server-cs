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
    [IdChat]                            BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [Remitente]                         INT                     NULL DEFAULT NULL,
    [Receptor]                          INT                     NULL DEFAULT NULL,
    [Mensaje]                           TEXT                    NULL DEFAULT NULL,
    [Fecha]                             DATETIME                NULL DEFAULT GETDATE(),
    [Estado]                            INT                     NULL DEFAULT NULL,
    [IdChatDetalle]                     BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ChatDetalle')
CREATE TABLE [dbo].[ChatDetalle] (
    [IdChatDetalle]                     BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdPersona]                         BIGINT                  NULL DEFAULT NULL,
    [Ultima]                            DATETIME                NULL DEFAULT GETDATE(),
    [Escribiendo]                       VARCHAR                 NULL DEFAULT NULL CHECK (escribiendo in ('No', 'Si'))
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Foto')
CREATE TABLE [dbo].[Foto] (
    [IdFoto]                            BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdMascota]                         BIGINT                  NULL DEFAULT NULL,
    [Imagen]                            VARCHAR(8000)           NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mascota')
CREATE TABLE [dbo].[Mascota] (
    [IdMascota]                         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IdPersona]                         BIGINT                  NULL DEFAULT NULL,
    [Nombre]                            VARCHAR(100)            NULL DEFAULT NULL,
    [Edad]                              VARCHAR(3)              NULL DEFAULT NULL,
    [Ubicacion]                         VARCHAR(100)            NULL DEFAULT NULL,
    [Raza]                              VARCHAR(2000)           NULL DEFAULT NULL,
    [Tipo]                              VARCHAR(100)            NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Persona')
CREATE TABLE [dbo].[Persona] (
    [IdPersona]                         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
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
    ADD CONSTRAINT [FkChatIdChatDetalle]
        FOREIGN KEY ([IdChatDetalle])
        REFERENCES [ChatDetalle] ([IdChatDetalle])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [ChatDetalle]
    ADD CONSTRAINT [FkChatDetalleIdPersona]
        FOREIGN KEY ([IdPersona])
        REFERENCES [Persona] ([IdPersona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Foto]
    ADD CONSTRAINT [FkFotoIdMascota]
        FOREIGN KEY ([IdMascota])
        REFERENCES [Mascota] ([IdMascota])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Mascota]
    ADD CONSTRAINT [FkMascotaIdPersona]
        FOREIGN KEY ([IdPersona])
        REFERENCES [Persona] ([IdPersona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
