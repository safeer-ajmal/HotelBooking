using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interface
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<int> Update(Hotel hotel);
    }
}
