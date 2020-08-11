

IF ((SELECT COUNT(*) FROM CustomerRole WHERE SystemName = 'tekspecialist') = 0)
BEGIN
	INSERT INTO CustomerRole ([Name],SystemName,IsSystemRole,Active,PurchasedWithProductId,DefaultTaxDisplayTypeId,OverrideTaxDisplayType,EnablePasswordLifetime,TaxExempt,FreeShipping)
	VALUES ('Specialist','tekspecialist',1,1,0,0,0,0,0,0)
END
ELSE
BEGIN 
	UPDATE CustomerRole SET Active = 1 WHERE SystemName = 'tekspecialist'
END



IF ((SELECT COUNT(*) FROM CustomerRole WHERE SystemName = 'tekassistant') = 0)
BEGIN
	INSERT INTO CustomerRole ([Name],SystemName,IsSystemRole,Active,PurchasedWithProductId,DefaultTaxDisplayTypeId,OverrideTaxDisplayType,EnablePasswordLifetime,TaxExempt,FreeShipping)
	VALUES ('Assistant','tekassistant',1,1,0,0,0,0,0,0)
END
ELSE
BEGIN 
	UPDATE CustomerRole SET Active = 1 WHERE SystemName = 'tekassistant'
END



IF ((SELECT COUNT(*) FROM LocaleStringResource WHERE ResourceName = 'Plugins.Appointment.Scheduler.SpecialistUsername') = 0)
BEGIN
	INSERT INTO LocaleStringResource VALUES ('Especialista','Plugins.Appointment.Scheduler.SpecialistUsername',1)
END

IF ((SELECT COUNT(*) FROM LocaleStringResource WHERE ResourceName = 'Plugins.Appointment.Scheduler.CustomerUsername') = 0)
BEGIN
	INSERT INTO LocaleStringResource VALUES ('Cliente','Plugins.Appointment.Scheduler.CustomerUsername',1)
END

IF ((SELECT COUNT(*) FROM LocaleStringResource WHERE ResourceName = 'Plugins.Appointment.Scheduler.Date') = 0)
BEGIN
	INSERT INTO LocaleStringResource VALUES ('Data/Hora','Plugins.Appointment.Scheduler.Date',1)
END

IF ((SELECT COUNT(*) FROM LocaleStringResource WHERE ResourceName = 'Plugins.Appointment.Scheduler.Id') = 0)
BEGIN
	INSERT INTO LocaleStringResource VALUES ('#','Plugins.Appointment.Scheduler.Id',1)
END

