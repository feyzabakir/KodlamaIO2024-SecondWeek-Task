using DataAccess.Abstracts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class InstructorDal : IInstructorDal
    {
        private readonly List<Instructor> _instructors;

        public InstructorDal()
        {
            _instructors = new List<Instructor>
            {
                new Instructor { Id = 1, FullName = "Feyza Nur Bakır", Email = "feyza@gmail.com", ImageUrl = "image1.jpg" },
                new Instructor { Id = 2, FullName = "Engin Demiroğ", Email = "engin@gmail.com", ImageUrl = "image2.jpg" }
            };
        }
        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await Task.FromResult(_instructors.FirstOrDefault(x => x.Id == id));
        }

        public IQueryable<Instructor> GetAll()
        {
            return _instructors.AsQueryable();
        }

        public async Task AddAsync(Instructor entity)
        {
            entity.Id = _instructors.Any() ? _instructors.Max(x => x.Id) + 1 : 1;
            _instructors.Add(entity);
            await Task.CompletedTask;
        }

        public void Update(Instructor entity)
        {
            var updateInstructor = _instructors.FirstOrDefault(x => x.Id == entity.Id);
            if (updateInstructor != null)
            {
                updateInstructor.FullName = entity.FullName;
                updateInstructor.Email = entity.Email;
                updateInstructor.ImageUrl = entity.ImageUrl;
            }
        }

        public void Remove(Instructor entity)
        {
            _instructors.Remove(entity);
        }
    }
}
