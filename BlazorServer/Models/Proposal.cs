using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Models;

public enum Status
{
    Created=0,
    Deleted=1,
    Approved=3
}

public class Proposal
{
    public static List<Proposal> ProposalsArray = new List<Proposal>();
    public int Id{get; set;}
    public string? NumberProposal{get; set;}
    [DataType(DataType.Date)]
    public DateTime DateTimeCreate{get; set;}
    public string? FullNumber{get; set;}
    public string? Status{get;set;}
}
