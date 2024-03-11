namespace JWT_P2.DTOs.Students
{
    public class StudentsGetDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Year { get; set; }
        public char Group { get; set; }
        public Guid SchoolId { get; set; }
    }
}
