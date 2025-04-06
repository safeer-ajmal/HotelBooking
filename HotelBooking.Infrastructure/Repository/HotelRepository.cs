using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HotelBooking.Application.Interface;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Infrastructure.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private readonly IDbConnection _db;
        public HotelRepository(IDbConnection db) : base(db)
        {
            _db = db;
        }

        public async Task<int> Update(Hotel hotel)
        {
            var query = @"UPDATE dbo.Hotel SET Name = @Name, Location = @Location, Price = @Price, Stars = @Stars WHERE ID = @Id";
        return await _db.ExecuteAsync(query, hotel);
        }
    }
}
