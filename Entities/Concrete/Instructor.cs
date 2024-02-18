using Entities.Abstacts;


namespace Entities.Concrete
{
    public class Instructor : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Course> Courses { get; set; } // Bire - çok ilişki
    }
}
