namespace LMSBase.Models.Domain
{
	public class Codelab
	{
		public int CodelabId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int LearningModuleId { get; set; }
		public LearningModule LearningModule { get; set; }
		public List<StudentCodelab> StudentCodelabs { get; set; }
	}
}
