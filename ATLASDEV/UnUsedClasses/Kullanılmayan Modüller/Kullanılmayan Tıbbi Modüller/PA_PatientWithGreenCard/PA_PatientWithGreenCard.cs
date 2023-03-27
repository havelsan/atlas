
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
    /// Yeşil Kartlı Hasta Kabul 
    /// </summary>
    public  partial class PA_PatientWithGreenCard : PatientAdmission
    {
        protected void PostTransition_DocumentApproval2Completed()
        {
            // From State : DocumentApproval   To State : Completed
#region PostTransition_DocumentApproval2Completed
   
#endregion PostTransition_DocumentApproval2Completed
        }

        protected void PostTransition_DocumentApproval2Rejected()
        {
            // From State : DocumentApproval   To State : Rejected
#region PostTransition_DocumentApproval2Rejected
            // hasta kabul reddedilirse episode kapatılır.
            Episode.CloseEpisode();
#endregion PostTransition_DocumentApproval2Rejected
        }

        protected void UndoTransition_DocumentApproval2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DocumentApproval   To State : Rejected
#region UndoTransition_DocumentApproval2Rejected
            
            Episode.UndoCloseEpisode();
#endregion UndoTransition_DocumentApproval2Rejected
        }

#region Methods
        protected override void SetPatientGroup()
        {
      
        }
        
#endregion Methods


    }
}