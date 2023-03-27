
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
    /// Birimlerarası Nakil 
    /// </summary>
    public partial class PatientTransferRequestForm : EpisodeActionForm
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
#region PatientTransferRequestForm_PreScript
    base.PreScript();
            

                if(this._PatientTransfer.OldInPatientTrtmentClinicApp != null && this._PatientTransfer.OldInPatientTrtmentClinicApp.BaseInpatientAdmission != null)
                {
                    if(this._PatientTransfer.OldInPatientTrtmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
                        this.QuarantineProtocolNo.Text = ((InpatientAdmission)this._PatientTransfer.OldInPatientTrtmentClinicApp.BaseInpatientAdmission).QuarantineProtocolNo.ToString();
                }
            
            if(string.IsNullOrEmpty(this._PatientTransfer.ReturnToRequestReason) && string.IsNullOrEmpty(this._PatientTransfer.ReturnToRequestByClinicReason))
            {
                this.Height=340;
                this.ReturnToRequestReason.Visible=false;
                this.labelReturnToRequestReason.Visible=false;
                this.ReturnToRequestClinicReason.Visible=false;
                this.labelReturnToRequestClinicReason.Visible=false;
            }
            else
            {
                this.Height=460;
                this.ReturnToRequestReason.Visible=true;
                this.labelReturnToRequestReason.Visible=true;
                this.ReturnToRequestClinicReason.Visible=true;
                this.labelReturnToRequestClinicReason.Visible=true;
            }
              this.TreatmentClinic.ListFilterExpression = "OBJECTID<>'" + this.RequestClinic.SelectedObjectID + "'";
            if(((ITTObject)this._PatientTransfer).IsNew)
            {
                this.DropStateButton(PatientTransfer.States.Cancelled);
            }
#endregion PatientTransferRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientTransferRequestForm_PostScript
    //MCA
           
           

            


    //MCA
#endregion PatientTransferRequestForm_PostScript

            }
                }
}