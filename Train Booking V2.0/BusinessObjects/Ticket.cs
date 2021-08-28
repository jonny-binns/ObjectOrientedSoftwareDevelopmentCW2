using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class Ticket
    {
        //creates the private attributes of the class
        private string _Name;
        private string _TrainID;
        private string _DepartureStation;
        private string _DestinationStation;
        private bool _FirstClass;
        private bool _Cabin;
        private decimal _Price;
        private string _Coach;
        private int _Seat;
        
        //get and set methods for the tickets name
        public string Name
        {
            get
            {
                //returns the private variable name 
                return _Name;
            }

            set
            {
                //checks if the string is empty
                if (value != string.Empty)
                {
                    //sets the name if the string isnt blank
                    _Name = value;
                }
                else
                {
                    //throws argument if the string is empty
                    throw new ArgumentException("Passenger name cannot be empty");
                }
            }
        }
        //contains the get and set methods for the train id the ticket is assigned to
        //the validation for this is done in the MainWindow.xaml.cs
        public string TrainID
        {
            get
            {
                //returns the train id
                return _TrainID;
            }

            set
            {
                //sets the train id
                _TrainID = value;
            }
        }
        //contains the get/set methods for the departure station of the ticket
        public string DepartureStation
        {
            get
            {
                //returns the Departure Station
                return _DepartureStation;
            }

            set
            {
                //validation to make sure the departure station is only one of the possible stations
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
                    //throws exception if the value isnt one of the possible stations
                    throw new ArgumentException("Please enter a vaid station from the list; Edinburgh Waverley, London Kings Cross, Peterborough, Darlington, York or Newcastle");
                }
            }
        }
        //methods to get/set the desination station of the ticket
        public string DestinationStation
        {
            get
            {
                //returns the desination station
                return _DestinationStation;
            }
            //validation to allow you to only set the desination station to one of the possible ones
            set
            {
                if (value.Equals("Edinburgh Waverley"))
                {
                    _DestinationStation = value;
                }
                else if (value.Equals("London Kings Cross"))
                {
                    _DestinationStation = value;
                }
                else if (value.Equals("Peterborough"))
                {
                    _DestinationStation = value;
                }
                else if (value.Equals("Darlington"))
                {
                    _DestinationStation = value;
                }
                else if (value.Equals("York"))
                {
                    _DestinationStation = value;
                }
                else if (value.Equals("Newcastle"))
                {
                    _DestinationStation = value;
                }
                else
                {
                    //throws exception if the value isnt one of the possible stations
                    throw new ArgumentException("Please enter a vaid station from the list; Edinburgh Waverley, London Kings Cross, Peterborough, Darlington, York or Newcastle");
                }
            }
        }
        //gets/setas weather the ticket is first class or not
        public bool FirstClass
        {
            get
            {
                //returns the first class attribute
                return _FirstClass;
            }

            set
            {
                //sets the first class variable
                _FirstClass = value;
            }
        }
        //gets/sets the cabin for the ticket
        public bool Cabin
        {
            get
            {
                //returns the cabin
                return _Cabin;
            }

            set
            {
                //sets the cabin
                _Cabin = value;
            }
        }
        //gets/sets the tickets price
        public decimal Price
        {
            get
            {
                //returns the price
                return _Price;
            }

            set
            {
                //validation to make sure the price is more than 0
                if (value == 0)
                {
                    //throws error if the price is 0
                    throw new ArgumentException("Have you remebered to calculate the price?");
                }
                else
                {
                    //sets the price
                    _Price = value;
                }
            }
        }
        //gets/sets what coach the ticket is for
        public string Coach
        {
            get
            {
                //returns the coach for the ticket
                return _Coach;
            }

            set
            {
                //validation to make sure the coach is a valid letter
                if (value.Any(char.IsLetter))
                {
                    _Coach = value;
                }
                else
                {
                    //throws argument if the coach isnt a valid letter
                    throw new ArgumentException("Please enter a valid letter");
                }
            }
        }
        //gets/sets the seat of the ticket
        public int Seat
        {
            get
            {
                //returns the seat number
                return _Seat;
            }

            set
            {
                //sets the seat number
                _Seat = value;
            }
        }

        //overrides ToString() to display all the attributes
        public override string ToString()
        {
            return "Name: " + _Name + ", " + "Train ID: " + _TrainID + ", " + "Departure Station: " + _DepartureStation + ", " + "Destination Station: " + _DestinationStation + ", " + " First Class: " + _FirstClass + ", " + "Cabin: " + _Cabin + ", " + "Price: £" + _Price + ", " + "Seat: " +  _Coach + _Seat + System.Environment.NewLine + System.Environment.NewLine;  
        }
        
    }
}