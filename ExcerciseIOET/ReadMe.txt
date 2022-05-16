#####  Exercise

The company ACME offers their employees the flexibility to work the hours they want. But due to some external circumstances they need to know what employees have been at the office within the same time frame

The goal of this exercise is to output a table containing pairs of employees and how often they have coincided in the office.

Input: the name of an employee and the schedule they worked, indicating the time and hours. This should be a .txt file with at least five sets of data. You can include the data from our examples below:

Example 1:

INPUT
RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00- 21:00
ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00
ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00

OUTPUT:
ASTRID-RENE: 2
ASTRID-ANDRES: 3
RENE-ANDRES: 2

Example 2:

INPUT:
RENE=MO10:15-12:00,TU10:00-12:00,TH13:00-13:15,SA14:00-18:00,SU20:00-21:00
ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00

OUTPUT:
RENE-ASTRID: 3



##### Architecture

The structure of the project consists of the following:

-Program.cs: Project startup file

-(Folder) Executable: Contains the executable file to test the application outside of VS.
    ExerciseIOET.exe: Executable file mentioned.

-(Folder) Helper: Contains the helper classes of the project logic.
    FileReaderHelper.cs: Contains the function to read text files
    ScheduleComparerHelper: Receives a list of employees, compares if there are matches between schedules and returns a list of strings with the matches.

-(Folder) Mapper: Contains the classes to map values
    FileToEmployeeScheduleMapper.cs: Receives the reading of the txt file and returns a list of employees with their schedules per day with start and end times.

-(Folder) Model: Contains the model classes of the application.
   Constants.cs: Defines the constants in the project (In our case it contains the paths for reading files for Debug and Release mode)
   EmployeeSchedule: It is the most important entity of the project, it defines an employee by his name and contains his list of work days with start and end times.

-(Folder) TxtFiles: Contains the text files to process.



##### Methodology

The methodology for solving the exercise was as follows:

1) A project structure was created that allows it to be expanded to more functions while maintaining the order and uniqueness of functions by method.
2) The System.IO.File library was used to read the txt file and convert it into independent lines.
3) To convert the lines of text in the EmployeeSchedule entity, a series of String methods were used (such as IndexOf, Split and Substring) to extract the different items such as the employee's name, the day of work and their corresponding start/end time.
4) To compare an employee with all the others, a list of checked employees was created. So, before comparing two new employees, check if they are already on the mentioned list.
5) A counter was created that increases every time a schedule crosses another between employees.
6) With the pairs of employees grouped together and the number of times they crossed paths during the week, the response is returned in text form to the console.
7) Executable generated with the command dotnet publish -r win10-x64 -o Executable -p:PublishSingleFile=true -p:PublishTrimmed=true -c Release



##### Instructions to execute

-Go to ExerciseIOET/Executable
-Open a cmd (Suggestion: Write cmd in the path to open a cmd instance in the folfer ExerciseIOET/Executable)
-Run the followin instruction in cmd "ExcerciseIOET"
-Write the name of the file you want to be read (Don't forget to add the extension .txt) [Input1.txt and Input2.txt are the available examples)
-If you want to test with a different text file, you have two options:
   1) Edit the content of one of the existing text files (Input1.txt or Input2.txt)
   2) Create a new file in the TxtFiles folder with the new content, run the command again and write the name of the new file