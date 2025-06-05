namespace TimesheetNameSpace
{
    public class TimesheetEntry
    {
        public int Id { get; set; }
        public int Employee { get; set; }
        public DateOnly Today { get; set; }
        public int Hours { get; set; }
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
