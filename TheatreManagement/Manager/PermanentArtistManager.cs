using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreManagement.Manager
{
    public class PermanentArtistManager : IArtistManager
    {
        public decimal GetPay()
        {
            double monthlyPay = 30000;
            return (int)monthlyPay;
        }

        public decimal GetShowPercentage()
        {
            double ticketSellPercentage = .2;
            double basic = 18000;
            double honorarium = basic * ticketSellPercentage;
            return (decimal)honorarium;
        }

        public decimal GetGrant()
        {
            double grant = 2000;
            return (decimal)grant;
        }
    }
}
