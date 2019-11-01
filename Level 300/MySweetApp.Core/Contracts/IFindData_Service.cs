using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetApp.Core.Contracts
{
    public interface IFindData_Service
    {
        IResult GetEntities(dynamic obj);
    }
}
