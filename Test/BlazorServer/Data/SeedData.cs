using Microsoft.EntityFrameworkCore;
using BlazorServer.Data;
using BlazorServer.Models;
namespace BlazorServer.Data;

public class SeedData
{
    public static void Initialize(BlazorServerContext db)
    {
                
        var proposals = new Proposal[]
        {
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
        };   
        db.Proposals.AddRange(proposals);
        db.SaveChanges();
    }
}
