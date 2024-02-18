using Entities.Abstacts;

namespace Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Course> Courses { get; set; }  // Bire-çok ilişki
    }
}
