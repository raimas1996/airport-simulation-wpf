using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class Pilot
    {
        private Hangar? _hangar;
        private Sky? _sky;
        private Track? _track;
        private GRI? _gri;
        private int _pilotId, _distance, _numFlightsLeft;
        private string _code = "Hi";
        private PilotEnum _pilotState = PilotEnum.ACTIVE;

        public Pilot()
        {

        }

        public GRI? Gri
        {
            get { return _gri; }
            set { _gri = value; }
        }

        public Hangar? HangarClass
        {
            get { return _hangar; }
            set { _hangar = value; }
        }

        public Sky? SkyClass
        {
            get { return _sky; }
            set { _sky = value; }
        }

        public Track? TrackClass
        {
            get { return _track; }
            set { _track = value; }
        }

        public int PilotId
        {
            get { return _pilotId; }
            set { _pilotId = value; }
        }

        public int NumFlightsLeft
        {
            get { return _numFlightsLeft; }
            set { _numFlightsLeft = value; }
        }

        public int Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public PilotEnum PilotState
        {
            get { return _pilotState; }
            set { _pilotState = value; }
        }

        /** A Pilot is active.*/
        public void Run()
        {
            int res = 0;
            int totalTime = 0;
            while (res == 0)
            {
                try
                {
                    switch (_pilotState)
                    {
                        case PilotEnum.ACTIVE:
                        case PilotEnum.HAS_LANDED:
                            totalTime = 0;
                            while(totalTime < _distance)
                            {
                                totalTime += 500;
                                Thread.Sleep(new Random().Next(500));
                            }
                            //track.scheduledToDepart(pilotId, distance, "SFD");
                            PilotState = PilotEnum.SCHEDULED_TO_DEPART;
                            break;

                        case PilotEnum.SCHEDULED_TO_DEPART:
                            /*while (!trackCleared)
                            {
                                Thread.Sleep(new Random().Next(500));
                            }*/
                            //sky.pilotDeparting(pilotId, "DEP");
                            PilotState = PilotEnum.DEPARTING;
                            break;

                        case PilotEnum.DEPARTING:
                            totalTime = 0;
                            while (totalTime < _distance)
                            {
                                totalTime += 500;
                                Thread.Sleep(new Random().Next(500));
                            }
                            //track.scheduledToLand(pilotId, distance, "SFD");
                            PilotState = PilotEnum.SCHEDULED_TO_LAND;
                            break;

                        case PilotEnum.SCHEDULED_TO_LAND:
                            /*while (!trackCleared)
                            {
                                Thread.Sleep(new Random().Next(500));
                            }
                            sky.pilotLanding(pilotId, "LAND");*/
                            PilotState = PilotEnum.LANDING;
                            break;

                    }
                }
                catch (Exception) { }
            }

            Console.WriteLine("O piloto %d ficou inativo\n", _pilotId);
        }
    }
}
