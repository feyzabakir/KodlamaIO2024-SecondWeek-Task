using DataAccess.Abstracts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CategoryDal : ICategoryDal
    {
        private readonly List<Category> _categories;

        public CategoryDal()
        {
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "C#" },
                new Category { Id = 2, Name = "Python" }
            };
        }


        public async Task AddAsync(Category entity)
        {
            entity.Id = _categories.Any() ? _categories.Max(x => x.Id) + 1 : 1;
            _categories.Add(entity);
            await Task.CompletedTask;
        }

        public IQueryable<Category> GetAll()
        {
            return _categories.AsQueryable();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await Task.FromResult(_categories.FirstOrDefault(x => x.Id == id));
        }

        public void Remove(Category entity)
        {
           _categories.Remove(entity);
        }

        public void Update(Category entity)
        {
            var updateCategory = _categories.FirstOrDefault(x => x.Id == entity.Id);
            if (updateCategory != null)
            {
                updateCategory.Name = entity.Name;
            }
        }
    }
}
