using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThAmCo.Events.Data;
using ThAmCo.Events.Services;

namespace ThAmCo.Events.Pages.EventList
{
    public class CreateModel : PageModel
    {

        //Registered data and services
        private readonly ThAmCo.Events.Data.EventsDbContext _context;
        private readonly EventTypeService _EventTypeService;

        public CreateModel(ThAmCo.Events.Data.EventsDbContext context, EventTypeService EventTypeService)
        {
            _context = context;
            _EventTypeService = EventTypeService;
        }

        //GET methods
        public async Task<IActionResult> OnGetAsync()
        {
            //GETs event types from service
            var et = await _EventTypeService.GetEventTypesAsync();
            var eventTypes = et.ToList();
            ViewData["EventType"] = new SelectList(eventTypes, "id", "title");

            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
