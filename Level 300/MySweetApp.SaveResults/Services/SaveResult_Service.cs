using MySweetApp.Core.Contracts;
using MySweetApp.Core.Enums;
using MySweetApp.SaveResults.Contracts;
using MySweetApp.SaveResults.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace MySweetApp.SaveResults.Services
{
    internal class SaveResult_Service : ISaveResult_Service
    {
        public ResultTypes SaveAsJSON(IResult result)
        {
            if (result.Payload.Count > 0)
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                using (StreamWriter file = new StreamWriter(Path.Combine(docPath, "MySweetData.json"), false))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, new JSON_File() { Type = result.Payload[0].GetType().ToString(), Count = result.Payload.Count });
                }

                return ResultTypes.Ok;
            }
            else
            {
                return ResultTypes.Failed;
            }
            
        }
    }
}