using Business.Abstracts;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericService(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_genericDal.GetAll().ToList());
        }

        public async Task<T> AddAsync(T entity)
        {
            await _genericDal.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _genericDal.Update(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(T entity)
        {
            _genericDal.Remove(entity);
            await Task.CompletedTask;
        }

    }
}
