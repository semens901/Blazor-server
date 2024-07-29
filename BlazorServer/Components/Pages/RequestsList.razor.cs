namespace BlazorServer.Pages;

using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using BlazorServer.Models;
using BlazorServer.Data;
using Models;
using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading.Tasks;


public partial class RequestsList
{
    private readonly List<Proposal> proposals = new();

    [Inject]
    private IDbContextFactory<BlazorServerContext> _dbContextFactory{get; set;}

    protected override async Task OnInitializedAsync()
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync();
        await db.Database.EnsureCreatedAsync();
        
    }
}