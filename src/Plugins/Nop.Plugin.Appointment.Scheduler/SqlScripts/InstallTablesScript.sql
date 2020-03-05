
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_NAME = 'TekAppointment'))
BEGIN

	CREATE TABLE dbo.TekAppointment
	(
		Id INT,
		[Date] DATETIME NOT NULL,
		Observation NVARCHAR(MAX),
		CustomerId INT NOT NULL,
		SpecialistId INT NOT NULL,

		Deleted BIT NOT NULL,
		CreatedOnUtc DATETIME NOT NULL,
		CreatedBy NVARCHAR(MAX),
		UpdatedOnUtc DATETIME NOT NULL,
		UpdatedBy NVARCHAR(MAX),

		CONSTRAINT Pk_tdAppointment_Id  PRIMARY KEY (Id)
	)

END

