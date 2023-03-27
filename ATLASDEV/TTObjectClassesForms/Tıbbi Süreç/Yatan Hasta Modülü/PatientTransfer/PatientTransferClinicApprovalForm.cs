
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
    public partial class PatientTransferClinicApprovalForm : EpisodeActionForm
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
#region PatientTransferClinicApprovalForm_PreScript
    base.PreScript();
            
                if(this._PatientTransfer.OldInPatientTrtmentClinicApp != null && this._PatientTransfer.OldInPatientTrtmentClinicApp.BaseInpatientAdmission != null)
                {
                    if(this._PatientTransfer.OldInPatientTrtmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
                        this.QuarantineProtocolNo.Text = ((InpatientAdmission)this._PatientTransfer.OldInPatientTrtmentClinicApp.BaseInpatientAdmission).QuarantineProtocolNo.ToString();
                }
            
            if(this.RoomGroup.SelectedValue==null)
                this.SetFirstEmptyBedByTreatmentClinic();
              
            this.DropStateButton(PatientTransfer.States.Cancelled);
#endregion PatientTransferClinicApprovalForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientTransferClinicApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(transDef!=null)
            {
                if(transDef.ToStateDefID==PatientTransfer.States.Request)
                {
                    StringEntryForm frm = new StringEntryForm();
                    this._PatientTransfer.ReturnToRequestByClinicReason= frm.ShowAndGetStringForm("İstek İade Sebebi");
                }
            }
#endregion PatientTransferClinicApprovalForm_ClientSidePostScript

        }

#region PatientTransferClinicApprovalForm_Methods
        protected void SetFirstEmptyBedByTreatmentClinic()
        {
            bool setValue=false;
            if(this.TreatmentClinic.SelectedValue==null)
                InfoBox.Alert("Tedavi göreceği klinik belirlenmemiştir .Lütfen bilgi işleme başvurunuz",MessageIconEnum.InformationMessage);
            else if(this.RoomGroup.SelectedValue==null )
            {
                this.Bed.SelectedObject=Common.GetFirstfEmptyBedV2((Guid)this.TreatmentClinic.SelectedObjectID);
            }
        }
        protected void SetFirstEmptyBedByRoomGroup()
        {
            bool setValue=false;
            if(this.RoomGroup.SelectedValue!=null)
            {
                if(Room.SelectedValue==null)
                {
                    setValue=true;
                    
                }
                else if(this._PatientTransfer.Room.RoomGroup!=this._PatientTransfer.RoomGroup)
                {
                    setValue=true;
                    
                }
                if(setValue)
                {
                    this.Room.SelectedValue=null;
                    this.Bed.SelectedObject=Common.GetFirstfEmptyBedV3((Guid)this.TreatmentClinic.SelectedObjectID,(Guid)this.RoomGroup.SelectedObjectID);
                }
            }
        }
        protected void SetFirstEmptyBedByRoom()
        {
            bool setValue=false;
            if(this.Room.SelectedValue!=null)
            {
                if(Bed.SelectedValue==null)
                    this.Bed.SelectedObject=Common.GetFirstfEmptyBedV4((Guid)this.TreatmentClinic.SelectedObjectID,(Guid)this.RoomGroup.SelectedObjectID,(Guid)this.Room.SelectedObjectID);
                else if (this._PatientTransfer.Bed.Room!=this._PatientTransfer.Room)
                    this.Bed.SelectedObject=Common.GetFirstfEmptyBedV4((Guid)this.TreatmentClinic.SelectedObjectID,(Guid)this.RoomGroup.SelectedObjectID,(Guid)this.Room.SelectedObjectID);
            }
        }
        
#endregion PatientTransferClinicApprovalForm_Methods
    }
}