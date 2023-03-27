
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Acil Hasta Müdahale
    /// </summary>
    public partial class EmergencyInterventionAdmissionForm 
    {
        override protected void BindControlEvents()
        {
            IsEmergencyInjured.CheckedChanged += new TTControlEventDelegate(IsEmergencyInjured_CheckedChanged);
            IsEmergencyDispatched.CheckedChanged += new TTControlEventDelegate(IsEmergencyDispatched_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IsEmergencyInjured.CheckedChanged -= new TTControlEventDelegate(IsEmergencyInjured_CheckedChanged);
            IsEmergencyDispatched.CheckedChanged -= new TTControlEventDelegate(IsEmergencyDispatched_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void IsEmergencyInjured_CheckedChanged()
        {
#region EmergencyInterventionAdmissionForm_IsEmergencyInjured_CheckedChanged
   if (this.IsEmergencyInjured.Value == true)
                this.IsEmergencyDispatched.Value = false;
#endregion EmergencyInterventionAdmissionForm_IsEmergencyInjured_CheckedChanged
        }

        private void IsEmergencyDispatched_CheckedChanged()
        {
#region EmergencyInterventionAdmissionForm_IsEmergencyDispatched_CheckedChanged
   if (this.IsEmergencyDispatched.Value == true)
                this.IsEmergencyInjured.Value = false;
#endregion EmergencyInterventionAdmissionForm_IsEmergencyDispatched_CheckedChanged
        }


        protected override void PreScript()
        {
#region EmergencyInterventionAdmissionForm_PreScript
    base.PreScript();
           
#endregion EmergencyInterventionAdmissionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region EmergencyInterventionAdmissionForm_PostScript
    base.PostScript(transDef);


#endregion EmergencyInterventionAdmissionForm_PostScript

            }
            
#region EmergencyInterventionAdmissionForm_Methods
        protected override void PrepareFormTitle()
        {
            if (this._EmergencyIntervention.MasterResource != null)
                this.Text += " - " + this._EmergencyIntervention.MasterResource.Name.ToUpper();
            if (this._EpisodeAction.Episode.Patient != null)
                this.Text += " - " + this._EpisodeAction.Episode.Patient.FullName.ToUpper();

        }
        
#endregion EmergencyInterventionAdmissionForm_Methods
    }
}