using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Train
    {
        //creates the private attributes of the class
        private string _TrainID;
        private string _DepartureStation;
        private string _DestinationStation;
        private string _Type;
        private DateTime _DepartureTime;
        private DateTime _DepartureDate;
        private bool _FirstClass;
        private string _TakenSeats;
        private bool _SleeperBerth;
        private string _IntermediateStops;

        //get/set methods for the trains id
        public string TrainID
        {
            get
            {
                //returns the train id
                return _TrainID;
            }

            set
            {
                //validation to make sure the trains id has to be 4 cahracters
                if (value.Length == 4)
                {
                    //sets the train id if its 4 characters long
                    _TrainID = value;
                }
                else
                {
                    //throws argument if it isnt exactly 4 characters
                    throw new ArgumentException("The train ID must be 4 characters");
                }
            }
        }

        //get/set methods for the trains departure station
        public string DepartureStation
        {
            get
            {
                //returns the departure station
                return _DepartureStation;
            }

            set
            {
                //validation to make sure the trains departure station can only be one of the valid stations
                if (value.Equals("Edinburgh Waverley"))
                {
                    _DepartureStation = value;
                }
                else if (value.Equals("London Kings Cross"))
                {
                    _DepartureStation = value;
                }
                else
                {
                    //throws an exception if the departure station to be set isnt one of the valid options
                    throw new ArgumentException("Departure station can only be either 'Edinburgh Waverley' or 'London Kings Cross'");
                }
            }
        }

        //get/set methods for the trains desination station
        public string DestinationStation
        {
            get
            {
                //returns the trains desination station
                return _DestinationStation;
            }

            set
            {
                //validation to make sure that the desination station can only be one of the valid stations
                if (value.Equals("Edinburgh Waverley"))
                {
                    _DestinationStation = value;
                }
                else if (value.Equals("London Kings Cross"))
                {
                    _DestinationStation = value;
                }
                else
                {
                    //throws excetion if the desination station isnt valid
                    throw new ArgumentException("Destination station can only be either 'Edinburgh Waverley' or 'London Kings Cross'");
                }
            }
        }

        //get/set methods for the trains type
        public string Type
        {
            get
            {
                //returns the type
                return _Type;
            }

            set
            {
                //sets the type
                _Type = value;
            }
        }

        //get/set methods for the trains departure time
        public DateTime DepartureTime
        {
            get
            {
                //returns the time
                return _DepartureTime;
            }

            set
            {
                //sets the time
                _DepartureTime = value;
            }
        }

        //get/set methods for the trains departure date 
        public DateTime DepartureDate
        {
            get
            {
                //returns the departure date
                return _DepartureDate;
            }

            set
            {
                //sets the departure date
                _DepartureDate = value;
            }
        }

        //get/set methods for weather the train allows a first class carrage
        public bool FirstClass
        {
            get
            {
                //returns the first class attribute
                return _FirstClass;
            }

            set
            {
                //sets the first class attribute
                _FirstClass = value;
            }
        }

        //get/set methods for all of the seats booked on the train
        public string TakenSeats
        {
            get
            {
                //returns all of the seats booked on the train
                return _TakenSeats;
            }
            set
            {
                //sets the seats booked on the train
                _TakenSeats = value;
            }
        }

        //virtural method for getting/setting the sleeper berth attribute, to be overridden by the child classes
        public virtual bool SleeperBerth
        {
            get
            {
                //returns the sleeper berth
                return _SleeperBerth;
            }
            set
            {
                //sets the sleeper berth
                _SleeperBerth = value;
            }
        }

        //virtual method for getting/setting the trains intermediate stops, to be overridden by the child classes
        public virtual string IntermediateStops
        {
            get
            {
                //returns the intermediate stops
                return _IntermediateStops;
            }

            set
            {
                //sets the intermediate stops
                _IntermediateStops = value;
            }
        }

        //virtual string for displaying all stations, to be overridden by the child classes
        public virtual string AllStations()
        {
            return null;
        }   
    }
}
