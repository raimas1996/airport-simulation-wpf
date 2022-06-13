using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class Track
    {
        private int _numPilots, numPilotsTrack;
        private GRI? _gri;
        private readonly object lockObject = new();

        public Track()
        {
            /* brokerPilotsToLandingPad = false;
            nextStateIsLandingPad = true; */
            numPilotsTrack = 0;
        }

        public GRI? Gri
        {
            get { return _gri; }
            set { _gri = value; }
        }

        public int NumPilots
        {
            get { return _numPilots; }
            set { _numPilots = value; }
        }

        public bool IsDeparting(int pilotId)
        {
            Monitor.Enter(lockObject);
            try
            {
                NumPilots++;
                if (NumPilots <= 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        public bool IsLanding(int pilotId)
        {
            Monitor.Enter(lockObject);
            try
            {
                NumPilots++;
                if (NumPilots <= 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        public bool HasDeparted(int pilotId)
        {
            Monitor.Enter(lockObject);
            try
            {
                NumPilots--;
                if (NumPilots <= 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        public bool HasLanded(int pilotId)
        {
            Monitor.Enter(lockObject);
            try
            {
                NumPilots--;
                if (NumPilots <= 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }
}
