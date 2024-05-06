using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinF
{
    public abstract class Aircraft
    {
        public int Altitude { get; set; }
        public event EventHandler TakeOffEvent;
        public event EventHandler LandingEvent;

        public abstract bool TakeOff();
        public abstract bool Land();

        protected virtual void OnTakeOffEvent()
        {
            TakeOffEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLandingEvent()
        {
            LandingEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
