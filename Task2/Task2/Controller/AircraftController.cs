using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinF.Models;

namespace WinF.Controller
{
    public class AircraftController
    {
        private Airplane airplane;
        private Helicopter helicopter;

        public event EventHandler TakeOffEvent;
        public event EventHandler LandingEvent;

        public AircraftController(Airplane airplane, Helicopter helicopter)
        {
            this.airplane = airplane;
            this.helicopter = helicopter;
        }

        public void HandleAirplaneTakeOff()
        {
            airplane.TakeOff();
        }

        public void HandleAirplaneLanding()
        {
            airplane.Land();
        }

        public void HandleHelicopterTakeOff()
        {
            helicopter.TakeOff();
        }

        public void HandleHelicopterLanding()
        {
            helicopter.Land();
        }
    }
}
