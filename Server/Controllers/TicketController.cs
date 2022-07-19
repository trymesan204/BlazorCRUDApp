using BlazorCRUDapp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDapp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketController(DataContext context)
        {
            _context = context;
        }

        public static List<Ticket> tickets = new List<Ticket>{
            new Ticket {id = 1, Name = "Sagarmatha", start = "Kathmandu", destination = "Birgunj", time = "8pm"},
            new Ticket {id = 2, Name = "Lantang", start = "Kathmandu", destination = "Rautahat", time = "7pm"}
        };

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetSingleTicket(int id)
        {
            var ticket = _context.Tickets
                .FirstOrDefault( t => t.id == id);
            if ( ticket == null )
            {
                return NotFound("Sorry, you don't have any ticket...");
            }
            return Ok(ticket);
        }
    }


}