//$F1071AE3
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class DentalProcedureServiceController : Controller
    {
        public class GetByExternalID_Input
        {
            public string EXTERNALID
            {
                get;
                set;
            }

            public string PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalProcedure> GetByExternalID(GetByExternalID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalProcedure.GetByExternalID(objectContext, input.EXTERNALID, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDentalProceduresByEpisodeAction_Input
        {
            public Guid EPISODEACTION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DentalProcedure.GetDentalProceduresByEpisodeAction_Class> GetDentalProceduresByEpisodeAction(GetDentalProceduresByEpisodeAction_Input input)
        {
            var ret = DentalProcedure.GetDentalProceduresByEpisodeAction(input.EPISODEACTION);
            return ret;
        }

        public class GetDentalProcedureByProcedureDoctorSection_Input
        {
            public string PROCEDUREOBJECT
            {
                get;
                set;
            }

            public string PROCEDUREDOCTOR
            {
                get;
                set;
            }

            public string RESSECTION
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
        public BindingList<DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class> GetDentalProcedureByProcedureDoctorSection(GetDentalProcedureByProcedureDoctorSection_Input input)
        {
            var ret = DentalProcedure.GetDentalProcedureByProcedureDoctorSection(input.PROCEDUREOBJECT, input.PROCEDUREDOCTOR, input.RESSECTION, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalProcedure.VEM_HASTA_DIS_Class> VEM_HASTA_DIS()
        {
            var ret = DentalProcedure.VEM_HASTA_DIS();
            return ret;
        }
    }
}