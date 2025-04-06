using HotelBooking.Application.Interface;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _db;
        public HotelController(IHotelRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var hotels = await _db.GetAll();
            return View(hotels);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _db.Add(hotel);
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                  .Select(e => e.ErrorMessage)
                                  .ToList();

            // Log validation errors or display them in the view
            Console.WriteLine(string.Join(", ", errors));
            ViewBag.ValidationErrors = errors;

            // Always return a view, even in case of unexpected errors
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int hotelid)
        {
            var hotel =  await _db.GetById(hotelid);

            return View(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _db.Update(hotel);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int hotelid)
        {
            var hotel = await _db.GetById(hotelid);
            return View(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Hotel hotel)
        {
           var log = await _db.Delete(hotel.Id);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Deleted: {hotel.Name}, Rows affected: {log}");
            Console.ResetColor();
            return RedirectToAction("Index");
        }

    }
}
