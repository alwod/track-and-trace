using System;
using System.Collections.Generic;
using System.Text;

namespace TrackAndTrace
{
    class Location
    {
        //Stores the name and type of a location.
        private string locationName;
        private string locationType;

        //Getter and setter for this locations name.
        public string LocationName
        {
            get { return this.locationName; }
            set { this.locationName = value; }
        }

        //Getter and setter for this locations type.
        public string LocationType
        {
            get { return this.locationType; }
            set { this.locationType = value; }
        }
    }
}
