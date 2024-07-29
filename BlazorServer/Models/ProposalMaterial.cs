namespace BlazorServer.Models;

public class ProposalMaterial
{
    public Status status;

    public int Id{get; set;}
    public string? Status{get;set;}
    public string? TextStatus{get; set;}
    public string? MaterialName{get; set;}
    public string? MaterialCode{get; set;}
    public int Count{get; set;}
    public string? Comment{get; set;}
    public int ProposalId{get; set;}
}
