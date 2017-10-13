CREATE TABLE [dbo].[PackageTaxonomy] (
    [PackageId]  BIGINT NOT NULL,
    [TaxonomyId] BIGINT NOT NULL,
    CONSTRAINT [PK_PackageTaxonomy] PRIMARY KEY CLUSTERED ([PackageId] ASC, [TaxonomyId] ASC),
    CONSTRAINT [FK_PackageTaxonomy_Package_PackageId] FOREIGN KEY ([PackageId]) REFERENCES [dbo].[Package] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PackageTaxonomy_Taxonomy_TaxonomyId] FOREIGN KEY ([TaxonomyId]) REFERENCES [dbo].[Taxonomy] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PackageTaxonomy_TaxonomyId]
    ON [dbo].[PackageTaxonomy]([TaxonomyId] ASC);

