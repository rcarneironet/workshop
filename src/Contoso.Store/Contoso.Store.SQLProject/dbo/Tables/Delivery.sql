CREATE TABLE [dbo].[Delivery] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL,
    [OrdemId]               UNIQUEIDENTIFIER NOT NULL,
    [CreateDate]            DATETIME         NOT NULL,
    [EstimatedDeliveryDate] DATETIME         NOT NULL,
    [Status]                VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Delivery_Ordem] FOREIGN KEY ([OrdemId]) REFERENCES [dbo].[Ordem] ([Id])
);

