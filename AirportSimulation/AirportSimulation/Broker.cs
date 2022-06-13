using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class Broker
    {
        private Hangar? _hangar;
        private Track? _track;
        private Sky? _sky;
        private int _brokerId;
        private GRI? _gri;
        private BrokerEnum brokerState;
        private string brokerText;

        public Broker()
        {
            brokerState = 0;
            brokerText = "HI";
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

        public int BrokerId
        {
            get { return _brokerId; }
            set { _brokerId = value; }
        }

        public string BrokerTextText
        {
            get { return brokerText; }
            set { brokerText = value; }
        }

        /** The Broker is active.*/
        public void Run()
        {
            int res = 0;
            while (res == 0)
            {
                try
                {
                    switch (brokerState)
                    {
                        case BrokerEnum.OBSERVING:
                            Thread.Sleep(new Random().Next(500));
                            brokerState = BrokerEnum.OBSERVING;
                            break;

                        case BrokerEnum.READY_TO_DEPART:
                            Thread.Sleep(new Random().Next(500));
                            //_track.IsDeparting("RTD");
                            break;

                        case BrokerEnum.FINISHED_DEPARTING:
                            Thread.Sleep(new Random().Next(500));
                            //_track.HasDeparted("FD");
                            break;

                        case BrokerEnum.READY_TO_LAND:
                            Thread.Sleep(new Random().Next(500));
                            //_track.IsLanding("RTL");
                            break;

                        case BrokerEnum.FINISHED_LANDING:
                            Thread.Sleep(new Random().Next(500));
                            //_track.HasLanded("FL");
                            break;

                    }
                }
                catch (Exception) { }
            }

            Console.WriteLine("Broker DIED\n");

        }
    }
}
