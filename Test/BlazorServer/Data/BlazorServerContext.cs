using Microsoft.EntityFrameworkCore;
using BlazorServer.Data;

namespace BlazorServer.Data
{
    public class BlazorServerContext : DbContext
    {
        public DbSet<BlazorServer.Models.Proposal> Proposals{get; set;} = default!;
        public BlazorServerContext(DbContextOptions<BlazorServerContext> options) : base(options)
        {}

        //public DbSet<BlazorServer.Models.ProposalMaterial> ProposalMaterials{get; set;} = default!;
    }
}


