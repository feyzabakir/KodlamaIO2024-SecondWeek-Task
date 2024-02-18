using Entities.Abstacts;


namespace Entities.Concrete
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CompletionRate { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
