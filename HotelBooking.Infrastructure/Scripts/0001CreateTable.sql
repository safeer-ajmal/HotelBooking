
    CREATE TABLE Hotel
    (
        ID INT PRIMARY KEY IDENTITY(1,1),
        Name VARCHAR(100) NOT NULL,
        Description VARCHAR(255) NOT NULL,
        Price DECIMAL(18, 2) NOT NULL,
        HotelCode AS (LEFT(Name, 2) + CAST(LEFT(CAST(Price AS VARCHAR), 2) AS VARCHAR)) PERSISTED
    );

