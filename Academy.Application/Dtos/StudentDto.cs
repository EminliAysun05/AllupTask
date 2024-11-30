using Academy.Domain.Enums;
using Core.Persistence.Paging;

namespace Academy.Application.Dtos;

public class StudentDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age {  get; set; }
    public StudentStatusType StatusType { get; set; }
}

public class StudentCreateDto : IDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
    public StudentStatusType StatusType { get; set; }
}

public class StudentUpdateDto : IDto
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public StudentStatusType StatusType { get; set; }
}

public class StudentListDto : BasePageableDto, IDto
{
    public List<StudentDto> Items { get; set; } = [];
}



