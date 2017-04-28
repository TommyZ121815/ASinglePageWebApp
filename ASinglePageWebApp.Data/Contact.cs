using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ASinglePageWebApp.Model
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(50), Required]
        public string FirstName { get; set; }
        [StringLength(50), Required]
        public string LastName { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }




        [Required]
        [Display(Name = "Home Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public int PhoneNum { get; set; }
        public bool Status { get; set; }
    }
}
