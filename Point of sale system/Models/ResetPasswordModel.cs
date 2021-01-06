using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Point_of_sale_system.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage ="New Password Here",AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("newPassword", ErrorMessage ="Password Does not Match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ResetCode { get; set; }
    }
}