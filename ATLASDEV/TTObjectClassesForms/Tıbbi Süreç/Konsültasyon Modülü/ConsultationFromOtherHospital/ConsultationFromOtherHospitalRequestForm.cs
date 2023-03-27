
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
    /// Diğer XXXXXXlerden Konsültasyon 
    /// </summary>
    public partial class ConsultationFromOtherHospitalRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            RequestedDepartment.SelectedObjectChanged += new TTControlEventDelegate(RequestedDepartment_SelectedObjectChanged);
            RequestedHospital.SelectedObjectChanged += new TTControlEventDelegate(RequestedHospital_SelectedObjectChanged);
            RequesterDepartment.SelectedObjectChanged += new TTControlEventDelegate(RequesterDepartment_SelectedObjectChanged);
            RequesterDoctor.SelectedObjectChanged += new TTControlEventDelegate(RequesterDoctor_SelectedObjectChanged);
            RequestedExternalHospital.SelectedObjectChanged += new TTControlEventDelegate(RequestedExternalHospital_SelectedObjectChanged);
            RequestedExternalDepartment.SelectedObjectChanged += new TTControlEventDelegate(RequestedExternalDepartment_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RequestedDepartment.SelectedObjectChanged -= new TTControlEventDelegate(RequestedDepartment_SelectedObjectChanged);
            RequestedHospital.SelectedObjectChanged -= new TTControlEventDelegate(RequestedHospital_SelectedObjectChanged);
            RequesterDepartment.SelectedObjectChanged -= new TTControlEventDelegate(RequesterDepartment_SelectedObjectChanged);
            RequesterDoctor.SelectedObjectChanged -= new TTControlEventDelegate(RequesterDoctor_SelectedObjectChanged);
            RequestedExternalHospital.SelectedObjectChanged -= new TTControlEventDelegate(RequestedExternalHospital_SelectedObjectChanged);
            RequestedExternalDepartment.SelectedObjectChanged -= new TTControlEventDelegate(RequestedExternalDepartment_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void RequestedDepartment_SelectedObjectChanged()
        {
#region ConsultationFromOtherHospitalRequestForm_RequestedDepartment_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(this.RequestedDepartment.DataMember);
#endregion ConsultationFromOtherHospitalRequestForm_RequestedDepartment_SelectedObjectChanged
        }

        private void RequestedHospital_SelectedObjectChanged()
        {
#region ConsultationFromOtherHospitalRequestForm_RequestedHospital_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(this.RequestedHospital.DataMember);
#endregion ConsultationFromOtherHospitalRequestForm_RequestedHospital_SelectedObjectChanged
        }

        private void RequesterDepartment_SelectedObjectChanged()
        {
#region ConsultationFromOtherHospitalRequestForm_RequesterDepartment_SelectedObjectChanged
   if(this._ConsultationFromOtherHospital.RequesterResource != null)
                this._ConsultationFromOtherHospital.RequesterResourceName = this._ConsultationFromOtherHospital.RequesterResource.Name;
#endregion ConsultationFromOtherHospitalRequestForm_RequesterDepartment_SelectedObjectChanged
        }

        private void RequesterDoctor_SelectedObjectChanged()
        {
#region ConsultationFromOtherHospitalRequestForm_RequesterDoctor_SelectedObjectChanged
   if(this._ConsultationFromOtherHospital.RequesterDoctor!=null)
                this._ConsultationFromOtherHospital.RequesterDoctorName=this._ConsultationFromOtherHospital.RequesterDoctor.Name;
#endregion ConsultationFromOtherHospitalRequestForm_RequesterDoctor_SelectedObjectChanged
        }

        private void RequestedExternalHospital_SelectedObjectChanged()
        {
#region ConsultationFromOtherHospitalRequestForm_RequestedExternalHospital_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(RequestedExternalHospital.DataMember);
#endregion ConsultationFromOtherHospitalRequestForm_RequestedExternalHospital_SelectedObjectChanged
        }

        private void RequestedExternalDepartment_SelectedObjectChanged()
        {
#region ConsultationFromOtherHospitalRequestForm_RequestedExternalDepartment_SelectedObjectChanged
   SetInternalOrExternalFieldsEnabling(RequestedExternalDepartment.DataMember);
#endregion ConsultationFromOtherHospitalRequestForm_RequestedExternalDepartment_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region ConsultationFromOtherHospitalRequestForm_PreScript
    base.PreScript();
            if(this._ConsultationFromOtherHospital.CurrentStateDefID != ConsultationFromOtherHospital.States.Rejected)
            {
                this.labelReasonOfReject.Visible = false;
                this.ReasonOfReject.Visible = false;
            }
            
            if (this.RequesterHospital.SelectedObject == null)
            {
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID",Guid.Empty.ToString()));
                BindingList<ResOtherHospital> requesterHospitalList = ResOtherHospital.GetBySite(this._ConsultationFromOtherHospital.ObjectContext,siteID);
                foreach(ResOtherHospital requesterHospital in requesterHospitalList)
                {
                    this.RequesterHospital.SelectedObject = requesterHospital;
                    break;
                }
            }
            
            if (this.RequesterDepartment.SelectedObject == null)
            {
                this.RequesterDepartment.SelectedObject = (ResSection)this._ConsultationFromOtherHospital.MasterResource;
                this._ConsultationFromOtherHospital.RequesterResourceName = ((ResSection)this._ConsultationFromOtherHospital.MasterResource).Name;
            }
            if (this.RequesterDoctor.SelectedObject == null)
            {
                ResUser currentUser = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                if (currentUser.UserType == UserTypeEnum.Doctor){
                    this.RequesterDoctor.SelectedObject = (ResUser)TTStorageManager.Security.TTUser.CurrentUser.UserObject;
                    this._ConsultationFromOtherHospital.RequesterDoctorName=this._ConsultationFromOtherHospital.RequesterDoctor.Name;
                }
            }
            
            if (this._ConsultationFromOtherHospital.CurrentStateDefID == ConsultationFromOtherHospital.States.Request)
            {
                this.labelProtocolNo.Visible = false;
                this.ProtocolNo.Visible = false;
            }
            else
            {
                this.labelProtocolNo.Visible = true;
                this.ProtocolNo.Visible = true;
            }
            
            if (this._ConsultationFromOtherHospital.CurrentStateDefID == ConsultationFromOtherHospital.States.Approval)
            {
                if (this.RequestedHospital.SelectedObject != null && this.RequestedDepartment.SelectedObject != null)
                    this.DropStateButton(ConsultationFromOtherHospital.States.ResultEntry);
                else if(this.RequestedExternalHospital.SelectedObject != null && this.RequestedExternalDepartment.SelectedObject != null)
                    this.DropStateButton(ConsultationFromOtherHospital.States.ConsultationInOtherHospital);
                
                if (this.RequestedHospital.SelectedObject != null || this.RequestedDepartment.SelectedObject != null)
                {
                    this.RequestedExternalHospital.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = true;
                }
                else if (this.RequestedExternalHospital.SelectedObject != null || this.RequestedExternalDepartment.SelectedObject != null)
                {
                    this.RequestedHospital.ReadOnly = true;
                    this.RequestedDepartment.ReadOnly = true;
                }
                
                this.RequesterDoctor.ReadOnly = true;
                this.SecDiagnosisGrid.ReadOnly = true;
                this.Symptom.ReadOnly = true;
                this.RequestDescription.ReadOnly = true;
                this.RequestedDepartment.ReadOnly = true;
                this.RequestedHospital.ReadOnly = true;
                this.RequestedExternalDepartment.ReadOnly = true;
                this.RequestedExternalHospital.ReadOnly = true;
            }

#endregion ConsultationFromOtherHospitalRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ConsultationFromOtherHospitalRequestForm_PostScript
    base.PostScript(transDef);
            
            if (this.RequestedHospital.SelectedObject != null && this.RequestedDepartment.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(1184));
            if (this.RequestedHospital.SelectedObject == null && this.RequestedDepartment.SelectedObject != null)
                throw new Exception(SystemMessage.GetMessage(1185));
            if (this.RequestedExternalHospital.SelectedObject != null && this.RequestedExternalDepartment.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(1186));
            if (this.RequestedExternalHospital.SelectedObject == null && this.RequestedExternalDepartment.SelectedObject != null)
                throw new Exception(SystemMessage.GetMessage(1187));
            if (this.RequestedHospital.SelectedObject == null && this.RequestedDepartment.SelectedObject == null &&
                this.RequestedExternalHospital.SelectedObject == null && this.RequestedExternalDepartment.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(1188));
#endregion ConsultationFromOtherHospitalRequestForm_PostScript

            }
            
#region ConsultationFromOtherHospitalRequestForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == ConsultationFromOtherHospital.States.ConsultationInOtherHospital)
                this._ConsultationFromOtherHospital.RunSendConsultationFromOtherHospital();
        }
        
#endregion ConsultationFromOtherHospitalRequestForm_Methods

#region ConsultationFromOtherHospitalRequestForm_ClientSideMethods
        private void SetInternalOrExternalFieldsEnabling(string dataMember)
        {
            if (dataMember == this.RequestedHospital.DataMember)
            {
                if(this.RequestedHospital.SelectedObject != null)
                {
                    this.RequestedDepartment.ReadOnly = false;
                    this.RequestedExternalHospital.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = true;
                    this.RequestedDepartment.SelectedObject = null;
                    this.RequestedExternalHospital.SelectedObject = null;
                    this.RequestedExternalDepartment.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedDepartment.SelectedObject == null)
                    {
                        this.RequestedExternalHospital.ReadOnly = false;
                        this.RequestedExternalDepartment.ReadOnly = false;
                    }
                }
            }
            else if (dataMember == this.RequestedDepartment.DataMember)
            {
                if(this.RequestedDepartment.SelectedObject != null)
                {
                    this.RequestedHospital.ReadOnly = false;
                    this.RequestedExternalHospital.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = true;
                    this.RequestedExternalHospital.SelectedObject = null;
                    this.RequestedExternalDepartment.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedHospital.SelectedObject == null)
                    {
                        this.RequestedExternalHospital.ReadOnly = false;
                        this.RequestedExternalDepartment.ReadOnly = false;
                    }
                }
            }
            else if (dataMember == this.RequestedExternalHospital.DataMember)
            {
                if(this.RequestedExternalHospital.SelectedObject != null)
                {
                    this.RequestedHospital.ReadOnly = true;
                    this.RequestedDepartment.ReadOnly = true;
                    this.RequestedExternalDepartment.ReadOnly = false;
                    this.RequestedHospital.SelectedObject = null;
                    this.RequestedDepartment.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedExternalDepartment.SelectedObject == null)
                    {
                        this.RequestedHospital.ReadOnly = false;
                        this.RequestedDepartment.ReadOnly = false;
                    }
                }
            }
            else if (dataMember == this.RequestedExternalDepartment.DataMember)
            {
                if(this.RequestedExternalDepartment.SelectedObject != null)
                {
                    this.RequestedHospital.ReadOnly = true;
                    this.RequestedDepartment.ReadOnly = true;
                    this.RequestedExternalHospital.ReadOnly = false;
                    this.RequestedHospital.SelectedObject = null;
                    this.RequestedDepartment.SelectedObject = null;
                }
                else
                {
                    if(this.RequestedExternalHospital.SelectedObject == null)
                    {
                        this.RequestedHospital.ReadOnly = false;
                        this.RequestedDepartment.ReadOnly = false;
                    }
                }
            }
            else
            {
                InfoBox.Show("Tanımsız DataMember.(" + dataMember + "). Lütfen Bilgi İşlemi arayınız.");
            }
        }
        
#endregion ConsultationFromOtherHospitalRequestForm_ClientSideMethods
    }
}