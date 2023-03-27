
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
    /// Randevu Formu
    /// </summary>
    public partial class AppointmentFormMedical : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region AppointmentFormMedical_PreScript
    base.PreScript();          
 this.tttextboxDescription.Text = string.Empty;
            //TextBox pDescriptionBox = (TextBox)tttextboxDescription;
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;

            tttextboxDescription.Text= BaseAction.GetFullAppointmentDescription(this._MedicalCommittee);
#endregion AppointmentFormMedical_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AppointmentFormMedical_PostScript
    base.PostScript(transDef);         this._MedicalCommittee.CompleteMyNewAppoinments();
#endregion AppointmentFormMedical_PostScript

            }
                }
}