using Microsoft.EntityFrameworkCore;
using BlazorServer.Data;
namespace BlazorServer.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using(var context = new BlazorServerContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<BlazorServerContext>>()
        ))
        {

            if(context == null || 
            context.Proposals == null)
            {
                throw new ArgumentNullException("Null BlazorServerContext");
            }

            if(context.Proposals.Any())
            {
                Proposal.ProposalsArray.AddRange(context.Proposals.ToList()); 
                return;
            }
                
            
            context.Proposals.AddRange(
                new Proposal
                {
                    NumberProposal = "10/0001",
                    DateTimeCreate = DateTime.Parse("2010-2-12"),
                    FullNumber = "12/001",
                    Status = "Создана"
                },
                new Proposal
                {
                    NumberProposal = "14/0002",
                    DateTimeCreate = DateTime.Parse("2014-2-12"),
                    FullNumber = "14/001",
                    Status = "Создана"
                },
                new Proposal
                {
                    NumberProposal = "16/0001",
                    DateTimeCreate = DateTime.Parse("2016-2-12"),
                    FullNumber = "16/001",
                    Status = "Создана"
                },
                new Proposal
                {
                    NumberProposal = "18/0001",
                    DateTimeCreate = DateTime.Parse("2018-2-12"),
                    FullNumber = "18/001",
                    Status = "Создана"
                }
            );
            
            /*context.ProposalMaterial.AddRange(
                new ProposalMaterial
                {
                    

                }
            );*/
            Proposal.ProposalsArray.AddRange(context.Proposals.ToList());
            context.SaveChanges();
        }
    }
}
