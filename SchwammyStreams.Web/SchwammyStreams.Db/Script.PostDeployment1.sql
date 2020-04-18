/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* This will only create the user on azure*/
if ((not exists(select * from sys.databases where name = 'SchwammyStreams')) AND (not exists(select * from sys.database_principals where name = '[schwammystreamsweb-svc-systest]')))
BEGIN

/* using a string because external provider is not valid syntax on local database */
EXEC ('create user [schwammystreamsweb-svc-systest] from external provider;')

ALTER ROLE db_datareader
  ADD MEMBER [schwammystreamsweb-svc-systest] 

ALTER ROLE db_datawriter
  ADD MEMBER [schwammystreamsweb-svc-systest] 
END
