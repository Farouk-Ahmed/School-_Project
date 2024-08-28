namespace SchoolProject.Data.AppMetaData
{
	public static class RouteApp
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
			public const string Paginated = prefix + "/Paginated";
		}
		public static class DepartmentRouting
		{
			public const string prefix = Roul + "Department";
			public const string GetById = prefix + "/Id";

		}
		public static class AppUserRouting
		{
			public const string prefix = Roul + "User";
			public const string Create = prefix + "/Create";
			public const string Paginated = prefix + "/Paginated";
			public const string GetById = prefix + "/{id}";
			public const string Edit = prefix + "/Edit";
			public const string Delete = prefix + "/{id}";
			public const string changpassword = prefix + "/ChangPassword";




		}
		public static class Authentication
		{
			public const string prefix = Roul + "Authentication";
			public const string signin = prefix + "/SginIn";
			public const string RefreshToken = prefix + "/Refresh-Token";
			public const string ValidateToken = prefix + "/Validate-Token";
		}

	}
}
