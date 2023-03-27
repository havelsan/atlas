
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Hasta Kabul Iptal
    /// </summary>
    public  partial class PatientAdmissionCancellation : EpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            

//            if(this.Episode.IsMedulaEpisode())
//            {
//                if(this.SubEpisode.PatientAdmission != null && this.SubEpisode.PatientAdmission.MedulaProvision != null)
//                {
//                    if(!string.IsNullOrEmpty(this.SubEpisode.PatientAdmission.MedulaProvision.ProvisionNo))
//                    {
//                        if(this.Episode.isMedulaProvisionUsedAsRelatedProvision(this.SubEpisode.PatientAdmission.MedulaProvision.ProvisionNo) == true)
//                            throw new TTUtils.TTException("Bu takipten sonra bu takibe bağlı başka takipler alınmış.Öncelikle onları silmelisiniz.");
//                        else
//                        {                            
//                            if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Mevcut provizyon iptal edilecek. Devam etmek istediğinize emin misiniz?") == "H")
//                                throw new TTUtils.TTException("İşlemden vazgeçildi");                                                        
//                            if(this.SubEpisode.PatientAdmission.MedulaProvision != null && this.SubEpisode.PatientAdmission.MedulaProvision.ProvisionNo != null)
//                            {
//                                string takipNo = Episode.PatientAdmission.MedulaProvision.ProvisionNo;
//                                HastaKabulIslemleri.takipSilGirisDVO takipSilGirisDVO = new HastaKabulIslemleri.takipSilGirisDVO();
//                                takipSilGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
//                                takipSilGirisDVO.takipNo = Episode.PatientAdmission.MedulaProvision.ProvisionNo;
//                                HastaKabulIslemleri.takipSilCevapDVO response = HastaKabulIslemleri.WebMethods.hastaKabulIptalSync(TTObjectClasses.Sites.SiteLocalHost, takipSilGirisDVO);
//                                
//                                if(response.sonucKodu != "0000")
//                                    throw new TTUtils.TTException(response.sonucMesaji);
//                                else
//                                {
//                                    TTVisual.InfoBox.Show("Hastanın " + takipNo + " kodlu takibi silinmiştir.", MessageIconEnum.InformationMessage);
//                                    XXXXXXMedulaServices.HastaKabulIptalParam hastaKabulIptalParam = new XXXXXXMedulaServices.HastaKabulIptalParam(takipSilGirisDVO, this.SubEpisode.PatientAdmission.MedulaProvision.ObjectID.ToString());
//                                    hastaKabulIptalParam.HastaKabulIptalCompletedInternal(response, takipSilGirisDVO, this.SubEpisode.PatientAdmission.MedulaProvision.ObjectID.ToString(), this.ObjectContext);
//                                    
//                                    // Hasta Kabul formundaki bilgi mesajı düzeltildi.
//                                    this.SubEpisode.PatientAdmission.SetTakipAlAreaTextMessage("Takip Silindi");
//                                    this.SubEpisode.PatientAdmission.takipAlHataMesaji = "";
//                                    
//                                    //Medula Provision iptal
//                                    this.SubEpisode.PatientAdmission.MedulaProvision.ProvisionNo = string.Empty;
//                                    this.SubEpisode.PatientAdmission.MedulaProvision.Status = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
//                                    this.SubEpisode.PatientAdmission.MedulaProvision.CurrentStateDefID = MedulaProvision.States.Cancelled;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
            
            // Muayene iptal edildi
            if(Episode.PatientExaminations != null)
            {
                if(Episode.PatientExaminations.Count > 0)
                {
                    PatientExamination patientExamination = (PatientExamination)Episode.PatientExaminations[0];
                    if(patientExamination.CurrentStateDefID != PatientExamination.States.Cancelled)
                        patientExamination.CurrentStateDefID = PatientExamination.States.Cancelled;
                }
            }
            
            //Diş Muayenesi iptal edildi
            //if(this.Episode.DentalExaminations != null)
            //{
            //    if(this.Episode.DentalExaminations.Count > 0)
            //    {
            //        DentalExamination dentalExamination = (DentalExamination)Episode.DentalExaminations[0];
            //        if(dentalExamination.CurrentStateDefID != DentalExamination.States.Cancelled)
            //            dentalExamination.CurrentStateDefID = DentalExamination.States.Cancelled;
            //    }
            //}
            
            //Hasta Kabul iptal state'ine alınır
            //Hasta kabul iptalden sonra hasta kabul düzeltmede 'iptal edilmiş nesnenin özelliği değiştirilemez' hatası alındığından kapatıldı MC
//            foreach (TTObjectStateTransitionDef transDef in this.SubEpisode.PatientAdmission.CurrentStateDef.SortedOutgoingTransitions.Values)
//            {
//                if(transDef.ToStateDef.Status == StateStatusEnum.Cancelled)
//                    this.SubEpisode.PatientAdmission.CurrentStateDefID = transDef.ToStateDefID;
//            }                      
            
            // Episode State'i AçıkDevam durumuna getirildi.
            if(Episode != null)
                Episode.CurrentStateDefID = Episode.States.ClosedToNew ;

            if(SubEpisode != null)  // && !this.SubEpisode.SGKSEP.MedulaSonucKodu.Equals("0001")  kontrolü vardı kaldırıldı, gerekirse eklenecek (MDZ)
                SubEpisode.CancelSubEpisodeProtocols();

#endregion PostTransition_New2Completed
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.PatientAdmissionCancellation;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientAdmissionCancellation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.New && toState == States.Completed)
                PostTransition_New2Completed();
        }

    }
}