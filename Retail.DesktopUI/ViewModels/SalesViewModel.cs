using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DesktopUI.ViewModels
{
	public class SalesViewModel : Screen
	{
		private BindingList<string> _products;
		private int _itemQuantity;
		private BindingList<string> _cart;

		public BindingList<string> Products
		{
			get { return _products; }
			set
			{
				_products = value;
				NotifyOfPropertyChange(() => this.Products);
			}
		}

		public BindingList<string> Cart
		{
			get { return _cart; }
			set
			{
				_cart = value;
				NotifyOfPropertyChange(() => this.Cart);
			}
		}

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set
			{
				_itemQuantity = value;
				NotifyOfPropertyChange(() => this.ItemQuantity);
			}
		}

		public string SubTotal
		{
			get
			{
				// todo - replace with calculation
				return "0,00€";
			}
		}

		public string Tax
		{
			get
			{
				// todo - replace with calculation
				return "0,00€";
			}
		}

		public string Total
		{
			get
			{
				// todo - replace with calculation
				return "0,00€";
			}
		}

		public bool CanAddToCart
		{
			get
			{
				bool result = false;
				
				// do something here

				return result;
			}
		}

		public void AddToCart()
		{

		}

		public bool CanRemoveFromCart
		{
			get
			{
				bool result = false;

				// do something here

				return result;
			}
		}

		public void RemoveFromCart()
		{

		}

		public bool CanCheckOut
		{
			get
			{
				bool result = false;

				// do something here

				return result;
			}
		}

		public void CheckOut()
		{

		}
	}
}
