using Academy.Domain.Enums;
using Core.Persistence.Repositories;

namespace Academy.Domain.Entities;

public class Student : Entity
{
    public required string Name {  get; set; }
    public int Age {  get; set; }
    public StudentStatusType StatusType { get; set; }
}
