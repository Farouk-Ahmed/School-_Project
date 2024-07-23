using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entityes.Identity;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure
{
	public static class ServiceRegisteration
	{
		public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
		{


			services.AddIdentity<User, IdentityRole>(options =>
			{
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedEmail = true;
			})
				.AddRoles<IdentityRole<int>>() // Add support for roles.
				.AddEntityFrameworkStores<AppDBContext>() // Configure Entity Framework stores.
				.AddTokenProvider<EmailTokenProvider<User>>(TokenOptions.DefaultEmailProvider);         // Add default token providers.

			return services;
		}
	}
}
