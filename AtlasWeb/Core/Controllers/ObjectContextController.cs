using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]")]
    public class ObjectContextController : Controller
    {
        [HttpGet]
        [Route("{objectDefID}")]
        public TTObject GetNewObject(Guid objectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ttObject = objectContext.CreateObject(objectDefID);
                TTObjectDef objectDef;
                if (TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefID, out objectDef))
                {
                    var stateDef = objectDef.StateDefs.Values.Where(d => d.IsEntry == true).FirstOrDefault();
                    if (stateDef != null)
                    {
                        ttObject.CurrentStateDefID = stateDef.StateDefID;
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return ttObject;
            }
        }

        [HttpGet]
        [Route("{objectDefName}")]
        public TTObject GetNewObjectWithDefName(string objectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ttObject = objectContext.CreateObject(objectDefName);
                objectContext.FullPartialllyLoadedObjects();
                return ttObject;
            }
        }

        [HttpGet]
        [Route("{objectID}/{objectDefID}")]
        public TTObject GetObject(Guid objectID, Guid objectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ttObject = objectContext.GetObject(objectID, objectDefID);
                objectContext.FullPartialllyLoadedObjects();
                return ttObject;
            }
        }

        [HttpGet]
        [Route("{objectID}/{objectDefName}")]
        public TTObject GetObjectWithDefName(Guid objectID, string objectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ttObject = objectContext.GetObject(objectID, objectDefName);
                objectContext.FullPartialllyLoadedObjects();
                return ttObject;
            }
        }

        [HttpGet]
        [Route("{objectID}/{objectDefID}/{relDefID}")]
        public IEnumerable<TTObject> GetObjectChildren(Guid objectID, Guid objectDefID, Guid relDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ttObject = objectContext.GetObject(objectID, objectDefID);
                var childObjectCollection = new TTObject.TTChildObjectCollection<TTObject>(ttObject, relDefID);
                ((TTObject.ITTChildObjectCollection)childObjectCollection).GetChildren();
                objectContext.FullPartialllyLoadedObjects();
                return childObjectCollection;
            }
        }

        [HttpGet]
        [Route("{objectID}/{objectDefName}/{relDefID}")]
        public IEnumerable<TTObject> GetObjectChildrenWithDefName(Guid objectID, string objectDefName, Guid relDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var ttObject = objectContext.GetObject(objectID, objectDefName);
                var childObjectCollection = new TTObject.TTChildObjectCollection<TTObject>(ttObject, relDefID);
                ((TTObject.ITTChildObjectCollection)childObjectCollection).GetChildren();
                objectContext.FullPartialllyLoadedObjects();
                return childObjectCollection;
            }
        }

        public class QueryObjectsInput
        {
            public string ObjectDefName { get; set; }
            public TTObjectDef ObjectDef { get; set; }
            public string FilterExpression { get; set; }
            public string OrderBy { get; set; }
        }

        [HttpPost]
        public IEnumerable<TTObject> QueryObjects(QueryObjectsInput input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                IBindingList bindingList = null;
                if (input.ObjectDef != null)
                {
                    bindingList = objectContext.QueryObjects(input.ObjectDef, input.FilterExpression, input.OrderBy);
                }
                else
                {
                    bindingList = objectContext.QueryObjects(input.ObjectDefName, input.FilterExpression, input.OrderBy);
                }

                objectContext.FullPartialllyLoadedObjects();
                return bindingList.Cast<TTObject>();
            }
        }

        [HttpPost]
        public void SerializeWithBaseType(TTObjectClasses.StockAction stockAction)
        {
            System.Diagnostics.Trace.WriteLine(stockAction.GetType().Name);
        }

        [HttpPost]
        public void SerializeWithoutType(TTObjectClasses.ChattelDocumentInputWithAccountancy stockAction)
        {
            System.Diagnostics.Trace.WriteLine(stockAction.GetType().Name);
        }

        [HttpPost]
        public void CurrencyTest(CurrencyTestModel testModel)
        {
            System.Diagnostics.Trace.WriteLine(testModel.Toplam);
            System.Diagnostics.Trace.WriteLine(testModel.GenelToplam);
        }

        [HttpPost]
        public void RtfTest(PatientExamination testModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var resultObject = objectContext.AddObject(testModel) as PatientExamination;
                objectContext.Save();
            }
        }

        [HttpGet]
        public string GetTestObject()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var testObject = objectContext.GetObject<TTObjectClasses.ChattelDocumentInputWithAccountancy>(new Guid("dde3120a-b60d-40b4-b9df-1826f7021b45"));
                objectContext.FullPartialllyLoadedObjects();
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.All;
                JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(settings);
                var stringBuilder = new StringBuilder();
                using (JsonTextWriter writer = new JsonTextWriter(new StringWriter(stringBuilder)))
                {
                    jsonSerializer.Serialize(writer, testObject);
                }

                return stringBuilder.ToString();
            }
        }

        [HttpGet]
        public TTObjectClasses.PatientExamination RtfTestGet()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var testObject = objectContext.GetObject<TTObjectClasses.PatientExamination>(new Guid("d31cece5-b4c6-4e57-a9ef-c5445d940c41"));
                objectContext.FullPartialllyLoadedObjects();
                return testObject;
            }
        }

    }
}