
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/25/2018 15:28:17
-- Generated from EDMX file: C:\Users\lowet\OneDrive\Axxes\.Net Competence\2018\Traineeship\Data Access\DataAccess.Part4.ModelFirst\DataAccess.Part4.ModelFirst\ConsultantModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Consultants];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ConsultantResumeItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResumeItems] DROP CONSTRAINT [FK_ConsultantResumeItem];
GO
IF OBJECT_ID(N'[dbo].[FK_CertificationResumeItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResumeItems] DROP CONSTRAINT [FK_CertificationResumeItem];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Consultants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Consultants];
GO
IF OBJECT_ID(N'[dbo].[Certifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Certifications];
GO
IF OBJECT_ID(N'[dbo].[ResumeItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResumeItems];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Consultants'
CREATE TABLE [dbo].[Consultants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(64)  NOT NULL,
    [LastName] nvarchar(64)  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [NoTurnSignals] bit  NOT NULL
);
GO

-- Creating table 'Certifications'
CREATE TABLE [dbo].[Certifications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(64)  NOT NULL,
    [CertificationCode] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ResumeItems'
CREATE TABLE [dbo].[ResumeItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateAcquired] datetime  NOT NULL,
    [Consultant_Id] int  NOT NULL,
    [Certification_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Consultants'
ALTER TABLE [dbo].[Consultants]
ADD CONSTRAINT [PK_Consultants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Certifications'
ALTER TABLE [dbo].[Certifications]
ADD CONSTRAINT [PK_Certifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResumeItems'
ALTER TABLE [dbo].[ResumeItems]
ADD CONSTRAINT [PK_ResumeItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Consultant_Id] in table 'ResumeItems'
ALTER TABLE [dbo].[ResumeItems]
ADD CONSTRAINT [FK_ConsultantResumeItem]
    FOREIGN KEY ([Consultant_Id])
    REFERENCES [dbo].[Consultants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsultantResumeItem'
CREATE INDEX [IX_FK_ConsultantResumeItem]
ON [dbo].[ResumeItems]
    ([Consultant_Id]);
GO

-- Creating foreign key on [Certification_Id] in table 'ResumeItems'
ALTER TABLE [dbo].[ResumeItems]
ADD CONSTRAINT [FK_CertificationResumeItem]
    FOREIGN KEY ([Certification_Id])
    REFERENCES [dbo].[Certifications]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CertificationResumeItem'
CREATE INDEX [IX_FK_CertificationResumeItem]
ON [dbo].[ResumeItems]
    ([Certification_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------