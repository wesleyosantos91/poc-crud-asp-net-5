using System.Collections.Generic;
using app.Models;

namespace app.Repositories
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        Person Update(long id, Person person);
        void Delete(long id);
        bool Exists(long id);
    }
}
