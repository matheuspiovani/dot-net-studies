using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable
    {
        public Customer()
        {
            Adresses = new List<Address>();
        }

        public Customer(int customerId) : this()
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public List<Address> Adresses { get; set; }
        public int CustomerType { get; set; }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if(!string.IsNullOrWhiteSpace(FirstName))
                {
                    if(!string.IsNullOrEmpty(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }

                return fullName;
            }
        }

        public static int InstanceCount { get; set; }

        /// <summary>
        /// Validates the customer data
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }

        public string Log()
        {
            var logString = CustomerId + ": " + FullName + " Email: " + EmailAddress;
            return logString;
        }
    }
}
