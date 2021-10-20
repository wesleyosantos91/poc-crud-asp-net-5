using System.Collections.Generic;
using app.Models;

namespace app.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
    }
}
