
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
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi 
    /// </summary>
    public partial class HCOHTransferDocumentConstitutionForm : EpisodeActionForm
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
#region HCOHTransferDocumentConstitutionForm_PreScript
    base.PreScript();
           
            string sentOtherResources = "";
            /*
            if (this._EpisodeAction.ProcedureDoctor == null && (Common.CurrentResource.UserType == UserTypeEnum.Doctor || Common.CurrentResource.UserType == UserTypeEnum.Dentist))
            {
                if(!(((ITTObject)_EpisodeAction).IsReadOnly))
                {
                    this._EpisodeAction.ProcedureDoctor = Common.CurrentResource;
                }
            }
            
            if(!((ITTObject)this._HealthCommitteeExaminationFromOtherHospitals).IsReadOnly)
            {
                ResUser requester = ((HealthCommittee)this._HealthCommitteeExaminationFromOtherHospitals.MasterAction).Requester;
                this._HealthCommitteeExaminationFromOtherHospitals.Doctor = requester;
            }
             */
            
            //if(this._HealthCommitteeExaminationFromOtherHospitals.MasterAction != null && this._HealthCommitteeExaminationFromOtherHospitals.MasterAction is HealthCommittee)
            //{
            //    HealthCommittee pMaster = this._HealthCommitteeExaminationFromOtherHospitals.MasterAction as HealthCommittee;
            //    if(!(((ITTObject)this._HealthCommitteeExaminationFromOtherHospitals).IsReadOnly))
            //    {
            //        if (pMaster.HCRequestReason.ReasonForExamination != null)
            //            this._HealthCommitteeExaminationFromOtherHospitals.RequestExplanation = pMaster.HCRequestReason.ReasonForExamination.Reason + "\r\n" + pMaster.ReasonForRequest + "\r\n" + this._HealthCommitteeExaminationFromOtherHospitals.RequestExplanation;
            //        else
            //            this._HealthCommitteeExaminationFromOtherHospitals.RequestExplanation = pMaster.ReasonForRequest + "\r\n" + this._HealthCommitteeExaminationFromOtherHospitals.RequestExplanation;
            //    }
            //}
            
            if (this._HealthCommitteeExaminationFromOtherHospitals.RequesterHospital == null)
            {
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID",Guid.Empty.ToString()));
                BindingList<ResOtherHospital> requesterHospitalList = ResOtherHospital.GetBySite(this._HealthCommitteeExaminationFromOtherHospitals.ObjectContext,siteID);
                foreach(ResOtherHospital requesterHospital in requesterHospitalList)
                {
                    this._HealthCommitteeExaminationFromOtherHospitals.RequesterHospital = requesterHospital;
                    break;
                }
            }
            
            // XXXXXX XXXXXX veya Dış XXXXXX olmasına göre geçilecek state i değiştirir
            if(this._HealthCommitteeExaminationFromOtherHospitals.Hospitals != null)
            {
                if(this._HealthCommitteeExaminationFromOtherHospitals.Hospitals is ResOtherHospital && this._HealthCommitteeExaminationFromOtherHospitals.ReferableResource != null)
                    this.DropStateButton(HealthCommitteeExaminationFromOtherHospitals.States.ExternalHospitalDecisionRegistration);
                else
                    this.DropStateButton(HealthCommitteeExaminationFromOtherHospitals.States.DecisionRegistration);
                
                if(this._HealthCommitteeExaminationFromOtherHospitals.Hospitals is ResOtherHospital && this._HealthCommitteeExaminationFromOtherHospitals.ReferableResource != null)
                {
                    if(this._HealthCommitteeExaminationFromOtherHospitals.MasterAction != null && this._HealthCommitteeExaminationFromOtherHospitals.MasterAction.LinkedActions.Count > 0)
                    {
                        foreach (BaseAction action in this._HealthCommitteeExaminationFromOtherHospitals.MasterAction.LinkedActions)
                        {
                            if (action is HealthCommitteeExaminationFromOtherHospitals && this._HealthCommitteeExaminationFromOtherHospitals.Hospitals == ((HealthCommitteeExaminationFromOtherHospitals)action).Hospitals && ((HealthCommitteeExaminationFromOtherHospitals)action).ReferableResource != null && ((HealthCommitteeExaminationFromOtherHospitals)action).CurrentStateDefID == HealthCommitteeExaminationFromOtherHospitals.States.New && this._HealthCommitteeExaminationFromOtherHospitals.ReferableResource != ((HealthCommitteeExaminationFromOtherHospitals)action).ReferableResource)
                                sentOtherResources += ((HealthCommitteeExaminationFromOtherHospitals)action).ReferableResource.ToString() + " , ";
                        }
                        if (!string.IsNullOrEmpty(sentOtherResources))
                            this._HealthCommitteeExaminationFromOtherHospitals.SentOtherResources = sentOtherResources.Substring(0, (sentOtherResources.Length - 3));
                        else
                            this._HealthCommitteeExaminationFromOtherHospitals.SentOtherResources = "";
                    }
                }
                
                if(this._HealthCommitteeExaminationFromOtherHospitals.Hospitals is ExternalHospitalDefinition && this._HealthCommitteeExaminationFromOtherHospitals.Speciality != null)
                {
                    if(this._HealthCommitteeExaminationFromOtherHospitals.MasterAction != null && this._HealthCommitteeExaminationFromOtherHospitals.MasterAction.LinkedActions.Count > 0)
                    {
                        foreach (BaseAction action in this._HealthCommitteeExaminationFromOtherHospitals.MasterAction.LinkedActions)
                        {
                            if (action is HealthCommitteeExaminationFromOtherHospitals && this._HealthCommitteeExaminationFromOtherHospitals.Hospitals == ((HealthCommitteeExaminationFromOtherHospitals)action).Hospitals && ((HealthCommitteeExaminationFromOtherHospitals)action).Speciality != null && ((HealthCommitteeExaminationFromOtherHospitals)action).CurrentStateDefID == HealthCommitteeExaminationFromOtherHospitals.States.New && this._HealthCommitteeExaminationFromOtherHospitals.Speciality != ((HealthCommitteeExaminationFromOtherHospitals)action).Speciality)
                                sentOtherResources += ((HealthCommitteeExaminationFromOtherHospitals)action).Speciality.ToString() + " , ";
                        }
                        if (!string.IsNullOrEmpty(sentOtherResources))
                            this._HealthCommitteeExaminationFromOtherHospitals.SentOtherResources = sentOtherResources.Substring(0, (sentOtherResources.Length - 3));
                        else
                            this._HealthCommitteeExaminationFromOtherHospitals.SentOtherResources = "";
                    }
                }
                
            }
#endregion HCOHTransferDocumentConstitutionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HCOHTransferDocumentConstitutionForm_PostScript
    base.PostScript(transDef);
            
            if(transDef != null && (transDef.ToStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.DecisionRegistration) || transDef.ToStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.ExternalHospitalDecisionRegistration)))
            {
                this._HealthCommitteeExaminationFromOtherHospitals.Doctor = null;
                //this._HealthCommitteeExaminationFromOtherHospitals.Speciality = null;
            }
#endregion HCOHTransferDocumentConstitutionForm_PostScript

            }
            
#region HCOHTransferDocumentConstitutionForm_Methods
        /*
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.DecisionRegistration))
                this._HealthCommitteeExaminationFromOtherHospitals.RunSendHealthCommitteeExaminationFromOtherHospitals();
        }
        */
        
#endregion HCOHTransferDocumentConstitutionForm_Methods
    }
}