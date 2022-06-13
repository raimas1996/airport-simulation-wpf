using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class GRI
    {
        private static int _numPilots;
        private static string _brokerStatus;
        private static string[] _pilotStatus;
        private static Logs[]? _logs;

        public GRI()
        {
            _brokerStatus = "OTT";
            _pilotStatus = new string[5];
        }

        public int NumPilots
        {
            get { return _numPilots; }
            set { _numPilots = value; }
        }

        public Logs[] LogsArray
        {
            get { return _logs; }
            set { _logs = value; }
        }

        public void appendLogs(Logs log)
        {
            _logs.Append(log);
        }
    }
}
