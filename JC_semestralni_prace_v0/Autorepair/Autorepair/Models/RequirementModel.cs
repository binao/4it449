using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autorepair.Models
{
    public class RequirementModel
    {
        [Display(Name = "Jméno")]
        [Required(ErrorMessage = "{0} je povinné")]
        [MaxLength(40, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string FirstName { get; set; }

        [Display(Name = "Přijmení")]
        [Required(ErrorMessage = "{0}  je povinné")]
        [MaxLength(40, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0}  je povinný")]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string Email { get; set; }

        [Display(Name = "Značka vozidla")]
        public string Brand { get; set; }

        [Display(Name = "Rok výroby")]
        public Nullable<int> YearOfMade { get; set; }

        [Display(Name = "Objem motoru")]
        public Nullable<double> EngineCapacity { get; set; }

        [Display(Name = "Typ motoru")]
        public string TypeOfEngine { get; set; }

        [Display(Name = "Popis problému")]
        [Required(ErrorMessage = "{0}  je povinný")]
        public string DescriptionOfProblem { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "ID")]
        public int ID { get; set; }


    }
}