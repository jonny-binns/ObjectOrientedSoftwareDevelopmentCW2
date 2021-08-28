using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class Sleeper : Train
    {
        private bool _SleeperBerth;
        private string _IntermediateStops;

        public bool SleeperBerth
        {
            get
            {
                return _SleeperBerth;
            }
            
            set
            {
                _SleeperBerth = value;
            }
        }

        public string IntermediateStops
        {
            get
            {
                return _IntermediateStops;
            }

            set
            {
                _IntermediateStops = value;
            }
        }

        public string AllStations()
        {
            return null;
        }
    }
}
