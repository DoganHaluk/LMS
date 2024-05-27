﻿using System;
using System.Collections.Generic;
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
		public string? Email { get; set; } = "";
		[Required]
		public string? Password { get; set; } = "";
		[Required]
		public string? RepeatPassword { get; set; } = "";
    }
}
