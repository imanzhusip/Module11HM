using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11HM
{
    public struct Employee : IEmployeeInformation
    {
        public string FirstName;
        public string LastName;
        public DateTime HireDate;
        public string Position;
        public char Gender;
        public decimal Salary;

        public string ToString()
        {
            return $"{FirstName} {LastName}, {Position}, {HireDate.ToShortDateString()}, {Gender}, {Salary:C}";
        }
    }

}
