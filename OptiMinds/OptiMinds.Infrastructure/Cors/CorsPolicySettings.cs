namespace OptiMinds.Infrastructure.Cors
{
	public class CorsPolicySettings
	{
		public const string SectionName = "CorsPolicySettings";
		public string AllowOrigns { get; set; }
		public string AllowHeaders { get; set; }
		public string AllowMethods { get; set; }

	}
}
