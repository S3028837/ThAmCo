using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuFoodItemsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public MenuFoodItemsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuFoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuFoodItem>>> GetMenuFoodItems()
        {
            return await _context.MenuFoodItems.ToListAsync();
        }

        // GET: api/MenuFoodItems/5
        [HttpGet("{MenuId}/{FoodItemId}")]
        public async Task<ActionResult<MenuFoodItem>> GetMenuFoodItem(int MenuId, int FoodItemId)
        {
            var menuFoodItem = await _context.MenuFoodItems.FirstOrDefaultAsync
                (m => m.MenuId == MenuId && m.FoodItemID == FoodItemId);

            if (menuFoodItem == null)
            {
                return NotFound();
            }

            return menuFoodItem;
        }

        // PUT: api/MenuFoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MenuId}/{FoodItemId}")]
        public async Task<IActionResult> PutMenuFoodItem(int MenuId, int FoodItemId, MenuFoodItem menuFoodItem)
        {
            //checks if specified menufooditem exists
            if (MenuId != menuFoodItem.MenuId || FoodItemId != menuFoodItem.FoodItemID)
            {
                return BadRequest();
            }

            _context.Entry(menuFoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {

                if (!MenuFoodItemExists(MenuId, FoodItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool MenuFoodItemExists(int menuId, int foodItemId)
        {
            return _context.MenuFoodItems.Any(m => m.MenuId == menuId || m.FoodItemID == foodItemId);
        }

        // POST: api/MenuFoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuFoodItem>> PostMenuFoodItem(MenuFoodItem menuFoodItem)
        {
            _context.MenuFoodItems.Add(menuFoodItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuFoodItemExists(menuFoodItem.MenuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuFoodItem", new { id = menuFoodItem.MenuId }, menuFoodItem);
        }

        // DELETE: api/MenuFoodItems/5
        [HttpDelete("{MenuId}/{FoodItemId}")]
        public async Task<IActionResult> DeleteMenuFoodItem(int MenuId, int FoodItemId)
        {
            var menuFoodItem = await _context.MenuFoodItems.FindAsync(MenuId, FoodItemId);
            if (menuFoodItem == null)
            {
                return NotFound();
            }

            _context.MenuFoodItems.Remove(menuFoodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItems.Any(e => e.MenuId == id);
        }
    }
}
