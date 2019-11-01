using Autodesk.Navisworks.Api;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System.Collections.Generic;

namespace MySweetApp.Navisworks.Models
{
    internal class Circle_SelectionType : SelectionTypeBase
    {
        public Circle_SelectionType(IFindData_Service findData_Service) : base("AutoCAD Circles", findData_Service) { }

        public override IResult Find()
        {
            return FindData_Service.GetEntities(new KeyValuePair<string, string>(DataPropertyNames.ItemType, "Circle"));
        }
    }
}