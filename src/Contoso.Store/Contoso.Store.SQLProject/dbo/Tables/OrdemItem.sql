CREATE TABLE [dbo].[OrdemItem] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [OrdemId]    UNIQUEIDENTIFIER NOT NULL,
    [ProdutoId]  UNIQUEIDENTIFIER NOT NULL,
    [Quantidade] INT              NOT NULL,
    [Preco]      NUMERIC (18, 2)  NOT NULL,
    CONSTRAINT [PK_OrdemItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrdemItem_Ordem] FOREIGN KEY ([OrdemId]) REFERENCES [dbo].[Ordem] ([Id]),
    CONSTRAINT [FK_OrdemItem_Produto] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id])
);

