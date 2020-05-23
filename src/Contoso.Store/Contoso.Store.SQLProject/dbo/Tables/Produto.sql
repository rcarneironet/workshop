CREATE TABLE [dbo].[Produto] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Titulo]            VARCHAR (100)    NOT NULL,
    [Imagem]            VARCHAR (500)    NOT NULL,
    [Preco]             NUMERIC (18, 2)  NOT NULL,
    [QuantidadeEstoque] INT              NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([Id] ASC)
);

