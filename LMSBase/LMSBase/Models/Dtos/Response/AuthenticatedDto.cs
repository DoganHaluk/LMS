using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
	public class AuthenticatedDto
	{
		public int? UserId { get; set; }

		public string? UserName {  get; set; }

		public string? Token { get; set; }

		public string? Role { get; set; }
	}
}
