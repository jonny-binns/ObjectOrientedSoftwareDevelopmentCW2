using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class Passenger
    {
        private string _Name;
        private string _TrainID;

        

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (value != string.Empty)
                {
                    _Name = value;
                }
                else
                {
                    throw new ArgumentException("Passenger name cannot be empty");
                }
            }
        }

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
    }
}
