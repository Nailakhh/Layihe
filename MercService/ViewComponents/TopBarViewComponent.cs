using MercService.Core.ViewModels;
using MercService.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercService.ViewComponents
{
    public class TopBarViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public TopBarViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new HomeIndexViewModel
            {
                ContactInfo = await _context.ContactInfos.FirstOrDefaultAsync(),
                Location = await _context.Locations.FirstOrDefaultAsync(),
                SocialLinks = await _context.SocialLinks.ToListAsync()
            };

            return View(viewModel);
        }
    }
}