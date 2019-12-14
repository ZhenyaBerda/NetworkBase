using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Globalization;

using System.Data.SqlClient;
using System.Data.Common;

namespace NetworkBase
{
	class Query
	{
		NetworkBaseEntities db = new NetworkBaseEntities();

		
		
		/*public IList SelectDevice(NoteNumb numb)
		{
			var devices = db.idDevices;

			var query =
			from device in devices
			select new
			{
				device.deviceID,
				device.Name
			};

			return query;

		}

		public List<T> ConvertQueryToList<T>(IQueryable<T> query)
		{
			return query.ToList();
		}*/

	}
}
