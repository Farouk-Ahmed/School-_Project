﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entityes.Identity
{
	public class UserRefreshToken
	{
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }
		public string? Token { get; set; }
		public string? RefreshToken { get; set; }
		public string? JWTId { get; set; }
		public bool IsUsed { get; set; }
		public bool IsRevoked { get; set; }
		public DateTime AddTime { get; set; }
		public DateTime ExpiryDate { get; set; }
		[ForeignKey(nameof(UserId))]
		[InverseProperty("UserRefreshTokens")]
		public virtual User User { get; set; }


	}
}
