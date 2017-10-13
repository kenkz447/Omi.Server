CREATE TABLE [dbo].[EntityType] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreateByUserId] NVARCHAR (450) NULL,
    [CreateDate]     DATETIME2 (7)  NULL,
    [DeleteByUserId] NVARCHAR (450) NULL,
    [DeleteDate]     DATETIME2 (7)  NULL,
    [Name]           NVARCHAR (450) NOT NULL,
    [Status]         INT            NOT NULL,
    CONSTRAINT [PK_EntityType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EntityType_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_EntityType_AspNetUsers_DeleteByUserId] FOREIGN KEY ([DeleteByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [AK_EntityType_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_EntityType_DeleteByUserId]
    ON [dbo].[EntityType]([DeleteByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EntityType_CreateByUserId]
    ON [dbo].[EntityType]([CreateByUserId] ASC);

