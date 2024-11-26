using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutritionApp.Models;
namespace NutritionApp.Controllers;

[Route("specials")]
[ApiController]
public class SamplesController : Controller
{
    private readonly SampleStoreContext _db;

    public SamplesController(SampleStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Sample>>> GetSpecials()
    {
        return (await _db.Samples.ToListAsync()).ToList();
    }
}