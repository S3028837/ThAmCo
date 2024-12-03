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
        }


        //method to register attendance
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the updated guest bookings to the database or other storage

            return RedirectToPage("/Eventlist/Index");
        }
    
    }
}
