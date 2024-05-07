namespace LMSBase.Models.Domain
{
	public class StudentCodelab
	{
		public int StudentCodelabId { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int CodelabId { get; set; }
		public Codelab Codelab { get; set; }
		public string Comment { get; set; }
		public int StatusId { get; set; }
		public Status Status { get; set; }
	}
}
