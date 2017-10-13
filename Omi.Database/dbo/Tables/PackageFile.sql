CREATE TABLE [dbo].[PackageFile] (
    [PackageId]          BIGINT NOT NULL,
    [FileEntityId]       BIGINT NOT NULL,
    [EntityFileEntityId] BIGINT NULL,
    [EntityPackageId]    BIGINT NULL,
    [UsingType]          INT    DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_PackageFile] PRIMARY KEY CLUSTERED ([PackageId] ASC, [FileEntityId] ASC),
    CONSTRAINT [FK_PackageFile_FileEntity_FileEntityId] FOREIGN KEY ([FileEntityId]) REFERENCES [dbo].[FileEntity] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PackageFile_Package_PackageId] FOREIGN KEY ([PackageId]) REFERENCES [dbo].[Package] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PackageFile_PackageFile_EntityPackageId_EntityFileEntityId] FOREIGN KEY ([EntityPackageId], [EntityFileEntityId]) REFERENCES [dbo].[PackageFile] ([PackageId], [FileEntityId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PackageFile_EntityPackageId_EntityFileEntityId]
    ON [dbo].[PackageFile]([EntityPackageId] ASC, [EntityFileEntityId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PackageFile_FileEntityId]
    ON [dbo].[PackageFile]([FileEntityId] ASC);

