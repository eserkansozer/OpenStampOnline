
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/08/2013 17:03:38
-- Generated from EDMX file: C:\Users\serkan_sozer\Documents\Visual Studio 2012\Projects\StampOnline\StampOnline\Models\Stamp.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OnlineStampDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OStampOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OStampOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_OStampGraphic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Graphics] DROP CONSTRAINT [FK_OStampGraphic];
GO
IF OBJECT_ID(N'[dbo].[FK_OStampStampLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StampLines] DROP CONSTRAINT [FK_OStampStampLine];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StampLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StampLines];
GO
IF OBJECT_ID(N'[dbo].[Graphics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Graphics];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[OStamps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OStamps];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StampLines'
CREATE TABLE [dbo].[StampLines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LineNr] int  NOT NULL,
    [Text] nvarchar(max)  NULL,
    [Bold] bit  NOT NULL,
    [Italic] bit  NOT NULL,
    [Font] nvarchar(max)  NOT NULL,
    [FontSize] int  NOT NULL,
    [Underlined] bit  NOT NULL,
    [OStampId] int  NOT NULL
);
GO

-- Creating table 'Graphics'
CREATE TABLE [dbo].[Graphics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [Url] nvarchar(max)  NOT NULL,
    [Size] int  NOT NULL,
    [OStamp_Id] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [OStamp_Id] int  NOT NULL
);
GO

-- Creating table 'OStamps'
CREATE TABLE [dbo].[OStamps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsTemplate] bit  NOT NULL,
    [Alignment] nvarchar(max)  NOT NULL,
    [Border] nvarchar(max)  NOT NULL,
    [Length] int  NOT NULL,
    [Width] int  NOT NULL,
    [NumberOfRows] int  NOT NULL,
    [VAlign] nvarchar(max)  NOT NULL,
    [PadColour] nvarchar(max)  NOT NULL,
    [HandleColour] nvarchar(max)  NOT NULL,
    [PdfUrl] nvarchar(max)  NULL,
    [PreviewUrl] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StampLines'
ALTER TABLE [dbo].[StampLines]
ADD CONSTRAINT [PK_StampLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Graphics'
ALTER TABLE [dbo].[Graphics]
ADD CONSTRAINT [PK_Graphics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OStamps'
ALTER TABLE [dbo].[OStamps]
ADD CONSTRAINT [PK_OStamps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OStamp_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OStampOrder]
    FOREIGN KEY ([OStamp_Id])
    REFERENCES [dbo].[OStamps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OStampOrder'
CREATE INDEX [IX_FK_OStampOrder]
ON [dbo].[Orders]
    ([OStamp_Id]);
GO

-- Creating foreign key on [OStamp_Id] in table 'Graphics'
ALTER TABLE [dbo].[Graphics]
ADD CONSTRAINT [FK_OStampGraphic]
    FOREIGN KEY ([OStamp_Id])
    REFERENCES [dbo].[OStamps]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OStampGraphic'
CREATE INDEX [IX_FK_OStampGraphic]
ON [dbo].[Graphics]
    ([OStamp_Id]);
GO

-- Creating foreign key on [OStampId] in table 'StampLines'
ALTER TABLE [dbo].[StampLines]
ADD CONSTRAINT [FK_OStampStampLine]
    FOREIGN KEY ([OStampId])
    REFERENCES [dbo].[OStamps]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OStampStampLine'
CREATE INDEX [IX_FK_OStampStampLine]
ON [dbo].[StampLines]
    ([OStampId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------