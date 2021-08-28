using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class Booking : Passenger
    {
        private string _DepartureStation;
        private string _DestinationStation;
        private bool _FirstClass;
        private bool _Cabin;

        public string DepartureStation
        {
            get
            {
                return _DepartureStation;
            }

            set
            {
                if (value.Equals("Edinburgh Waverley"))
                {
                    _DepartureStation = value;
                }
                else if (value.Equals("London Kings Cross"))
                {
                    _DepartureStation = value;
                }
                else if (value.Equals("Peterborough"))
                {
                    _DepartureStation = value;
                }
                else if (value.Equals("Darlington"))
                {
                    _DepartureStation = value;
                }
                else if (value.Equals("York"))
                {
                    _DepartureStation = value;
                }
                else if (value.Equals("Newcastle"))
                {
                    _DepartureStation = value;
                }
                else
                {
                    throw new ArgumentException("Please enter a vaid station from the list; Edinburgh Waverley, London Kings Cross, Peterborough, Darlington, York or Newcastle");
                }
            }
        }

        public string DestinationStation
        {
            get
            {
                return _DestinationStation;
            }

            set
            {
                _DestinationStation = value;
            }
        }

        public bool FirstClass
        {
            get
            {
                return _FirstClass;
            }

            set
            {
                    _FirstClass = value;
            }
        }

        public bool Cabin
        {
            get
            {
                return _Cabin;
            }

            set
            {
                
                _Cabin = value;
            }
        }

    }
}
