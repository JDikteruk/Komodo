using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoEmail_Repo
{
    public enum CustType { Current = 1, Future, Past };

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustType Type { get; set; }
        public string Message
        {
            get
            {
                switch (Type)
                {
                    case CustType.Current:
                        return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    case CustType.Future:
                        return "We currently have the lowest rates on Helicopter Insurance!";
                    case CustType.Past:
                        return "It's been a long time since we've heard from you, we want you back";
                    default:
                        return null;
                }
            }
            set
            {
                switch (Type)
                {
                    case CustType.Current:
                        Message = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                        break;
                    case CustType.Future:
                        Message = "We currently have the lowest rates on Helicopter Insurance!";
                        break;
                    case CustType.Past:
                        Message = "It's been a long time since we've heard from you, we want you back";
                        break;
                }
            }
        }

        public Customer() { };

        public Customer(string firstName, string lastName, CustType custType) 
        {
            FirstName = firstName;
            LastName = lastName;
            Type = custType;
        };

    }
}
