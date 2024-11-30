using Academy.Application.Dtos;
using Academy.Domain.Entities;
using Academy.Domain.Enums;
using Academy.Persistence.Repositories.Abstraction;
using AutoMapper;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Academy.Application.Services.StudentService;

public class StudentManager : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentManager(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<StudentDto>> AddAsync(StudentCreateDto createDto)
    {
        var studentEntity = _mapper.Map<Student>(createDto);
        var createdStudent = await _studentRepository.AddAsync(studentEntity);

        var response = new ResponseDto<StudentDto>()
        {
            Data = _mapper.Map<StudentDto>(createdStudent)
        };

        return response;
    }

    public async Task<ResponseDto<StudentDto>> DeleteAsync(int id)
    {
        var existStudent = await _studentRepository.GetAsync(id);

        if (existStudent == null)
            return new ResponseDto<StudentDto>
            {
                IsSucceed = false,
                Message = "not found"
            };

        var deletedStudent = await _studentRepository.DeleteAsync(existStudent);

        var response = new ResponseDto<StudentDto>()
        {
            Data = _mapper.Map<StudentDto>(deletedStudent)
        };

        return response;
    }

    public async Task<ResponseDto<StudentDto?>> GetAsync(int id)
    {
        //throw new Exception("jhbnd");
        var studentEntity = await _studentRepository.GetAsync(id);

        if (studentEntity == null) return new ResponseDto<StudentDto?>
        {
            IsSucceed = false,
            Message = $"{id}-li student tapilmadi"
        };

        var response = new ResponseDto<StudentDto?>()
        {
            Data = _mapper.Map<StudentDto?>(studentEntity)
        };

        return response;
    }

    public async Task<ResponseDto<StudentDto?>> GetAsync(Expression<Func<Student, bool>> predicate, Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null)
    {
        var studentEntity = await _studentRepository.GetAsync(predicate, include);

        if (studentEntity == null) return new ResponseDto<StudentDto?>
        {
            IsSucceed = false,
            Message = "not found"
        };

        var response = new ResponseDto<StudentDto?>()
        {
            Data = _mapper.Map<StudentDto>(studentEntity)
        };

        return response;
    }

    public async Task<ResponseDto<StudentListDto>> GetListAsync(Expression<Func<Student, bool>>? predicate = null, Func<IQueryable<Student>, IOrderedQueryable<Student>>? orderBy = null, Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
    {
        var studentListEntity = await _studentRepository.GetListAsync(predicate, orderBy, include, index, size, enableTracking);

        if (studentListEntity == null) return new ResponseDto<StudentListDto>
        {
            IsSucceed = false,
            Message = "not found"
        };

        var response = new ResponseDto<StudentListDto>()
        {
            Data = _mapper.Map<StudentListDto>(studentListEntity)
        };

        return response;
    }

    public async Task<ResponseDto<StudentDto>> UpdateAsync(int id, StudentUpdateDto updateDto)
    {
        var existStudent = await _studentRepository.GetAsync(id);

        if (existStudent == null) return new ResponseDto<StudentDto>
        {
            IsSucceed = false,
            Message = "not found"
        };

        existStudent = _mapper.Map(updateDto, existStudent);

        var updatedStudent = await _studentRepository.UpdateAsync(existStudent);

        var response = new ResponseDto<StudentDto>()
        {
            Data = _mapper.Map<StudentDto>(updatedStudent)
        };

        return response;
    }
}
