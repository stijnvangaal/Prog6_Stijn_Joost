
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/31/2014 13:10:05
-- Generated from EDMX file: D:\stijn\school\c#\blok 6\Prog6_Stijn_Joost\AppieApp2\DomainModel\AppieDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AppieDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AfdelingProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSet1] DROP CONSTRAINT [FK_AfdelingProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductMerk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductMerkSet1] DROP CONSTRAINT [FK_ProductProductMerk];
GO
IF OBJECT_ID(N'[dbo].[FK_MerkProductMerk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductMerkSet1] DROP CONSTRAINT [FK_MerkProductMerk];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMerkKorting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KortingSet1] DROP CONSTRAINT [FK_ProductMerkKorting];
GO
IF OBJECT_ID(N'[dbo].[FK_BoodschappenLijstBoodschappenProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoodschappenProductSet1] DROP CONSTRAINT [FK_BoodschappenLijstBoodschappenProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ReceptReceptProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceptProductSet1] DROP CONSTRAINT [FK_ReceptReceptProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMerkReceptProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceptProductSet1] DROP CONSTRAINT [FK_ProductMerkReceptProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMerkBoodschappenProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoodschappenProductSet1] DROP CONSTRAINT [FK_ProductMerkBoodschappenProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProductSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet1];
GO
IF OBJECT_ID(N'[dbo].[AfdelingSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AfdelingSet1];
GO
IF OBJECT_ID(N'[dbo].[MerkSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MerkSet1];
GO
IF OBJECT_ID(N'[dbo].[ProductMerkSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductMerkSet1];
GO
IF OBJECT_ID(N'[dbo].[KortingSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KortingSet1];
GO
IF OBJECT_ID(N'[dbo].[BoodschappenLijstSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoodschappenLijstSet1];
GO
IF OBJECT_ID(N'[dbo].[BoodschappenProductSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoodschappenProductSet1];
GO
IF OBJECT_ID(N'[dbo].[ReceptSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceptSet1];
GO
IF OBJECT_ID(N'[dbo].[ReceptProductSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceptProductSet1];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet1'
CREATE TABLE [dbo].[ProductSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(255)  NOT NULL,
    [AfdelingNaam] nvarchar(255)  NULL
);
GO

-- Creating table 'AfdelingSet1'
CREATE TABLE [dbo].[AfdelingSet1] (
    [Naam] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'MerkSet1'
CREATE TABLE [dbo].[MerkSet1] (
    [Naam] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'ProductMerkSet1'
CREATE TABLE [dbo].[ProductMerkSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [MerkNaam] nvarchar(255)  NOT NULL,
    [Prijs] float  NOT NULL
);
GO

-- Creating table 'KortingSet1'
CREATE TABLE [dbo].[KortingSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KortingCode] nvarchar(255)  NOT NULL,
    [BeginDatum] datetime  NOT NULL,
    [EindDatum] datetime  NOT NULL,
    [Percentage] float  NOT NULL,
    [ProductMerkId] int  NOT NULL
);
GO

-- Creating table 'BoodschappenLijstSet1'
CREATE TABLE [dbo].[BoodschappenLijstSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotaalPrijs] float  NOT NULL
);
GO

-- Creating table 'BoodschappenProductSet1'
CREATE TABLE [dbo].[BoodschappenProductSet1] (
    [BoodschappenLijstId] int  NOT NULL,
    [Aantal] int  NOT NULL,
    [ProductMerkId1] int  NOT NULL
);
GO

-- Creating table 'ReceptSet1'
CREATE TABLE [dbo].[ReceptSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'ReceptProductSet1'
CREATE TABLE [dbo].[ReceptProductSet1] (
    [ReceptId] int  NOT NULL,
    [ProductMerkId] int  NOT NULL,
    [Aantal] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductSet1'
ALTER TABLE [dbo].[ProductSet1]
ADD CONSTRAINT [PK_ProductSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Naam] in table 'AfdelingSet1'
ALTER TABLE [dbo].[AfdelingSet1]
ADD CONSTRAINT [PK_AfdelingSet1]
    PRIMARY KEY CLUSTERED ([Naam] ASC);
GO

-- Creating primary key on [Naam] in table 'MerkSet1'
ALTER TABLE [dbo].[MerkSet1]
ADD CONSTRAINT [PK_MerkSet1]
    PRIMARY KEY CLUSTERED ([Naam] ASC);
GO

-- Creating primary key on [Id] in table 'ProductMerkSet1'
ALTER TABLE [dbo].[ProductMerkSet1]
ADD CONSTRAINT [PK_ProductMerkSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KortingSet1'
ALTER TABLE [dbo].[KortingSet1]
ADD CONSTRAINT [PK_KortingSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BoodschappenLijstSet1'
ALTER TABLE [dbo].[BoodschappenLijstSet1]
ADD CONSTRAINT [PK_BoodschappenLijstSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BoodschappenLijstId], [ProductMerkId1] in table 'BoodschappenProductSet1'
ALTER TABLE [dbo].[BoodschappenProductSet1]
ADD CONSTRAINT [PK_BoodschappenProductSet1]
    PRIMARY KEY CLUSTERED ([BoodschappenLijstId], [ProductMerkId1] ASC);
GO

-- Creating primary key on [Id] in table 'ReceptSet1'
ALTER TABLE [dbo].[ReceptSet1]
ADD CONSTRAINT [PK_ReceptSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ReceptId], [ProductMerkId] in table 'ReceptProductSet1'
ALTER TABLE [dbo].[ReceptProductSet1]
ADD CONSTRAINT [PK_ReceptProductSet1]
    PRIMARY KEY CLUSTERED ([ReceptId], [ProductMerkId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AfdelingNaam] in table 'ProductSet1'
ALTER TABLE [dbo].[ProductSet1]
ADD CONSTRAINT [FK_AfdelingProduct]
    FOREIGN KEY ([AfdelingNaam])
    REFERENCES [dbo].[AfdelingSet1]
        ([Naam])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AfdelingProduct'
CREATE INDEX [IX_FK_AfdelingProduct]
ON [dbo].[ProductSet1]
    ([AfdelingNaam]);
GO

-- Creating foreign key on [ProductId] in table 'ProductMerkSet1'
ALTER TABLE [dbo].[ProductMerkSet1]
ADD CONSTRAINT [FK_ProductProductMerk]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductMerk'
CREATE INDEX [IX_FK_ProductProductMerk]
ON [dbo].[ProductMerkSet1]
    ([ProductId]);
GO

-- Creating foreign key on [MerkNaam] in table 'ProductMerkSet1'
ALTER TABLE [dbo].[ProductMerkSet1]
ADD CONSTRAINT [FK_MerkProductMerk]
    FOREIGN KEY ([MerkNaam])
    REFERENCES [dbo].[MerkSet1]
        ([Naam])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MerkProductMerk'
CREATE INDEX [IX_FK_MerkProductMerk]
ON [dbo].[ProductMerkSet1]
    ([MerkNaam]);
GO

-- Creating foreign key on [ProductMerkId] in table 'KortingSet1'
ALTER TABLE [dbo].[KortingSet1]
ADD CONSTRAINT [FK_ProductMerkKorting]
    FOREIGN KEY ([ProductMerkId])
    REFERENCES [dbo].[ProductMerkSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMerkKorting'
CREATE INDEX [IX_FK_ProductMerkKorting]
ON [dbo].[KortingSet1]
    ([ProductMerkId]);
GO

-- Creating foreign key on [BoodschappenLijstId] in table 'BoodschappenProductSet1'
ALTER TABLE [dbo].[BoodschappenProductSet1]
ADD CONSTRAINT [FK_BoodschappenLijstBoodschappenProduct]
    FOREIGN KEY ([BoodschappenLijstId])
    REFERENCES [dbo].[BoodschappenLijstSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ReceptId] in table 'ReceptProductSet1'
ALTER TABLE [dbo].[ReceptProductSet1]
ADD CONSTRAINT [FK_ReceptReceptProduct]
    FOREIGN KEY ([ReceptId])
    REFERENCES [dbo].[ReceptSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductMerkId] in table 'ReceptProductSet1'
ALTER TABLE [dbo].[ReceptProductSet1]
ADD CONSTRAINT [FK_ProductMerkReceptProduct]
    FOREIGN KEY ([ProductMerkId])
    REFERENCES [dbo].[ProductMerkSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMerkReceptProduct'
CREATE INDEX [IX_FK_ProductMerkReceptProduct]
ON [dbo].[ReceptProductSet1]
    ([ProductMerkId]);
GO

-- Creating foreign key on [ProductMerkId1] in table 'BoodschappenProductSet1'
ALTER TABLE [dbo].[BoodschappenProductSet1]
ADD CONSTRAINT [FK_ProductMerkBoodschappenProduct]
    FOREIGN KEY ([ProductMerkId1])
    REFERENCES [dbo].[ProductMerkSet1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMerkBoodschappenProduct'
CREATE INDEX [IX_FK_ProductMerkBoodschappenProduct]
ON [dbo].[BoodschappenProductSet1]
    ([ProductMerkId1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------