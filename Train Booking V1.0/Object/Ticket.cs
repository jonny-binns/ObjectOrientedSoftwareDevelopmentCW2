using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object
{
    public class Ticket : Booking
    {
        private decimal _Price;
        private string _Coach;
        private int _Seat;

        public decimal Price
        {
            get
            {
                return _Price;
            }

            set
            {
                _Price = value;
            }
        }

        public string Coach
        {
            get
            {
                return _Coach;
            }

            set
            {
                if (value.Any(char.IsLetter))
                {
                    _Coach = value;
                }
                else
                {
                    throw new ArgumentException("Please enter a valid letter");
                }
            }
        }

        public int Seat
        {
            get
            {
                return _Seat;
            }

            set
            {
                _Seat = value;
            }
        }



    }
}
