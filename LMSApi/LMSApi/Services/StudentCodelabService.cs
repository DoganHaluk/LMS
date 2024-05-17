using LMSApi.Configuration;
using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Services
{
	public class StudentCodelabService
	{
		private readonly LMSDbContext _context;

		public StudentCodelabService(LMSDbContext context)
		{
			_context = context;
		}


		public StudentCodelab GetStudentCodelab(int id)
		{
			return _context.StudentCodeLabs.Where(s=>s.StudentCodelabId==id).Include(s=>s.Status).FirstOrDefault();
		}

		public StudentCodelab GetStudentCodelabWithDoneStatus(int studentId,int codelabId)
		{
			return _context.StudentCodeLabs.Where(s => s.UserId == studentId).Where(s => s.CodelabId == codelabId).Where(s => s.StatusId == 7).FirstOrDefault();
		}

		public StudentCodelab CreateStudentCodelab(StudentCodelab studentCodelab)
		{
			_context.StudentCodeLabs.Add(studentCodelab);
			_context.SaveChanges();
			return studentCodelab;
		}

		public StudentCodelab UpdateStatus(StudentCodelab studentCodelab)
		{
			var updated = _context.StudentCodeLabs.Find(studentCodelab.StudentCodelabId);
			updated.StatusId = studentCodelab.StatusId;
			_context.SaveChanges();
			return updated;
		}

		public StudentCodelab UpdateComment(StudentCodelab studentCodelab)
		{
			var updated = _context.StudentCodeLabs.Find(studentCodelab.StudentCodelabId);
			updated.Comment = studentCodelab.Comment;
			_context.SaveChanges();
			return updated;
		}


	}
}
