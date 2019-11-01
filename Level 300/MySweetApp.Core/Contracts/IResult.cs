using MySweetApp.Core.Enums;
using System.Collections.Generic;

namespace MySweetApp.Core.Contracts
{
    public interface IResult
    {
        ResultTypes ResultType { get; set; }
        List<object> Payload { get; }
    }
}