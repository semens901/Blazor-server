using BlazorServer.Models;

namespace BlazorServer;

public class ClientServices
{
    private readonly HttpClient _httpClient;

    public ClientServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Proposal>> GetProposals()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Proposal>>("https://localhost:7105/api/DataGrid");
        return result;
    }

    public async Task<Proposal> InsertProposal(Proposal value)
    {
        await _httpClient.PostAsJsonAsync<Proposal>($"https://localhost:7105/api/DataGrid/", value);
        return value;
    }

    public async Task<bool> RemoveProposal(int Id)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync($"https://localhost:7105/api/DataGrid/{Id}");

        return true;
    }

    public async Task<Proposal> UpdateBook ( int Id, Proposal value )
    {
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"https://localhost:7105/api/DataGrid/{Id}", value);

        return value;

    }
}
