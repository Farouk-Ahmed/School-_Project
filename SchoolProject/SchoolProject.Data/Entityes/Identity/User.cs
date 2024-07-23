using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entityes.Identity
{
	public class User : IdentityUser<int>

	{
		public string Address { get; set; }
		public string Country { get; set; }
	}
}
