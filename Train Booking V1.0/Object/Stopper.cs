using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class Stopper : Train
    {
        private string _IntermediateStops;

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
