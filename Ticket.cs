using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffelApp
{
    public class Ticket
    {
        private List<int> TicketNumberList;

        public Ticket()
        {
            TicketNumberList = new List<int>();
        }

        public List<int> GetTicketNumbers()
        {
            Random random = new Random();
            int noCount = 0;
            while (noCount < 5)
            {
                var randomNumber = random.Next(1, 15);
                if (!TicketNumberList.Contains(randomNumber))
                {
                    TicketNumberList.Add(randomNumber);
                    noCount++;
                }

            }

            return TicketNumberList;
        }

        public void ShowTicketNumbers()
        {
            foreach (int no in TicketNumberList)
            {
                Console.Write($"{no} /t");
            }
        }
    }
}
