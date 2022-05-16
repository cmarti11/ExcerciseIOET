using System;
using System.Collections.Generic;
using ExcerciseIOET.Model;

namespace ExcerciseIOET.Mapper
{
	public class FileToEmployeeScheduleMapper
	{
		public FileToEmployeeScheduleMapper()
		{
		}

		public List<EmployeeSchedule> MapEmployeeSchedules (IEnumerable<string> lines)
        {
			if (lines != null)
            {
				var result = new List<EmployeeSchedule>();
				foreach (var line in lines)
				{
					int position = line.IndexOf("=");
					if (position < 0)
						continue;
					EmployeeSchedule item = new EmployeeSchedule();
					item.EmployeName = line.Substring(0, position);
					item.Schedule = MapSchedules(line.Substring(position + 1));
					result.Add(item);
				}
				if (result.Count > 0) return result;
			}
			
			return new List<EmployeeSchedule>();
        }

        private List<DaySchedule> MapSchedules(string line)
        {
			if (!string.IsNullOrEmpty(line))
            {
				var list = new List<DaySchedule>();
				var commaSeparated = line.Split(",");
				foreach(var item in commaSeparated)
                {
					list.Add(MapDay(item));
                }
				if(list.Count > 0) return list;
			}
			return new List<DaySchedule>();
		}

        private DaySchedule MapDay(string item)
        {
			if (!string.IsNullOrEmpty(item))
			{
				return MapHoursRange(item.Substring(0, 2), item.Substring(2));
			}
			return new DaySchedule();
		}

        private DaySchedule MapHoursRange(string dayName, string value)
        {
			if (!string.IsNullOrEmpty(value))
			{

				var result = new DaySchedule();
				int position = value.IndexOf("-");
				if (position < 0)
					return new DaySchedule();
				result.DayName = dayName;
				result.StartHour = MapHoursMinutes(value.Substring(0, position));
				result.EndHour = MapHoursMinutes(value.Substring(position + 1));
				return result;
			}
			return new DaySchedule();
		}

		private TimeSpan MapHoursMinutes (string range)
        {
			int separator = range.IndexOf(":");
			var hour = Convert.ToInt32(range.Substring(0, separator));
			var minute = Convert.ToInt32(range.Substring(separator + 1));
			return new TimeSpan(hour, minute, 0);

		}
    }
}

