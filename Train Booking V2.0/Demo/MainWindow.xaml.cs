/*
 * v.2.3
 * Author: Jonathan Binns
 * Purpose: To be able to create/store/search new trains and bookings on those trains
 * Date Last Modified: 07/12/18
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //creates a new instance of train list called store
        private TrainList store = new TrainList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            //creates a new instance of ticket
            Ticket t = new Ticket();
            //tries the enclosed code, if an argument is thrown its caught in the below block
            try
            {
               //searches the train id entered to check that the corresponding train exists
                var train = store.findTrain(PassengerTrainIDTxt.Text);
                if ( train != null)
                {
                    //if the train exists it adds the ID to the ticket
                    t.TrainID = PassengerTrainIDTxt.Text;
                }
                else
                {
                    //throws exception if the train doesnt exist
                    throw new ArgumentException("Please Enter a Valid Train");
                }

                //sets passenger name to the content of the passenger name textbox
                t.Name = PassengerNameTxt.Text;
                
                //checks that the departure station and desination station cant be the same
                if(PassengerDepartureStationTxt.Text == PassengerDesinationStationTxt.Text)
                {
                    //throws exception if they are
                    throw new ArgumentException("The destination station cant be the same as the departure station");
                }
                //checks that the departure/destination station are on the trains route
                if(!train.AllStations().ToString().Contains(PassengerDepartureStationTxt.Text) || !train.AllStations().ToString().Contains(PassengerDesinationStationTxt.Text))
                {
                    //throws exception if it isnt
                    throw new ArgumentException("Please enter a valid station for this train");
                }
                else
                {
                    //if it passes the validations it sets the departure/destination stations to whats in the text boxes
                    t.DepartureStation = PassengerDepartureStationTxt.Text;
                    t.DestinationStation = PassengerDesinationStationTxt.Text;
                }

                //validation to only allow people to sit in coach A if they are wanting a first class seat and validation to make sure you cant book a first class ticket on a train without a first class cabin
                if (PassengerFirstClassTxt.Text == "True" && PassengerCoachTxt.Text == "A" && train.FirstClass == true)
                {
                    t.FirstClass = Convert.ToBoolean(PassengerFirstClassTxt.Text);
                    t.Coach = "A";
                }
                if (train.FirstClass == false && PassengerFirstClassTxt.Text == "True")
                {
                    throw new ArgumentException("Please make sure the train has a first class carrage");
                }
                if (train.FirstClass == false)
                {
                    t.FirstClass = Convert.ToBoolean(PassengerFirstClassTxt.Text);
                    t.Coach = PassengerCoachTxt.Text;
                }
                else if(PassengerFirstClassTxt.Text == "False" && PassengerCoachTxt.Text == "A" || PassengerFirstClassTxt.Text == "True" && PassengerCoachTxt.Text != "A")
                {
                    throw new ArgumentException("Please select coach a if you want first class");
                }
                else if(train.FirstClass == false && PassengerFirstClassTxt.Text == "True" || train.FirstClass == false && PassengerCoachTxt.Text == "A")
                {
                    throw new ArgumentException("Please make sure the train has a first class carrage");
                }
                else
                {
                    t.FirstClass = Convert.ToBoolean(PassengerFirstClassTxt.Text);
                    t.Coach = PassengerCoachTxt.Text;
                }


                //sets true if the user wants a cabin, only sets if the train is a sleeper
                if (train.Type == "Sleeper" || PassengerCabinTxt.Text == "False")
                {
                    t.Cabin = Convert.ToBoolean(PassengerCabinTxt.Text);
                }
                else
                {
                    throw new ArgumentException("Please Select a Sleeper Train if you want a cabin");
                }

                try
                {
                    //displays the price in the price text box
                    t.Price = Convert.ToDecimal(PassengerPriceTxt.Text);
                }
                catch
                {
                    //only allows you to add a customer once you have calculated a price
                    throw new ArgumentException("Have you remebered to calculate the price?");
                }

                //checks that the seat is a valid number
                try
                {
                    Int32 PassengerSeatTest = new Int32();
                    PassengerSeatTest = Convert.ToInt32(PassengerSeatTxt.Text);
                    if (PassengerSeatTest >= 1 && PassengerSeatTest <= 60)
                    {
                        t.Seat = int.Parse(PassengerSeatTxt.Text);
                    }
                    else
                    {
                        throw new ArgumentException("Please enter a valid seat, between 1 and 60");
                    }
                }
                catch
                {
                    //throws an argument if it isnt a valid number
                    throw new ArgumentException("Please enter a valid number");
                }

                //adds the coach and seat together and saves it to a string called booked seat
                string Bookedseat = PassengerCoachTxt.Text + PassengerSeatTxt.Text.ToString();
                
                //checks that the seat to be booked hasnt already been taken
                if (train.TakenSeats == null || !train.TakenSeats.Contains(Bookedseat))
                {
                    //adds the booked seat to the train
                    train.TakenSeats += Bookedseat + ",";
                }
                else
                {
                    //throws exception if the seat has already been booked
                    throw new ArgumentException("This seat has already been booked");
                }

                store.addTicket(t);

                //sets all the text boxes to blank
                PassengerNameTxt.Text = "";
                PassengerTrainIDTxt.Text = "";
                PassengerDepartureStationTxt.Text = "";
                PassengerDesinationStationTxt.Text = "";
                PassengerFirstClassTxt.Text = "";
                PassengerCabinTxt.Text = "";
                PassengerPriceTxt.Text = "";
                PassengerCoachTxt.Text = "";
                PassengerSeatTxt.Text = "";
            }
            //catches any arguments thrown in the above block
            catch (Exception ex)
            {
                //displays a message box with any argument thrown
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FindBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            //tries the below code and throws an exception if it throws any arguments
            try
            {
                //creates a string called name, to be searched from the passenger name text box
                string Name = PassengerNameTxt.Text;
                //searches the name in the list
                var t = store.findTicket(Name);
                //displays the ticket in a message box
                MessageBox.Show(t.ToString());
                
            }
            //catches any arguments thrown in the above code
            catch(Exception ex)
            {
                //displays the content of any arguments thrown
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void DeleteBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            //creates a string called d, short for delete, from the passenger name text  box
            string d = PassengerNameTxt.Text;
            //deletes the passenger with the corresponding name from the list
            store.deleteTicket(d);

            //sets all text boxes to blank
            PassengerNameTxt.Text = "";
            PassengerTrainIDTxt.Text = "";
            PassengerDepartureStationTxt.Text = "";
            PassengerDesinationStationTxt.Text = "";
            PassengerFirstClassTxt.Text = "";
            PassengerCabinTxt.Text = "";
            PassengerPriceTxt.Text = "";
            PassengerCoachTxt.Text = "";
            PassengerSeatTxt.Text = "";
        }

        private void ClearBookingBtn_Click(object sender, RoutedEventArgs e)
        {
            //sets all text boxes to blank
            PassengerNameTxt.Text = "";
            PassengerTrainIDTxt.Text = "";
            PassengerDepartureStationTxt.Text = "";
            PassengerDesinationStationTxt.Text = "";
            PassengerFirstClassTxt.Text = "";
            PassengerCabinTxt.Text = "";
            PassengerPriceTxt.Text = "";
            PassengerCoachTxt.Text = "";
            PassengerSeatTxt.Text = "";
        }

        private void GenerateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            //adds customer details to the box to be easily changed for validation purposes
            PassengerNameTxt.Text = "Jonny";
            PassengerTrainIDTxt.Text = "1234";
            PassengerDepartureStationTxt.Text = "Edinburgh Waverley";
            PassengerDesinationStationTxt.Text = "London Kings Cross";
            PassengerFirstClassTxt.Text = "False";
            PassengerCabinTxt.Text = "False";
            PassengerCoachTxt.Text = "A";
            PassengerSeatTxt.Text = "1";
        }

        private void CalculatePriceBtn_Click(object sender, RoutedEventArgs e)
        {
            //creates a decimal called price and sets it to 0
            decimal price = 0;
            //if the departure station is edinburgh and the desination station is london £50 is added to 'price'
            if (PassengerDepartureStationTxt.Text == "Edinburgh Waverley" && PassengerDesinationStationTxt.Text == "London Kings Cross")
            {
                price += 50;
            }
            //if the departure station is london and the desination station is edinburgh £50 is added to 'price'
            if (PassengerDepartureStationTxt.Text == "London Kings Cross" && PassengerDesinationStationTxt.Text == "Edinburgh Waverley")
            {
                price += 50;
            }
            //if the departure station is any one of the intermediate stations £25 is added to price
            if (PassengerDepartureStationTxt.Text == "Peterborough" || PassengerDepartureStationTxt.Text == "Darlington" || PassengerDepartureStationTxt.Text == "York" || PassengerDepartureStationTxt.Text == "Newcastle")
            {
                price += 25;
            }
            //else if the desination stations is any one of the intermediate stations £25 is added to price
            else if (PassengerDesinationStationTxt.Text == "Peterborough" || PassengerDesinationStationTxt.Text == "Darlington" || PassengerDesinationStationTxt.Text == "York" || PassengerDesinationStationTxt.Text == "Newcastle")
            {
                price += 25;
            }
            //if the ticket is for first class £10 is added to the price
            if (PassengerFirstClassTxt.Text == "True")
            {
                price += 10;
            }
            //if the ticket is for a cabin £20 is added to the price
            if (PassengerCabinTxt.Text == "True")
            {
                price += 20; 
            }
            //searches for the train with the corresponding id to the one entered into the passengers train id text box
            var train = store.findTrain(PassengerTrainIDTxt.Text);
            //if the trains type is sleeper then £10 is added to the ticket
            if (train.Type == "Sleeper")
            {
                price += 10;
            }

            //the passenger price text box is then set to the price just calculated
            PassengerPriceTxt.Text = price.ToString();
        }

        private void AddTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            //tries the enclosed code if an argument is thrown its caught in the below block 
            try
            {
                //runs the code when the express type is selected in the combo box
                if (TrainTypeCombo.SelectedItem == ExpressComboLbl)
                {
                    //tries the enclosed code if an argument is thrown its caught in the below block 
                    try
                    {
                        //creates a new instance of express
                        Express t = new Express();
                        //sets the type of the object to express
                        t.Type = "Express";
                        //searches the train id entered into the text box to see if it has been taken
                        var train = store.findTrain(TrainIDTxt.Text);
                        if ( train == null)
                        {
                            //sets the train id to the one entered if the id isnt found in the list
                            t.TrainID = TrainIDTxt.Text;
                        }
                        else
                        {
                            //throws an argument if the id entered is found in the list
                            throw new ArgumentException("Please enter a train ID that has not been used");
                        }


                        //validation to check that the desination and departure stations entered are not the same
                        if (TrainDepartureStationTxt.Text == TrainDestinationStationTxt.Text)
                        {
                            //throws argument if they are the same
                            throw new ArgumentException("The departure and destination stations can't be the same");
                        }
                        else
                        {
                            //if they arent the same it sets the departure/desination stations to the text entered
                            t.DepartureStation = TrainDepartureStationTxt.Text;
                            t.DestinationStation = TrainDestinationStationTxt.Text;
                        }

                        //sets the trains departure time to whats entered into the text box, will throw an argument if the text entered isnt in the correct format
                        t.DepartureTime = Convert.ToDateTime(TrainDepartureTimeTxt.Text);
                        //sets the trains departure date to whats entered into the text box, will throw an argument if the text entered isnt in the correct format
                        t.DepartureDate = Convert.ToDateTime(TrainDepartureDateTxt.Text);
                        //allows you to select if the train has a first class coach or not, if so it will be coach a
                        t.FirstClass = Convert.ToBoolean(TrainFirstClassTxt.Text);
                        
                        //adds the train to the list store
                        store.addTrain(t);
                        //clears the form
                        TrainIDTxt.Text = "";
                        TrainDepartureStationTxt.Text = "";
                        TrainDestinationStationTxt.Text = "";
                        TrainDepartureTimeTxt.Text = "";
                        TrainDepartureDateTxt.Text = "";
                        SleeperBerthTxt.Text = "";
                        TrainFirstClassTxt.Text = "";
                        NewcastleCheck.IsChecked = false;
                        Yorkcheck.IsChecked = false;
                        DarlingtonCheck.IsChecked = false;
                        PeterboroughCheck.IsChecked = false;
                    }
                    //catches any arguments thrown in the above section
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                //runs the code if the sleeper type is selected in the combo box
                if (TrainTypeCombo.SelectedItem == SleeperComboLbl)
                {
                    //tries the below block, if any arguments are thrown they are caught in the below block
                    try
                    {
                        //creates a new instance of sleeper
                        Sleeper t = new Sleeper();
                        //sets the trains type to sleeper
                        t.Type = "Sleeper";
                        //searches the train id entered into the text box to make sure it doesnt already exist
                        var train = store.findTrain(TrainIDTxt.Text);
                        if (train == null)
                        {
                            //if the search returns null the train id is set to the id entered in the text box
                            t.TrainID = TrainIDTxt.Text;
                        }
                        else
                        {
                            //if not it throws an argument
                            throw new ArgumentException("Please enter a train ID that has not been used");
                        }
                        //throws exception of the departure and desination station are about to be set to the same thing
                        if (TrainDepartureStationTxt.Text == TrainDestinationStationTxt.Text)
                        {
                            throw new ArgumentException("The departure and destination stations can't be the same");
                        }
                        else
                        {
                            //if they arent the same it sets them to the text entered in the text box
                            t.DepartureStation = TrainDepartureStationTxt.Text;
                            t.DestinationStation = TrainDestinationStationTxt.Text;
                        }
                        //creates a string called intermediate stations and sets it to null
                        string IntermediateStations = null;
                        //adds a string with the station name if the corressponding checkbox is checked
                        if (NewcastleCheck.IsChecked == true)
                        {
                            IntermediateStations += "Newcastle, ";
                        }

                        if (Yorkcheck.IsChecked == true)
                        {
                            IntermediateStations += "York, ";
                        }

                        if (DarlingtonCheck.IsChecked == true)

                        {
                            IntermediateStations += "Darlington, ";
                        }

                        if (PeterboroughCheck.IsChecked == true)
                        {
                            IntermediateStations += "Peterborough, ";
                        }
                        //sets the intermediate stops of the train to the intermediate stops string, decided by which checkboxes are checked
                        t.IntermediateStops = IntermediateStations;
                        //creates a TimeSpan called test to validate the 
                        TimeSpan Test = new TimeSpan(20, 0, 0);
                        //creates a DateTime to test the value entered into the departure time text box
                        DateTime DepartureTest = Convert.ToDateTime(TrainDepartureTimeTxt.Text);
                        //if the hour of the DateTime DepartureTest is bigger than the TimeSpan Test the time is set
                        if (DepartureTest.Hour > Test.Hours)
                        {
                            t.DepartureTime = Convert.ToDateTime(TrainDepartureTimeTxt.Text);
                        }
                        else
                        {
                            //throws exception if the time to be set is less than 9PM 
                            throw new ArgumentException("Sleeper Trains cannot be beofre 9pm");
                        }
                        
                        //sets the date to what is entered in the text box
                        t.DepartureDate = Convert.ToDateTime(TrainDepartureDateTxt.Text);
                        //allows you to set if the train has a sleeper berth
                        t.SleeperBerth = Convert.ToBoolean(SleeperBerthTxt.Text);
                        //allows you to set if the train has a first class coach
                        t.FirstClass = Convert.ToBoolean(TrainFirstClassTxt.Text);
                        //adds the train
                        store.addTrain(t);
                        //sets the form to blank
                        TrainIDTxt.Text = "";
                        TrainDepartureStationTxt.Text = "";
                        TrainDestinationStationTxt.Text = "";
                        TrainDepartureTimeTxt.Text = "";
                        TrainDepartureDateTxt.Text = "";
                        SleeperBerthTxt.Text = "";
                        TrainFirstClassTxt.Text = "";
                        NewcastleCheck.IsChecked = false;
                        Yorkcheck.IsChecked = false;
                        DarlingtonCheck.IsChecked = false;
                        PeterboroughCheck.IsChecked = false;
                    }
                    //catches any arguments thrown in the above section
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                //runs the below code if the selected item in the combo box is for a stopper train
                if (TrainTypeCombo.SelectedItem == StopperComboLbl)
                {
                    //tries the below code and if any arguments are thrown they will be caught in the below block
                    try
                    {
                        //creates a new instance of stopper
                        Stopper t = new Stopper();
                        //sets the type of the train to stopper
                        t.Type = "Stopper";
                        //searches the train id entered into the text box and if it isnt found sets the trains id to the one entered
                        var train = store.findTrain(TrainIDTxt.Text);
                        if (train == null)
                        {
                            t.TrainID = TrainIDTxt.Text;
                        }
                        else
                        {
                            //throws argument if the id is found
                            throw new ArgumentException("Please enter a train ID that has not been used");
                        }
                        //checks that the train departure and desination stations cant be the same
                        if (TrainDepartureStationTxt.Text == TrainDestinationStationTxt.Text)
                        {
                            //throws exception if they are the same
                            throw new ArgumentException("The departure and destination stations can't be the same");
                        }
                        else
                        {
                            //sets the desination/departure stations if they arent the same
                            t.DepartureStation = TrainDepartureStationTxt.Text;
                            t.DestinationStation = TrainDestinationStationTxt.Text;
                        }
                        //creates a string called Intermediate Stations
                        string IntermediateStations = null;
                        //adds a string containing the name of the station if its corresponding check box has been selected
                        if (NewcastleCheck.IsChecked == true)
                        {
                            IntermediateStations += "Newcastle, ";
                        }

                        if(Yorkcheck.IsChecked == true)
                        {
                            IntermediateStations += "York, ";
                        }

                        if(DarlingtonCheck.IsChecked == true)
                        {
                            IntermediateStations += "Darlington, ";
                        }

                        if (PeterboroughCheck.IsChecked == true)
                        {
                            IntermediateStations += "Peterborough, ";
                        }
                        //sets the trains intermediate stops to the string generated
                        t.IntermediateStops = IntermediateStations;
                        //sets the departure time to the one input in the text box
                        t.DepartureTime = Convert.ToDateTime(TrainDepartureTimeTxt.Text);
                        //sets the departure date to the one input in the text box
                        t.DepartureDate = Convert.ToDateTime(TrainDepartureDateTxt.Text);
                        //allows you to set a first class carraige on the train, if set the first class carriage is carrage a
                        t.FirstClass = Convert.ToBoolean(TrainFirstClassTxt.Text);
                        //adds the train to the list
                        store.addTrain(t);
                        //sets the form to blank
                        TrainIDTxt.Text = "";
                        TrainDepartureStationTxt.Text = "";
                        TrainDestinationStationTxt.Text = "";
                        TrainDepartureTimeTxt.Text = "";
                        TrainDepartureDateTxt.Text = "";
                        SleeperBerthTxt.Text = "";
                        TrainFirstClassTxt.Text = "";
                        NewcastleCheck.IsChecked = false;
                        Yorkcheck.IsChecked = false;
                        DarlingtonCheck.IsChecked = false;
                        PeterboroughCheck.IsChecked = false;
                    }
                    //catches any previous arguments thrown
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                }
                //throws exceptions if the combo box has not been selected
                if (TrainTypeCombo.SelectedItem == null)
                {
                    throw new ArgumentException("Did you remember to select the train type?");
                }
                //sets the combo box to null
                TrainTypeCombo.SelectedValue = 0;
            }
            //catches any arguments thrown in the above code
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FindTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            //tries the below code, if any arguments are thrown theyre caught in the block below
            try
            {
                //creates a string id to be searched, from the entry in the trains train id text box
                string id = TrainIDTxt.Text;
                //finds the id in the list
                var t = store.findTrain(id);
                //displays the train in a messagebox
                MessageBox.Show(t.ToString());
            }
            //catches any exception 
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DeleteTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            //creates an id to be deleted from what the user inputs into the trains text id box
            string ID = TrainIDTxt.Text;
            //deletes the id entered
            store.deleteTrain(ID);
            //sets the form to blank
            TrainIDTxt.Text = "";
            TrainDepartureStationTxt.Text = "";
            TrainDestinationStationTxt.Text = "";
            TrainDepartureTimeTxt.Text = "";
            TrainDepartureDateTxt.Text = "";
            SleeperBerthTxt.Text = "";
            TrainFirstClassTxt.Text = "";
            NewcastleCheck.IsChecked = false;
            Yorkcheck.IsChecked = false;
            DarlingtonCheck.IsChecked = false;
            PeterboroughCheck.IsChecked = false;
        }

        private void ClearTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            //clears the form
            TrainIDTxt.Text = "";
            TrainDepartureStationTxt.Text = "";
            TrainDestinationStationTxt.Text = "";
            TrainDepartureTimeTxt.Text = "";
            TrainDepartureDateTxt.Text = "";
            SleeperBerthTxt.Text = "";
            TrainFirstClassTxt.Text = "";
            NewcastleCheck.IsChecked = false;
            Yorkcheck.IsChecked = false;
            DarlingtonCheck.IsChecked = false;
            PeterboroughCheck.IsChecked = false;

        }

        private void GenerateTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            //adds a set of data to the text boxes so I can easily test out the form
            TrainIDTxt.Text = "1234";
            TrainDepartureStationTxt.Text = "Edinburgh Waverley";
            TrainDestinationStationTxt.Text = "London Kings Cross";
            TrainDepartureTimeTxt.Text = "19:00";
            TrainDepartureDateTxt.Text = "10/10/2018";
            TrainFirstClassTxt.Text = "True";
        }

        private void FindTrainByDateBtn_Click(object sender, RoutedEventArgs e)
        {
            //tries the below code and any exceptions thrown are cought in the below block
            try
            {
                //creates a DateTime to search from the text entered into the trains departure date text box
                DateTime SearchDate = Convert.ToDateTime(TrainDepartureDateTxt.Text);
                //searches the DateTime created, and returns all trains that depart on that day
                var t = store.findTrainDate(SearchDate);
                //combines all of the objects into one string
                string combinedString = string.Join<Train>("", t.ToArray());
                //displays the string in a message box
                MessageBox.Show(combinedString);
            }
            //catches any arguments thrown by the above code
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FindAllPassengersBtn_Click(object sender, RoutedEventArgs e)
        {
            //tries the below code, any arguments thrown are caught in the below block
            try
            {
                //ceates a train id to be searched from the train id entered in the passenger train id text box
                String SearchTrainID = PassengerTrainIDTxt.Text;
                //searches the train id and returns all tickets with that train id
                var t = store.findAllPassengers(SearchTrainID);
                //combines all of the tickets returned and sets them to the string
                string combinedString = string.Join<Ticket>("", t.ToArray());
                //displays the string in a message box
                MessageBox.Show(combinedString);
            }
            //catches any errors thrown in the above block and displays them in a message box
            catch (Exception ex)

            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
