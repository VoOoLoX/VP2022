CREATE TABLE [Orders] (
	ID int NOT NULL IDENTITY,
	FirstName varchar(50) NULL,
	LastName varchar(50) NULL,
	Country varchar(100) NULL,
	City varchar(100) NULL,
	Street varchar(200) NULL,
	PostalCode int DEFAULT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE [Roles] (
	ID int NOT NULL IDENTITY,
	Name varchar(50) NULL,
	PRIMARY KEY (ID)
);

SET IDENTITY_INSERT [Roles] ON
INSERT INTO [Roles] (ID, Name) VALUES (1, N'Customer')
INSERT INTO [Roles] (ID, Name) VALUES (2, N'Manager')
INSERT INTO [Roles] (ID, Name) VALUES (3, N'Admin')
SET IDENTITY_INSERT [Roles] OFF

CREATE TABLE [Users] (
	ID int NOT NULL IDENTITY,
	Email varchar(100) NULL,
	Password varchar(255) DEFAULT NULL,
	RoleID int DEFAULT 1,
	PRIMARY KEY (ID),
	FOREIGN KEY (RoleID) REFERENCES [Roles] (ID)
);

CREATE TABLE [Manufacturers] (
	ID int NOT NULL IDENTITY,
	Name varchar(50) NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE [VehicleModels] (
	ID int NOT NULL IDENTITY,
	Name varchar(50) NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE [VehicleTypes] (
	ID int NOT NULL IDENTITY,
	Name varchar(50) DEFAULT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE [Features] (
	ID int NOT NULL IDENTITY,
	CruiseControl bit DEFAULT NULL,
	ParkingSensors bit DEFAULT NULL,
	ElectricWindows bit DEFAULT NULL,
	Sunroof bit DEFAULT NULL,
	XenonHeadlights bit DEFAULT NULL,
	Multimedia bit DEFAULT NULL,
	PowerAssistedSteering bit DEFAULT NULL,
	AirConditioning bit DEFAULT NULL,
	Navigation bit DEFAULT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE [Security] (
	ID int NOT NULL IDENTITY,
	Airbag bit DEFAULT NULL,
	ESP bit DEFAULT NULL,
	ASR bit DEFAULT NULL,
	ChildLock bit DEFAULT NULL,
	Immobiliser bit DEFAULT NULL,
	CentralLocking bit DEFAULT NULL,
	PRIMARY KEY (ID)
);

CREATE TABLE [Vehicles] (
	ID int NOT NULL IDENTITY,
	Price decimal(16,2) DEFAULT NULL,
	Mileage decimal DEFAULT NULL,
	Year int DEFAULT NULL,
	Color varchar(20) NULL,
	Fuel varchar(20) DEFAULT NULL,
	CubicCapacity int DEFAULT NULL,
	HorsePower int DEFAULT NULL,
	ManufacturerID int DEFAULT NULL,
	ModelID int DEFAULT NULL,
	TypeID int DEFAULT NULL,
	FeaturesID int DEFAULT NULL,
	SecurityID int DEFAULT NULL,
	PRIMARY KEY (ID),
	FOREIGN KEY (ManufacturerID) REFERENCES [Manufacturers] (ID),
	FOREIGN KEY (ModelID) REFERENCES [VehicleModels] (ID),
	FOREIGN KEY (TypeID) REFERENCES [VehicleTypes] (ID),
	FOREIGN KEY (FeaturesID) REFERENCES Features (ID),
	FOREIGN KEY (SecurityID) REFERENCES Security (ID)
);

CREATE TABLE [Images] (
	ID int NOT NULL IDENTITY,
	Blob varbinary(max),
	VehicleID int DEFAULT NULL,
	PRIMARY KEY (ID),
	FOREIGN KEY (VehicleID) REFERENCES Vehicles (ID)
);

CREATE TABLE [SoldVehicles] (
	ID int NOT NULL IDENTITY,
	Date date DEFAULT NULL,
	VehicleID int DEFAULT NULL,
	UserID int DEFAULT NULL,
	OrderID int DEFAULT NULL,
	PRIMARY KEY (ID),
	FOREIGN KEY (VehicleID) REFERENCES [Vehicles] (ID),
	FOREIGN KEY (UserID) REFERENCES [Users] (ID),
	FOREIGN KEY (OrderID) REFERENCES [Orders] (ID)
);