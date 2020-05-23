CREATE TABLE [dbo].[Ordem] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [ClienteId]   UNIQUEIDENTIFIER NULL,
    [Numero]      VARCHAR (50)     NOT NULL,
    [DataCriacao] DATETIME         NOT NULL,
    [Status]      VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Ordem] PRIMARY KEY CLUSTERED ([Id] ASC)
);

