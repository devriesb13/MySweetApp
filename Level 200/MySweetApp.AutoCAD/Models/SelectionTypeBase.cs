using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System;
using System.Linq;
using AAAS = Autodesk.AutoCAD.ApplicationServices;
using AADS = Autodesk.AutoCAD.DatabaseServices;
using AAR = Autodesk.AutoCAD.Runtime;

namespace MySweetApp.AutoCAD.Models
{
    abstract class SelectionTypeBase : ISelectionType
    {
        public SelectionTypeBase(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract IResult Find();

        public IResult GetEntities(Type type)
        {
            var db = AAAS.Core.Application.DocumentManager.MdiActiveDocument.Database;
            var returnresult = new Result_Model();

            using (AADS.Transaction tr = db.TransactionManager.StartTransaction())
            {
                try
                {
                    var modelspaceId = AADS.SymbolUtilityServices.GetBlockModelSpaceId(db);
                    var modelspace = modelspaceId.GetObject(AADS.OpenMode.ForRead, false) as AADS.BlockTableRecord;
                    var rxobjclass = AAR.RXObject.GetClass(type);
                    var entityids = modelspace.Cast<AADS.ObjectId>().Where(id => id.ObjectClass == rxobjclass);

                    returnresult.Payload.Clear();
                    entityids.ToList().ForEach(id => returnresult.Payload.Add(id.GetObject(AADS.OpenMode.ForRead, false)));

                    tr.Commit();
                }
                catch
                {
                    tr.Abort();
                    returnresult.ResultType = Core.Enums.ResultTypes.Failed;
                }     
            }

            return returnresult;
        }
    }
}