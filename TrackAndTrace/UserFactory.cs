using System;
using System.Collections.Generic;
using System.Text;

namespace TrackAndTrace
{
    class UserFactory
    {
        //Holds a record of the last ID number.
        private int lastUserId = 0;
        //Holds the only UserFactory object.
        private static UserFactory instance;

        //Private constructor so it cannot be called.
        private UserFactory() { }

        //Allows access to the only instance of UserFactory.
        //If one does'nt exist, it will instanciate UserFactory.
        public static UserFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserFactory();
                }
                return instance;
            }
        }

        //Creates an instance of User and automatically gives it an ID, which increments by 1 every time.
        public User FactoryMethod()
        {
            lastUserId++;
            return new User(lastUserId);
        }
    }
}
