namespace SchoolProject.Data.AppMetaData
{
	public static class Router
	{
		public const string root = "Api";
		public const string version = "V1";
		public const string Roul = root + "/" + version + "/";

		public static class StudentRouting
		{
			public const string prefix = Roul + "Student";
			public const string List = prefix + "/List";
			public const string GetById = prefix + "/{id}";
			public const string Create = prefix + "/Create";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
		}

	}
}
