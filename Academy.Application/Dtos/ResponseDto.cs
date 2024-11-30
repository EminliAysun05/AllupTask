using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Dtos
{
    public class ResponseDto<T>
    {
        public string? Message {  get; set; }
        public bool IsSucceed { get; set; } = true;
        public T? Data { get; set; }
    }
}
