CREATE TABLE [dbo].[Endereco] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [ClienteId]    UNIQUEIDENTIFIER NOT NULL,
    [Rua]          VARCHAR (50)     NOT NULL,
    [Numero]       INT              NOT NULL,
    [Complemento]  VARCHAR (50)     NULL,
    [Distrito]     VARCHAR (50)     NOT NULL,
    [Cidade]       VARCHAR (50)     NOT NULL,
    [Estado]       VARCHAR (50)     NOT NULL,
    [Pais]         VARCHAR (50)     NOT NULL,
    [TipoEndereco] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Endereco_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([Id])
);

