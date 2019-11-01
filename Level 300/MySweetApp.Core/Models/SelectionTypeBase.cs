using MySweetApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySweetApp.Core.Models
{
    public abstract class SelectionTypeBase : ISelectionType
    {
        public SelectionTypeBase(string name, IFindData_Service data_Service)
        {
            Name = name;
            FindData_Service = data_Service;
        }

        public IFindData_Service FindData_Service { get; }

        public string Name { get; }

        public abstract IResult Find();
    }
}
