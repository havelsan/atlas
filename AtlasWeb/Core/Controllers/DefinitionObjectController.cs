using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TTInstanceManagement;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class DefinitionObjectController : Controller
    {
        [HttpPost]
        public IActionResult ExportDefinitionObject([FromBody]DefinitionObjectInput input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var targetObject = objectContext.GetObject(input.ObjectID, input.ObjectDefName, false);
                objectContext.FullPartialllyLoadedObjects();

                string exportXMLString = TTObjectContext.ExportToXML(new List<TTObject> { targetObject });

                var memoryStream = new System.IO.MemoryStream();
                var streamWriter = new StreamWriter(memoryStream);
                streamWriter.Write(exportXMLString);
                streamWriter.Flush();
                memoryStream.Position = 0;

                var response = new FileStreamResult(memoryStream, "application/xml");
                return response;
            }
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        public async Task<IActionResult> ImportDefinitionObject()
        {

            var result = await MultipartRequestHelper.BindMultiPartFormDataToViewModel<SendObjectDefinitionXmlInput>(this);
            var objectResult = result as ObjectResult;
            var viewModel = objectResult.Value as SendObjectDefinitionXmlInput;

            if (viewModel != null)
            {
                if (viewModel.Attachments != null)
                {
                    var formFile = viewModel.Attachments.FirstOrDefault();
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(formFile.OpenReadStream());

                    TTObjectContext.ImportDataFromXML(xmlDocument);

                }
            }

            return Ok();
        }



    }
}
