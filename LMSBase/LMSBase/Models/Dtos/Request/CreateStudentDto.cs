using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
    public class CreateStudentDto
    {
        [Required]
        public string? UserName { get; set; } = "";
		[Required]
		[EmailAddress]
		public string? Email { get; set; } = "";
		[Required]
		[PasswordPropertyText]
		public string? Password { get; set; } = "";
		[Required]
		[PasswordPropertyText]
		public string? RepeatPassword { get; set; } = "";
    }
}
