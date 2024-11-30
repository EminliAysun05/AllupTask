using Academy.Domain.Entities;
using Core.Persistence.Repositories;

namespace Academy.Persistence.Repositories.Abstraction;

public interface IStudentRepository : IRepositoryAsync<Student>
{
}
