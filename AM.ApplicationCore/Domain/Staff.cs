using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {

        public string Function { get; set; }
        public DateTime EmployementDate { get; set; }
        // [Required (ErrorMessage =("doit eter une valeur monetaire"))]
        [DataType (DataType.Currency)]
        public double Salary { get; set; }
        public override void PassengerType()
        {
            base.PassengerType(); // => I'am Passenger 
            Console.WriteLine(  "I'am Staff");
        }
    }
}
