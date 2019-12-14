using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkBase
{
	public enum Table
	{
		device = 0,
		user = 1,
		department = 2,
		deviceNateworks = 3,
		network = 4,
	}

	public enum Role
	{
		admin,
		editor

	}

	enum NoteNumb
	{
		all = 0,
		five = 5,
		ten = 10,
		fifty = 50,
		onehundred = 100
	}
}
