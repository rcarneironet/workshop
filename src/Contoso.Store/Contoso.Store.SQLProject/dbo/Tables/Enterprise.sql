CREATE TABLE [dbo].[Enterprise] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [Nome]  VARCHAR (50) NOT NULL,
    [Ativo] BIT          NULL,
    CONSTRAINT [PK_Enterprise] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [UN_Enterprise_Nome]
    ON [dbo].[Enterprise]([Nome] ASC);

