using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Models;

public enum Status
{
    Created=0,
    Deleted=1,
    Approved=3
}

[Serializable]
public class Proposal
{
    [Key]
    public int Id{get; set;}
    [Required]
    public string? NumberProposal{get; set;}
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateTimeCreate{get; set;}
    [Required]
    public string? FullNumber{get; set;}
    [Required]
    public string? Status{get;set;}
}
