//$09CD892E
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class EyeExaminationServiceController : Controller
    {
        [HttpGet]
        public Eye_ExaminationViewModel Eye_Examination(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return Eye_ExaminationLoadInternal(input);
        }

        [HttpPost]
        public Eye_ExaminationViewModel Eye_ExaminationLoad(FormLoadInput input)
        {
            return Eye_ExaminationLoadInternal(input);
        }
        public Eye_ExaminationViewModel Eye_ExaminationLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var FormDefID = Guid.Parse("c5a6a506-dd16-4208-a9c5-ef5a2e560146");
            var ObjectDefID = Guid.Parse("6f2c7971-c123-4a39-8589-c5494590699b");
            var viewModel = new Eye_ExaminationViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
                    viewModel._EyeExamination = objectContext.GetObject(id.Value, ObjectDefID) as EyeExamination;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._EyeExamination, FormDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EyeExamination, FormDefID);
                    viewModel.VisualSharpnessDefinitionNews = objectContext.LocalQuery<VisualSharpnessDefinitionNew>().ToArray();
                    viewModel.PhysicianApplicationEpisodeID = viewModel._EyeExamination.PhysicianApplication.Episode.ObjectID;
                    viewModel.hasDiagnosis = viewModel._EyeExamination.PhysicianApplication.Diagnosis.Count > 0 ? true : false;
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._EyeExamination = new EyeExamination(objectContext);
                }
            }

            return viewModel;
        }

        [HttpPost]
        public void Eye_Examination(Eye_ExaminationViewModel viewModel)
        {
            var formDefID = Guid.Parse("c5a6a506-dd16-4208-a9c5-ef5a2e560146");

            using (var objectContext = new TTObjectContext(false))
            {
                var eyeExamination = (EyeExamination)objectContext.AddObject(viewModel._EyeExamination);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(eyeExamination, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._EyeExamination, formDefID);
                objectContext.Save();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public OldGlassesReport[] GetOldGlassesReports(Guid eyeExamination)
        {
            List<OldGlassesReport> result = new List<OldGlassesReport>();
            using (var objectContext = new TTObjectContext(true))
            {
                EyeExamination eyeExaminationObj = (EyeExamination)objectContext.GetObject(eyeExamination, "EyeExamination");
                IBindingList details = objectContext.QueryObjects("GLASSESREPORT", " CURRENTSTATE IS NOT CANCELLED AND EPISODE=" + TTConnectionManager.ConnectionManager.GuidToString(eyeExaminationObj.PhysicianApplication.Episode.ObjectID), "ACTIONDATE");
                foreach (GlassesReport item in details)
                {
                    OldGlassesReport oldGlassesReport = new OldGlassesReport();
                    oldGlassesReport.ActionDate = (DateTime)item.ReportDate;
                    oldGlassesReport.GlassesReportNo = item.EReceteNo;
                    oldGlassesReport.ObjectId = item.ObjectID;
                    oldGlassesReport.currentState = item.CurrentStateDef.DisplayText;
                    result.Add(oldGlassesReport);
                }
                objectContext.FullPartialllyLoadedObjects();
            }

            return result.ToArray();
        }

    }
}

namespace Core.Models
{
    public class Eye_ExaminationViewModel : BaseViewModel, ISpecialityBasedObjectViewModel
    {
        public TTObjectClasses.EyeExamination _EyeExamination
        {
            get;
            set;
        }

        public TTObjectClasses.VisualSharpnessDefinitionNew[] VisualSharpnessDefinitionNews
        {
            get;
            set;
        }

        public Guid PhysicianApplicationEpisodeID
        {
            get;
            set;
        }

        public void AddSpecialityBasedObjectViewModelToContext(TTObjectContext objectContext)
        {
            var eyeExamination = (EyeExamination)objectContext.AddObject(this._EyeExamination);
        }

        public bool hasDiagnosis = false;
    }
}