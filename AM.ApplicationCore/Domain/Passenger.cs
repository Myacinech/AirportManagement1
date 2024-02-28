using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {

        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        public FullName fullName { get; set; }

        [DataType (DataType.Date)]
        [Display (Name = "Date of birth") ]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"\d(8)$")]
        public int? TelNumber { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }

        public  IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "FirstName: " + fullName.FirstName + " LastName: " + fullName.LastName + " date of Birth: " + BirthDate;
        }

        //poly par signature :
       
       public bool CheckProfile(string nom , string prenom)
        {

         return fullName.FirstName.Equals(nom) && fullName.LastName.Equals(prenom);

        }

        public bool CheckProfile (string nom , string prenom ,string email)
        {
            // return FirstName.Equals(nom) && LastName.Equals(prenom) && EmailAddress.Equals(email);
            return CheckProfile(nom, prenom) && EmailAddress.Equals(email);
        }

        public bool Login(string nom , string prenom , string email = null)
        {
            //if (email != null)
            //    return CheckProfile(nom, prenom, email);
            //return CheckProfile(nom, prenom);


            return (email != null) ? CheckProfile(nom, prenom, email) : CheckProfile(nom, prenom);


        }

        //poly par héritage 

        public virtual void PassengerType()
        {
            //cwl + 2 tab
            Console.WriteLine("I'am Passenger"  );
        }



       
    }
}
