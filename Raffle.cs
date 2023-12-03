using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffelApp
{
    public class Raffle
    {
        private decimal pot;
        private List<Ticket> ticketsList = new List<Ticket>();
        private List<int> winningTicketNumbers = new List<int>();

        public List<int> GetWinningTicketNumbers()
        {
            winningTicketNumbers = new Ticket().GetTicketNumbers();
            return winningTicketNumbers;
        }

        public void DispalyRaffelInstructions()
        {
            Console.WriteLine("Welcome to My Raffle App");
            Console.WriteLine("Status: Draw has not started");
            Console.WriteLine("[1] Start a New Draw");
            Console.WriteLine("[2] Buy Tickets");
            Console.WriteLine("[3] Run Raffle");
            Console.WriteLine("[-99] Exit Application");
            
        }

        public void StartDraw(int drawId, decimal potSize)
        {
            var draw = new Draw(drawId, potSize);
            Console.WriteLine();
            Console.WriteLine($"New Raffle draw has been started.Initial pot size: {potSize}");
            Console.WriteLine("Press any key to return to main menu");
            Console.WriteLine();
        }
    }
}
