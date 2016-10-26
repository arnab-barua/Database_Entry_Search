CREATE PROCEDURE lastOne
	@word varchar(MAX)
AS
	SELECT DISTINCT nexa.*,contact.*, detail.*
	FROM (SELECT items FROM Split(@word, ',')) AS SplitTbl
		INNER JOIN nexa
		ON CHARINDEX(items, nexa.Name) > 0
		INNER JOIN contact
		ON nexa.ID=contact.ID
		INNER JOIN detail
		ON nexa.ID=detail.ID