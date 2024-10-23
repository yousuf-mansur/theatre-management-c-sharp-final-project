using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreManagement.Manager
{
    public class GuestArtistManager : IArtistManager
    {
        public decimal GetPay()
        {
            double perShowpay = 5000;
            return (int)perShowpay;
        }

        public decimal GetShowPercentage()
        {
            double ticketSellPercentage = .1;
            double basic = 5000;
            double honorarium = basic * ticketSellPercentage;
            return (int)honorarium;
        }
        public decimal GetTransportAllowance()
        {
            return 1000;
        }
        public decimal GetFoodAllowance()
        {
            return 1500;
        }
    }
}
