using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreManagement.Manager
{
    public interface IArtistManager
    {
        decimal GetShowPercentage();
        decimal GetPay();
    }
}
