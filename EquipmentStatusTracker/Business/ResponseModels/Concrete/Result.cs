using Business.ResponseModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ResponseModels.Concrete
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; } = string.Empty;
        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
    }
}
