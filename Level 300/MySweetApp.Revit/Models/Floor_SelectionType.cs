using Autodesk.Revit.DB;
using MySweetApp.Core.Attributes;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;

namespace MySweetApp.Revit.Models
{
    internal class Floor_SelectionType : SelectionTypeBase
    {
        public Floor_SelectionType(IFindData_Service findData_Service) : base("Floors", findData_Service)
        {
        }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(typeof(Floor));
        }
    }
}