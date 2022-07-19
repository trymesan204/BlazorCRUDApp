using BlazorCRUDapp.Shared;
using System.Net.Http.Json;

namespace BlazorCRUDapp.Client.Service
{
    public class TicketService: ITicketService
    {
        private readonly HttpClient _http;

        public TicketService(HttpClient http)
        {
            _http = http;
        }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public async Task GetTickets()
        {
            var result = await _http.GetFromJsonAsync<List<Ticket>>("api/ticket");
            if (result != null)
                Tickets = result;
        }

        public async Task<Ticket> GetSingleTicket(int id)
        {
            var result = await _http.GetFromJsonAsync<Ticket>($"api/ticket/{id}");
            if (result != null)
                return result;
            throw new Exception("Ticket not found...");
        }
    }
}