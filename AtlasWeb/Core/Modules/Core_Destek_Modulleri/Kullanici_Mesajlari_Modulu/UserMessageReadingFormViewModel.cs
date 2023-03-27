//$F133370B
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class UserMessageServiceController
    {
        partial void PreScript_UserMessageReadingForm(UserMessageReadingFormViewModel viewModel, UserMessage userMessage, TTObjectContext objectContext)
        {
            viewModel.messagegroups = UserMessageGroupDefinition.GetAllMessageGroupDefinition(objectContext, "").ToArray();
        }
    }
}

namespace Core.Models
{
    public partial class UserMessageReadingFormViewModel
    {
        public TTObjectClasses.UserMessageGroupDefinition[] messagegroups
        {
            get;
            set;
        }
    }
}
