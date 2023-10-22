USE Books

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Authors] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Covers] (
    [Id] uniqueidentifier NOT NULL,
    [Image] varbinary(max) NOT NULL,
    CONSTRAINT [PK_Covers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(450) NOT NULL,
    [Description] nvarchar(2500) NOT NULL,
    [Created] datetime2 NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    [CoverId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Covers_CoverId] FOREIGN KEY ([CoverId]) REFERENCES [Covers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO

CREATE UNIQUE INDEX [IX_Books_CoverId] ON [Books] ([CoverId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231022141756_InitBooksDbTables', N'7.0.12');
GO

COMMIT;
GO

