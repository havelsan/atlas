using Infrastructure.Filters;
using Core.Models.TestProject;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers.TestProject
{
    class Test
    {
        public string Adi
        {
            get;
            set;
        }

        public string Soyadi
        {
            get;
            set;
        }
    }

    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class TestProjectApiController : Controller
    {
        [HttpGet()]
        public TestProjectModel ReadTestHtml()
        {
            TestProjectModel model = new TestProjectModel()
            {Rtf = "<p><center>Sample content</center></p>"};
            return model;
        }
    }
}