CREATE TABLE [dbo].[Package] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreateByUserId] NVARCHAR (450) NULL,
    [CreateDate]     DATETIME2 (7)  NULL,
    [DeleteByUserId] NVARCHAR (450) NULL,
    [DeleteDate]     DATETIME2 (7)  NULL,
    [EntityTypeId]   BIGINT         NULL,
    [Name]           NVARCHAR (MAX) NULL,
    [Status]         INT            NOT NULL,
    CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Package_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Package_AspNetUsers_DeleteByUserId] FOREIGN KEY ([DeleteByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Package_EntityType_EntityTypeId] FOREIGN KEY ([EntityTypeId]) REFERENCES [dbo].[EntityType] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Package_EntityTypeId]
    ON [dbo].[Package]([EntityTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Package_DeleteByUserId]
    ON [dbo].[Package]([DeleteByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Package_CreateByUserId]
    ON [dbo].[Package]([CreateByUserId] ASC);

