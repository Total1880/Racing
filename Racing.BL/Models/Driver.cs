using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class Driver
    {
        private readonly Guid driverId;
        private readonly string firstName;
        private readonly string lastName;
        private int speed = -1;

        #region constructors
        public Driver()
        {
            firstName = "No first name";
            lastName = "No last name";
        }

        public Driver(string inputFirstName, string inputLastName, int inputSpeed)
        {
            firstName = inputFirstName;
            lastName = inputLastName;
            speed = inputSpeed;
            driverId = Guid.NewGuid();
        }
        #endregion

        #region accessors
        public Guid DriverId
        {
            get { return driverId; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion
    }
}
