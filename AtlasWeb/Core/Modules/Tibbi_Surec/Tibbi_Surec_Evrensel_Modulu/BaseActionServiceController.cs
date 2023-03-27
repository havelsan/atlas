//$E911262D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class BaseActionServiceController : Controller
    {
        public class GetMyNewAppointments_Input
        {
            public TTObjectClasses.BaseAction baseAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.ComponentModel.BindingList<TTObjectClasses.Appointment> GetMyNewAppointments(GetMyNewAppointments_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.baseAction != null)
                    input.baseAction = (TTObjectClasses.BaseAction)objectContext.AddObject(input.baseAction);
                var ret = BaseAction.GetMyNewAppointments(input.baseAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetFullAppointmentDescription_Input
        {
            public TTObjectClasses.BaseAction baseAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Radyoloji_Test_Randevu, TTRoleNames.Radyoloji_Test_R)]
        public string GetFullAppointmentDescription(GetFullAppointmentDescription_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.baseAction != null)
                    input.baseAction = (TTObjectClasses.BaseAction)objectContext.AddObject(input.baseAction);
                var ret = BaseAction.GetFullAppointmentDescription(input.baseAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetFullCompletedAppointmentDescription_Input
        {
            public TTObjectClasses.BaseAction baseAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetFullCompletedAppointmentDescription(GetFullCompletedAppointmentDescription_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.baseAction != null)
                    input.baseAction = (TTObjectClasses.BaseAction)objectContext.AddObject(input.baseAction);
                var ret = BaseAction.GetFullCompletedAppointmentDescription(input.baseAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByFilterExpression_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BaseAction> GetByFilterExpression(GetByFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BaseAction.GetByFilterExpression(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByBaseActionWorklistDate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BaseAction> GetByBaseActionWorklistDate(GetByBaseActionWorklistDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BaseAction.GetByBaseActionWorklistDate(objectContext, input.STARTDATE, input.ENDDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByWLFilterExpression_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BaseAction> GetByWLFilterExpression(GetByWLFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BaseAction.GetByWLFilterExpression(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAppointmentActions_Input
        {
            public Guid MASTERRESOURCE
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<BaseAction.GetAppointmentActions_Class> GetAppointmentActions(GetAppointmentActions_Input input)
        {
            var ret = BaseAction.GetAppointmentActions(input.MASTERRESOURCE, input.STARTDATE, input.ENDDATE);
            return ret;
        }
    }
}