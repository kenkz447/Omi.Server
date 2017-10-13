CREATE TABLE [dbo].[Taxonomy] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreateByUserId] NVARCHAR (450) NULL,
    [CreateDate]     DATETIME2 (7)  NULL,
    [DeleteByUserId] NVARCHAR (450) NULL,
    [DeleteDate]     DATETIME2 (7)  NULL,
    [Name]           NVARCHAR (450) NOT NULL,
    [Status]         INT            NOT NULL,
    [TaxonomyTypeId] BIGINT         NOT NULL,
    CONSTRAINT [PK_Taxonomy] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Taxonomy_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Taxonomy_AspNetUsers_DeleteByUserId] FOREIGN KEY ([DeleteByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Taxonomy_TaxonomyType_TaxonomyTypeId] FOREIGN KEY ([TaxonomyTypeId]) REFERENCES [dbo].[TaxonomyType] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [AK_Taxonomy_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Taxonomy_TaxonomyTypeId]
    ON [dbo].[Taxonomy]([TaxonomyTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Taxonomy_DeleteByUserId]
    ON [dbo].[Taxonomy]([DeleteByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Taxonomy_CreateByUserId]
    ON [dbo].[Taxonomy]([CreateByUserId] ASC);

