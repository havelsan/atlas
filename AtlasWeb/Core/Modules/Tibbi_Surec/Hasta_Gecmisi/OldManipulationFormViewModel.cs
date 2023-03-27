//$16B8D22A
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
    public partial class ManipulationServiceController
    {
        partial void PreScript_OldManipulationForm(OldManipulationFormViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext)
        {
            if(manipulation!=null)
            {
                if(manipulation.ManipulationRequest != null)
                {
                    if(manipulation.ManipulationRequest.ActionDate != null)
                    {
                        viewModel.RequestDate = manipulation.ManipulationRequest.ActionDate;
                    }

                    if(manipulation.ManipulationRequest.ProcedureDoctor != null)
                    {
                        viewModel.RequestDoctor = isNullOrEmpty(manipulation.ManipulationRequest.ProcedureDoctor.Name);
                    }

                    //Ýstek yapan birim 
                    viewModel.RequestClinic = manipulation.FromResource.Name;

                    if (manipulation.ManipulationRequest.PreInformation != null)
                    {
                        viewModel.PreInformation = manipulation.ManipulationRequest.PreInformation.ToString();
                    }
                }

                if(manipulation.ActionDate != null)
                {
                    viewModel.ActionDate = manipulation.ActionDate;
                }

                if(manipulation.ManipulationProcedures.Count>0)
                {
                    viewModel.ProcedureName = manipulation.ManipulationProcedures[0].ProcedureObject.Name;
                    viewModel.ProcedureDepartment = manipulation.ManipulationProcedures[0].ProcedureDepartment.Name;
                    viewModel.Description = manipulation.ManipulationProcedures[0].Description;
                }

                if(manipulation.ProcedureDoctor != null)
                {
                    viewModel.ProcedureDoctor = manipulation.ProcedureDoctor.Name;
                }

                if (manipulation.ProcedureReport != null)
                {
                    viewModel.ProcedureReport = manipulation.ProcedureReport.ToString();
                }

                if (manipulation.Report != null)
                {
                    viewModel.ResultReport = manipulation.Report.ToString();
                }
            }

        }
        private string isNullOrEmpty(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            else
            {
                return input;
            }
        }
    }
}

namespace Core.Models
{
    public partial class OldManipulationFormViewModel
    {
        public DateTime? RequestDate
        {
            get;
            set;
        }
        public string RequestDoctor
        {
            get;
            set;
        }
        public string RequestClinic
        {
            get;
            set;
        }
        public string PreInformation
        {
            get;
            set;
        }
        public DateTime? ActionDate
        {
            get;
            set;
        }
        public string ProcedureName
        {
            get;
            set;
        }
        public string ProcedureDepartment
        {
            get;
            set;
        }
        public string ProcedureDoctor
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string ProcedureReport
        {
            get;
            set;
        }
        public string ResultReport
        {
            get;
            set;
        }
 
    }
}
