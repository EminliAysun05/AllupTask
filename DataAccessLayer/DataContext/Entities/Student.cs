using Core.Persistence.Repositories;

namespace DataAccessLayer.DataContext.Entities;

public class Student : Entity
{
    public required string Name {  get; set; }
    public int Age { get; set; }
}
