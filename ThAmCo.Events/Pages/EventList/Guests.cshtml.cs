using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.EventList
{
    public class GuestsModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public GuestsModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public IList<Guest> Guest { get; set; } = default!;

        [BindProperty]
        public List<GuestBookingVM> Bookings { get; set; } = new List<GuestBookingVM>();

        
        //Lists guests for a specified Event
        public IList<GuestBooking> GuestBooking { get;set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            var bookingContext = _context.GuestBookings.AsQueryable();
            if (id != null)
            {
                bookingContext = bookingContext.Where(b => b.EventId == id);
            }
            bookingContext = bookingContext
                .Include(g => g.Guest)
                .Include(g => g.Event);

            GuestBooking = await bookingContext.ToListAsync();

            Bookings = GuestBooking.Select(g => new GuestBookingVM
            {
                 Attendance = g.Attendance,
                  EventId = g.EventId,
                   EventName = g.Event.EventName,
                    GuestEmail = g.Guest.GuestEmail,
                    GuestPhone = g.Guest.GuestPhone,
                     GuestId = g.GuestId,
                       GuestName = g.Guest.GuestName,
            }).ToList();
        }



        //method to register attendance
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GuestBooking).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GuestBookingExists(GuestBooking.GuestBookingId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("/Eventlist/Index");
        }
        private bool GuestBookingExists(int id)
        {
            return _context.GuestBookings.Any(e => e.GuestBookingId == id);
        }
    }
}
