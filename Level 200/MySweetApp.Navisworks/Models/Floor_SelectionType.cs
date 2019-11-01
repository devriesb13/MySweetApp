using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;

namespace MySweetApp.Navisworks.Models
{
    internal class Floor_SelectionType : SelectionTypeBase
    {
        public Floor_SelectionType() : base("Revit Floors") { }

        public override IResult Find()
        {
            return GetEntities("Floor", DataPropertyNames.ItemName);
        }
    }
}