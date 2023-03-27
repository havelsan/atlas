
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
    /// Kemoterapi - Radyoterapi Tedavi Protokolü için kullanılan ana nesnein altındaki seans nesnesidir.
    /// </summary>
    public  partial class ChemoRadioCureProtocolDet : SubactionProcedureFlowable
    {
        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ChemoRadioCureProtocolDet.States.Cure && toState == ChemoRadioCureProtocolDet.States.Completed)
                UndoTransition_Completed2Cure(transDef);            
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (toState == ChemoRadioCureProtocolDet.States.Completed)
                PostTransition_2Completed(transDef);
        }

        protected void PostTransition_2Completed(TTObjectStateTransitionDef transDef)
        {
            if(ChemoRadioCureProtocol.IsRadiotherapyCure == false)
            {
                var activeSep = SubEpisode.LastActiveSubEpisodeProtocol;
                if (activeSep != null && activeSep.MedulaTedaviTuru.tedaviTuruKodu == "G")
                {
                    if (activeSep.CloneType != SEPCloneTypeEnum.PatientInvoice && activeSep.SubEpisode?.PatientAdmission?.IsOldAction != true)
                    {
                        TigEpisode.createNewTigObjectForTreatmentCure(activeSep, ObjectContext);
                    }
                }
            }
            
        }
       

        protected void UndoTransition_Completed2Cure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            if (ChemoRadioCureProtocol.IsRadiotherapyCure != true)
            {
                if (SolutionMaterial != null)
                {
                    SolutionMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                    SolutionMaterial = null;
                }
                if (DrugMaterial != null)
                {
                    DrugMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                    DrugMaterial = null;
                }
            }
            this.PerformedDate = null;
            #endregion UndoTransition_Completed2Cancelled
        }
    }
}