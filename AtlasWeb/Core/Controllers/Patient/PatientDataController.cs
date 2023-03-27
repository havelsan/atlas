using Infrastructure.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PatientDataController : Controller
    {
        public bool CreateOrUpdate([FromQuery] TTObjectClasses.Patient patient, [FromQuery] int i)
        {
            TTObjectClasses.Patient serverPatient = null;
            using (var objectContext = new TTObjectContext(true))
            {
                if (patient.ObjectID != Guid.Empty)
                {
                    serverPatient = objectContext.GetObject(patient.ObjectID, "Patient") as TTObjectClasses.Patient;
                }
                else
                {
                    serverPatient = new TTObjectClasses.Patient(objectContext);
                }

                serverPatient.UniqueRefNo = patient.UniqueRefNo;
                serverPatient.Name = patient.Name;
                serverPatient.Surname = patient.Surname;
                serverPatient.FatherName = patient.FatherName;
                serverPatient.Sex = patient.Sex;
                serverPatient.BirthDate = patient.BirthDate;
                objectContext.Save();
            }

            return true;
        }

        private readonly static Guid TestPatientId = Guid.Parse("5eeba121-97f4-4c1b-b421-14c4eae0577b");
        public Task<string> NewPatient()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                TTObjectClasses.Patient patient = objectContext.GetObject(TestPatientId, "Patient") as TTObjectClasses.Patient;
                //var ser = new JavaScriptSerializer();
                //var result = ser.Serialize(patient);
                var stringBuilder = new StringBuilder();
                using (var stringWriter = new StringWriter(stringBuilder))
                {
                    var xmlSerializer = new XmlSerializer(typeof (TTObjectClasses.Patient));
                    xmlSerializer.Serialize(stringWriter, patient);
                }

                ITraceWriter traceWriter = new MemoryTraceWriter();
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Formatting = Formatting.Indented;
                jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
                jsonSerializer.TraceWriter = traceWriter;
                jsonSerializer.Error += JsonSerializer_Error;
                //jsonSerializer.Converters.Add(new JavaScriptDateTimeConverter());
                jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
                var stringBuilderJson = new StringBuilder();
                using (StringWriter sw = new StringWriter(stringBuilderJson))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        jsonSerializer.Serialize(writer, patient);
                    }

                var traceMessage = traceWriter.ToString();
                return Task.FromResult(stringBuilderJson.ToString());
            }
        }

        private void JsonSerializer_Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
        //System.Diagnostics.Trace.WriteLine(e.CurrentObject.ToString());
        }
    }
}