﻿using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Services
{
	public class StudentCodelabEditor
	{
		private readonly StudentCodelabService _studentCodelabService;

		public StudentCodelabEditor(StudentCodelabService studentCodelabService)
		{
			_studentCodelabService = studentCodelabService;
		}


		public StudentCodelab GetStudentCodelab(int id)
		{
			return _studentCodelabService.GetStudentCodelab(id);
		}

		public StudentCodelab CreateStudentCodelab(StudentCodelab studentCodelab)
		{
			return _studentCodelabService.CreateStudentCodelab(studentCodelab);
		}

		public StudentCodelab UpdateStatus(StudentCodelab studentCodelab)
		{
			return _studentCodelabService.UpdateStatus(studentCodelab);
		}

		public StudentCodelab UpdateComment(StudentCodelab studentCodelab)
		{
			return _studentCodelabService.UpdateComment(studentCodelab);
		}


	}
}
