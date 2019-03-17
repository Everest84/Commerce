USE [Commerce]
GO

/****** Object:  Table [dbo].[UserCredentials]    Script Date: 3/16/2019 11:01:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserCredentials](
	[UserId] [uniqueidentifier] NOT NULL,
	[Salt] [varchar](255) NOT NULL,
 CONSTRAINT [PK_UserCredentials] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserCredentials]  WITH CHECK ADD  CONSTRAINT [FK_UserCredentials_UserRegistration_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO

ALTER TABLE [dbo].[UserCredentials] CHECK CONSTRAINT [FK_UserCredentials_UserRegistration_UserId]
GO

