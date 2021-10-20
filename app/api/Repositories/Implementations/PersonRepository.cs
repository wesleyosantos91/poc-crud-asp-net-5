﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using app.Models;
using app.Models.Contexts;
using Microsoft.AspNetCore.Http;

namespace app.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {

        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(long id, Person person)
        {
            if (!Exists(id)) throw new BadHttpRequestException($"id not found: {id}");

            var result = FindById(id);

            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            
            return person;
        }

        public void Delete(long id)
        {
            var result = FindById(id);
            if (result !=null)
            {
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}