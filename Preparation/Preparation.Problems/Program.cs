using System.Linq;

namespace Preparation.Problems 
{
    public class Program
    {
        static void Main(string[] args)
        {

            var guid1 = new Guid("58452F3A-A7E6-4DC4-BD2A-A6C8AC7CDF90");
            string name1 = "John";

            var guid2 = new Guid("E5CC9A2C-1C05-4E72-9C15-CEBECD5F3972");
            string name2 = "Clare";

            var guid3 = new Guid("B95681C9-A7EB-4C60-84A4-4B484A7F9E18");
            string name3 = "Peter";

            var teachers = new List<Teacher>();

            teachers.Add(new Teacher(guid1, name1));
            teachers.Add(new Teacher(guid2, name2));
            teachers.Add(new Teacher(guid3, name3));
            
            DateTime datetime1 = new DateTime(2012, 1, 1);
            DateTime datetime2 = new DateTime(2012, 1, 2);
            DateTime datetime3 = new DateTime(2012, 1, 4);
            
            var appointments = new List<Appointment>();

            appointments.Add(new Appointment(guid2, datetime1));
            appointments.Add(new Appointment(guid2, datetime2));
            appointments.Add(new Appointment(guid3, datetime3));

            List<Teacher> teachersWithoutLessons = new List<Teacher>();

            foreach (var teacher in teachers)
            {
                if (!appointments.Any(x => x.Id == teacher.Id))
                {
                    teachersWithoutLessons.Add(teacher);
                }
            }
        }
    }
}