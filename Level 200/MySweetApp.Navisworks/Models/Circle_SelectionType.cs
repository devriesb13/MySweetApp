using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;

namespace MySweetApp.Navisworks.Models
{
    internal class Circle_SelectionType : SelectionTypeBase
    {
        public Circle_SelectionType() : base("AutoCAD Circles") { }

        public override IResult Find()
        {
            return GetEntities("Circle", DataPropertyNames.ItemType);
        }
    }
}