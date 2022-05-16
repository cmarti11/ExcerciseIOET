using System;
using System.Collections.Generic;
using System.Linq;
using ExcerciseIOET.Model;

namespace ExcerciseIOET.Helper
{
	public class ScheduleComparerHelper
	{
		public ScheduleComparerHelper()
		{
		}

        public List<Tuple<EmployeeSchedule, EmployeeSchedule>> checkedEmployees = new List<Tuple<EmployeeSchedule, EmployeeSchedule>>();

        public List<string> CompareSchedules (List<EmployeeSchedule> employees)
        {
			if(employees != null)
            {
				var result = new List<string>();
				if (employees.Count < 2) return new List<string>();
				foreach (var employee in employees)
                {
                    var restOfEmployees = employees.Where(x => x != employee).ToList();
                    var compared = CompareEmployeeWithEmployees(employee, restOfEmployees);
					if (compared != null)
					result.AddRange(compared);
                }
                if (result.Count > 0) return result;
            }
			return new List<string>();
        }

        private List<string> CompareEmployeeWithEmployees(EmployeeSchedule employee, List<EmployeeSchedule> employees)
        {
            var result = new List<string>();
            foreach (var selected in employees)
            {
                if (TupleIsChecked(employee, selected, checkedEmployees)) continue;
				result.Add(CompareEmployeeWithEmployee(employee, selected));
                checkedEmployees.Add(new Tuple<EmployeeSchedule, EmployeeSchedule>(employee, selected));
            }
            return result;
        }

        private bool TupleIsChecked(EmployeeSchedule employee, EmployeeSchedule selected, List<Tuple<EmployeeSchedule, EmployeeSchedule>> checkedEmployees)
        {
            return checkedEmployees.Any(x => x.Item1 == employee && x.Item2 == selected) || (checkedEmployees.Any(x => x.Item1 == selected && x.Item2 == employee));
        }

        private string CompareEmployeeWithEmployee(EmployeeSchedule employee, EmployeeSchedule selected)
        {
            int coincidenceCount = 0;
            foreach (var day in employee.Schedule)
            {
                var match = selected.Schedule.FirstOrDefault(x => x.DayName == day.DayName);
                if (match != null)
                {
                    if (CompareEmployeeHours(day.StartHour, day.EndHour, match.StartHour, match.EndHour))
                    {
                        coincidenceCount++;
                    }
                }
            }
            if (coincidenceCount > 0)
            {
                return String.Format(@"{0}-{1}: {2}", employee.EmployeName, selected.EmployeName, coincidenceCount.ToString());
            }
            return null;
        }

        private bool CompareEmployeeHours(TimeSpan startHour1, TimeSpan endHour1, TimeSpan startHour2, TimeSpan endHour2)
        {
            if (startHour1 == startHour2) return true;
            if (startHour1 > startHour2 && startHour1 < endHour2) return true;
            if (startHour2 > startHour1 && startHour2 < endHour1) return true;
            return false;
        }
    }
}

