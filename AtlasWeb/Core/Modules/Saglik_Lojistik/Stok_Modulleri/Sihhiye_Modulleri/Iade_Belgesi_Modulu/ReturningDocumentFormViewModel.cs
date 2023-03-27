//$FCBBE9C4
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ReturningDocumentServiceController
    {
    }
}

namespace Core.Models
{
    public partial class ReturningDocumentFormViewModel
    {
        public OuttableLotDTO[] OuttableLotList { get; set; }
    }
}