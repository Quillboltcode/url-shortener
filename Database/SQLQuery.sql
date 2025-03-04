/* Get connection string */
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name();

/* Creat table url in database */
CREATE DATABASE UrlshortenDB;

/* Use database */
Use UrlshortenDB;


CREATE TABLE UrlMappings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ShortCode NVARCHAR(10) NOT NULL UNIQUE,
    LongUrl NVARCHAR(2048) NOT NULL,
    CreatedAt DATETIME NOT NULL
);

/*View table */
Select * From dbo.UrlMappings