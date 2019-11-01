using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.DB;
using MySweetApp.Core.Contracts;

namespace MySweetApp.Revit.Models
{
    class Floor_SelectionType : SelectionTypeBase
    {
        public Floor_SelectionType(Document document) : base("Floors", document)
        {
        }

        public override IResult Find()
        {
            return GetEntities(typeof(Floor));
        }
    }
}
