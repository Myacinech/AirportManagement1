using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain

{
    [Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "doit eter de long min 3")]
        [MaxLength(25, ErrorMessage = "doit etre de longeuer maximale de  25 char")]
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
