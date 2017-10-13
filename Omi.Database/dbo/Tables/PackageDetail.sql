CREATE TABLE [dbo].[PackageDetail] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [Area]      INT            NOT NULL,
    [Language]  NVARCHAR (MAX) NULL,
    [PackageId] BIGINT         NOT NULL,
    [Price]     INT            NOT NULL,
    [SortText]  NVARCHAR (MAX) NULL,
    [Title]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_PackageDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PackageDetail_Package_PackageId] FOREIGN KEY ([PackageId]) REFERENCES [dbo].[Package] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PackageDetail_PackageId]
    ON [dbo].[PackageDetail]([PackageId] ASC);

