﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoEmail_Repo
{
    public class CustomerRepo
    {
        private List<Customer> _CustList = new List<Customer>();

        //Create
        public void AddCustomer(Customer cust)
        {
            _CustList.Add(cust);
        }

        //Read
        public List<Customer> GetCustomers()
        {
            _CustList.Sort();
            return _CustList;
        }

        //Update
        public void UpdateCustomer(string frtNM, string lstNM, Customer customer)
        {
            var c = GetCustomersByName(frtNM, lstNM);

            if (c != null)
            {
                c.FirstName = customer.FirstName;
                c.LastName = customer.LastName;
                c.Type = customer.Type;
            }
        }

        //Delete
        public bool RemoveCustomer(string firstNM, string lastNM)
        {
            var cust = GetCustomersByName(firstNM, lastNM);

            if (cust != null)
            {
                int intCount = _CustList.Count;
                _CustList.Remove(cust);
                if (intCount > _CustList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }


        //Help
        private Customer GetCustomersByName(string fName, string lName)
        {
            foreach (Customer name in _CustList)
            {
                if (name.LastName == lName && name.FirstName == fName)
                {
                    return name;
                }
            }
            return null;
        }
    }
}
