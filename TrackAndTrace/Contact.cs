using System;
using System.Collections.Generic;
using System.Text;

namespace TrackAndTrace
{
    class Contact
    {
        //Stores the details of each contact
        private int user1;
        private int user2;
        private DateTime dateOfContact;

        //Getter and setter for one of the users in a contact
        public int User1
        {
            get { return this.user1; }
            set { this.user1 = value; }
        }

        //Getter and setter for the second user in a contact
        public int User2
        {
            get { return this.user2; }
            set { this.user2 = value; }
        }

        //Getter and setter for the date and time at which a contact occured
        public DateTime DateOfContact
        {
            get { return this.dateOfContact; }
            set { this.dateOfContact = value; }
        }
    }
}
