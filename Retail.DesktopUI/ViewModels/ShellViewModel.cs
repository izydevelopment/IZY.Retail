using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Retail.DesktopUI.EventModels;

namespace Retail.DesktopUI.ViewModels
{
	public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
	{
		private IEventAggregator _events;
		private SalesViewModel _salesVM;
		private SimpleContainer _container;

		public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, SimpleContainer container)
		{
			this._events = events;
			this._salesVM = salesVM;
			this._container = container;

			this._events.Subscribe(this);

			ActivateItem(_container.GetInstance<LoginViewModel>());
		}

		public void Handle(LogOnEvent message)
		{
			ActivateItem(this._salesVM);
		}
	}
}
