using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandQ.Data.Enums
{
    public enum Roles
    {
        //As the manager is set to 1, the other values count up from there.
        MANAGER = 1, ASSISTANT_MANAGER, SALES_REP, BACKROOM_STOCKIST
    }
}
