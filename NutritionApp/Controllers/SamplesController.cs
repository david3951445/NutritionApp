using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NutritionApp.Controllers;

[Route("samples")]
[ApiController]
public class SamplesController : Controller
{
    private readonly SamplesContext _db;

    public SamplesController(SamplesContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Sample>>> GetSamaples()
    {
        return (await _db.Samples.ToListAsync()).ToList();
    }
}