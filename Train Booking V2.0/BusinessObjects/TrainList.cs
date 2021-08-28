using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class TrainList
    {
        //creates the private lists that will be used throughout the methods
        //creates a list to store all trains
        private List<Train> _trains = new List<Train>();
        //creates a list to store all the trains that depart on the same day
        private List<Train> _trainsOnSameDay = new List<Train>();
        //creates a list to store all tickets
        private List<Ticket> _tickets = new List<Ticket>();
        //creates a list to store all tickets on one train
        private List<Ticket> _allPassengersOnOneTrain = new List<Ticket>();

        //method to add a train to the train list
        public void addTrain(Train newTrain)
        {
            //adds the train to the list
            _trains.Add(newTrain);
        }

        //method to find a single train by its ID
        public Train findTrain(string searchTrainID)
        {
            //looks through each train in the list of all trains and returns the one with the id that matches the id to be searched
            foreach (Train t in _trains)
            {
                if (searchTrainID == t.TrainID)
                {
                    return t;
                }
            }

            return null;
        }

        //method to find all the trains that depart on the same date
        public List<Train> findTrainDate(DateTime searchTrainDate)
        {
            //looks through each train in the list of all trains and if the trains date matches the date being searched the train is added to a second list
            foreach (Train t in _trains)
            {
                if (searchTrainDate == t.DepartureDate)
                {
                    _trainsOnSameDay.Add(t);
                }
            }
            //returns the list
            return _trainsOnSameDay;
        }

        //method to delete a train from the list
        public void deleteTrain(string deleteTrainId)
        {
            //searches the train to be deleted and if the search doesnt return null removes the train from the list
            Train t = this.findTrain(deleteTrainId);
            if (t != null)
            {
                _trains.Remove(t);
            }

        }

        //method to add a ticket to the list
        public void addTicket(Ticket newTicket)
        {
            //adds the ticket to the list of all tickets
            _tickets.Add(newTicket);
        }

        //method to find a ticket by its name
        public Ticket findTicket(string searchName)
        {
            //looks through each ticket and if the name to be searched is the same as the name on the ticket the ticket is returned
            foreach (Ticket t in _tickets)
            {
                if (searchName == t.Name)
                {
                    return t;
                }
            }

            return null;
        }

        //method to delete a ticket from the list
        public void deleteTicket(string deleteName)
        {
            //finds the ticket by the name 
            Ticket t = this.findTicket(deleteName);
            //if the ticket returned doesnt equal null, the ticket is removed from the list
            if (t != null)
            {
                _tickets.Remove(t);
            }
        }

        //method to find all passengers on one train
        public List<Ticket> findAllPassengers(string SearchTrainID)
        {
            //looks through each ticket in the list of all tickets and if the train id of that ticket is the same as the train id to be searched it adds the ticket to another list
            foreach (Ticket t in _tickets)
            {
                if (SearchTrainID == t.TrainID)
                {
                    _allPassengersOnOneTrain.Add(t);
                }
            }
            //returns the list
            return _allPassengersOnOneTrain;
        }
        
    } 
}
