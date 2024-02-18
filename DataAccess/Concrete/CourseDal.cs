using DataAccess.Abstracts;
using Entities.Concrete;


namespace DataAccess.Concrete
{
    public class CourseDal : ICourseDal
    {
        private readonly List<Course> _courses;

        public CourseDal()
        {
            _courses = new List<Course>
            {
                new Course { Id = 1, Title = "Yazılım Geliştirici Yetiştirme Kampı (C# + ANGULAR)", Description = "C# Başlangıç Seviye", Price = 200, CompletionRate = 90, CategoryId = 1, InstructorId = 1 },
                new Course { Id = 2, Title = "Senior Yazılım Geliştirici Yetiştirme Kampı (.NET)", Description = "C# İleri Seviye", Price = 100, CompletionRate = 85, CategoryId = 2, InstructorId = 2 }
            };
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await Task.FromResult(_courses.FirstOrDefault(x => x.Id == id));
        }

        public IQueryable<Course> GetAll()
        {
            return _courses.AsQueryable();
        }

        public async Task AddAsync(Course entity)
        {
            entity.Id = _courses.Any() ? _courses.Max(x => x.Id) + 1 : 1;
            _courses.Add(entity);
            await Task.CompletedTask;
        }

        public void Update(Course entity)
        {
            var updateCourse = _courses.FirstOrDefault(x => x.Id == entity.Id);
            if (updateCourse != null)
            {
                updateCourse.Title = entity.Title;
                updateCourse.Description = entity.Description;
                updateCourse.Price = entity.Price;
                updateCourse.CompletionRate = entity.CompletionRate;
                updateCourse.CategoryId = entity.CategoryId;
                updateCourse.InstructorId = entity.InstructorId;
            }
        }

        public void Remove(Course entity)
        {
            _courses.Remove(entity);
        }
    }
}
