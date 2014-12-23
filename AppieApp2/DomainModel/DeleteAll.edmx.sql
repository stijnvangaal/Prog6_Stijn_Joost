
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/23/2014 18:02:28
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
    ALTER TABLE [dbo].[ProductSet] DROP CONSTRAINT [FK_AfdelingProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_BoodschappenLijstBoodschappenProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoodschappenProductSet] DROP CONSTRAINT [FK_BoodschappenLijstBoodschappenProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMerkBoodschappenProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoodschappenProductSet] DROP CONSTRAINT [FK_ProductMerkBoodschappenProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMerkKorting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KortingSet] DROP CONSTRAINT [FK_ProductMerkKorting];
GO
IF OBJECT_ID(N'[dbo].[FK_MerkProductMerk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductMerkSet] DROP CONSTRAINT [FK_MerkProductMerk];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductMerk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductMerkSet] DROP CONSTRAINT [FK_ProductProductMerk];
GO
IF OBJECT_ID(N'[dbo].[FK_ReceptProductSet_ProductMerkSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceptProductSet] DROP CONSTRAINT [FK_ReceptProductSet_ProductMerkSet];
GO
IF OBJECT_ID(N'[dbo].[FK_ReceptProductSet_ReceptSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceptProductSet] DROP CONSTRAINT [FK_ReceptProductSet_ReceptSet];
GO
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
IF OBJECT_ID(N'[dbo].[FK_ProductMerkBoodschappenProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoodschappenProductSet1] DROP CONSTRAINT [FK_ProductMerkBoodschappenProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMerkReceptProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceptProductSet1] DROP CONSTRAINT [FK_ProductMerkReceptProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AfdelingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AfdelingSet];
GO
IF OBJECT_ID(N'[dbo].[BoodschappenLijstSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoodschappenLijstSet];
GO
IF OBJECT_ID(N'[dbo].[BoodschappenProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoodschappenProductSet];
GO
IF OBJECT_ID(N'[dbo].[KortingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KortingSet];
GO
IF OBJECT_ID(N'[dbo].[MerkSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MerkSet];
GO
IF OBJECT_ID(N'[dbo].[ProductMerkSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductMerkSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[ReceptSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceptSet];
GO
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
IF OBJECT_ID(N'[dbo].[ReceptProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceptProductSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------