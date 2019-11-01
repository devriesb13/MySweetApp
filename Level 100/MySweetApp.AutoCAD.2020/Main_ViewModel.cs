using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AADS = Autodesk.AutoCAD.DatabaseServices;
using AAPS = Autodesk.AutoCAD.ApplicationServices;
using AAR = Autodesk.AutoCAD.Runtime;

namespace MySweetApp.AutoCAD._2020
{
    internal class Main_ViewModel
    {
        public Main_ViewModel()
        {
            FindTypes = new ObservableCollection<string>() { "Lines", "Circles" };
            FindType = new RelayCommand(p => Handler_FindType_Execute(p));
            FoundTypes = new ObservableCollection<AADS.DBObject>();
        }

        public ICommand FindType { get; }

        public ObservableCollection<string> FindTypes { get; }

        public ObservableCollection<AADS.DBObject> FoundTypes { get; }

        private void GetEntities(Type type)
        {
            var db = AAPS.Core.Application.DocumentManager.MdiActiveDocument.Database;

            using (AADS.Transaction tr = db.TransactionManager.StartTransaction())
            {
                var modelspaceId = AADS.SymbolUtilityServices.GetBlockModelSpaceId(db);
                var modelspace = modelspaceId.GetObject(AADS.OpenMode.ForRead, false) as AADS.BlockTableRecord;
                var rxobjclass = AAR.RXObject.GetClass(type);
                var entityids = modelspace.Cast<AADS.ObjectId>().Where(id => id.ObjectClass == rxobjclass);

                FoundTypes.Clear();
                entityids.ToList().ForEach(id => FoundTypes.Add(id.GetObject(AADS.OpenMode.ForRead, false)));

                tr.Commit();
            }
        }

        private void Handler_FindType_Execute(object param)
        {
            if (param is null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            if (param is string)
            {
                switch (param)
                {
                    case "Lines":
                        GetEntities(typeof(AADS.Line));
                        break;

                    case "Circles":
                        GetEntities(typeof(AADS.Circle));
                        break;
                }
            }
        }
    }
}