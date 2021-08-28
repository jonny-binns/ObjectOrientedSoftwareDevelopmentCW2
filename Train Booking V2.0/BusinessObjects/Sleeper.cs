using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    //sleeper inherits from train
    public class Sleeper : Train
    {
        //overrides the sleeper berth bool
        public override bool SleeperBerth
        {
            get => base.SleeperBerth;
            set => base.SleeperBerth = value;
        }
        //overrides the intermediate stops string
        public override string IntermediateStops
        {
            get => base.IntermediateStops;
            set => base.IntermediateStops = value;
        }
        //overrides AllStations to show the desination, departure and intermediate stops
        public override string AllStations()
        {
            return DepartureStation + ", " + IntermediateStops + DestinationStation;
        }
        //overrides to string to display the relevent attrubutes
        public override string ToString()
        {
            return "Train ID: " + TrainID + ", " + "Type: " + Type + ", " + "Departure Station: " + DepartureStation + ", " + "Intermediate Stations: " + IntermediateStops + "Destination Station:" + DestinationStation + ", " + "Departure Time:" + DepartureTime.ToString("HH:mm") + ", " + "Departure Date: " + DepartureDate.ToString("dd/MM/yyyy") + ", " + "First Class: " + FirstClass + ", " + "Sleeper Bearth: " + SleeperBerth + "Taken Seats: " + TakenSeats + System.Environment.NewLine + System.Environment.NewLine;
        }
    }
}
