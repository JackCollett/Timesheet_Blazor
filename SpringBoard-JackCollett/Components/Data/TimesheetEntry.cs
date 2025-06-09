using System.ComponentModel.DataAnnotations;

namespace TimesheetNameSpace
{
    public class TimesheetEntry
    {
        
        public int Id { get; set; }

        [Range(1, 300)]
        public int Employee { get; set; }

        [Range(Today.AddDays(-7), Today)]
        public DateOnly Today { get; set; }

        [Range(1, 8)]
        public int Hours { get; set; }

        [Range(1, 999)]
        public int Job { get; set; }

        // Parameterless constructor (required by EF Core)
        public TimesheetEntry() { }

        // Optional convenience constructor
        public TimesheetEntry(int employee, DateOnly date, int hours, int jobNumber)
        {
            Employee = employee;
            Today = date;
            Hours = hours;
            Job = jobNumber;
        }
    }
}
