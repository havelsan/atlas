
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Diş Laboratuar Kontrol
    /// </summary>
    public  partial class DentalLaboratoryProcedure : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PostTransition_New2Cancelled
            Cancel();
            if (DentalExamination != null && DentalExamination.Laboratory != null && DentalExamination.Laboratory.Count > 0)
                DentalExamination.Laboratory.RemoveAt(0);
#endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            Cancel();
            if (DentalExamination != null && DentalExamination.Laboratory != null && DentalExamination.Laboratory.Count > 0)
                DentalExamination.Laboratory.RemoveAt(0);
#endregion PostTransition_Completed2Cancelled
        }

#region Methods
        public DentalLaboratoryProcedure(TTObjectContext objectContext,DentalExamination dentalExamination):this(objectContext)
        {
            RequestDate = Common.RecTime();
            DentalExamination = dentalExamination;
            ProcedureDoctor = dentalExamination.ProcedureDoctor;
            ProcedureDepartment = dentalExamination.ProcedureDepartment;
            Episode = dentalExamination.Episode;
            MasterResource = dentalExamination.MasterResource;
            FromResource = dentalExamination.MasterResource;
            CurrentStateDefID = DentalLaboratoryProcedure.States.New;
        }
        
        public DentalLaboratoryProcedure(TTObjectContext objectContext,DentalExamination dentalExamination,DentalExaminationSuggestedProsthesis dentalExaminationSuggestedProsthesis):this(objectContext)
        {
            RequestDate = Common.RecTime();
            DentalExamination = dentalExamination;
            ProcedureDoctor = dentalExamination.ProcedureDoctor;
            ProcedureDepartment = dentalExamination.ProcedureDepartment;
            Episode = dentalExamination.Episode;
            MasterResource = dentalExaminationSuggestedProsthesis.Department;
            FromResource = dentalExamination.MasterResource;
            CurrentStateDefID = DentalLaboratoryProcedure.States.New;
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalLaboratoryProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalLaboratoryProcedure.States.New && toState == DentalLaboratoryProcedure.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == DentalLaboratoryProcedure.States.Completed && toState == DentalLaboratoryProcedure.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}