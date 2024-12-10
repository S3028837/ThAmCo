using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.GuestBookingList
{
    public class DeleteModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public DeleteModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;
        public Guest Guest { get; set; } = default!;

        [BindProperty]
        public GuestBooking GuestBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbooking = await _context.GuestBookings
                                        .Include(gb => gb.Guest)
                                        .Include(gb => gb.Event)
                                        .FirstOrDefaultAsync(m => m.GuestBookingId == id);

            if (guestbooking == null)
            {
                return NotFound();
            }
            else
            {
                GuestBooking = guestbooking;
            }
           
            Guest = guestbooking.Guest;
            Event = guestbooking.Event;

            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbooking = await _context.GuestBookings.FindAsync(id);
            if (guestbooking != null)
            {
                GuestBooking = guestbooking;
                _context.GuestBookings.Remove(GuestBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
