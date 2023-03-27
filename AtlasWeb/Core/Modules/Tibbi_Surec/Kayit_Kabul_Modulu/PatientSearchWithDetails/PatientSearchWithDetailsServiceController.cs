using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PatientSearchWithDetailsServiceController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Hasta_Arama_Kayit_Kabul)]
        public List<Patient> PatientSearchWithDetailsForm(PatientSearchWithDetailsFormViewModel model)
        {
            List<Patient> result = new List<Patient>();
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    string filterExpression = Patient.GetFilterExpression(model.UniqueRefNo, model.Name, model.Surname, model.FatherName, model.MotherName, model.BirthDate, model.BirthPlace, null, null, model.PasaportNo);
                    BindingList<Patient> patientSearchList = Patient.GetPatientObjectsByInjection(context, filterExpression);
                    if (patientSearchList != null && patientSearchList.Count > 0)
                    {
                        foreach (Patient patient in patientSearchList)
                        {
                            result.Add(patient);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return result;
        }
    }
}