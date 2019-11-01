using MySweetApp.Core.Contracts;
using AADS = Autodesk.AutoCAD.DatabaseServices;

namespace MySweetApp.AutoCAD.Models
{
    internal class Line_SelectionType : SelectionTypeBase
    {
        public Line_SelectionType() : base("Lines") { }

        public override IResult Find()
        {
            return GetEntities(typeof(AADS.Line));
        }
    }
}