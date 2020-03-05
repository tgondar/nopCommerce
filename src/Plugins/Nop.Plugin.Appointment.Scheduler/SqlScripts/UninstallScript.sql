

IF ((SELECT COUNT(*) FROM CustomerRole WHERE SystemName = 'tekspecialist') > 0)
BEGIN 
	UPDATE CustomerRole SET Active = 0 WHERE SystemName = 'tekspecialist'
END

IF ((SELECT COUNT(*) FROM CustomerRole WHERE SystemName = 'tekassistant') > 0)
BEGIN 
	UPDATE CustomerRole SET Active = 0 WHERE SystemName = 'tekassistant'
END

