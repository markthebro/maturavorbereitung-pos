CREATE TABLE [Employee] (
  [ID] UNIQUEIDENTIFIER DEFAULT NEWID(),
  [Firstname] NVARCHAR(50) NOT NULL,
  [Lastname] NVARCHAR(50) NOT NULL,
  [SVNR] NVARCHAR(10) NOT NULL,

  CONSTRAINT [PK_Employee] PRIMARY KEY ([ID]),
);
GO

CREATE TABLE [Vehicle] (
  [ID] UNIQUEIDENTIFIER,
  [Brand] NVARCHAR(32) NOT NULL CONSTRAINT [DF_Vehicle_Brand] DEFAULT ('no brand'),
  [Model] NVARCHAR(25) NOT NULL CONSTRAINT [DF_Vehicle_Model] DEFAULT ('unknown'),
  [VehicleNo] NVARCHAR(50) NOT NULL,
  [NumberPlate] NVARCHAR(50) NOT NULL,
  [Type] NVARCHAR(25) NOT NULL CONSTRAINT [DF_Vehicle_Type] DEFAULT ('PKW'),
  [km] DECIMAL(9,2),

  CONSTRAINT [PK_Vehicle] PRIMARY KEY ([ID]),
  CONSTRAINT [UQ_Vehicle] UNIQUE ([VehicleNo]),
);
GO

CREATE TABLE [Reservation] (
  [ID] UNIQUEIDENTIFIER,
  [VehicleID] UNIQUEIDENTIFIER NOT NULL,
  [EmployeeID] UNIQUEIDENTIFIER NOT NULL,
  [Date] DATETIME NOT NULL
  
  CONSTRAINT [PK_Reservation] PRIMARY KEY ([ID]),
  CONSTRAINT [UQ_Reservation] UNIQUE ([VehicleID], [EmployeeID], [Date]),
  CONSTRAINT [UQ_Reservation_Vehicle] UNIQUE ([VehicleID], [Date]),
  CONSTRAINT [UQ_Reservation_Employee] UNIQUE ([EmployeeID], [Date]),
  CONSTRAINT [FK_Reservation_Vehicle] FOREIGN KEY ([VehicleID]) REFERENCES [Vehicle]([ID]),
  CONSTRAINT [FK_Reservation_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [Employee]([ID]),
);
GO

CREATE TABLE [Trip] (
  [ID] UNIQUEIDENTIFIER,
  [StartDate] DATETIME NOT NULL,
  [EndDate] DATETIME NOT NULL,
  [kmBegin] DECIMAL(9,2) NOT NULL,
  [kmEnd] DECIMAL(9,2) NOT NULL,
  [StartLoc] NVARCHAR(99) NOT NULL,
  [EndLoc] NVARCHAR(99) NOT NULL,
  [twoWay] BIT NOT NULL,

  [VehicleID] UNIQUEIDENTIFIER NOT NULL,
  [EmployeeID] UNIQUEIDENTIFIER NOT NULL,

  CONSTRAINT [PK_Trip] PRIMARY KEY ([ID]),
  CONSTRAINT [FK_Trip_Vehicle] FOREIGN KEY ([VehicleID]) REFERENCES [Vehicle]([ID]),
  CONSTRAINT [FK_Trip_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [Employee]([ID]),
);
GO