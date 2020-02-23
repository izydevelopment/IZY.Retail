using Retail.Api.Library.Internal.DataAccess;
using Retail.Api.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Api.Library.DataAccess
{
	public class UserData
	{
		public List<UserModel> GetUserById(string id)
		{
			SqlDataAccess sql = new SqlDataAccess();

			var p = new { Id = id };

			var result = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "Retail.Database");

			return result;
		}
	}
}
