

IF ((SELECT COUNT(*) FROM CustomerRole WHERE SystemName = 'tekspecialist') = 0)
BEGIN
	INSERT INTO CustomerRole ([Name],SystemName,IsSystemRole,Active,PurchasedWithProductId,DefaultTaxDisplayTypeId,OverrideTaxDisplayType,EnablePasswordLifetime,TaxExempt,FreeShipping)
	VALUES ('Specialist','tekspecialist',1,1,0,0,0,0,0,0),
			('Assistant','tekassistant',1,1,0,0,0,0,0,0)
END
ELSE
BEGIN 
	UPDATE CustomerRole SET Active = 1 WHERE SystemName IN ('tekspecialist', 'tekassistant')
END

