using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Retail.Api.Library.DataAccess;
using Retail.Api.Library.Models;

namespace Retail.Api.Controllers
{
	[Authorize]
    public class UserController : ApiController
    {
		[HttpGet]
		public UserModel GetById()
		{
			string userId = RequestContext.Principal.Identity.GetUserId();
			UserData data = new UserData();

			return data.GetUserById(userId).First();
		}
        
    }
}
