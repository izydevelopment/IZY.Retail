using System.Collections.Generic;

namespace Retail.DesktopUI
{
	public interface ICalculations
	{
		List<string> Register { get; set; }

		double Add(double x, double y);
	}
}