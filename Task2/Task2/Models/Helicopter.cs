using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinF.Models
{
    public class Helicopter : Aircraft
    {
        public Helicopter()
        {
            Altitude = 0;
        }

        public override bool TakeOff()
        {

            Altitude += 500;
            if (Altitude == 500)
            {
                OnTakeOffEvent();
            }

            return true;
        }

        public override bool Land()
        {

            Altitude -= 200;
            if (Altitude <= 0)
            {
                Altitude = 0;
                OnLandingEvent();
            }
            return true;
        }
    }
}
