using MercService.Core.Models;
using MercService.Core.ViewModels;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MercService.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSettingsController : Controller
    {
        private readonly AppDbContext _context;

        public AdminSettingsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new SiteInfoViewModel
            {
                ContactInfo = await _context.ContactInfos.FirstOrDefaultAsync(),
                Locations = await _context.Locations.ToListAsync(),
                SocialLinks = await _context.SocialLinks.ToListAsync()
            };

            return View(viewModel);
        }

      


        // --------------------- LOCATION -------------------------
        [HttpPost]
        public IActionResult AddLocation(string Name, string Address, string Latitude, string Longitude)
        {
            if (!double.TryParse(Latitude, NumberStyles.Any, CultureInfo.InvariantCulture, out double lat) ||
                !double.TryParse(Longitude, NumberStyles.Any, CultureInfo.InvariantCulture, out double lng))
            {
                return BadRequest("Koordinat formatı səhvdir.");
            }

            var newLoc = new Location
            {
                Name = Name,
                Address = Address,
                Latitude = lat,
                Longitude = lng
            };

            _context.Locations.Add(newLoc);
            _context.SaveChanges();

            return Json(new
            {
                id = newLoc.Id,
                name = newLoc.Name,
                latitude = newLoc.Latitude,
                longitude = newLoc.Longitude
            });
        }



        [HttpPost]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            var existing = await _context.Locations.FindAsync(location.Id);
            if (existing != null)
            {
                existing.Name = location.Name;
                existing.Address = location.Address;
                existing.Latitude = location.Latitude;
                existing.Longitude = location.Longitude;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // --------------------- SOCIAL LINK ----------------------

        [HttpPost]
        public async Task<IActionResult> AddSocialLink(SocialLink link)
        {
            _context.SocialLinks.Add(link);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialLink(SocialLink link)
        {




            var existing = await _context.SocialLinks.FindAsync(link.Id);
            if (existing != null)
            {
                existing.Platform = link.Platform;
                existing.Url = link.Url;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSocialLink(int id)
        {
            var link = await _context.SocialLinks.FindAsync(id);
            if (link != null)
            {
                _context.SocialLinks.Remove(link);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}