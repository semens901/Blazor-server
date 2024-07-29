using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorServer.Models;
using BlazorServer.Data;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BlazorServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecialsController : Controller
{
    private readonly BlazorServerContext _db;

    public SpecialsController(BlazorServerContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<List<Proposal>> Get()
    {
        return (await _db.Proposals.ToListAsync());
    }

}
