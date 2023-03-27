//$4E4ED7A6
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class ManipulationServiceController
    {
        partial void PreScript_ManipulationRequestAcceptionForm(ManipulationRequestAcceptionFormViewModel viewModel, Manipulation manipulation, TTObjectContext objectContext)
        {
            Guid Doctor = new Guid("9431A69C-1A2A-4DCF-B1D3-6B1368318F89"); // Uzman Doktor
            Guid Secretary = new Guid("db5c91e1-2179-4b3e-9b9b-c418b2dee02f");
            Guid Technician = new Guid("992625fd-0883-4854-bcef-9291619bae0a");
            if (Common.CurrentUser.HasRole(Doctor))
                viewModel._isDoctor = true;
            else
                viewModel._isDoctor = false;
            if (Common.CurrentUser.HasRole(Secretary))
                viewModel._isSecretary = true;
            else
                viewModel._isSecretary = false;
            if (Common.CurrentUser.HasRole(Technician))
                viewModel._isTechnician = true;
            else
                viewModel._isTechnician = false;
            if (Common.CurrentUser.IsSuperUser)
                viewModel._isSuperUser = true;
            else
                viewModel._isSuperUser = false;
        }

        partial void PostScript_ManipulationRequestAcceptionForm(ManipulationRequestAcceptionFormViewModel viewModel, Manipulation manipulation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDef.StateDefID == Manipulation.States.DoctorProcedure || transDef.ToStateDef.StateDefID == Manipulation.States.Appointment || transDef.ToStateDef.StateDefID == Manipulation.States.TechnicianProcedure)
                {
                    System.Reflection.PropertyInfo propInfo = manipulation.GetType().GetProperty("ProtocolNo");
                    if (propInfo != null && propInfo.PropertyType == typeof (TTSequence))
                    {
                        TTSequence protocolNo = propInfo.GetValue(manipulation, null) as TTSequence;
                        if (protocolNo.Value == null)
                            protocolNo.GetNextValue(manipulation.MasterResource.ObjectID.ToString(), Common.RecTime().Year);
                    }
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ManipulationRequestAcceptionFormViewModel
    {
        public object _selectedManipulationProcedureObject
        {
            get;
            set;
        }

        public bool _isDoctor
        {
            get;
            set;
        }

        public bool _isSecretary
        {
            get;
            set;
        }

        public bool _isTechnician
        {
            get;
            set;
        }

        public bool _isSuperUser
        {
            get;
            set;
        }
    }
}