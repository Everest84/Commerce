USE [Commerce]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GoalType](
	[GoalTypeId] [int] NOT NULL,
	[Description1] [varchar](255) NOT NULL,
	[Description2] [varchar](255) NOT NULL,
 CONSTRAINT [PK_GoalType] PRIMARY KEY CLUSTERED 
(
	[GoalTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Goal](
	[GoalId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[GoalTypeId] [int] NOT NULL,
	[AccountType] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[Deadline] [datetime] NOT NULL,
 CONSTRAINT [PK_Goal] PRIMARY KEY CLUSTERED 
(
	[GoalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Goal] ADD  CONSTRAINT [DF_Goal_GoalId]  DEFAULT (newid()) FOR [GoalId]
GO

ALTER TABLE [dbo].[Goal] ADD  CONSTRAINT [DF_Goal_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[Goal] ADD CONSTRAINT [CK_Deadline] CHECK (Deadline > getdate())
GO 

ALTER TABLE [dbo].[Goal]  WITH CHECK ADD CONSTRAINT [FK_Goal_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO

ALTER TABLE [dbo].[Goal] CHECK CONSTRAINT [FK_Goal_UserId]
GO

ALTER TABLE [dbo].[Goal]  WITH CHECK ADD CONSTRAINT [FK_Goal_GoalTypeId] FOREIGN KEY([GoalTypeId])
REFERENCES [dbo].[GoalType] ([GoalTypeId])
GO

ALTER TABLE [dbo].[Goal] CHECK CONSTRAINT [FK_Goal_GoalTypeId]
GO