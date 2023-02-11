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
    [IntIdChat]                         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntRemitente]                      INT                     NULL DEFAULT NULL,
    [IntReceptor]                       INT                     NULL DEFAULT NULL,
    [TxtMensaje]                        TEXT                    NULL DEFAULT NULL,
    [DtFecha]                           DATETIME                NULL DEFAULT GETDATE(),
    [IntEstado]                         INT                     NULL DEFAULT NULL,
    [IntIdChatDetalle]                  BIGINT                  NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'ChatDetalle')
CREATE TABLE [dbo].[ChatDetalle] (
    [IntIdChatDetalle]                  BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdPersona]                      BIGINT                  NULL DEFAULT NULL,
    [DtUltima]                          DATETIME                NULL DEFAULT GETDATE(),
    [EnmEscribiendo]                    VARCHAR                 NULL DEFAULT NULL CHECK (enmEscribiendo in ('No', 'Si'))
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Foto')
CREATE TABLE [dbo].[Foto] (
    [IntIdFoto]                         BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdMascota]                      BIGINT                  NULL DEFAULT NULL,
    [StrImagen]                         VARCHAR(8000)           NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Mascota')
CREATE TABLE [dbo].[Mascota] (
    [IntIdMascota]                      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [IntIdPersona]                      BIGINT                  NULL DEFAULT NULL,
    [StrNombre]                         VARCHAR(100)            NULL DEFAULT NULL,
    [StrEdad]                           VARCHAR(3)              NULL DEFAULT NULL,
    [StrUbicacion]                      VARCHAR(100)            NULL DEFAULT NULL,
    [StrRaza]                           VARCHAR(2000)           NULL DEFAULT NULL,
    [StrTipo]                           VARCHAR(100)            NULL DEFAULT NULL
);

IF NOT EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name LIKE 'Persona')
CREATE TABLE [dbo].[Persona] (
    [IntIdPersona]                      BIGINT              NOT NULL PRIMARY KEY IDENTITY,
    [StrNombres]                        VARCHAR(200)            NULL DEFAULT NULL,
    [StrCelular]                        VARCHAR(30)             NULL DEFAULT NULL,
    [StrEmail]                          VARCHAR(100)            NULL DEFAULT NULL,
    [StrUsuario]                        VARCHAR(20)             NULL DEFAULT NULL,
    [StrClave]                          VARCHAR(20)             NULL DEFAULT NULL
);

-- ---------------------------- --
-- --------FOREIGN KEYS-------- --
-- ---------------------------- --

ALTER TABLE [Chat]
    ADD CONSTRAINT [FkChatIdChatDetalle]
        FOREIGN KEY ([IntIdChatDetalle])
        REFERENCES [ChatDetalle] ([IntIdChatDetalle])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [ChatDetalle]
    ADD CONSTRAINT [FkChatDetalleIdPersona]
        FOREIGN KEY ([IntIdPersona])
        REFERENCES [Persona] ([IntIdPersona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Foto]
    ADD CONSTRAINT [FkFotoIdMascota]
        FOREIGN KEY ([IntIdMascota])
        REFERENCES [Mascota] ([IntIdMascota])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;

ALTER TABLE [Mascota]
    ADD CONSTRAINT [FkMascotaIdPersona]
        FOREIGN KEY ([IntIdPersona])
        REFERENCES [Persona] ([IntIdPersona])
        ON DELETE NO ACTION
        ON UPDATE NO ACTION;
