using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HotelBooking.Application.Interface;

namespace HotelBooking.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbConnection _db;
        public Repository(IDbConnection db){
            _db = db;
        }
        public async Task<int> Add(T entity)
        {
            var query = @"INSERT INTO dbo.Hotel (Name, Location, Price, Stars) VALUES 
                (@Name, @Location, @Price, @Stars);
            SELECT CAST(SCOPE_IDENTITY() AS int)";
            return await _db.ExecuteScalarAsync<int>(query, entity);
        }

        public async Task<int> Delete(int id)
        {
            var query = "DELETE FROM dbo.Hotel WHERE ID = @id";
            return await _db.ExecuteAsync(query, new { ID = id });
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query = "SELECT * FROM dbo.Hotel";
                return await _db.QueryAsync<T>(query);
        }

        public async Task<T?> GetById(int id)
        {
            var query = "SELECT * FROM dbo.Hotel WHERE ID = @id";
            return await _db.QueryFirstOrDefaultAsync<T>(query, new {ID = id });
        }
    }
}
