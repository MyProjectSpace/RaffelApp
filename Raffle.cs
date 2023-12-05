using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffelApp
{
    public class Raffle
    {
        private decimal pot = 0;
        private decimal seedingFund = 100;
        private decimal totalRewardFund = 0;
        private List<User> users = new List<User>();
        private List<int> winningTicketNumbers = new List<int>();
        private List<Ticket> totalTickets = new List<Ticket>();

        public List<int> GetWinningTicketNumbers()
        {
            winningTicketNumbers = new Ticket().GetTicketNumbers();
            return winningTicketNumbers;
        }

        public void DispalyRaffelInstructions(RaffleStatus status)
        {
            Console.WriteLine("Welcome to My Raffle App");
            Console.WriteLine($"Status:{GetEnumString(status)}");
            if (status != RaffleStatus.NotStarted)
            {
                Console.Write($"Raffle pot size is {GetPotSize()}");
                Console.WriteLine();
            }
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
            winningTicketNumbers.Clear();
            totalTickets.Clear();
            var draw = new Draw(drawId, potSize);
            Console.WriteLine();
            Console.WriteLine($"New Raffle draw has been started.Initial pot size: {GetPotSize()}");
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
                    totalTickets.Add(ticket);
                    Console.Write($"Ticket {i}:");
                    ticket.ShowTicketNumbers();
                    user.Tickets.Add(ticket);
                    Console.WriteLine();
                }
                users.Add(user);
                Console.WriteLine("Press any key to return to main menu");
            }
        }

        private decimal GetPotSize()
        {
            pot = seedingFund + totalTickets.Count * 5;
            return pot;
        }

        public void RunRaffle()
        {
            winningTicketNumbers = new Ticket().GetTicketNumbers();
            Console.WriteLine();
            Console.Write($"Winning Ticket is {string.Join(' ', winningTicketNumbers)}");
            DisplayWinningGroups();
            Console.WriteLine();
            seedingFund = pot - totalRewardFund;
            users.Clear();
            winningTicketNumbers.Clear();
        }

        private void CalculateAndDisplayWinners(int group, decimal rewardPercentage)
        {
            var winners = users.Where(user =>
            user.Tickets.Any(ticket => ticket.TicketNumberList.Intersect(winningTicketNumbers).Count() == group)).ToList();
            if (winners.Count == 0)
            {
                Console.WriteLine($"Group {group}:No winners");
                return;
            }
            else
            {
                Console.WriteLine($"Group {group} Winners:");
                foreach (var winner in winners)
                {
                    var winningTickets = winner.Tickets.Where(ticket =>
                ticket.TicketNumberList.Intersect(winningTicketNumbers).Count() == group).ToList();
                    decimal reward = (pot * rewardPercentage) / winningTickets.Count;
                    Console.WriteLine($"{winner.Name} with {winningTickets.Count} winning ticket(s)- ${reward}");
                    totalRewardFund = totalRewardFund + reward;
                }
                Console.WriteLine();
            }
        }

        private void DisplayWinningGroups()
        {
            CalculateAndDisplayWinners(2, 0.1m);
            CalculateAndDisplayWinners(3, 0.15m);
            CalculateAndDisplayWinners(4, 0.25m);
            CalculateAndDisplayWinners(5, 0.5m);
        }
    }
}
