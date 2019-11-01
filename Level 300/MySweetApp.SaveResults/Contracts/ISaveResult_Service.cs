using MySweetApp.Core.Contracts;
using MySweetApp.Core.Enums;

namespace MySweetApp.SaveResults.Contracts
{
    public interface ISaveResult_Service
    {
        ResultTypes SaveAsJSON(IResult result);
    }
}