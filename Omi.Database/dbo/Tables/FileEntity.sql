CREATE TABLE [dbo].[FileEntity] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreateByUserId] NVARCHAR (450) NULL,
    [CreateDate]     DATETIME2 (7)  NULL,
    [DeleteByUserId] NVARCHAR (450) NULL,
    [DeleteDate]     DATETIME2 (7)  NULL,
    [FileType]       INT            NOT NULL,
    [MetaJson]       NVARCHAR (MAX) NULL,
    [Size]           BIGINT         NOT NULL,
    [Src]            NVARCHAR (450) NOT NULL,
    [Status]         INT            NOT NULL,
    CONSTRAINT [PK_FileEntity] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FileEntity_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_FileEntity_AspNetUsers_DeleteByUserId] FOREIGN KEY ([DeleteByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [AK_FileEntity_Src] UNIQUE NONCLUSTERED ([Src] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_FileEntity_DeleteByUserId]
    ON [dbo].[FileEntity]([DeleteByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FileEntity_CreateByUserId]
    ON [dbo].[FileEntity]([CreateByUserId] ASC);

