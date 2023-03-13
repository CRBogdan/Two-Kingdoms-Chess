using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Kingdoms_Chess.Move
{
    public class OffensiveMove : Move
    {
        public override string getMoveColor()
        {
            return "red";
        }
    }
}
