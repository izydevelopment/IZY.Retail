﻿using System;

namespace Retail.DesktopUI.Library.Models
{
	public interface ILoggedInUserModel
	{
		DateTime CreatedDate { get; set; }
		string Email { get; set; }
		string FirstName { get; set; }
		string Id { get; set; }
		string LastName { get; set; }
		string Token { get; set; }
	}
}