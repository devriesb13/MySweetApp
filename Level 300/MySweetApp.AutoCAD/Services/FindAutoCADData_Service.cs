using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System;
using System.Linq;
using AAAS = Autodesk.AutoCAD.ApplicationServices;
using AADS = Autodesk.AutoCAD.DatabaseServices;
using AAR = Autodesk.AutoCAD.Runtime;

namespace MySweetApp.AutoCAD.Services
{
    internal class FindAutoCADData_Service : IFindData_Service
    {
        public FindAutoCADData_Service() { }

        public IResult GetEntities(dynamic obj)
        {
            var returnresult = new Result_Model();

            if (obj is Type)
            {
                var db = AAAS.Core.Application.DocumentManager.MdiActiveDocument.Database;

                using (AADS.Transaction tr = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        var modelspaceId = AADS.SymbolUtilityServices.GetBlockModelSpaceId(db);
                        var modelspace = modelspaceId.GetObject(AADS.OpenMode.ForRead, false) as AADS.BlockTableRecord;
                        var rxobjclass = AAR.RXObject.GetClass(obj as Type);
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
            }
            else
            {
                returnresult.ResultType = Core.Enums.ResultTypes.Failed;
            }

            return returnresult;
        }
    }
}