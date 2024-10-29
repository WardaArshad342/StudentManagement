namespace DomainModels
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
