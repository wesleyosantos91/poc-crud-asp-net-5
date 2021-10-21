using System;
using System.Collections.Generic;
using System.Linq;
using app.Models.Base;
using app.Models.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace app.Generic
{
    public class GenericRepository <T> : IRepository<T> where T: BaseEntity
    {
        private readonly ApplicationDbContext _context;

        private DbSet<T> dataset;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public T Create(T item)
        {
            dataset.Add(item);
            _context.SaveChanges();
            return item;
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(long id, T item)
        {
            if (!Exists(id)) throw new BadHttpRequestException($"id not found: {id}");

            var result = FindById(id);

            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            
            return item;
        }

        public void Delete(long id)
        {
            var result = FindById(id);
            if (result !=null)
            {
                dataset.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}