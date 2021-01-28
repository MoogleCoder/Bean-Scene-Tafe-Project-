USE [BeanScene]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestuarantId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[UserId] [nvarchar](max) NULL,
	[RestuarantId] [int] NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[SittingId] [int] NOT NULL,
	[StatusIdId] [int] NULL,
	[StatusId1] [int] NULL,
	[SourceId] [int] NOT NULL,
	[Guest] [int] NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[Duration] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationSources]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationSources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReservationSources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationStatuses]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReservationStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restuarants]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restuarants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Restuarants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sittings]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sittings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SittingTypeId] [int] NOT NULL,
	[RestuarantId] [int] NOT NULL,
	[Start] [datetime2](7) NOT NULL,
	[End] [datetime2](7) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_Sittings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SittingTypes]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SittingTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_SittingTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableReservations]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableReservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[ReservationId] [int] NOT NULL,
 CONSTRAINT [PK_TableReservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 10/20/2020 4:47:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020053009_initial', N'3.1.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020053857_string', N'3.1.6')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201020054056_string2', N'3.1.6')
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
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Restuarants_RestuarantId] FOREIGN KEY([RestuarantId])
REFERENCES [dbo].[Restuarants] ([Id])
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Restuarants_RestuarantId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Restuarants_RestuarantId] FOREIGN KEY([RestuarantId])
REFERENCES [dbo].[Restuarants] ([Id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Restuarants_RestuarantId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_People_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[People] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_People_PersonId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_ReservationSources_SourceId] FOREIGN KEY([SourceId])
REFERENCES [dbo].[ReservationSources] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_ReservationSources_SourceId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_ReservationStatuses_StatusId1] FOREIGN KEY([StatusId1])
REFERENCES [dbo].[ReservationStatuses] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_ReservationStatuses_StatusId1]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_ReservationStatuses_StatusIdId] FOREIGN KEY([StatusIdId])
REFERENCES [dbo].[ReservationStatuses] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_ReservationStatuses_StatusIdId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Sittings_SittingId] FOREIGN KEY([SittingId])
REFERENCES [dbo].[Sittings] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Sittings_SittingId]
GO
ALTER TABLE [dbo].[Sittings]  WITH CHECK ADD  CONSTRAINT [FK_Sittings_Restuarants_RestuarantId] FOREIGN KEY([RestuarantId])
REFERENCES [dbo].[Restuarants] ([Id])
GO
ALTER TABLE [dbo].[Sittings] CHECK CONSTRAINT [FK_Sittings_Restuarants_RestuarantId]
GO
ALTER TABLE [dbo].[Sittings]  WITH CHECK ADD  CONSTRAINT [FK_Sittings_SittingTypes_SittingTypeId] FOREIGN KEY([SittingTypeId])
REFERENCES [dbo].[SittingTypes] ([Id])
GO
ALTER TABLE [dbo].[Sittings] CHECK CONSTRAINT [FK_Sittings_SittingTypes_SittingTypeId]
GO
ALTER TABLE [dbo].[TableReservations]  WITH CHECK ADD  CONSTRAINT [FK_TableReservations_Reservations_ReservationId] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservations] ([Id])
GO
ALTER TABLE [dbo].[TableReservations] CHECK CONSTRAINT [FK_TableReservations_Reservations_ReservationId]
GO
ALTER TABLE [dbo].[TableReservations]  WITH CHECK ADD  CONSTRAINT [FK_TableReservations_Tables_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[Tables] ([Id])
GO
ALTER TABLE [dbo].[TableReservations] CHECK CONSTRAINT [FK_TableReservations_Tables_TableId]
GO
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD  CONSTRAINT [FK_Tables_Areas_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[Tables] CHECK CONSTRAINT [FK_Tables_Areas_AreaId]
GO
