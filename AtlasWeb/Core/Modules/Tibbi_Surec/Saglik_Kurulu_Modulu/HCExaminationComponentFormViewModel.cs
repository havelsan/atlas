//$BB700C53
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class HCExaminationComponentServiceController
    {
        partial void PreScript_HCExaminationComponentForm(HCExaminationComponentFormViewModel viewModel, HCExaminationComponent hcExaminationComponent, TTObjectContext objectContext)
        {
            if (viewModel._HCExaminationComponent.ReportDate == null)
                viewModel._HCExaminationComponent.ReportDate = DateTime.Now;
            if (viewModel._HCExaminationComponent.PatientExamination != null)
            {
                if (viewModel.Height == null)
                    viewModel.Height = viewModel._HCExaminationComponent.PatientExamination[0].Heights.LastOrDefault() != null ? viewModel._HCExaminationComponent.PatientExamination[0].Heights.LastOrDefault().Value : 0;
                if (viewModel.Weight == null)
                    viewModel.Weight = viewModel._HCExaminationComponent.PatientExamination[0].Weights.LastOrDefault() != null ? viewModel._HCExaminationComponent.PatientExamination[0].Weights.LastOrDefault().Value : 0;
            }

            if (viewModel._HCExaminationComponent.ReasonForExamination != null && viewModel._HCExaminationComponent.ReasonForExamination.HCReportTypeDefinition != null)
            {
                viewModel.IsDisabled = viewModel._HCExaminationComponent.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true ? true : false;
            }

            if (viewModel._HCExaminationComponent.EDisabledReport != null)
            {
                if (viewModel._HCExaminationComponent.EDisabledReport.IsCozgerReport.HasValue)
                    viewModel.IsCozger = (bool)viewModel._HCExaminationComponent.EDisabledReport.IsCozgerReport;

            }

            if(viewModel.IsCozger == true)
            {
                List<string> areaList = new List<string>();
                foreach (var hcExamComp in viewModel._HCExaminationComponent.EDisabledReport.HCExaminationComponent)
                {
                    if(viewModel._HCExaminationComponent.ObjectID != hcExamComp.ObjectID && hcExamComp.CozgerSpecReqArea != null)
                    {
                        areaList.Add(hcExamComp.CozgerSpecReqArea.ObjectID.ToString());
                    }
                }
                viewModel.CozgerListFilterExpression = "";
                if (areaList.Count == 1)
                {
                    viewModel.CozgerListFilterExpression = " THIS.OBJECTID <> '" + areaList[0] + "' ";
                }else if (areaList.Count > 1)
                {
                    viewModel.CozgerListFilterExpression = " THIS.OBJECTID NOT IN (";
                    foreach (var objId in areaList)
                    {
                        viewModel.CozgerListFilterExpression += "'" + objId + "',";
                    }

                    viewModel.CozgerListFilterExpression = viewModel.CozgerListFilterExpression.Remove(viewModel.CozgerListFilterExpression.LastIndexOf(',')) + ")";
                }
            }

            foreach (var item in viewModel._HCExaminationComponent.HCExaminationDisabledRatio)
            {
                var a = item;
            }

            if(viewModel._HCExaminationComponent.CozgerSpecReqArea != null)
            {
                var a = viewModel._HCExaminationComponent.CozgerSpecReqArea;
            }
            if (viewModel._HCExaminationComponent.CozgerSpecReqLevel != null)
            {
                var a = viewModel._HCExaminationComponent.CozgerSpecReqLevel;
            }
            ContextToViewModel(viewModel, objectContext);
        }

        partial void PostScript_HCExaminationComponentForm(HCExaminationComponentFormViewModel viewModel, HCExaminationComponent hcExaminationComponent, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel.Height != null)
            {
                Height height = null;
                if (viewModel._HCExaminationComponent.PatientExamination[0].Heights.Count == 0)
                {
                    height = new Height(objectContext);
                    height.EpisodeAction = viewModel._HCExaminationComponent.PatientExamination[0];
                }
                else
                {
                    height = viewModel._HCExaminationComponent.PatientExamination[0].Heights[0];
                }

                height.Value = Convert.ToInt32(viewModel.Height);
                height.ExecutionDate = Common.RecTime();
            }

            if (viewModel.Weight != null)
            {
                Weight weight = null;
                if (viewModel._HCExaminationComponent.PatientExamination[0].Weights.Count == 0)
                {
                    weight = new Weight(objectContext);
                    weight.EpisodeAction = viewModel._HCExaminationComponent.PatientExamination[0];
                }
                else
                {
                    weight = viewModel._HCExaminationComponent.PatientExamination[0].Weights[0];
                }

                weight.Value = Convert.ToInt32(viewModel.Weight);
                weight.ExecutionDate = Common.RecTime();
            }
        }
    }
}

namespace Core.Models
{
    public partial class HCExaminationComponentFormViewModel
    {
        public bool IsDisabled
        {
            get;
            set;
        }

        public bool IsCozger = false;


        public double? Height
        {
            get;
            set;
        }

        public double? Weight
        {
            get;
            set;
        }

        public TTObjectClasses.CozgerSpecReqArea[] CozgerSpecReqAreas
        {
            get;
            set;
        }

        public TTObjectClasses.CozgerSpecReqLevel[] CozgerSpecReqLevels
        {
            get;
            set;
        }

        public TTObjectClasses.HCExaminationDisabledRatio[] HCExaminationDisabledRatios
        {
            get;
            set;
        }

        public string CozgerListFilterExpression { get; set; }
    }
}