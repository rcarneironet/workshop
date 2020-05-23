CREATE TABLE [dbo].[Cliente] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Nome]      VARCHAR (50)     NOT NULL,
    [Documento] VARCHAR (11)     NOT NULL,
    [Email]     VARCHAR (40)     NOT NULL,
    [Telefone]  VARCHAR (15)     NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

