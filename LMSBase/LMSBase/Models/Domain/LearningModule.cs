namespace LMSBase.Models.Domain
{
	public class LearningModule
	{
		public int LearningModuleId { get; set; }
		public string ModuleName { get; set; }
		public int? ParentId {  get; set; }
		public List<LearningModule> SubModules { get; set; }
		public LearningModule Parent { get; set; }
		public List<Codelab> Codelabs { get; set; }
		public int? StatusId { get; set; }
		public Status Status { get; set; }
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
