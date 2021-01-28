USE [BeanScene]
GO
SET IDENTITY_INSERT [dbo].[ReservationSources] ON 
GO
INSERT [dbo].[ReservationSources] ([Id], [Name]) VALUES (1, N'Online')
GO
INSERT [dbo].[ReservationSources] ([Id], [Name]) VALUES (2, N'Mobile App')
GO
INSERT [dbo].[ReservationSources] ([Id], [Name]) VALUES (3, N'Email')
GO
INSERT [dbo].[ReservationSources] ([Id], [Name]) VALUES (4, N'Phone')
GO
SET IDENTITY_INSERT [dbo].[ReservationSources] OFF
GO
SET IDENTITY_INSERT [dbo].[ReservationStatuses] ON 
GO
INSERT [dbo].[ReservationStatuses] ([Id], [Name]) VALUES (1, N'Pending')
GO
INSERT [dbo].[ReservationStatuses] ([Id], [Name]) VALUES (2, N'Confirmed')
GO
INSERT [dbo].[ReservationStatuses] ([Id], [Name]) VALUES (3, N'Cancelled')
GO
INSERT [dbo].[ReservationStatuses] ([Id], [Name]) VALUES (4, N'Seated')
GO
INSERT [dbo].[ReservationStatuses] ([Id], [Name]) VALUES (5, N'Completed')
GO
SET IDENTITY_INSERT [dbo].[ReservationStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Restuarants] ON 
GO
INSERT [dbo].[Restuarants] ([Id], [Name]) VALUES (1, N'Bean Scene')
GO
SET IDENTITY_INSERT [dbo].[Restuarants] OFF
GO
SET IDENTITY_INSERT [dbo].[SittingTypes] ON 
GO
INSERT [dbo].[SittingTypes] ([Id], [Name]) VALUES (1, N'Breakfast')
GO
INSERT [dbo].[SittingTypes] ([Id], [Name]) VALUES (2, N'Lunch')
GO
INSERT [dbo].[SittingTypes] ([Id], [Name]) VALUES (3, N'Dinner')
GO
INSERT [dbo].[SittingTypes] ([Id], [Name]) VALUES (4, N'Event')
GO
SET IDENTITY_INSERT [dbo].[SittingTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Areas] ON 
GO
INSERT [dbo].[Areas] ([Id], [RestuarantId], [Name]) VALUES (8, 1, N'Main')
GO
INSERT [dbo].[Areas] ([Id], [RestuarantId], [Name]) VALUES (9, 1, N'Outside')
GO
INSERT [dbo].[Areas] ([Id], [RestuarantId], [Name]) VALUES (10, 1, N'Balcony')
GO
SET IDENTITY_INSERT [dbo].[Areas] OFF
GO
SET IDENTITY_INSERT [dbo].[Tables] ON 
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (4, 8, N'M1')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (5, 8, N'M2')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (6, 8, N'M3')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (7, 8, N'M4')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (8, 8, N'M5')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (9, 8, N'M6')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (10, 8, N'M7')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (11, 8, N'M8')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (13, 8, N'M9')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (14, 8, N'M10')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (15, 9, N'O1')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (16, 9, N'O2')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (17, 9, N'O3')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (18, 9, N'O4')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (19, 9, N'O5')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (20, 9, N'O6')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (21, 9, N'O7')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (22, 9, N'O8')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (23, 9, N'O9')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (24, 9, N'O10')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (25, 10, N'B1')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (26, 10, N'B2')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (27, 10, N'B3')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (28, 10, N'B4')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (29, 10, N'B5')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (30, 10, N'B6')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (31, 10, N'B7')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (32, 10, N'B8')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (33, 10, N'B9')
GO
INSERT [dbo].[Tables] ([Id], [AreaId], [Name]) VALUES (34, 10, N'B10')
GO
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020053009_initial', N'3.1.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020053857_string', N'3.1.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020054056_string2', N'3.1.6')
GO
