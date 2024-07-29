using Microsoft.EntityFrameworkCore;
using BlazorServer.Models;
using BlazorServer.Data;

namespace BlazorServer.Data
{
    public class BlazorServerContext : DbContext
    {
        private string? connectionString;
        public DbSet<BlazorServer.Models.Proposal> Proposals{get; set;} = default!;
        public BlazorServerContext(DbContextOptions<BlazorServerContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlazorServer.Models.Proposal>(proposal =>
            {
               proposal.HasKey(e => e.Id);
               proposal.Property(e => e.Id).ValueGeneratedOnAdd(); 
            });
        }

        //public DbSet<BlazorServer.Models.ProposalMaterial> ProposalMaterials{get; set;} = default!;
    }
}


