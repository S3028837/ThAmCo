using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.GuestBookingList
{
    public class CreateModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public CreateModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            //Debugged with help from Microsoft Copilot
            //Gets Event Details
            GuestBooking = _context.GuestBookings
                .Include(gb => gb.Event)
                .FirstOrDefault(gb => gb.EventId == id);

            ViewData["EventName"] = GuestBooking.Event.EventName;
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName");
            return Page();
        }

        [BindProperty]
        public GuestBooking GuestBooking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GuestBookings.Add(GuestBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("/EventList/Guests", new { id = GuestBooking.EventId });
        }
    }
}
