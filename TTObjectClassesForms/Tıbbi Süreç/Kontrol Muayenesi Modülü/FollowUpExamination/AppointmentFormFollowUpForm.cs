
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
    public partial class AppointmentFormFollowUp : AppointmentFormBase
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
#region AppointmentFormFollowUp_PreScript
    base.PreScript();
#endregion AppointmentFormFollowUp_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AppointmentFormFollowUp_PostScript
    if (transDef != null)
            {
                foreach (Appointment appointment in EpisodeAction.GetMyNewAppointments(this._FollowUpExamination.ObjectID))
                {
                    this._FollowUpExamination.ProcedureDoctor = (ResUser)appointment.Resource;
                    this._FollowUpExamination.MasterResource = (ResSection)appointment.MasterResource;
                }
            }
            base.PostScript(transDef);
#endregion AppointmentFormFollowUp_PostScript

            }
                }
}