using Academy.Application.Dtos;

namespace Academy.Mvc.Consume.Models
{
    public class ResponseModel
    {
        public string? Message {  get; set; }
        public StudentDto Data {  get; set; }
        public bool IsSucceed {  get; set; }

        public override string ToString()
        {
            return $"{Message} {IsSucceed} {Data.Name}";
        }
    }
}
