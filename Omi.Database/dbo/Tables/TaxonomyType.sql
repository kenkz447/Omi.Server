CREATE TABLE [dbo].[TaxonomyType] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreateByUserId] NVARCHAR (450) NULL,
    [CreateDate]     DATETIME2 (7)  NULL,
    [DeleteByUserId] NVARCHAR (450) NULL,
    [DeleteDate]     DATETIME2 (7)  NULL,
    [EntityTypeId]   BIGINT         NULL,
    [Name]           NVARCHAR (450) NOT NULL,
    [Status]         INT            NOT NULL,
    CONSTRAINT [PK_TaxonomyType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TaxonomyType_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_TaxonomyType_AspNetUsers_DeleteByUserId] FOREIGN KEY ([DeleteByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_TaxonomyType_EntityType_EntityTypeId] FOREIGN KEY ([EntityTypeId]) REFERENCES [dbo].[EntityType] ([Id]),
    CONSTRAINT [AK_TaxonomyType_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TaxonomyType_EntityTypeId]
    ON [dbo].[TaxonomyType]([EntityTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TaxonomyType_DeleteByUserId]
    ON [dbo].[TaxonomyType]([DeleteByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TaxonomyType_CreateByUserId]
    ON [dbo].[TaxonomyType]([CreateByUserId] ASC);

