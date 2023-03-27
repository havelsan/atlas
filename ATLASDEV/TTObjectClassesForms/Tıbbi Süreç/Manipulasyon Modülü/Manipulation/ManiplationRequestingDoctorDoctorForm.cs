
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManiplationRequestingDoctorDoctorForm : EpisodeActionForm
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
#region ManiplationRequestingDoctorDoctorForm_PreScript
    base.PreScript();
            
            if(Common.CurrentDoctor == null)
                this.GridDiagnosis.ReadOnly = true;
            else
                this.GridDiagnosis.ReadOnly = false;
#endregion ManiplationRequestingDoctorDoctorForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ManiplationRequestingDoctorDoctorForm_PostScript
    base.PostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID != Manipulation.States.Cancelled)
                {
                    if(this._Manipulation.ManipulationRequest != null && !(this._Manipulation.ManipulationRequest.MasterAction is HealthCommitteeExaminationFromOtherDepartments) && !(this._Manipulation.ManipulationRequest.MasterAction is HealthCommittee))
                    {
                    if (this._Manipulation.Episode.Diagnosis.Count <= 0)
                        if (this._Manipulation.Diagnosis.Count <= 0)
                            throw new Exception(SystemMessage.GetMessage(635));
                    }
                }
                //                if(transDef.ToStateDefID==Manipulation.States.DoctorProcedure)
                //                {
                //                    TTFormClasses.StringEntryForm frm = new TTFormClasses.StringEntryForm();
                //                    this._Manipulation.ReasonToContinue=frm.ShowAndGetStringForm("İşleme Devam Etme Sebebi");
                //                }
            }
#endregion ManiplationRequestingDoctorDoctorForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ManiplationRequestingDoctorDoctorForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            //TODO Medula!
            //if(transDef != null)
            //{
            //    //RequestingDoctorFromDoctorProcedure-ToDoctorProcedure
            //    if(transDef.FromStateDefID == Manipulation.States.RequestingDoctorFromDoctorProcedure && transDef.ToStateDefID == Manipulation.States.DoctorProcedure)
            //    {
            //         // Medula Takip İşlemleri
            //        if (_Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(this._Manipulation.Episode) == true && 
            //             _Manipulation.IsMedulaProvisionNecessaryProcedureExists() == true)
            //        {
            //            if(_Manipulation.IsGunubirlikTakip == true){
            //                if (_Manipulation.MedulaProvision == null)
            //                {
            //                    MedulaProvision _medulaProvision = new MedulaProvision(_Manipulation.ObjectContext);
            //                    _Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
            //                    _Manipulation.MedulaProvision = _medulaProvision;
            //                }
            //                _Manipulation.GetManipulationMedulaTakip();
            //            }
            //            else
            //            {
            //                string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Uyarı", "Günübirlik Takip Al alanı işaretlenmediğinden takip alınmadan işleme devam edilecektir.Devam Etmek İstiyor Musunuz?");
            //                if (result == "V")
            //                {
            //                    InfoBox.Alert("Takip almak için Günübirlik Takip Al alanını işaretleyip gerekli alanları doldurmalısınız.", MessageIconEnum.InformationMessage );
            //                    return;
            //                } 
            //            }
            //        }
            //    }
            //}
#endregion ManiplationRequestingDoctorDoctorForm_ClientSidePostScript

        }

#region ManiplationRequestingDoctorDoctorForm_Methods
        //        protected override void OnOkClick(TTObjectStateTransitionDef transDef)
        //        {
        //            if(transDef!=null)
        //            {
        //                if(transDef.ToStateDefID==Manipulation.States.DoctorProcedure)
        //                {
        //                    TTFormClasses.StringEntryForm frm = new TTFormClasses.StringEntryForm();
        //                    this._Manipulation.ReasonToContinue=frm.ShowAndGetStringForm("İşleme Devam Etme Sebebi");
        //                }
        //            }
        //            base.OnOkClick(transDef);
        //        }
        
#endregion ManiplationRequestingDoctorDoctorForm_Methods
    }
}