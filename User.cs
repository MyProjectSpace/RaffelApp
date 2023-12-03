using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffelApp
{
    public class User
    {
        public string Name { get; private set; }
        public List<Ticket> Tickets { get; private set; }

        public User(string name)
        {
            Name = name;
            Tickets = new List<Ticket>();
        }

        public void BuyTickets()
        {
            Console.WriteLine("Enter name:");
            Name = Console.ReadLine();
            Console.WriteLine("No of tickets to purchase");
            int noOfTickets = 0;
            string noOfTicketsString = Console.ReadLine();
            if (!int.TryParse(noOfTicketsString, out noOfTickets))
            { 
                Console.WriteLine("Enter valid no of tickets:");
                return;
            }

            if (noOfTickets > 5)
            {
                Console.WriteLine("Can not buy more than 5 tickets");
            }
            else
            {
                for (int i = 0; i < noOfTickets; i++)
                {
                    Ticket t = new Ticket();
                    Tickets.Add(t);
                }
            }
        }


    }
}
