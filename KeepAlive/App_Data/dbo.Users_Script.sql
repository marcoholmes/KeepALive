CREATE TABLE [dbo].[Users] (
    [Id_user]          INT            IDENTITY (1, 1) NOT NULL,
    [ce_username]      NVARCHAR (20)  NOT NULL,
    [ce_pwd]           NVARCHAR (50)  NOT NULL,
    [de_email]         NVARCHAR (100) NOT NULL,
    [yn_locked]        BIT            NULL,
    [da_registration]  DATETIME       NULL,
    [da_last_login]    DATETIME       NULL,
    [yn_confirm_email] BIT            NULL,
    [ce_pwd_hash] NCHAR(200) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id_user] ASC),
    UNIQUE NONCLUSTERED ([de_email] ASC),
    UNIQUE NONCLUSTERED ([ce_username] ASC)
);

