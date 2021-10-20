using System;
using System.Collections.Generic;
using app.Models;

namespace app.Services.Implementations
{
    public class PersonService : IPersonService
    {
        
        public Person Create(Person person)
        {
            return person;
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (var i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return MockPerson(id);
        }

        public Person Update(long id, Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }
        
        private static Person MockPerson(long i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Wesley",
                LastName = "Oliveira",
                Address = "Novo Gama - Goias - Brasil",
                Gender = "Male"
            };
        }
    }
}