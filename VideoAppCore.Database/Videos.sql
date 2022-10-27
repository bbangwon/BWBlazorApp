﻿-- 비디오 테이블
CREATE TABLE [dbo].[Videos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Title] NVARCHAR(MAX) NOT NULL,  -- 제목
	[Url] NVARCHAR(MAX) NULL,	-- URL
	[Name] NVARCHAR(MAX) NULL,	-- 이름
	[Company] NVARCHAR(255) NULL,	-- 회사
	[Created] DATETIME DEFAULT(GETDATE()),
)
