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
using System.Text.RegularExpressions;

namespace TrackAndTrace
{
    /// <summary>
    /// Mikha Walter Rohrs - 40437226
    /// Last updated: 11/12/2020
    /// A program that can record multiple users and track their contacts with other users and locations
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creates the first and only instance of the UserFactory object
        UserFactory idMaker = UserFactory.Instance;
        //Creates a list of all users, locations, contacts and visits
        List<User> userList = new List<User>();
        List<Location> locationList = new List<Location>();
        List<Contact> contactList = new List<Contact>();
        int id = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Hides everything except for the base buttons and shows everything required to add a user.
        private void bAddUser_Click(object sender, RoutedEventArgs e)
        {
            textboxFName.IsEnabled = true;
            textboxFName.Visibility = Visibility.Visible;
            textboxLName.IsEnabled = true;
            textboxLName.Visibility = Visibility.Visible;
            textboxPhoneNum.IsEnabled = true;
            textboxPhoneNum.Visibility = Visibility.Visible;
            
            bConfirmUserDetails.Visibility = Visibility.Visible;
            
            textboxLocName.IsEnabled = false;
            textboxLocName.Visibility = Visibility.Hidden;
            coboLocationType.IsEnabled = false;
            coboLocationType.Visibility = Visibility.Hidden;
            bConfirmLocDetails.Visibility = Visibility.Hidden;

            textboxUser1.IsEnabled = false;
            textboxUser1.Visibility = Visibility.Hidden;
            textboxUser2.IsEnabled = false;
            textboxUser2.Visibility = Visibility.Hidden;
            datePicker.IsEnabled = false;
            datePicker.Visibility = Visibility.Hidden;
            bConfirmContact.Visibility = Visibility.Hidden;
            contactErrorMessage.Text = "";

            usercontactText.Visibility = Visibility.Hidden;
            bOriginalContact.Visibility = Visibility.Hidden;
            bOriginalContact.IsEnabled = false;
            afterDateText.Visibility = Visibility.Hidden;
            datepickerOfContact.Visibility = Visibility.Hidden;
            datepickerOfContact.IsEnabled = false;
            bListMaker.Visibility = Visibility.Hidden;
            listContactList.Visibility = Visibility.Hidden;

            idCheck.Text = "User: " + Convert.ToString(id); 
        }

        //Hides everything except for the base buttons and shows everything required to add a location.
        private void bAddLocation_Click(object sender, RoutedEventArgs e)
        {
            textboxLocName.IsEnabled = true;
            textboxLocName.Visibility = Visibility.Visible;
            coboLocationType.IsEnabled = true;
            coboLocationType.Visibility = Visibility.Visible;
            bConfirmLocDetails.IsEnabled = true;
            bConfirmLocDetails.Visibility = Visibility.Visible;
            bConfirmLocDetails.Visibility = Visibility.Visible;

            bConfirmUserDetails.Visibility = Visibility.Visible;
            
            textboxFName.IsEnabled = false;
            textboxFName.Visibility = Visibility.Hidden;
            textboxLName.IsEnabled = false;
            textboxLName.Visibility = Visibility.Hidden;
            textboxPhoneNum.IsEnabled = false;
            textboxPhoneNum.Visibility = Visibility.Hidden;

            textboxUser1.IsEnabled = false;
            textboxUser1.Visibility = Visibility.Hidden;
            textboxUser2.IsEnabled = false;
            textboxUser2.Visibility = Visibility.Hidden;
            datePicker.IsEnabled = false;
            datePicker.Visibility = Visibility.Hidden;
            bConfirmContact.Visibility = Visibility.Hidden;
            contactErrorMessage.Text = "";

            usercontactText.Visibility = Visibility.Hidden;
            bOriginalContact.Visibility = Visibility.Hidden;
            bOriginalContact.IsEnabled = false;
            afterDateText.Visibility = Visibility.Hidden;
            datepickerOfContact.Visibility = Visibility.Hidden;
            datepickerOfContact.IsEnabled = false;
            bListMaker.Visibility = Visibility.Hidden;
            listContactList.Visibility = Visibility.Hidden;

            idCheck.Text = "";
        }

        //Checks if the phone number entered by the user is valid. If valid it adds all the info to the current
        //instance of User and stores the instance into a list.
        //Otherwise, send an error message.
        private void bConfirmUserDetails_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.Match(textboxPhoneNum.Text, @"^(\+[0-9]{9})$").Success)
            {
                User currentId = idMaker.FactoryMethod();
                currentId.FirstName = textboxFName.Text;
                currentId.LastName = textboxLName.Text;
                currentId.TelephoneNum = textboxPhoneNum.Text;

                userList.Add(currentId);

                id++;
                bConfirmUserDetails.Visibility = Visibility.Hidden;
            }
            else
            {
                textboxPhoneNum.Text = "Invalid phone number";
            }
        }

        //Creates a new instance of shop, cafe or park; which are all locations, and stores in a list.
        private void bConfirmLocDetails_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(coboLocationType.SelectedItem) == "System.Windows.Controls.ComboBoxItem: Shop")
            {
                locationList.Add(new Shop()
                {
                    LocationName = textboxLocName.Text,
                    LocationType = "Shop"
                });
                bConfirmLocDetails.Visibility = Visibility.Hidden;
            }
            else if (Convert.ToString(coboLocationType.SelectedItem) == "System.Windows.Controls.ComboBoxItem: Cafe")
            {
                locationList.Add(new Cafe()
                {
                    LocationName = textboxLocName.Text,
                    LocationType = "Cafe"
                });
                bConfirmLocDetails.Visibility = Visibility.Hidden;
            }
            else if (Convert.ToString(coboLocationType.SelectedItem) == "System.Windows.Controls.ComboBoxItem: Park")
            {
                locationList.Add(new Park()
                {
                    LocationName = textboxLocName.Text,
                    LocationType = "Park"
                });
                bConfirmLocDetails.Visibility = Visibility.Hidden;
            }
            else
            {
                textboxLocName.Text = "Please enter type";
            }
        }

        //Hides everything except for the base buttons and shows everything needed to record a contact.
        private void bRecordContact_Click(object sender, RoutedEventArgs e)
        {
            textboxUser1.IsEnabled = true;
            textboxUser1.Visibility = Visibility.Visible;
            textboxUser2.IsEnabled = true;
            textboxUser2.Visibility = Visibility.Visible;
            datePicker.IsEnabled = true;
            datePicker.Visibility = Visibility.Visible;
            bConfirmContact.Visibility = Visibility.Visible;
            contactErrorMessage.Text = "";

            textboxFName.IsEnabled = false;
            textboxFName.Visibility = Visibility.Hidden;
            textboxLName.IsEnabled = false;
            textboxLName.Visibility = Visibility.Hidden;
            textboxPhoneNum.IsEnabled = false;
            textboxPhoneNum.Visibility = Visibility.Hidden;

            textboxLocName.IsEnabled = false;
            textboxLocName.Visibility = Visibility.Hidden;
            coboLocationType.IsEnabled = false;
            coboLocationType.Visibility = Visibility.Hidden;
            bConfirmLocDetails.Visibility = Visibility.Hidden;

            bConfirmUserDetails.Visibility = Visibility.Hidden;

            usercontactText.Visibility = Visibility.Hidden;
            bOriginalContact.Visibility = Visibility.Hidden;
            bOriginalContact.IsEnabled = false;
            afterDateText.Visibility = Visibility.Hidden;
            datepickerOfContact.Visibility = Visibility.Hidden;
            datepickerOfContact.IsEnabled = false;
            bListMaker.Visibility = Visibility.Hidden;
            listContactList.Visibility = Visibility.Hidden;

            idCheck.Text = "";
        }

        //This method checks if the 2 user IDs entered exist, aswell as converting the date and time entered into
        //a variable of type DateTime.
        //All of this information is stored in an instance of Contact, which is then stored in a list of contacts.
        private void bConfirmContact_Click(object sender, RoutedEventArgs e)
        {
            int user1 = 0;
            int user2 = 0;

            //Checks if IDs are valid
            for (int i = 0; i < userList.Count; i++)
            {
                if ( textboxUser1.Text != "")
                {
                    if (userList[i].UserIdNumber == Convert.ToInt32(textboxUser1.Text))
                    {
                        user1 = Convert.ToInt32(textboxUser1.Text);
                    }
                }              
            }
            for (int i = 0; i < userList.Count; i++)
            {
                if (textboxUser2.Text != "")
                {
                    if (userList[i].UserIdNumber == Convert.ToInt32(textboxUser2.Text) && textboxUser2.Text != null)
                    {
                        user2 = Convert.ToInt32(textboxUser2.Text);
                    }
                }               
            }

            //Converts the date and time entered into string, seperates it into many substrings which are converted
            //to int. Also makes sure the user actually enters a date.
            string date = Convert.ToString(datePicker.SelectedDate);
            if (datePicker.SelectedDate != null)
            {
                string sDay = date.Substring(0, 2);
                string sMonth = date.Substring(3, 2);
                string sYear = date.Substring(6, 4);
                string sHour = date.Substring(11, 2);
                string sMinute = date.Substring(14, 2);
                string sSeconds = date.Substring(17, 2);

                int day = Convert.ToInt32(sDay);
                int month = Convert.ToInt32(sMonth);
                int year = Convert.ToInt32(sYear);
                int hour = Convert.ToInt32(sHour);
                int minute = Convert.ToInt32(sMinute);
                int seconds = Convert.ToInt32(sSeconds);

                //If the user IDs are valid, create a new instance of Contact with these details.
                if (user1 != 0 && user2 != 0)
                {
                    contactList.Add(new Contact()
                    {
                        User1 = user1,
                        User2 = user2,
                        DateOfContact = new DateTime(year, month, day, hour, minute, seconds)
                    });
                    bConfirmContact.Visibility = Visibility.Hidden;
                }
                //Error message of one of the IDs is invalid.
                else
                {
                    contactErrorMessage.Text = "Invalid user ID";
                }
            }
            else
            {
                contactErrorMessage.Text = "Must enter a Date";
            } 
        }

        //Incomplete method.
        private void bRecordVisit_Click(object sender, RoutedEventArgs e)
        {

        }

        //Hides all visible text boxes and shows the textboxes, date pickers, and buttons neede to show the list
        //of contacts.
        private void bGenContactList_Click(object sender, RoutedEventArgs e)
        {
            usercontactText.Visibility = Visibility.Visible;
            bOriginalContact.Visibility = Visibility.Visible;
            bOriginalContact.IsEnabled = true;
            afterDateText.Visibility = Visibility.Visible;
            datepickerOfContact.Visibility = Visibility.Visible;
            datepickerOfContact.IsEnabled = true;
            bListMaker.Visibility = Visibility.Visible;
            listContactList.Visibility = Visibility.Visible;

            textboxUser1.IsEnabled = false;
            textboxUser1.Visibility = Visibility.Hidden;
            textboxUser2.IsEnabled = false;
            textboxUser2.Visibility = Visibility.Hidden;
            datePicker.IsEnabled = false;
            datePicker.Visibility = Visibility.Hidden;
            bConfirmContact.Visibility = Visibility.Hidden;

            textboxFName.IsEnabled = false;
            textboxFName.Visibility = Visibility.Hidden;
            textboxLName.IsEnabled = false;
            textboxLName.Visibility = Visibility.Hidden;
            textboxPhoneNum.IsEnabled = false;
            textboxPhoneNum.Visibility = Visibility.Hidden;

            textboxLocName.IsEnabled = false;
            textboxLocName.Visibility = Visibility.Hidden;
            coboLocationType.IsEnabled = false;
            coboLocationType.Visibility = Visibility.Hidden;
            bConfirmLocDetails.Visibility = Visibility.Hidden;

            bConfirmUserDetails.Visibility = Visibility.Hidden;

            idCheck.Text = "";
        }

        //Deals with generating the list of phone numbers of those who contacted a specific user.
        private void bListMaker_Click(object sender, RoutedEventArgs e)
        {
            //Clears the list incase it already has phone numbers from a previous query.
            listContactList.ItemsSource = null;
            listContactList.Items.Clear();

            //Makes sure a contact actually exists and that a date is entered.
            if (datepickerOfContact.SelectedDate != null || contactList.Count != 0)
            {
                //The ID number of the user who has been contacted.
                int originId = Convert.ToInt32(bOriginalContact.Text);

                //Takes the string date from the date picker.
                string date = Convert.ToString(datepickerOfContact.SelectedDate);
                string sDay = date.Substring(0, 2);
                string sMonth = date.Substring(3, 2);
                string sYear = date.Substring(6, 4);
                string sHour = date.Substring(11, 2);
                string sMinute = date.Substring(14, 2);
                string sSeconds = date.Substring(17, 2);
                //Seperates date into various substrings, such as year and day, and converts those into integers.
                int day = Convert.ToInt32(sDay);
                int month = Convert.ToInt32(sMonth);
                int year = Convert.ToInt32(sYear);
                int hour = Convert.ToInt32(sHour);
                int minute = Convert.ToInt32(sMinute);
                int seconds = Convert.ToInt32(sSeconds);
                //Uses the seperate integers to create a DateTime.
                DateTime originDate = new DateTime(year, month, day, hour, minute, seconds);

                //Goes through all instances of Contact stored in contactList.
                for (int i = 0; i < contactList.Count; i++)
                {
                    //If the date selected is later than the date of the current contact:
                    if (originDate > contactList[i].DateOfContact)
                    {
                        //Check if the current contact contains the ID we are looking for.
                        if (originId == contactList[i].User1 || originId == contactList[i].User2)
                        {
                            //If the ID is found, go through every instance of User stored in userList.
                            for (int j = 0; j < userList.Count; j++)
                            {
                                //Finds the Users with the same ID number so we can get the phone number.
                                if (userList[j].UserIdNumber == contactList[i].User1 || userList[j].UserIdNumber == contactList[i].User2)
                                {
                                    //Stops the list from displaying the original ID's phonenumber in the list.
                                    if (userList[j].UserIdNumber != originId)
                                    {
                                        listContactList.Items.Add("ID:" + userList[j].UserIdNumber + " Phone: " + userList[j].TelephoneNum);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                listContactList.Items.Add("Must enter a date and have made a contact");
            }  
        }
    }
}
