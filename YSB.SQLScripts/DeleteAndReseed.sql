USE [YSB]
GO

DELETE FROM dbo.Curriculums

DBCC CHECKIDENT('Curriculums', RESEED, 0)
