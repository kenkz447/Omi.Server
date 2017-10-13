CREATE TABLE [dbo].[CustomFieldGroup] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [CreateByUserId] NVARCHAR (450) NULL,
    [CreateDate]     DATETIME2 (7)  NULL,
    [DeleteByUserId] NVARCHAR (450) NULL,
    [DeleteDate]     DATETIME2 (7)  NULL,
    [Name]           NVARCHAR (MAX) NULL,
    [Status]         INT            NOT NULL,
    CONSTRAINT [PK_CustomFieldGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomFieldGroup_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_CustomFieldGroup_AspNetUsers_DeleteByUserId] FOREIGN KEY ([DeleteByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_CustomFieldGroup_DeleteByUserId]
    ON [dbo].[CustomFieldGroup]([DeleteByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CustomFieldGroup_CreateByUserId]
    ON [dbo].[CustomFieldGroup]([CreateByUserId] ASC);

