using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public sealed class StartProgram
    {
        public int numPilots = 5;
        public int max_distance = 1000;
        public int sum_max_distances = 0;
        public int[] max_distances;

        public string[] airplaneNames = { "Flight 350", "Flight 777", "Airbus 350", "Boeing 737", "Airbus 500" };

        public GRI? gri;
        public Hangar hangar;
        public Track track;
        public Sky sky;

        public Broker broker;
        private Pilot[] _pilotsArray = new Pilot[5];

        public Pilot[] PilotsArray
        {
            get { return _pilotsArray; }
            set { _pilotsArray = value; }
        }

        public StartProgram()
        {
            max_distances = new int[numPilots];

            gri = new()
            {
                NumPilots = numPilots
            };

            track = new()
            {
                Gri = gri,
                NumPilots = numPilots
            };

            hangar = new()
            {
                Gri = gri,
                NumPilots = numPilots
            };

            sky = new()
            {
                Gri = gri,
                NumPilots = numPilots
            };

            for (int i = 0; i < numPilots; i++)
            {
                max_distances[i] = new Random().Next(max_distance) + 1;
                sum_max_distances += max_distances[i];

                Pilot pilot = new()
                {
                    Gri = gri,
                    PilotId = i,
                    Code = airplaneNames[i],
                    NumFlightsLeft = new Random().Next(10),
                    Distance = max_distances[i],
                    HangarClass = hangar,
                    SkyClass = sky,
                    TrackClass = track
                };
                Thread pilotThread = new(pilot.Run);
                pilotThread.Start();
                PilotsArray.Append(pilot);
            }

            broker = new()
            {
                Gri = gri,
                BrokerId = 0,
                HangarClass = hangar,
                SkyClass = sky,
                TrackClass = track
            };
            Thread brokerThread = new(broker.Run);
            brokerThread.Start();
        }

        private static StartProgram? instance = null;
        private static readonly object padlock = new();

        public static StartProgram Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StartProgram();
                    }
                    return instance;
                }
            }
        }
    }
}
