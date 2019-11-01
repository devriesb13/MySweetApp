using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;

namespace MySweetApp.Navisworks.Models
{
    internal class Line_SelectionType : SelectionTypeBase
    {
        public Line_SelectionType() : base("AutoCAD Lines") { }

        public override IResult Find()
        {
            return GetEntities("Line Set", DataPropertyNames.ItemType);
        }
    }
}