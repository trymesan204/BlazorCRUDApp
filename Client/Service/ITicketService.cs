using BlazorCRUDapp.Shared;

namespace BlazorCRUDapp.Client.Service
{
    public interface ITicketService
    {
        List<Ticket> Tickets { get; set; }

        Task GetTickets();

        Task<Ticket> GetSingleTicket(int id);

    }
}