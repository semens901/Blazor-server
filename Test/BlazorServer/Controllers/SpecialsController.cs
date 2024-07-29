using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorServer.Data;
using BlazorServer.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialsController : ControllerBase
{
    private readonly BlazorServerContext _db;

    public SpecialsController(BlazorServerContext db)
    {
        _db = db;
    }

    [HttpPut("{Id}")]
    public async Task<Proposal> Put(int Id, [FromBody] Proposal cust)
    {
        var edit = await _db.Proposals.FindAsync(Id);
        if(edit != null)
        {
            edit.NumberProposal = cust.NumberProposal;
            edit.DateTimeCreate = cust.DateTimeCreate;
            edit.FullNumber = cust.FullNumber;
            edit.Status = cust.Status;
        }
        return edit;
    }

    [HttpDelete("{Id}")]
    public async Task<Proposal> Delete(int Id)
    {
        var delete = await _db.Proposals.FindAsync(Id);
        if(delete != null)
        {
            _db.Proposals.Remove(delete);
            await _db.SaveChangesAsync();
        }
        return delete;
    }

    [HttpPost]
    public async Task<ActionResult<Proposal>> Post( Proposal value)
    {
        _db.Proposals.Add(value);
        _db.SaveChanges();
        return Ok(value);
    }

    [HttpGet]
    public async Task<ActionResult<List<Proposal>>> GetSpecials()
    {
        return (await _db.Proposals.ToListAsync()).OrderByDescending(s => s.Id).ToList();
    }
    

    [HttpGet("{id}")]
    public async Task<ActionResult<List<Proposal>>> Get()
    {
        return _db.Proposals.ToList();
    }

    /*[HttpGet]
    public async Task<ActionResult<List<Proposal>>> GetSpecials()
    {
        return (await _db.Proposals.ToListAsync()).OrderByDescending(s => s.Id).ToList();
    }*/
}