using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    //express inherits from train
    public class Express : Train
    {
        //overrides the method for AllStations, only displays the departure and desination stations, as they are the only ones that are valid for express trains
        public override string AllStations()
        {
            return DepartureStation + ", " + DestinationStation;
        }
        //overrides tostring to show all the appropriate attrubutes for the express class
        public override string ToString()
        {
            return "Train ID: " + TrainID + ", " + "Type: " + Type + ", " + "Departure Station: " + DepartureStation + ", " + "Destination Station:" + DestinationStation + ", " + "Departure Time:" +  DepartureTime.ToString("HH:mm") + ", " + "Departure Date: " + DepartureDate.ToString("dd/MM/yyyy") + ", " +"First Class: "+ FirstClass + ", " +"Taken Seats: " + TakenSeats + System.Environment.NewLine + System.Environment.NewLine;
        }
    }
}
