using Autodesk.Revit.DB;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;

namespace MySweetApp.Revit.Models
{
    class Wall_SelectionType : SelectionTypeBase
    {
        public Wall_SelectionType(IFindData_Service findData_Service) : base("Walls", findData_Service)
        {
        }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(typeof(Wall));
        }
    }
}