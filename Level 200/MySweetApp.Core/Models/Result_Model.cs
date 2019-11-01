using MySweetApp.Core.Contracts;
using MySweetApp.Core.Enums;
using System.Collections.Generic;

namespace MySweetApp.Core.Models
{
    public class Result_Model : IResult
    {
        public Result_Model()
        {
            ResultType =  ResultTypes.Ok;
            Payload = new List<object>();
        }

        public ResultTypes ResultType { get; set; }

        public List<object> Payload { get; }
    }
}