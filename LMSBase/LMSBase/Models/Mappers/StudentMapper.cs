using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Mappers
{
	public class StudentMapper
	{
		public static StudentDto ToDto(Student student)
		{
			StudentDto dto = new StudentDto()
			{
				StudentId = student.UserId,
				StudentName = student.UserName,
			};
			return dto;
		}
	}
}
