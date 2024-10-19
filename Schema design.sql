CREATE DATABASE CARS;
GO

USE CARS;
GO

CREATE TABLE Victims (
    VictimID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    ContactInformation VARCHAR(100)
);

CREATE TABLE Suspects (
    SuspectID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    ContactInformation VARCHAR(100)
);

CREATE TABLE LawEnforcementAgencies (
    AgencyID INT IDENTITY(1,1) PRIMARY KEY,
    AgencyName VARCHAR(100),
    Jurisdiction VARCHAR(100),
    ContactInformation VARCHAR(100)
);

CREATE TABLE Officers (
    OfficerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    BadgeNumber VARCHAR(20),
    Rank VARCHAR(20),
    ContactInformation VARCHAR(100),
    AgencyID INT FOREIGN KEY REFERENCES LawEnforcementAgencies(AgencyID)
);

CREATE TABLE Incidents (
    IncidentID INT IDENTITY(1,1) PRIMARY KEY,
    IncidentType VARCHAR(50),
    IncidentDate DATE,
    Location VARCHAR(250),
    Description TEXT,
    Status VARCHAR(20),
    VictimID INT FOREIGN KEY REFERENCES Victims(VictimID),
    SuspectID INT FOREIGN KEY REFERENCES Suspects(SuspectID)
);

CREATE TABLE Evidence (
    EvidenceID INT IDENTITY(1,1) PRIMARY KEY,
    Description TEXT,
    LocationFound VARCHAR(250),
    IncidentID INT FOREIGN KEY REFERENCES Incidents(IncidentID)
);

CREATE TABLE Reports (
    ReportID INT IDENTITY(1,1) PRIMARY KEY,
    IncidentID INT FOREIGN KEY REFERENCES Incidents(IncidentID),
    ReportingOfficer INT FOREIGN KEY REFERENCES Officers(OfficerID),
    ReportDate DATE,
    ReportDetails TEXT,
    Status VARCHAR(20)
);

CREATE TABLE Cases (
    CaseId INT IDENTITY(1,1) PRIMARY KEY, 
    CaseDescription NVARCHAR(255) NOT NULL, 
    CreatedAt DATETIME DEFAULT GETDATE()    
);

CREATE TABLE CaseIncidents (
    CaseId INT NOT NULL,
    IncidentId INT NOT NULL,
    PRIMARY KEY (CaseId, IncidentId),
    FOREIGN KEY (CaseId) REFERENCES Cases(CaseId),
    FOREIGN KEY (IncidentId) REFERENCES Incidents(IncidentId)
);

SELECT * FROM Victims;
SELECT * FROM Suspects;
SELECT * FROM Incidents;
SELECT * FROM Cases;
SELECT * FROM CaseIncidents;
