using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinF.Models
{
    public class Airplane : Aircraft
    {
        public int RunwayLength { get; set; }

        public Airplane(int runwayLength)
        {
            Altitude = 0;
            RunwayLength = runwayLength;
        }

        public override bool TakeOff()
        {
            if (RunwayLength < 1000)
            {
                MessageBox.Show("Недостаточная длина взлетной полосы!");
                return false;
            }

            Altitude += 1000;
            if (Altitude == 1000)
            {
                OnTakeOffEvent();
            }

            return true;
        }

        public override bool Land()
        {
            Altitude -= 500;
            if (Altitude <= 0)
            {
                Altitude = 0;
                OnLandingEvent();
            }
            return true;
        }
    }

}
