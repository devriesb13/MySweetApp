using Autodesk.Revit.DB;
using MySweetApp.Core.Contracts;

namespace MySweetApp.Revit.Models
{
    class Wall_SelectionType : SelectionTypeBase
    {
        public Wall_SelectionType(Document document) : base("Walls", document)
        {
        }

        public override IResult Find()
        {
            return GetEntities(typeof(Wall));
        }
    }
}