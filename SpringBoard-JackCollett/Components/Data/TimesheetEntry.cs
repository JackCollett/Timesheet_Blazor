

namespace TimesheetNameSpace
{
    public class TimesheetEntry(int Id, int employee, DateOnly date, int hours, int job_number)
    {
        public int id { get; set; } = Id;

        public int Employee { get; set; } = employee;
        public DateOnly Today { get; set; } = date;
        public int Hours { get; set; } = hours;
        public int Job { get; set; } = job_number;

    }
}