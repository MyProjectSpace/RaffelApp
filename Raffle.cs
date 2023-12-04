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
        private  List<User> users = new List<User>();
        private List<int> winningTicketNumbers = new List<int>();

        public List<int> GetWinningTicketNumbers()
        {
            winningTicketNumbers = new Ticket().GetTicketNumbers();
            return winningTicketNumbers;
        }

        public void DispalyRaffelInstructions(RaffleStatus status)
        {
            Console.WriteLine("Welcome to My Raffle App");
            Console.WriteLine($"Status:{GetEnumString(status)}");
            Console.WriteLine("[1] Start a New Draw");
            Console.WriteLine("[2] Buy Tickets");
            Console.WriteLine("[3] Run Raffle");
            Console.WriteLine("[-99] Exit Application");

        }

        private string GetEnumString(RaffleStatus status)
        {
            return Enum.GetName(typeof(RaffleStatus), (int)status);
        }

        public void StartDraw(int drawId, decimal potSize)
        {
            var draw = new Draw(drawId, potSize);
            Console.WriteLine();
            Console.WriteLine($"New Raffle draw has been started.Initial pot size: {potSize}");
            Console.WriteLine("Press any key to return to main menu");
            Console.WriteLine();
        }

        public void BuyTickets()
        {
            Console.WriteLine("Enter your name, no of tickets to purchase");
            string nameAndTickets = Console.ReadLine();
            var Name = nameAndTickets.Split(',')[0];
            var noOfTicketsString = nameAndTickets.Split(',')[1];
            int noOfTickets;
            var ticketList = new List<Ticket>();
            if (int.TryParse(noOfTicketsString, out noOfTickets))
            {
                Console.WriteLine($"Hi {Name}, you have purchase {noOfTickets} ticket(s)");
                var user = new User(Name);
                for (int i = 1; i <= noOfTickets; i++)
                {
                    var ticket = new Ticket();
                    ticketList.Add(ticket);
                    Console.Write($"Ticket {i}:");
                    ticket.ShowTicketNumbers();
                    user.Tickets.Add(ticket);
                    Console.WriteLine(); 
                }
                users.Add(user);
                Console.WriteLine("Press any key to return to main menu");
            }
        }

        public void RunRaffle()
        { 
            winningTicketNumbers = new Ticket().GetTicketNumbers();
            Console.Write($"Winning Ticket is {string.Join(' ', winningTicketNumbers)}");
        }

        private void CalculateAndDisplayWinners(int group, decimal rewardPercentage)
        {
            var winners = users.Where(user =>
            user.Tickets.Any(ticket => ticket.TicketNumberList.Intersect(winningTicketNumbers).Count() == group)).ToList();
            if (winners.Count == 0)
            {
                Console.WriteLine("No winners");
                return;
            }
            else
            { 
                foreach (var winner in winners)
                {
                    
                }
            }
        }
    }
}
