
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
    /// Diğer Birim(ler)den Sağlık Kurulu Muayenesi 
    /// </summary>
    public partial class HCEODNewForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
           
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            
            base.UnBindControlEvents();
        }

       

        protected override void ClientSidePreScript()
        {
#region HCEODNewForm_ClientSidePreScript
    base.ClientSidePreScript();
            SelectHCActionToBeLinked();
            // Secilen Heyet Kabul adımındaki SK  ya da  Diğer Birim(ler)den SKM İstek / red dışındaki işlemler  Önceki Havale Edilen XXXXXX ve Birimler gridine set edilir.
            if(_HealthCommitteeExaminationFromOtherDepartments.CurrentStateDefID == HealthCommitteeExaminationFromOtherDepartments.States.New )
            {
                if(this._HealthCommitteeExaminationFromOtherDepartments.HCActionToBeLinked != null)
                {
                    HealthCommittee pMaster = this._HealthCommitteeExaminationFromOtherDepartments.HCActionToBeLinked as HealthCommittee;
                    if(pMaster != null)
                        this._HealthCommitteeExaminationFromOtherDepartments.ReasonForExamination = pMaster.HCRequestReason.ReasonForExamination;
                }         
            }
#endregion HCEODNewForm_ClientSidePreScript

        }

#region HCEODNewForm_ClientSideMethods
        private void SelectHCActionToBeLinked()
        {
            ArrayList healthCommitteeActionList = new ArrayList();
            foreach(EpisodeAction episodeAction in this._HealthCommitteeExaminationFromOtherDepartments.Episode.EpisodeActions)
            {
                if(episodeAction is HealthCommittee && !episodeAction.IsCancelled)
                {
                    HealthCommittee healthCommittee = episodeAction as HealthCommittee;
                    healthCommitteeActionList.Add(healthCommittee);
                }
            }
            
            if(healthCommitteeActionList.Count == 0)
                throw new TTException("Vakada Sağlık Kurulu işlemi bulunmadığından hastanın durumu bu işlem için uygun değildir.");
            
            MultiSelectForm pForm = new MultiSelectForm();
            foreach(HealthCommittee healthCommittee in healthCommitteeActionList)
                pForm.AddMSItem("İşlem No :" + healthCommittee.ID.ToString(), healthCommittee.ObjectID.ToString(), healthCommittee);
            
            pForm.GetMSItem(this, "İlgili Sağlık Kurulu işlemini seçiniz");
            if(!((ITTObject)(HealthCommittee)pForm.MSSelectedItemObject).IsReadOnly)
            {
                HealthCommittee healthCommittee = pForm.MSSelectedItemObject as HealthCommittee;                
                this._HealthCommitteeExaminationFromOtherDepartments.HCActionToBeLinked = healthCommittee;
            }
        }
        
#endregion HCEODNewForm_ClientSideMethods
    }
}