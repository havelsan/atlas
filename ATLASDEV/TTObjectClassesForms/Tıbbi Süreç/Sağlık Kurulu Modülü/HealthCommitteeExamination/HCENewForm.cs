
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
    /// Sağlık Kurulu Muayenesi
    /// </summary>
    public partial class HCENewForm : EpisodeActionForm
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
#region HCENewForm_PreScript
    base.PreScript();
            if (!(this._HealthCommitteeExamination.MasterResource is ResPoliclinic && ((ResPoliclinic)this._HealthCommitteeExamination.MasterResource).PatientCallSystemInUse == true))
                this.DropStateButton(HealthCommitteeExamination.States.InsertedIntoQueue);
           
            if(this._HealthCommitteeExamination.CurrentStateDefID == HealthCommitteeExamination.States.New)
            {
                if(this._HealthCommitteeExamination.MasterAction != null && this._HealthCommitteeExamination.MasterAction is HealthCommittee)
                {
                    HealthCommittee pMaster = this._HealthCommitteeExamination.MasterAction as HealthCommittee;
                    if(!(((ITTObject)this._HealthCommitteeExamination).IsReadOnly))
                    {                       
                        this._HealthCommitteeExamination.NumberOfProcess = pMaster.NumberOfProcedure;
                        this._HealthCommitteeExamination.ReasonForExamination = pMaster.HCRequestReason.ReasonForExamination;
                    }
                }
                
                if(this._HealthCommitteeExamination.MasterAction != null && this._HealthCommitteeExamination.MasterAction is HealthCommitteeOfProfessors)
                {
                    HealthCommitteeOfProfessors pMaster = this._HealthCommitteeExamination.MasterAction as HealthCommitteeOfProfessors;                    
                    this._HealthCommitteeExamination.NumberOfProcess = pMaster.NumberOfProcedure;
                    
                    string sReasonID = TTObjectClasses.SystemParameter.GetParameterValue("HEALTHCOMMITTEEREASONFOREXAM", "");
                    if(!string.IsNullOrEmpty(sReasonID))
                    {
                        IList<ReasonForExaminationDefinition> pDefs = (IList<ReasonForExaminationDefinition>)ReasonForExaminationDefinition.GetReasonForExaminationDefinitionByID(this._HealthCommitteeExamination.ObjectContext, sReasonID);
                        this._HealthCommitteeExamination.ReasonForExamination = pDefs[0];
                    }
                    else
                    {
                        ReasonForExaminationDefinition newDef = (ReasonForExaminationDefinition)this._HealthCommitteeExamination.ObjectContext.CreateObject("ReasonForExaminationDefinition");
                        //new ReasonForExaminationDefinition(this._HealthCommitteeExamination.ObjectContext);
                        newDef.Code = 99;//Temporary
                        newDef.Reason = "Profesörler Sağlık Kurulu İçin";
                        newDef.ReasonForExaminationType = ReasonForExaminationTypeEnum.HealthCommitteOfProfessors;
                        this._HealthCommitteeExamination.ReasonForExamination = newDef;
                        
                        TTObjectClasses.SystemParameter param = new TTObjectClasses.SystemParameter(this._HealthCommitteeExamination.ObjectContext);
                        param.Name = "HEALTHCOMMITTEEREASONFOREXAM";
                        param.Description = "Profesörler Sağlık Kurulu Ne Maksatla muayane edildiği parametresidir.";
                        param.Value = newDef.ObjectID.ToString();
                        
                        InfoBox.Alert("Sağlık Kurulu Muayene Edecek Birim(ler) / XXXXXX(ler) Tanımlama ekranından Profesörler Sağlık Kurulu için olan tanımı kontrol ediniz.", MessageIconEnum.InformationMessage);
                    }
                }
            }
            
            if(this._HealthCommitteeExamination.Episode.OpeningDate.HasValue && DateTime.Now.Subtract(this._HealthCommitteeExamination.Episode.OpeningDate.Value).Days < 30)
                this.DropStateButton(HealthCommitteeExamination.States.PatientNoShown);
#endregion HCENewForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HCENewForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            this.CreateQueueItem(transDef);
#endregion HCENewForm_ClientSidePostScript

        }

#region HCENewForm_ClientSideMethods
        /*
        private void CreateQueueItem(TTObjectStateTransitionDef transDef)
        {
            if(transDef != null && transDef.ToStateDefID == HealthCommitteeExamination.States.InsertedIntoQueue)
            {
                if(this._HealthCommitteeExamination.MasterResource is ResPoliclinic && ((ResPoliclinic)this._HealthCommitteeExamination.MasterResource).PatientCallSystemInUse == true)
                {
                    ExaminationQueueDefinition queueDef = null;
                    queueDef = this.SelectQueue(this._HealthCommitteeExamination.ObjectContext,this._HealthCommitteeExamination.MasterResource,false);
                    
                    if(queueDef == null)
                        throw new Exception("Hastanın ekleneceği sıra seçilmedi.");
                    else
                    {
                        ResUser queueUser = this.SelectQueueUser(this._HealthCommitteeExamination.ObjectContext,queueDef,false);
                        if(queueUser != null)
                        {
                            this.SetAuthorizedUserByQueueUser(queueUser,(EpisodeAction)this._HealthCommitteeExamination);
                            if(this._HealthCommitteeExamination.AuthorizedUsers.Count > 0)
                            {
                                AuthorizedUser authorizedUser = this._HealthCommitteeExamination.AuthorizedUsers[this._HealthCommitteeExamination.AuthorizedUsers.Count-1];
                                this._HealthCommitteeExamination.ProcedureDoctor=authorizedUser.User;
                            }
                        }
                        else
                        {
                            string uKey = ShowBox.Show(ShowBoxTypeEnum.Message,"Evet,Hayır","E,H","Uyarı","Doktor Atama","Doktor atama yapmadan devam etmek istediğinize emin misiniz?",2);
                            if(String.IsNullOrEmpty(uKey) == true || uKey == "H")
                                throw new Exception("İşlemden vazgeçildi.");
                        }
                        
                        bool isEmergency = false;
                        if(this._HealthCommitteeExamination.FromResource is ResClinic)
                        {
                            if(((ResClinic)this._HealthCommitteeExamination.FromResource).IsEmergencyClinic == true)
                                isEmergency = true;
                        }
                        ExaminationQueueItem queueItem = null;
                        queueItem = this._HealthCommitteeExamination.CreateExaminationQueueItem(this._HealthCommitteeExamination.SubEpisode.PatientAdmission,queueDef,isEmergency);
                        if(queueItem == null)
                            throw new Exception("Hastanın " + queueDef.Name + " kuyruğunda aktif bir sırası zaten mevcut. Sıraya ekleme yapılamaz.");
                    }
                }
            }
        }
         */
        
#endregion HCENewForm_ClientSideMethods
    }
}