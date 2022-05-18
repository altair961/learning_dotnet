namespace Preparation.Problems
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }

        public Appointment(Guid id, DateTime datetime)
        {
            Id = id;
            DateTime = datetime;
        }
    }
}
