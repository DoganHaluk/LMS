using LMSApi.Configuration;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Response;
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


		public List<StudentCodelab> GetStudentCodelabs(int id)
		{
			return _context.StudentCodeLabs.Where(s=>s.UserId == id).Include(s=>s.Status).ToList();
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

		public StudentCodelab UpdateStudentCodelab(StudentCodelabSummaryDto studentCodelab)
		{
			var updated = _context.StudentCodeLabs.Find(studentCodelab.StudentCodelabId);
			updated.StatusId = studentCodelab.Status.StatusId;
			updated.Comment = studentCodelab.Comment;
			_context.SaveChanges();
			return updated;
		}

	}
}
