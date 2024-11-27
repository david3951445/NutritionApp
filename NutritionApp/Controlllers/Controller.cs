using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NutritionApp.Controllers;

[Route("specials")]
[ApiController]
public class SamplesController : Controller
{
    private readonly SamplesContext _db;

    public SamplesController(SamplesContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Sample>>> GetSpecials()
    {
        return (await _db.Samples.ToListAsync()).ToList();
    }
}