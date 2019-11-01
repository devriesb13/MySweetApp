using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;

namespace MySweetApp.Navisworks.Models
{
    internal class Wall_SelectionType : SelectionTypeBase
    {
        public Wall_SelectionType() : base("Revit Walls") { }

        public override IResult Find()
        {
            return GetEntities("Basic Wall", DataPropertyNames.ItemName);
        }
    }
}