using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AirportSimulation
{
    public class Hangar
    {
        private int _numPilots, numPilotsHangar;
        private bool brokerPilotsToLandingPad, nextStateIsLandingPad;
        private readonly object lockObject = new();
        private GRI? _gri;

        public Hangar()
        {
            brokerPilotsToLandingPad = false;
            nextStateIsLandingPad = true;
            numPilotsHangar = 0;
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

        /** The airplane go to the hangar after a flight.*/
        public int RequestPermissionToLand(int pilotId, string pilotStatus)
        {
            Monitor.Enter(lockObject);
            try
            {
                //gri.updatePilotStatus(pilotId, pilotStatus);
                numPilotsHangar++;
                Monitor.Pulse(lockObject);
                try{
                    while(!brokerPilotsToLandingPad)
                    {
                        Monitor.Wait(lockObject);
                    }
                }catch (Exception) { }
                numPilotsHangar--;

                if (numPilotsHangar == 0)
                    brokerPilotsToLandingPad = false;

                if (nextStateIsLandingPad)
                    return 1;

                return 0;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
   
        public int AcceptRequestToTakeOff(int pilotId, string pilotStatus)
        {
            Monitor.Enter(lockObject);
            try
            {
                //gri.updateBrokerStatus(brokerState);
                try
                {
                    while (numPilotsHangar < _numPilots)
                    {
                        Monitor.Wait(lockObject);
                    }
                }
                catch (Exception) { }

                brokerPilotsToLandingPad = true;
                nextStateIsLandingPad = true;
                Monitor.PulseAll(lockObject);
                return 1;
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }
}
