using System;
using ExcerciseIOET.Mapper;
using ExcerciseIOET.Helper;
using ExcerciseIOET.Model;

namespace ExcerciseIOET
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Write the name of the file that will be processed (Remember to add .txt at the end)");
                string fileName = (string)Console.ReadLine();
                ProcessFile(fileName);
                Console.WriteLine("Done; press any key");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format(@"Error: {0}", e.Message));
            }
        }

        private static void ProcessFile(string fileName)
        {
            FileToEmployeeScheduleMapper scheduleMapper = new FileToEmployeeScheduleMapper();
            FileReaderHelper fileReader = new FileReaderHelper();
            ScheduleComparerHelper scheduleComparerHelper = new ScheduleComparerHelper();
            var lines = fileReader.GetLines(fileName);
            var schedules = scheduleMapper.MapEmployeeSchedules(lines);
            var comparisons = scheduleComparerHelper.CompareSchedules(schedules);
            if (comparisons.Count > 0)
                comparisons.ForEach(n => Console.WriteLine(n));
        }
    }
}

