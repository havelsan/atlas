
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
    public partial class AppointmentFormStone : EpisodeActionForm
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
#region AppointmentFormStone_PreScript
    base.PreScript();          
 this.tttextboxDescription.Text = string.Empty;
            //TextBox pDescriptionBox = (TextBox)tttextboxDescription;
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;

            tttextboxDescription.Text= BaseAction.GetFullAppointmentDescription(this._StoneBreakUpRequest);
#endregion AppointmentFormStone_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AppointmentFormStone_PostScript
    base.PostScript(transDef);
            if (transDef != null)
            {
                foreach (Appointment appointment in EpisodeAction.GetMyNewAppointments(this._StoneBreakUpRequest.ObjectID))
                {
                    this._StoneBreakUpRequest.Equipment = (ResEquipment)appointment.Resource;
                }
                if(transDef.ToStateDefID==StoneBreakUpRequest.States.Procedure)
                {
                    foreach(StoneBreakUpProcedure stoneBreakUpProcedure in this._StoneBreakUpRequest.StoneBreakUpProcedures)
                    {
                        this.ApplyProcedure(stoneBreakUpProcedure);
                    }
                }
            }
            this._StoneBreakUpRequest.CompleteMyNewAppoinments();
#endregion AppointmentFormStone_PostScript

            }
                }
}