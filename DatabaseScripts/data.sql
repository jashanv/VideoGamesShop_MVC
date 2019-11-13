INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'60e7503c-f6b5-437a-9192-a5e3307a7739', N'admin@gameplay.com', N'ADMIN@GAMEPLAY.COM', N'admin@gameplay.com', N'ADMIN@GAMEPLAY.COM', 1, N'AQAAAAEAACcQAAAAEHWaJNy/jS2ahPo+fmg+hZnjLqi0ATSdg5t6qGY97L852WdxWRXnA1tgc8XrBzMIyw==', N'7WRTLZ26NIRIDCKZSM75AY3GFXXBCW4L', N'24733751-00b2-4b06-bb1e-6365201590ef', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Player] ON
INSERT INTO [dbo].[Player] ([Id], [Name], [ContactNumber]) VALUES (1, N'John Smith', N'02134567890')
INSERT INTO [dbo].[Player] ([Id], [Name], [ContactNumber]) VALUES (2, N'Peter Parker', N'02109923456')
INSERT INTO [dbo].[Player] ([Id], [Name], [ContactNumber]) VALUES (3, N'Ken Gareth', N'02177712345')
SET IDENTITY_INSERT [dbo].[Player] OFF
SET IDENTITY_INSERT [dbo].[VideoGame] ON
INSERT INTO [dbo].[VideoGame] ([Id], [Name], [HighestScore], [PricePerPlay]) VALUES (1, N'Delta Force', 6000, CAST(10.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[VideoGame] ([Id], [Name], [HighestScore], [PricePerPlay]) VALUES (2, N'Mortal Kombat ', 7000, CAST(12.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[VideoGame] ([Id], [Name], [HighestScore], [PricePerPlay]) VALUES (3, N'Need For Speed', 8000, CAST(10.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[VideoGame] ([Id], [Name], [HighestScore], [PricePerPlay]) VALUES (4, N'Splinter Cell', 200000, CAST(20.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[VideoGame] OFF
SET IDENTITY_INSERT [dbo].[GamePlay] ON
INSERT INTO [dbo].[GamePlay] ([Id], [PlayerId], [VideoGameId], [StartTime]) VALUES (1, 1, 1, N'2019-11-14 09:22:00')
INSERT INTO [dbo].[GamePlay] ([Id], [PlayerId], [VideoGameId], [StartTime]) VALUES (2, 2, 3, N'2019-11-15 10:00:00')
INSERT INTO [dbo].[GamePlay] ([Id], [PlayerId], [VideoGameId], [StartTime]) VALUES (3, 1, 4, N'2019-11-28 09:50:00')
SET IDENTITY_INSERT [dbo].[GamePlay] OFF
