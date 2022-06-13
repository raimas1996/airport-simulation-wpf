using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSimulation
{
    public class Logs
    {
        private string _logText;

        public Logs()
        {

        }

        public string LogText
        {
            get => _logText;
            set { _logText = value; }
        }
    }
}
