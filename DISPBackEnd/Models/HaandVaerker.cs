using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISPBackEnd.Models
{
    public class HaandVaerker
    {
        public int HaandVaerkerId { get; set; }
        public string EmployeeDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Speciality { get; set; }
        public Vaerktoejskasse Vaerktoejskasse { get; set; }
    }
}
