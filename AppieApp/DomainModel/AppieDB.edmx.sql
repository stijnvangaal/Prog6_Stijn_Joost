
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/22/2014 14:58:44
-- Generated from EDMX file: D:\stijn\school\c#\blok 6\Prog6_Stijn_Joost\AppieApp\DomainModel\AppieDB.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL,
    [AfdelingNaam] nvarchar(max)  NULL
);
GO

-- Creating table 'AfdelingSet'
CREATE TABLE [dbo].[AfdelingSet] (
    [Naam] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MerkSet'
CREATE TABLE [dbo].[MerkSet] (
    [Naam] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductMerkSet'
CREATE TABLE [dbo].[ProductMerkSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [MerkNaam] nvarchar(max)  NOT NULL,
    [Prijs] float  NOT NULL
);
GO

-- Creating table 'KortingSet'
CREATE TABLE [dbo].[KortingSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KortingCode] nvarchar(max)  NOT NULL,
    [BeginDatum] datetime  NOT NULL,
    [EindDatum] datetime  NOT NULL,
    [Percentage] float  NOT NULL,
    [ProductMerkId] int  NOT NULL
);
GO

-- Creating table 'BoodschappenLijstSet'
CREATE TABLE [dbo].[BoodschappenLijstSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TotaalPrijs] int  NOT NULL
);
GO

-- Creating table 'BoodschappenProductSet'
CREATE TABLE [dbo].[BoodschappenProductSet] (
    [BoodschappenLijstId] int  NOT NULL,
    [ProductMerkId] int  NOT NULL,
    [Aantal] int  NOT NULL
);
GO

-- Creating table 'ReceptSet'
CREATE TABLE [dbo].[ReceptSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naam] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ReceptProductSet'
CREATE TABLE [dbo].[ReceptProductSet] (
    [ReceptId] int  NOT NULL,
    [ProductMerkId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Naam] in table 'AfdelingSet'
ALTER TABLE [dbo].[AfdelingSet]
ADD CONSTRAINT [PK_AfdelingSet]
    PRIMARY KEY CLUSTERED ([Naam] ASC);
GO

-- Creating primary key on [Naam] in table 'MerkSet'
ALTER TABLE [dbo].[MerkSet]
ADD CONSTRAINT [PK_MerkSet]
    PRIMARY KEY CLUSTERED ([Naam] ASC);
GO

-- Creating primary key on [Id] in table 'ProductMerkSet'
ALTER TABLE [dbo].[ProductMerkSet]
ADD CONSTRAINT [PK_ProductMerkSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KortingSet'
ALTER TABLE [dbo].[KortingSet]
ADD CONSTRAINT [PK_KortingSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BoodschappenLijstSet'
ALTER TABLE [dbo].[BoodschappenLijstSet]
ADD CONSTRAINT [PK_BoodschappenLijstSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BoodschappenLijstId], [ProductMerkId] in table 'BoodschappenProductSet'
ALTER TABLE [dbo].[BoodschappenProductSet]
ADD CONSTRAINT [PK_BoodschappenProductSet]
    PRIMARY KEY CLUSTERED ([BoodschappenLijstId], [ProductMerkId] ASC);
GO

-- Creating primary key on [Id] in table 'ReceptSet'
ALTER TABLE [dbo].[ReceptSet]
ADD CONSTRAINT [PK_ReceptSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ReceptId], [ProductMerkId] in table 'ReceptProductSet'
ALTER TABLE [dbo].[ReceptProductSet]
ADD CONSTRAINT [PK_ReceptProductSet]
    PRIMARY KEY CLUSTERED ([ReceptId], [ProductMerkId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AfdelingNaam] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [FK_AfdelingProduct]
    FOREIGN KEY ([AfdelingNaam])
    REFERENCES [dbo].[AfdelingSet]
        ([Naam])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AfdelingProduct'
CREATE INDEX [IX_FK_AfdelingProduct]
ON [dbo].[ProductSet]
    ([AfdelingNaam]);
GO

-- Creating foreign key on [ProductId] in table 'ProductMerkSet'
ALTER TABLE [dbo].[ProductMerkSet]
ADD CONSTRAINT [FK_ProductProductMerk]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductMerk'
CREATE INDEX [IX_FK_ProductProductMerk]
ON [dbo].[ProductMerkSet]
    ([ProductId]);
GO

-- Creating foreign key on [MerkNaam] in table 'ProductMerkSet'
ALTER TABLE [dbo].[ProductMerkSet]
ADD CONSTRAINT [FK_MerkProductMerk]
    FOREIGN KEY ([MerkNaam])
    REFERENCES [dbo].[MerkSet]
        ([Naam])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MerkProductMerk'
CREATE INDEX [IX_FK_MerkProductMerk]
ON [dbo].[ProductMerkSet]
    ([MerkNaam]);
GO

-- Creating foreign key on [ProductMerkId] in table 'KortingSet'
ALTER TABLE [dbo].[KortingSet]
ADD CONSTRAINT [FK_ProductMerkKorting]
    FOREIGN KEY ([ProductMerkId])
    REFERENCES [dbo].[ProductMerkSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMerkKorting'
CREATE INDEX [IX_FK_ProductMerkKorting]
ON [dbo].[KortingSet]
    ([ProductMerkId]);
GO

-- Creating foreign key on [BoodschappenLijstId] in table 'BoodschappenProductSet'
ALTER TABLE [dbo].[BoodschappenProductSet]
ADD CONSTRAINT [FK_BoodschappenLijstBoodschappenProduct]
    FOREIGN KEY ([BoodschappenLijstId])
    REFERENCES [dbo].[BoodschappenLijstSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductMerkId] in table 'BoodschappenProductSet'
ALTER TABLE [dbo].[BoodschappenProductSet]
ADD CONSTRAINT [FK_ProductMerkBoodschappenProduct]
    FOREIGN KEY ([ProductMerkId])
    REFERENCES [dbo].[ProductMerkSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMerkBoodschappenProduct'
CREATE INDEX [IX_FK_ProductMerkBoodschappenProduct]
ON [dbo].[BoodschappenProductSet]
    ([ProductMerkId]);
GO

-- Creating foreign key on [ReceptId] in table 'ReceptProductSet'
ALTER TABLE [dbo].[ReceptProductSet]
ADD CONSTRAINT [FK_ReceptReceptProduct]
    FOREIGN KEY ([ReceptId])
    REFERENCES [dbo].[ReceptSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductMerkId] in table 'ReceptProductSet'
ALTER TABLE [dbo].[ReceptProductSet]
ADD CONSTRAINT [FK_ProductMerkReceptProduct]
    FOREIGN KEY ([ProductMerkId])
    REFERENCES [dbo].[ProductMerkSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMerkReceptProduct'
CREATE INDEX [IX_FK_ProductMerkReceptProduct]
ON [dbo].[ReceptProductSet]
    ([ProductMerkId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------