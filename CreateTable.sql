CREATE TABLE [dbo].[Readers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [Addres] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[SupplyStates]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IssueStatus] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[ReturnStates]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [RetState] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BookTitle] NVARCHAR(50) NOT NULL, 
    [Authoe] NVARCHAR(50) NOT NULL, 
    [Year] NVARCHAR(50) NOT NULL, 
    [ReaderId] INT NULL, 
    [SupplyStateId] INT NULL, 
    [ReturnStateId] INT NULL

CONSTRAINT [FK_Readers_Books] FOREIGN KEY ([ReaderId]) REFERENCES [Readers]([Id]) ON DELETE SET NULL,
CONSTRAINT [FK_Supply_Books] FOREIGN KEY ([SupplyStateId]) REFERENCES [SupplyStates]([Id]) ON DELETE SET NULL,
CONSTRAINT [FK_Return_Books] FOREIGN KEY ([ReturnStateId]) REFERENCES [ReturnStates]([Id]) ON DELETE SET NULL
)
