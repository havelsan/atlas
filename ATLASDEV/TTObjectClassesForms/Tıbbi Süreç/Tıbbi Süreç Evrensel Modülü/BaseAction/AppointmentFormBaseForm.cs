
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
    public partial class AppointmentFormBase : TTForm
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
#region AppointmentFormBase_PreScript
    int index = 0;

            this.tttextboxDescription.Text = string.Empty;
            //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars = ScrollBars.Vertical;

            if (this._BaseAction.GetStateHistory().Count > 1)
            {
                index = this._BaseAction.GetStateHistory().Count - 1;
                if (this._BaseAction.GetStateHistory()[index].IsUndo == true)
                {
                    this.tttextboxDescription.Text = BaseAction.GetFullCompletedAppointmentDescription(this._BaseAction);
                }
                else
                {
                    this.tttextboxDescription.Text = BaseAction.GetFullAppointmentDescription(this._BaseAction);
                }
            }
            else
            {
                this.tttextboxDescription.Text = BaseAction.GetFullAppointmentDescription(this._BaseAction);
            }
#endregion AppointmentFormBase_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AppointmentFormBase_PostScript
            // TODO ServerSideFormPosta taþý!
    //if (transDef != null)
    //            this._BaseAction.CompleteMyNewAppoinments();
            var a = 1;
#endregion AppointmentFormBase_PostScript

            }
                }
}