namespace SchoolProject.Core.Features.AppUser.Queries.Responce
{
	public class GetUserByIdResponse
	{
		public string FullName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }
		public string PhoneNumber { get; set; }
	}
}
