using Retail.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DesktopUI.Library.Api
{
	public class ApiHelper : IApiHelper
	{
		private HttpClient apiClient { get; set; }
		private ILoggedInUserModel _loggedInUser;

		public ApiHelper(ILoggedInUserModel loggedInUser)
		{
			InitializeClient();
			this._loggedInUser = loggedInUser;
		}

		private void InitializeClient()
		{
			string api = ConfigurationManager.AppSettings["api"];

			this.apiClient = new HttpClient();
			this.apiClient.BaseAddress = new Uri(api);
			this.apiClient.DefaultRequestHeaders.Accept.Clear();
			this.apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<AuthenticatedUser> Authenticate(string userName, string password)
		{
			var data = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("grant_type", "password"),
				new KeyValuePair<string, string>("userName", userName),
				new KeyValuePair<string, string>("password", password),
			});

			using (HttpResponseMessage response = await apiClient.PostAsync("/Token", data))
			{
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
					return result;
				}
				else
				{
					throw new Exception(response.ReasonPhrase);
				}
			}
		}

		public async Task GetLoggedInUserInfo(string token)
		{
			this.apiClient.DefaultRequestHeaders.Clear();
			this.apiClient.DefaultRequestHeaders.Accept.Clear();
			this.apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			this.apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

			using (HttpResponseMessage response = await apiClient.GetAsync("Api/User"))
			{
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
					this._loggedInUser.Token = result.Token;
					this._loggedInUser.Id = result.Id;
					this._loggedInUser.FirstName = result.FirstName;
					this._loggedInUser.LastName = result.LastName;
					this._loggedInUser.Email = result.Email;
					this._loggedInUser.CreatedDate = result.CreatedDate;
				}
				else
				{
					throw new Exception(response.ReasonPhrase);
				}
			}
		}
	}
}
