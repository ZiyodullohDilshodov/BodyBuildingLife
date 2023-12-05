using BodyBuildingLife.Domain.Entities.Persons;

namespace BodyBuildingLife.Data.IRepositories;

public  interface IPersonRepository : IRepository<Person>
{
    public Task<Person>AddProteinInPerson(Person person);
}
