using MercService.DAL.Context;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LookupController : ControllerBase
{
    private readonly AppDbContext _context;

    public LookupController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var categories = _context.Categories
            .Select(c => new { c.Id, c.Name })
            .ToList();

        return Ok(categories);
    }

    [HttpGet("models")]
    public IActionResult GetModels(int categoryId)
    {
        var models = _context.Models
            .Where(m => m.CategoryId == categoryId)
            .Select(m => new { m.Id, m.Name })
            .ToList();

        return Ok(models);
    }

    [HttpGet("years")]
    public IActionResult GetYears()
    {
        // Artıq modelId ilə filtr etmirik — 2000-dən indiki ilə qədər bütün illər
        var years = Enumerable.Range(2000, DateTime.Now.Year - 1999)
            .Select(y => new { Id = y, Name = y.ToString() })
            .ToList();

        return Ok(years);
    }

    [HttpGet("problems")]
    public IActionResult GetProblems()
    {
        var problems = _context.CarProblems
            .Select(p => new { p.Id, p.Title })
            .ToList();

        return Ok(problems);
    }

    [HttpGet("submodels")]
    public IActionResult GetSubModels(int modelId)
    {
        var subModels = _context.SubModels
            .Where(sm => sm.ModelId == modelId)
            .Select(sm => new { sm.Id, sm.Name })
            .ToList();

        return Ok(subModels);
    }
}