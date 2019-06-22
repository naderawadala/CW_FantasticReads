CREATE TABLE [dbo].[Users] (
    [UserID]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [IsAdmin]  BIT           NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);



