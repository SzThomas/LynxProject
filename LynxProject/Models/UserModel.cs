using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LynxProject.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a username")]
        public string Username { get; set; }
        
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        
        [Display(Name = "Email")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email address")]
        public string Email { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])[a-zA-Z0-9](.{6,12})$", ErrorMessage = "Error, Wrong Password Format")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Invalid Phone Number")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public List<SelectListItem> UserList { get; set; }
    }
}