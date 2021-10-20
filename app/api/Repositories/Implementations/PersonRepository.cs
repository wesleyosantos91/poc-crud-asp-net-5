using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;
using app.Models.Contexts;

namespace app.Repositories.Implementations
{
    public class PersonRepository : IRepository<Person>
    {
        
        private readonly ApplicationDbContext _dbContext;

        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> Create(Person _object)
        {
            var obj = await _dbContext.Persons.AddAsync(_object);  
            _dbContext.SaveChanges();  
            return obj.Entity;
        }

        public void Update(Person _object)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Person GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Person _object)
        {
            _dbContext.Remove(_object);  
            _dbContext.SaveChanges();  
        }
    }
}