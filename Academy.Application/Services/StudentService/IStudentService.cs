using Academy.Application.Dtos;
using Academy.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Academy.Application.Services.StudentService;

public interface IStudentService
{
    Task<ResponseDto<StudentDto?>> GetAsync(int id);

    Task<ResponseDto<StudentDto?>> GetAsync(Expression<Func<Student, bool>> predicate, Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null);

    Task<ResponseDto<StudentListDto>> GetListAsync(Expression<Func<Student, bool>>? predicate = null,
                                    Func<IQueryable<Student>, IOrderedQueryable<Student>>? orderBy = null,
                                    Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null,
                                    int index = 0, int size = 10, bool enableTracking = true);

    Task<ResponseDto<StudentDto>> AddAsync(StudentCreateDto createDto);
    Task<ResponseDto<StudentDto>> UpdateAsync(int id, StudentUpdateDto updateDto);
    Task<ResponseDto<StudentDto>> DeleteAsync(int id);
}
