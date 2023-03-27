//$F6A943DB
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
using TTDefinitionManagement;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class ConsultationServiceController : Controller
    {
        public class GetByMasterActionNQL_Input
        {
            public Guid MASTERACTION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Consultation.GetByMasterActionNQL_Class> GetByMasterActionNQL(GetByMasterActionNQL_Input input)
        {
            var ret = Consultation.GetByMasterActionNQL(input.MASTERACTION);
            return ret;
        }

        public class GetAllConsultationsOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Consultation> GetAllConsultationsOfPatient(GetAllConsultationsOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Consultation.GetAllConsultationsOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        partial void PostScript_AppointmentFormConsultation(AppointmentFormConsultationViewModel viewModel, Consultation consultation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDef.Status != StateStatusEnum.Cancelled && transDef.ToStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
                {
                    foreach (Appointment appointment in consultation.GetMyNewAppointments())
                    {
                        AuthorizedUser authorizedUser = new AuthorizedUser(objectContext);
                        authorizedUser.User = (ResUser)appointment.Resource;
                        consultation.AuthorizedUsers.Add(authorizedUser);
                        consultation.ProcedureDoctor = (ResUser)appointment.Resource;
                    }
                }
                else
                {
                    //YAPILACAK : Obje delete i yapıldığında aşağıdaki kod açılacak.
                    //this._ConsultationProcedure.AuthorizedUsers.DeleteChildren();
                    AuthorizedUser authorizedUser = new AuthorizedUser(objectContext);
                    authorizedUser.User = (ResUser)consultation.ProcedureDoctor;
                    consultation.AuthorizedUsers.Add(authorizedUser);
                }
            }
        }
    }
}