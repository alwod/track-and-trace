using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TrackAndTrace
{
    class User
    {
        //Variables required for a user.
        private int userId;
        private string firstName;
        private string lastName;
        private string telephoneNum;

        //Getter for this users ID.
        public int UserIdNumber
        {
            get { return this.userId; }
        }
        //Sets the user ID to that which was generated in the UserFactory.
        public User(int id)
        {
            userId = id;   
        }
        
        //Getter and setter for the users first name.
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        //Getter and setter for the users last name.
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        //Getter and setter for the users telephone number.
        public string TelephoneNum
        {
            get { return this.telephoneNum; }
            set { this.telephoneNum = value; }
        }
    }
}
