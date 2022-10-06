namespace laborator19_Catalog_.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Rank Rank { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
    public enum Rank
    {
        Instructor,
        Assistant_Professor,
        Associate_Professor,
        Professor,
    }
}