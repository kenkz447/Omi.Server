CREATE TABLE [dbo].[CustomField] (
    [Id]                  BIGINT         IDENTITY (1, 1) NOT NULL,
    [AllowHtml]           BIT            NOT NULL,
    [CreateByUserId]      NVARCHAR (450) NULL,
    [CreateDate]          DATETIME2 (7)  NULL,
    [CustomFieldDetailId] BIGINT         NOT NULL,
    [CustomFieldGroupId]  BIGINT         NOT NULL,
    [DeleteByUserId]      NVARCHAR (450) NULL,
    [DeleteDate]          DATETIME2 (7)  NULL,
    [Name]                NVARCHAR (MAX) NOT NULL,
    [Order]               INT            NULL,
    [Required]            BIT            NULL,
    [Status]              INT            NOT NULL,
    [Type]                NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CustomField] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomField_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_CustomField_AspNetUsers_DeleteByUserId] FOREIGN KEY ([DeleteByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_CustomField_CustomFieldGroup_CustomFieldGroupId] FOREIGN KEY ([CustomFieldGroupId]) REFERENCES [dbo].[CustomFieldGroup] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_CustomField_CustomFieldGroupId]
    ON [dbo].[CustomField]([CustomFieldGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CustomField_DeleteByUserId]
    ON [dbo].[CustomField]([DeleteByUserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CustomField_CreateByUserId]
    ON [dbo].[CustomField]([CreateByUserId] ASC);

