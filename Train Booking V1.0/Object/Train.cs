using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class Train
    {
        private string _TrainID;
        private string _DepartureStation;
        private string _DestinationStation;
        private string _Type;
        private TimeSpan _DepartureTime;
        private DateTime _DepartureDate;
        private bool _FirstClass;

        public string TrainID
        {
            get
            {
                return _TrainID;
            }

            set
            {
                _TrainID = value;
            }
        }

        public string DepartureStation
        {
            get
            {
                return _DepartureStation;
            }

            set
            {
                _DepartureStation = value;
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

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        public TimeSpan DepartureTime
        {
            get
            {
                return _DepartureTime;
            }

            set
            {
                _DepartureTime = value;
            }
        }

        public DateTime DepartureDate
        {
            get
            {
                return _DepartureDate;
            }

            set
            {
                _DepartureDate = value;
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
                //assumtion made that all trains have first class
                _FirstClass = true;
            }
        }
    }
}
