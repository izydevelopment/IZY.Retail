using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retail.DesktopUI.Library.Api;
using Retail.DesktopUI.EventModels;

namespace Retail.DesktopUI.ViewModels
{
	public class LoginViewModel : Screen
	{
		private string _userName;
		private string _password;
		private string _errorMessage;
		private IApiHelper _apiHelper;
		private IEventAggregator _events;

		public LoginViewModel(IApiHelper apiHelper, IEventAggregator events)
		{
			this._apiHelper = apiHelper;
			this._events = events;
		}

		public string UserName
		{
			get { return this._userName; }
			set
			{
				this._userName = value;
				NotifyOfPropertyChange(() => this.UserName);
				NotifyOfPropertyChange(() => this.CanLogIn);
			}
		}
		public string Password
		{
			get { return this._password; }
			set
			{
				this._password = value;
				NotifyOfPropertyChange(() => this.Password);
				NotifyOfPropertyChange(() => this.CanLogIn);
			}
		}
		public bool IsErrorVisible
		{
			get
			{
				var result = false;

				if(!String.IsNullOrWhiteSpace(this.ErrorMessage))
				{
					result = true;
				}

				return result;
			}

		}
		public string ErrorMessage
		{
			get { return this._errorMessage; }
			set
			{
				this._errorMessage = value;
				NotifyOfPropertyChange(() => this.IsErrorVisible);
				NotifyOfPropertyChange(() => this.ErrorMessage);
			}
		}
		public bool CanLogIn
		{
			get
			{
				bool result = false;
				if (this.UserName?.Length > 0 && this.Password?.Length > 0)
				{
					result = true;
				}

				return result;
			}
		}

		public async Task LogIn()
		{
			try
			{
				this.ErrorMessage = "";
				var result = await this._apiHelper.Authenticate(this.UserName, this.Password);

				await this._apiHelper.GetLoggedInUserInfo(result.Access_Token);

				this._events.PublishOnUIThread(new LogOnEvent());
			}
			catch (Exception ex)
			{
				this.ErrorMessage = ex.Message;
			}	
		}
	}
}
