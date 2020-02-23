using Retail.DesktopUI.Library.Models;
using System.Threading.Tasks;

namespace Retail.DesktopUI.Library.Api
{
	public interface IApiHelper
	{
		Task<AuthenticatedUser> Authenticate(string userName, string password);
		Task GetLoggedInUserInfo(string token);
	}
}