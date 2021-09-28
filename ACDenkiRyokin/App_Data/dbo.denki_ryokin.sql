CREATE TABLE [dbo].[denki_ryokin] (
    [ManagementID]         NVARCHAR (50) NOT NULL,
    [ChangeInfomation] NVARCHAR (15) NULL,
    [Date]         DATE          NULL,
    [Applicant]        NVARCHAR (50) NULL,
    [Status]           NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([ManagementID] ASC)
);

