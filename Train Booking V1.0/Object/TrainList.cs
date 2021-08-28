using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class TrainList
    {
        private List<Train> _trains = new List<Train>();
        private List<Ticket> _tickets = new List<Ticket>();

        public void addTrain(Train newTrain)
        {
            _trains.Add(newTrain);
        }

        public Train findTrain(string searchTrainID)
        {
            foreach(Train t in _trains)
            {
                if (searchTrainID == t.TrainID)
                {
                    return t;
                }      
            }

            return null;
        }

        public void deleteTrain(string deleteTrainId)
        {
            Train t = this.findTrain(deleteTrainId);
            if (t != null)
            {
                _trains.Remove(t);
            }

        }

        public void addTicket(Ticket newTicket)
        {
            _tickets.Add(newTicket);
        }

        public Ticket findTicket(string searchName)
        {
            foreach (Ticket t in _tickets)
            {
                if (searchName == t.Name)
                {
                    return t;
                }
            }

            return null;
        }

        public void deleteTicket(string deleteName)
        {
            Ticket t = this.findTicket(deleteName);
            if (t != null)
            {
                _tickets.Remove(t);
            }
        }

    }
}
