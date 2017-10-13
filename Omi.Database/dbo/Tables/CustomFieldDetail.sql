CREATE TABLE [dbo].[CustomFieldDetail] (
    [Id]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [Append]          NVARCHAR (MAX) NULL,
    [CharacterLimit]  INT            NOT NULL,
    [CreateByUserId]  NVARCHAR (450) NULL,
    [CreateDate]      DATETIME2 (7)  NULL,
    [CustomFieldId]   BIGINT         NOT NULL,
    [DefaultValue]    NVARCHAR (MAX) NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [Label]           NVARCHAR (MAX) NULL,
    [Language]        NVARCHAR (MAX) NULL,
    [PlaceholderText] NVARCHAR (MAX) NULL,
    [Prepend]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CustomFieldDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomFieldDetail_AspNetUsers_CreateByUserId] FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_CustomFieldDetail_CustomField_CustomFieldId] FOREIGN KEY ([CustomFieldId]) REFERENCES [dbo].[CustomField] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_CustomFieldDetail_CustomFieldId]
    ON [dbo].[CustomFieldDetail]([CustomFieldId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CustomFieldDetail_CreateByUserId]
    ON [dbo].[CustomFieldDetail]([CreateByUserId] ASC);

