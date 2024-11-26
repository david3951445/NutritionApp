using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutritionApp.Models;

namespace NutritionApp.Controllers;

[Route("specials")]
[ApiController]
public class SamplesController : Controller
{
    private readonly SampleContext _db;

    public SamplesController(SampleContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Sample>>> GetSpecials()
    {
        return (await _db.Samples.ToListAsync()).ToList();
    }
}