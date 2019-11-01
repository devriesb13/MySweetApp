using MySweetApp.Core.Contracts;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace MySweetApp.AutoCAD.Models
{
    internal class Circle_SelectionType : SelectionTypeBase
    {
        public Circle_SelectionType() : base("Circles") { }

        public override IResult Find()
        {
            return GetEntities(typeof(AADS.Circle));
        }
    }
}