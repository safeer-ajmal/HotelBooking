
EXEC sp_rename 'dbo.HotelBooking', 'Hotel';
ALTER TABLE dbo.Hotel ADD Rating INT NULL;

EXEC sp_rename 'dbo.Hotel.Rating', 'Stars1';
