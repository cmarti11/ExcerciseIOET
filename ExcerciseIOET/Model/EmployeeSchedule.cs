using System;
using System.Collections.Generic;

namespace ExcerciseIOET.Model
{
	public class EmployeeSchedule
	{

		public string EmployeName { get; set; }

		public List<DaySchedule> Schedule { get; set; }

	}

	public class DaySchedule
    {
		public string DayName { get; set; }
		public TimeSpan StartHour { get; set; }
		public TimeSpan EndHour { get; set; }
    }
}

