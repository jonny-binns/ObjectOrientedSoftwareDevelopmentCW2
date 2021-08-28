using Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Train_Booking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TrainList store = new TrainList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            Ticket t = new Ticket();
            try
            {
                t.Name = PassengerNameTxt.Text;
                t.TrainID = TrainIDPassengerTxt.Text;
                t.DestinationStation = DestinationStationPassengerTxt.Text;
                t.DepartureStation = DepartureStationPassengerTxt.Text;
                t.FirstClass = Convert.ToBoolean(FirstClassPassingerTxt.Text);
                t.Cabin = Convert.ToBoolean(CabinPassengerTxt.Text);
                t.Coach = CoachPassengerTxt.Text;
                t.Seat = int.Parse(SeatPassengerTxt.Text);

                store.addTicket(t);

                PassengerNameTxt.Text = "";
                TrainIDPassengerTxt.Text = "";
                DestinationStationPassengerTxt.Text = "";
                DepartureStationPassengerTxt.Text = "";
                FirstClassPassingerTxt.Text = "";
                CabinPassengerTxt.Text = "";
                CoachPassengerTxt.Text = "";
                SeatPassengerTxt.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
           
        }

        private void FindBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            string n = PassengerNameTxt.Text;
            var t = store.findTicket(n);

            PassengerNameTxt.Text = t.Name;
            TrainIDPassengerTxt.Text = t.TrainID;
            DestinationStationPassengerTxt.Text = t.DestinationStation;
            DepartureStationPassengerTxt.Text = t.DepartureStation;
            FirstClassPassingerTxt.Text = Convert.ToString(t.FirstClass);
            CabinPassengerTxt.Text = Convert.ToString(t.Cabin);
            CoachPassengerTxt.Text = t.Coach;
            SeatPassengerTxt.Text = Convert.ToString(t.Seat);
        }

        private void ClearBookingFormBtn_Click(object sender, RoutedEventArgs e)
        {
            
            PassengerNameTxt.Text = "";
            TrainIDPassengerTxt.Text = "";
            DestinationStationPassengerTxt.Text = "";
            DepartureStationPassengerTxt.Text = "";
            FirstClassPassingerTxt.Text = "";
            CabinPassengerTxt.Text = "";
            CoachPassengerTxt.Text = "";
            SeatPassengerTxt.Text = "";
            
            
        }

        private void DeleteBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            string d = PassengerNameTxt.Text;
            store.deleteTicket(d);

            PassengerNameTxt.Text = "";
            TrainIDPassengerTxt.Text = "";
            DestinationStationPassengerTxt.Text = "";
            DepartureStationPassengerTxt.Text = "";
            FirstClassPassingerTxt.Text = "";
            CabinPassengerTxt.Text = "";
            CoachPassengerTxt.Text = "";
            SeatPassengerTxt.Text = "";
        }

        private void AddTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            Train t = new Train();

            t.TrainID = TrainIDTrainTxt.Text;
            t.DepartureStation = DepartureStationTrainTxt.Text;
            t.DestinationStation = DestinationStationTrainTxt1.Text;
            t.Type = TrainTypeTxt.Text;

            store.addTrain(t);

            TrainIDTrainTxt.Text = "";
            DepartureStationTrainTxt.Text = "";
            DestinationStationTrainTxt1.Text = "";
            TrainTypeTxt.Text = "";

        }

        private void FindTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = TrainIDTrainTxt.Text;
            var t = store.findTrain(id);

            TrainIDTrainTxt.Text = t.TrainID;
            DepartureStationTrainTxt.Text = t.DepartureStation;
            DestinationStationTrainTxt1.Text = t.DestinationStation;
            TrainTypeTxt.Text = t.Type;
        }


        private void ClearTrainFormBtn_Click(object sender, RoutedEventArgs e)
        {
            TrainIDTrainTxt.Text = "";
            DepartureStationTrainTxt.Text = "";
            DestinationStationTrainTxt1.Text = "";
            TrainTypeTxt.Text = "";
        }

        private void DeleteTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            string ID = TrainIDTrainTxt.Text;
            store.deleteTrain(ID);

            TrainIDTrainTxt.Text = "";
            DepartureStationTrainTxt.Text = "";
            DestinationStationTrainTxt1.Text = "";
            TrainTypeTxt.Text = "";
        }
    }
}
