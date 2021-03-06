﻿using Autodesk.Revit.DB;
using MySweetApp.Core.Contracts;
using MySweetApp.Core.Models;
using System;
using System.Linq;
using Prism.Ioc;

namespace MySweetApp.Revit.Services
{
    internal class FindRevitData_Service : IFindData_Service
    {
        public FindRevitData_Service()
        {
        }

        public IResult GetEntities(dynamic obj)
        {
            var returnresult = new Result_Model();

            if (obj is Type data)
            {
                var doc = Bootstrapper.Instance.Container.Resolve<Document>();
                FilteredElementCollector allelements = new FilteredElementCollector(doc).OfClass(data);
                allelements.ToList().ForEach(element => returnresult.Payload.Add(element));
            }
            else
            {
                returnresult.ResultType = Core.Enums.ResultTypes.Failed;
            }

            return returnresult;
        }
    }
}