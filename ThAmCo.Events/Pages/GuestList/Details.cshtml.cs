using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.GuestList
{
    public class DetailsModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public DetailsModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        //gets a guests details
        public Guest Guest { get; set; } = default!;


        //gets a list of guest bookings
        public IList<GuestBooking> GuestBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //getsa specific guests details
            var guest = await _context.Guests.FirstOrDefaultAsync(m => m.GuestId == id);
            if (guest == null)
            {
                return NotFound();
            }
            else
            {
                Guest = guest;
            }

            //gets the guest bookings that the guest has booked onto
            var bookingContext = _context.GuestBookings.AsQueryable();
            if (id != null)
            {
                bookingContext = bookingContext.Where(b => b.GuestId == id);
            }
            bookingContext = bookingContext
                .Include(g => g.Guest)
                .Include(g => g.Event);

            GuestBooking = await bookingContext.ToListAsync();

            return Page();
        }

    }
}
