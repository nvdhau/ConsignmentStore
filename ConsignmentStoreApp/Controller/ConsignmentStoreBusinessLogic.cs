using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using ConsignmentStoreApp.EF_Classes;
using System.Data.Entity;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsignmentStoreApp.Controller
{
    public static class ConsignmentStoreBusinessLogic
    {
        //error codes
        public const int VALID = 1;
        public const int INVALID_EMAIL = -1;
        public const int INVALID_PASSWORD = -2;


        public static ConsignmentStoreEntities context = new ConsignmentStoreEntities();
        public static Employee loggedInEmployee;//current logged in employee

        public static decimal GetConsignorRatio()
        {
            return 1 - decimal.Parse(ConfigurationManager.AppSettings.Get("ConsignmentFee"));
        }

        public static int Authenticate(string email, string password) 
        {
            Employee loginEmployee = context.Employees.Where(employee => employee.EmployeeEmail.Trim() == email).FirstOrDefault();

            if(loginEmployee == null)
            {//invalid email
                return INVALID_EMAIL;
            }
            else if(loginEmployee.EmployeePassword != password)
            {//incorrect password
                return INVALID_PASSWORD;
            }
            else
            {//valid email and password
                loggedInEmployee = loginEmployee;
                return VALID;
            }
        }

    }
}
