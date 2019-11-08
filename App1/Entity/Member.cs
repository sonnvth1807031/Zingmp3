using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Entity
{
    class Member
    {
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string avatar { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string introduction { get; set; }
        public int gender { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Dictionary<string, string> Validate()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(firstName))
            {
                errors.Add("firstName", "FirstName is required!");
            }
            else if (firstName.Length < 5 || firstName.Length > 30)
            {
                errors.Add("firstName", "FirstName must be 5 to 30 characters!");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                errors.Add("lastName", "LastName is required!");
            }
            else if (lastName.Length < 5 || lastName.Length > 30)
            {
                errors.Add("lastName", "LastName must be 5 to 30 characters!");
            }

            if (string.IsNullOrEmpty(avatar))
            {
                errors.Add("avatar", "Avatar is required!");
            }
            else if (avatar.Length < 5 || avatar.Length > 30)
            {
                errors.Add("avatar", "Avatar must be 5 to 30 characters!");
            }

            if (string.IsNullOrEmpty(phone))
            {
                errors.Add("phone", "Phone is required!");
            }
            else if (phone.Length >= 10)
            {
                errors.Add("phone", "Phone 10 characters!");
            }

            if (string.IsNullOrEmpty(address))
            {
                errors.Add("address", "Address is required!");
            }
            else if (address.Length < 5 || address.Length > 100)
            {
                errors.Add("address", "Address must be 5 to 100 characters!");
            }

            if (string.IsNullOrEmpty(introduction))
            {
                errors.Add("introduction", "Introduction is required!");
            }
            else if (introduction.Length < 5 || introduction.Length > 100)
            {
                errors.Add("introduction", "Introduction must be 5 to 100 characters!");
            }
            
            if (string.IsNullOrEmpty(email))
            {
                errors.Add("email", "Email is required!");
            }
            
            if (string.IsNullOrEmpty(password))
            {
                errors.Add("password", "Name is required!");
            }
            return errors;
        }
    }
}
