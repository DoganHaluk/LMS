﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
    public class CoachSummaryDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Role { get; set; } = "Coach";

        public List<CoachSchoolClassDto> CoachSchoolClasses { get; set; }
    }
}
