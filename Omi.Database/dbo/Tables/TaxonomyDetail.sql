CREATE TABLE [dbo].[TaxonomyDetail] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreateByUserId] NVARCHAR (450) NULL,
    [CreateDate]     DATETIME2 (7)  NULL,
    [Icon]           NVARCHAR (MAX) NULL,
    [Label]          NVARCHAR (MAX) NULL,
    [Language]       NVARCHAR (MAX) NULL,
    [TaxonomyId]     BIGINT         NOT NULL,
    CONSTRAINT [PK_TaxonomyDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TaxonomyDetail_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_TaxonomyDetail_Taxonomy_TaxonomyId] FOREIGN KEY ([TaxonomyId]) REFERENCES [dbo].[Taxonomy] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TaxonomyDetail_TaxonomyId]
    ON [dbo].[TaxonomyDetail]([TaxonomyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TaxonomyDetail_CreateByUserId]
    ON [dbo].[TaxonomyDetail]([CreateByUserId] ASC);

