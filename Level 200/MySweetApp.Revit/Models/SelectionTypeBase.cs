using Autodesk.Revit.DB;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System;
using System.Linq;

namespace MySweetApp.Revit.Models
{
    abstract class SelectionTypeBase : ISelectionType
    {
        private readonly Document doc;

        public SelectionTypeBase(string name, Document document)
        {
            Name = name;
            doc = document;
        }

        public string Name { get; }

        public abstract IResult Find();

        public IResult GetEntities(Type type)
        {
            var returnresult = new Result_Model();

            FilteredElementCollector allelements = new FilteredElementCollector(doc).OfClass(type);
            allelements.ToList().ForEach(element => returnresult.Payload.Add(element));

            return returnresult;
        }
    }
}