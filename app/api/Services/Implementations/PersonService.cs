using System.Collections.Generic;
using app.Generic;
using app.Models;

namespace app.Services.Implementations
{
    public class PersonService : IPersonService
    {

        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(long id, Person person)
        {
            
            return _repository.Update(id, person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}