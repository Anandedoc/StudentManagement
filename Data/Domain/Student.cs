namespace Data.Domain
{
    public class Student
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }
        public string Grade { get; set; }
    }
}
