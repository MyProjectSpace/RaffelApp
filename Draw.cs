using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffelApp
{
    public class Draw
    {
        public int DrawId { get; private set; }
        public decimal PotSize { get; private set; }
        public List<int> WinningNumbersList { get; set; }
        public decimal Jackpot { get; set; }

        public Draw(int drawId, decimal potSize)
        {
            DrawId = drawId;
            PotSize = potSize;

        }
    }
}
