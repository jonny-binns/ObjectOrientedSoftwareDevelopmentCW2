using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    //stopper inherits from train
    public class Stopper : Train
    {
        //overrides the intermediate stops string
        public override string IntermediateStops
        {
            get => base.IntermediateStops;
            set => base.IntermediateStops = value;
        }
        //overrides the all stations string to show the departure, intermediate and desination stations
        public override string AllStations()
        {
            return DepartureStation + ", " + IntermediateStops + DestinationStation;
        }
        //overrides ToString to show all relevant attributes
        public override string ToString()
        {
            return "Train ID: " + TrainID + ", " + "Type: " + Type + ", " + "Departure Station: " + DepartureStation + ", " + "Intermediate Stations: " + IntermediateStops + "Destination Station:" + DestinationStation + ", " + "Departure Time:" + DepartureTime.ToString("HH:mm") + ", " + "Departure Date: " + DepartureDate.ToString("dd/MM/yyyy") + ", " + "First Class: " + FirstClass + ", " + "Taken Seats: " + TakenSeats + System.Environment.NewLine + System.Environment.NewLine;
        }
    }
}
