CREATE TABLE [dbo].[Book] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (200) NOT NULL,
    [Price]         FLOAT (53)     NOT NULL,
    [DateOfRelease] DATE           NOT NULL,
    [Pages]         INT            NOT NULL,
    [AuthorID]      INT            NOT NULL,
    [SeriesID]      INT            NULL,
    [GenreID]       INT            NOT NULL,
    [CoverURL]      NVARCHAR (200) NULL,
    CONSTRAINT [PK_Book_1] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Author] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Book_Genre1] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genre] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Book_Series] FOREIGN KEY ([SeriesID]) REFERENCES [dbo].[Series] ([ID]) ON DELETE CASCADE
);











