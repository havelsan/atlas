
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
    /// XXXXXXler Arası Sevk 
    /// </summary>
    public  partial class DispatchToOtherHospital : EpisodeActionWithDiagnosis, IWorkListEpisodeAction, IAllocateSpeciality
    {
        public partial class GetDispatchInformationOfPatientNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetDispatchedPatientsNQL_Class : TTReportNqlObject 
        {
        }

        public partial class DispatchCountQuery_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_XXXXXXlerArasiSevk_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_HASTA_SEVK_Class : TTReportNqlObject 
        {
        }

        #region IAllocateSpeciality Members
        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public EpisodeAction GetMyEpisodeAction()
        {
            return MyEpisodeAction;
        }

        public void SetMyEpisodeAction(EpisodeAction value)
        {
            MyEpisodeAction = value;
        }

        public SubActionProcedure GetMySubActionProcedure()
        {
            return MySubActionProcedure;
        }

        public void SetMySubActionProcedure(SubActionProcedure value)
        {
            MySubActionProcedure = value;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "DISPATCHERDOCTOR":
                    {
                        ResUser value = (ResUser)newValue;
#region DISPATCHERDOCTOR_SetParentScript
                        if(value != null)
            {
                DispatcherDoctorName = (value.Title==null ? "" :(Common.GetDescriptionOfDataTypeEnum(value.Title.Value)+" " ))+ value.Name;
                DispatcherDoctorDiplomaRegNo = value.DiplomaRegisterNo;
                DispatcherDoctorEmploymentID = value.EmploymentRecordID;
            }
            else
            {
                DispatcherDoctorName = null;
                DispatcherDoctorDiplomaRegNo = null;
                DispatcherDoctorEmploymentID = null;
            }
#endregion DISPATCHERDOCTOR_SetParentScript
                    }
                    break;
                case "DISPATCHEDDOCTOR":
                    {
                        ResUser value = (ResUser)newValue;
#region DISPATCHEDDOCTOR_SetParentScript
                        if(value != null)
            {
                DispatchedDoctorName = (value.Title==null ? "" :(Common.GetDescriptionOfDataTypeEnum(value.Title.Value)+" " ))+ value.Name;
                DispatchedDoctorDiplomaRegNo = value.DiplomaRegisterNo;
                DispatchedDoctorEmploymentID = value.EmploymentRecordID;
            }
            else
            {
                DispatchedDoctorName = null;
                DispatchedDoctorDiplomaRegNo = null;
                DispatchedDoctorEmploymentID = null;
            }
#endregion DISPATCHEDDOCTOR_SetParentScript
                    }
                    break;
                case "REQUESTEDREFERABLEHOSPITAL":
                    {
                        ReferableHospital value = (ReferableHospital)newValue;
#region REQUESTEDREFERABLEHOSPITAL_SetParentScript
                        if(value != null)
            {
                if(value.ResOtherHospital != null)
                    RequestedSite = value.ResOtherHospital.Site;
                else
                    RequestedSite = null;
            }
            else
            {
                RequestedSite = null;
            }
#endregion REQUESTEDREFERABLEHOSPITAL_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();

#endregion PostUpdate
        }

        #region POST TRANS
        protected void PostTransition_New2SendMedula()
        {
            // From State : New   To State : SendMedula
#region PostTransition_New2SendMedula
            
            if(MutatDisiAracXXXXXXRaporID.Value == null)
                MutatDisiAracXXXXXXRaporID.GetNextValue();
            

#endregion PostTransition_New2SendMedula
        }

        protected void PostTransition_New2Dispatched()
        {
            // From State : New   To State : Dispatched
#region PostTransition_New2Dispatched
            
            /*
            try
            {
                if(this.Episode.AsalObject != null)
                {
                    if(this.RequestedSite != null && this.RequestedReferableHospital != null)
                    {
                        List<AsalObject> sendList = new List<AsalObject>();
                        AsalObject asalObject = Episode.AsalObject;
                        asalObject.XXXXXXden_Ayrilis_Tarihi = Common.RecTime();
                        sendList.Add(asalObject);
                        AsalObject.RemoteMethods.SaveCentraAsalObjectsToSite(this.RequestedSite.ObjectID, sendList);
                    }
                }
            }
            catch
            {}
            */

#endregion PostTransition_New2Dispatched
        }

        protected void PostTransition_SendMedula2DeleteDispatchProvision()
        {
            // From State : New   To State : SendMedula
            #region PostTransition_SendMedula2DeleteDispatchProvision

            MedulaSevkIptal();

            #endregion PostTransition_SendMedula2DeleteDispatchProvision
        }

        protected void PostTransition_SendMedula2Cancel()
        {
            // From State : New   To State : SendMedula
            #region PostTransition_SendMedula2Cancel

            MedulaSevkIptal();
            Cancel();
            #endregion PostTransition_SendMedula2Cancel
        }

        protected void PostTransition_DeleteDispatchProvision2Cancel()
        {
            Cancel();
        }

        #endregion

        #region  UNDO TRANS
        protected void UndoTransition_New2Dispatched(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Dispatched
#region UndoTransition_New2Dispatched
            NoBackStateBack();
#endregion UndoTransition_New2Dispatched
        }

        protected void UndoTransition_Dispatched2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Dispatched   To State : Completed
#region UndoTransition_Dispatched2Completed
            
           // NoBackStateBack();
#endregion UndoTransition_Dispatched2Completed
        }

        protected void UndoTransition_SendMedula2Dispatched(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SendMedula   To State : Dispatched
            #region UndoTransition_SendMedula2Dispatched

            MedulaSevkIptal();

            #endregion UndoTransition_SendMedula2Dispatched
        }

        #endregion
      
        #region Methods
        /*
        public void RunSendDispatchToOtherHospital()
        {
            if(this.RequestedReferableHospital !=null && this.TargetEpisodeObjectID==null) // daha önce gönderilmediyse
            {
                if(this.RequestedReferableHospital.ResOtherHospital!=null)
                {
                    if(this.RequestedReferableHospital.ResOtherHospital.Site!=null)
                    {
                        Guid savePoint = this.ObjectContext.BeginSavePoint();
                        String messageString="";
                        try
                        {
                            List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
                            foreach (DiagnosisGrid dg in this.Episode.Diagnosis)
                            {
                                diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
                            }
                            Sites localSite=TTObjectClasses.SystemParameter.GetSite();
                            TTMessage message =  DispatchToOtherHospital.RemoteMethods.SendDispatchToOtherHospital(this.RequestedSite.ObjectID, this.Episode.Patient, this.Episode.PrepareEpisodeForRemoteMethod(true), this.SubEpisode.PatientAdmission.PreparePatientAdmissionForRemoteMethod(true), (DispatchToOtherHospital)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList, localSite,this.Episode.GetMyEpisodeProtocolForRemoteMethod(),this.ObjectID);
                            messageString=message.MessageID.ToString();
                        }
                        finally
                        {
                            this.ObjectContext.RollbackSavePoint(savePoint);
                            this.MessageID = messageString;
                            this.ObjectContext.Save();
                        }
                    }
                }
            }
        }
        
        public void RunReturnDispatchToOtherHospital()
        {
            if(this.RequestedReferableHospital.ResOtherHospital!=null)
            {
                if(this.RequestedReferableHospital.ResOtherHospital.Site!=null)
                {
                    Guid savePoint = this.ObjectContext.BeginSavePoint();
                    String messageString="";
                    try
                    {
                        List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
                        foreach (DiagnosisGrid dg in this.Episode.Diagnosis)// Geriye gönderilirken yalnız XXXXXXler arası sevk işleminde konulan tanılar geriye gönderiliyor.
                        {
                            if(dg.ResponsibleUser!=null)
                                diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
                        }
                        TTMessage message = DispatchToOtherHospital.RemoteMethods.ReturnDispatchToOtherHospital(this.RequesterHospital.Site.ObjectID,(DispatchToOtherHospital)this.PrepareEpisodeActionForRemoteMethod(true),diagnosisList);
                        messageString=message.MessageID.ToString();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        this.ObjectContext.RollbackSavePoint(savePoint);
                        this.MessageID = messageString;
                        this.ObjectContext.Save();
                    }
                }
            }
        }
        */

        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            DispatchToOtherHospital dispatchToOtherHospital = (DispatchToOtherHospital)base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);

            if(withNewObjectID)
                dispatchToOtherHospital.DispatcherDoctor = null;
            
            return dispatchToOtherHospital;
        }
        
        /*
         * MEDULA SEVK BILDIRIM IPTAL METODU
         * */
        
        public bool MedulaESevkBildirimIptalSync(){
            
            try{
                SevkIslemleri.sevkIptalCevapDVO sevkIptalCevapDVO= SevkIslemleri.WebMethods.sevkBildirimIptalSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkBildirimIptalDVO());
                if(sevkIptalCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(sevkIptalCevapDVO.sonucKodu) == false){
                        if(sevkIptalCevapDVO.sonucKodu.Equals("0000")){
                            TTUtils.InfoMessageService.Instance.ShowMessage("Sevk Takip No: "+ MedulaSevkTakipNo + " olan sevkin iptal işlemi başarı ile sonuçlandı.");
                            MedulaSevkTakipNo= null;
                            return true;
                        }else{
                            if(string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                                throw new Exception("Sonuç Kodu : "+ sevkIptalCevapDVO.sonucKodu +" ve Sonuç Mesajı :"+ sevkIptalCevapDVO.sonucMesaji);
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M26929", "Sonuç mesajı alanı boş!"));
                        }
                    }else{
                        if(string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                            throw new Exception(sevkIptalCevapDVO.sonucMesaji);
                        throw new Exception(TTUtils.CultureService.GetText("M26925", "Sonuç Kodu ve Sonuç Mesajı boş!"));
                    }
                }else
                    throw new Exception("Meduladan cevap dönmedi!");
            }
            catch(Exception e){
                throw new Exception("Medula sevk bildirimi iptal işlemi sırasında hata oluştu! "+ e.Message);
            }
            //return false;
        }
        
        /*
         * MEDULA SEVK BILDIRIM IPTAL METODU
         * */
        
        public SevkIslemleri.sevkBildirimIptalDVO GetSevkBildirimIptalDVO()
        {
            SevkIslemleri.sevkBildirimIptalDVO sevkBildirimIptalDVO= new SevkIslemleri.sevkBildirimIptalDVO();
            
            if(MedulaSevkTakipNo != null){
                sevkBildirimIptalDVO.sevkTakipNo = MedulaSevkTakipNo ;
            }else{
                throw new Exception("Medulaya sevk bildirimi yapılmamış. Öncelikle bildirimi yapmalısınız!");
            }
            
            sevkBildirimIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return sevkBildirimIptalDVO;
        }
        
        
        /*
         * MEDULA MUTAT DIŞI ARAÇ RAPOR SIL METODU
         * */
        
        public bool MutatDisiAracRaporSilSync(){
            
            try{
                SevkIslemleri.mutatDisiIptalCevapDVO mutatDisiIptalCevapDVO= SevkIslemleri.WebMethods.mutatDisiAracRaporSilSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporIptalDVO());
                if(mutatDisiIptalCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucKodu) == false){
                        if(mutatDisiIptalCevapDVO.sonucKodu.Equals("0000")){
                            TTUtils.InfoMessageService.Instance.ShowMessage("Mutat dışı araç rapor id: "+ MutatDisiAracRaporId + " olan raporun silme işlemi başarı ile sonuçlandı.");
                            MutatDisiAracRaporId= null;
                            return true;
                        }else{
                            if(string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                                throw new Exception("Sonuç Kodu : "+ mutatDisiIptalCevapDVO.sonucKodu +" ve Sonuç Mesajı :"+ mutatDisiIptalCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Sonuç Kodu : "+ mutatDisiIptalCevapDVO.sonucKodu +" ve sonuç mesajı alanı boş.");
                        }
                    }else{
                        if(string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                            throw new Exception(TTUtils.CultureService.GetText("M26926", "Sonuç Mesajı :")+ mutatDisiIptalCevapDVO.sonucMesaji);
                        throw new Exception(TTUtils.CultureService.GetText("M26924", "Sonuç Kodu ve Mesajı alanları boş!"));
                    }
                }else
                    throw new Exception(TTUtils.CultureService.GetText("M25361", "Cevap dönmedi!"));
            }
            catch(Exception e){
                throw new Exception("Medulaya mutat dışı araç rapor silme işlemi sırasında hata oluştu! "+ e.Message);
            }
            //return false;
        }
        
        /*
         * MEDULA MUTAT DIŞI RAPOR IPTAL DVO HAZIRLANMASI
         * */
        public SevkIslemleri.mutatDisiRaporIptalDVO GetMutatDisiRaporIptalDVO()
        {
            SevkIslemleri.mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO= new SevkIslemleri.mutatDisiRaporIptalDVO();
            if(MutatDisiAracRaporId != null && !MutatDisiAracRaporId.Equals((long)(Convert.ToInt64("0"))))
                mutatDisiRaporIptalDVO.raporID = Convert.ToInt32(MutatDisiAracRaporId);
            else
                throw new Exception("Medulaya mutat dışı araç rapor kaydı yapılmamış. Öncelikle kayıt yapmalısınız!");
            
            
            mutatDisiRaporIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            
            return mutatDisiRaporIptalDVO;
        }

        public override void SetMyPropertiesByMasterAction(EpisodeAction episodeAction)
        {
            //this = episodeAction;
            //this.ActionDate = Common.RecTime().Date;
            // this.MasterResource = (ResSection)episodeAction.MasterResource;
            FromResource = (ResSection)episodeAction.MasterResource;
            Episode = (Episode)episodeAction.Episode;
        }

        public void MedulaSevkIptal()
        {
            if (Episode != null && SubEpisode.IsSGK == true)
            {

                try
                {
                    MedulaESevkBildirimIptalSync();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                try
                {
                    if (MutatDisiAracRaporId != null && !MutatDisiAracRaporId.Equals((long)(Convert.ToInt64("0"))))
                        MutatDisiAracRaporSilSync();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }


        }

        public void MedulaESevkBildirSync()
        {
            try
            {
                SevkIslemleri.sevkCevapDVO sevkCevapDVO = new SevkIslemleri.sevkCevapDVO();
                sevkCevapDVO = SevkIslemleri.WebMethods.sevkBildirSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkBildirimDVO());

                if (sevkCevapDVO != null)
                {
                    if (String.IsNullOrEmpty(sevkCevapDVO.sonucKodu) == false)
                    {
                        if (sevkCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoMessageService.Instance.ShowMessage("E-sevk bildirim işlemi başarı ile sonuçlandı. Sevk Takip No: " + sevkCevapDVO.sevkTakipNo);
                            MedulaSevkTakipNo = sevkCevapDVO.sevkTakipNo;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
                                throw new Exception("E-sevk bildiriminde hata var. Sonuç Mesajı :" + sevkCevapDVO.sonucMesaji);
                            else throw new Exception("E-sevk bildiriminde hata var");
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
                            throw new Exception("Medula sevk bildiriminde hata var: " + sevkCevapDVO.sonucMesaji);
                        else throw new Exception("Medulaya e-sevk bildirimi yapılması sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
                    }
                }
                else throw new Exception("Medulaya e-sevk bildirimi yapılamadı!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public SevkIslemleri.sevkBildirimDVO GetSevkBildirimDVO()
        {
            SevkIslemleri.sevkBildirimDVO sevkBildirimDVO = new SevkIslemleri.sevkBildirimDVO();
            // *sevkTakipNo : Sevke karar verilen takip numarası

            if (Episode != null && SubEpisode.PatientAdmission != null && SubEpisode.PatientAdmission.SEP != null && !String.IsNullOrEmpty(SubEpisode.PatientAdmission.SEP.MedulaTakipNo))
                sevkBildirimDVO.sevkTakipNo = SubEpisode.PatientAdmission.SEP.MedulaTakipNo;
            else throw new Exception("Medulaya e-sevk bildiriminde sevk takip no alanı dolu olmalıdır!");
            // *protokolNo
            if (Episode != null && Episode.HospitalProtocolNo != null && Episode.HospitalProtocolNo.Value != null)
                sevkBildirimDVO.protokolNo = Episode.HospitalProtocolNo.Value.ToString();
            else throw new Exception("Medulaya e-sevk bildiriminde protokol numarası alanı dolu olmalıdır!");
            // *sevkEdilenIl

            if (DispatchCity != null && DispatchCity.KODU != null)
                sevkBildirimDVO.sevkEdilenIl = Convert.ToInt32(DispatchCity.KODU.ToString());
            else throw new Exception("Medulaya e-sevk bildiriminde gideceği şehir alanı dolu olmalıdır!");
            // *sevkEdilenXXXXXX

            //if(this.MedulaSiteCode != null)
            sevkBildirimDVO.sevkEdilenTesis = Convert.ToInt32(MedulaSiteCode);
            //else
            //    throw new Exception("Medulaya e-sevk bildiriminde gideceği tesis alanı dolu olmalıdır!");

            // *sevkEdilenBrans
            if (DispatchedSpeciality != null && DispatchedSpeciality.Code != null)
                sevkBildirimDVO.sevkEdilenBrans = DispatchedSpeciality.Code;
            else throw new Exception("Medulaya e-sevk bildiriminde sevk edilen branş alanı dolu olmalıdır!");
            // *sevkVasitasi
            if (SevkVasitasi != null && SevkVasitasi.sevkVasitasiKodu != null)
                sevkBildirimDVO.sevkVasitasi = Convert.ToInt32(SevkVasitasi.sevkVasitasiKodu);
            else throw new Exception("Medulaya e-sevk bildiriminde sevk vasıtası alanı dolu olmalıdır!");
            // *sevkNedeni
            if (SevkNedeni != null && SevkNedeni.SevkNedeniKodu != null)
                sevkBildirimDVO.sevkNedeni = Convert.ToInt32(SevkNedeni.SevkNedeniKodu);
            else throw new Exception("Medulaya e-sevk bildiriminde sevk nedeni alanı dolu olmalıdır!");
            // *sevkNedeniAciklama (Sevk nedeni diğer ise dolu)
            if (SevkNedeni != null && SevkNedeni.SevkNedeniKodu != null)
            {
                if (SevkNedeni.SevkNedeniKodu.Equals("10"))
                {
                    if (ReasonOfDispatch != null)
                        sevkBildirimDVO.sevkNedeniAciklama = ReasonOfDispatch;
                    else throw new Exception("Medulaya e-sevk bildiriminde sevk nedeni alanı Diğer seçildiğinden sevk nedeni açıklama alanı dolu olmalıdır!");
                }
                else
                {
                    if (ReasonOfDispatch != null)
                        sevkBildirimDVO.sevkNedeniAciklama = ReasonOfDispatch;
                    else sevkBildirimDVO.sevkNedeniAciklama = "";
                }
            }
            // tedaviTipi
            if (SevkTedaviTipi != null && SevkTedaviTipi.sevkTedaviTipiKodu != null)
                sevkBildirimDVO.tedaviTipi = Convert.ToInt32(SevkTedaviTipi.sevkTedaviTipiKodu);
            else throw new Exception("Medulaya e-sevk bildiriminde sevk tedavi tipi alanı dolu olmalıdır!");
            // *refakatci
            if (MedulaRefakatciDurumu != null && MedulaRefakatciDurumu.Equals(true))
            {
                sevkBildirimDVO.refakatci = "E";
                // refakakciGerekcesi
                if (CompanionReason != null)
                    sevkBildirimDVO.refakakciGerekcesi = CompanionReason;
                else throw new Exception("Medulaya e-sevk bildiriminde refakatçi durumu Evet seçildiğinden refakatçi gerekçesi alanı dolu olmalıdır!");
            }
            else if (MedulaRefakatciDurumu == null || MedulaRefakatciDurumu.Equals(false))
            {
                sevkBildirimDVO.refakatci = "H";
            }
            else
            {
                sevkBildirimDVO.refakatci = "E";
                // refakakciGerekcesi
                if (CompanionReason != null && !String.Empty.Equals(CompanionReason.Trim()))
                    sevkBildirimDVO.refakakciGerekcesi = CompanionReason;
                else
                {
                    throw new Exception("Medulaya e-sevk bildiriminde refakatçi durumu var seçildiği zaman gerekçe alanı zorunludur!");
                }
            }

            // *sevkTani  -> SevkTaniDVO[]
            List<SevkIslemleri.sevkTaniDVO> sevkTaniList = new List<SevkIslemleri.sevkTaniDVO>();
            sevkTaniList = GetSevkTaniDVOList("Medulaya e-sevk bildiriminde").ToList<SevkIslemleri.sevkTaniDVO>();
            if (sevkTaniList != null)
                sevkBildirimDVO.sevkTani = sevkTaniList.ToArray();
            else throw new Exception("Medulaya e-sevk bildiriminde hastaya ait tanı girilmiş olmalıdır!");

            // *sevkEdenDoktor   -> SevkDoktorDVO[]
            List<SevkIslemleri.sevkDoktorDVO> sevkDoktorList = new List<SevkIslemleri.sevkDoktorDVO>();
            sevkDoktorList = GetSevkDoktorDVOList("Medulaya e-sevk bildiriminde").ToList<SevkIslemleri.sevkDoktorDVO>();
            if (sevkDoktorList != null)
                sevkBildirimDVO.sevkEdenDoktor = sevkDoktorList.ToArray();
            else throw new Exception("Medulaya e-sevk bildiriminde sevk eden doktorların bilgileri girilmiş olmalıdır!");
            // raporId : Mutat dışı araç rapor numarası
            if (SevkVasitasi != null && SevkVasitasi.sevkVasitasiKodu != null)
            {
                if (!SevkVasitasi.sevkVasitasiKodu.Equals("1") && !SevkVasitasi.sevkVasitasiKodu.Equals("12"))
                {
                    if (MutatDisiAracRaporKaydetSync())
                    {
                        if (MutatDisiAracRaporId != null)
                            sevkBildirimDVO.raporId = Convert.ToInt64(MutatDisiAracRaporId);
                        else throw new Exception("Medulaya e-sevk bildiriminde öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
                    }
                    else
                    {
                        throw new Exception("Medulaya e-sevk bildiriminde öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
                    }
                }
                else
                {
                    // Mutat araç ise (Mutat Araç kodları: 1 ve 12) rapor numarası 0 yollanıyor.
                    MutatDisiAracRaporId = (long)Convert.ToInt64("0");
                    sevkBildirimDVO.raporId = Convert.ToInt64(MutatDisiAracRaporId);
                }
            }
            // *kullaniciTesisKodu
            sevkBildirimDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            return sevkBildirimDVO;
        }


        public SevkIslemleri.sevkTaniDVO[] GetSevkTaniDVOList(string type)
        {
            List<SevkIslemleri.sevkTaniDVO> sevkTaniDVOList = null;
            if (Episode != null)
            {
                sevkTaniDVOList = new List<SevkIslemleri.sevkTaniDVO>();
                foreach (var diagnose in (Episode.GetMyMedulaDiagnosisDefinitionICDCodes(Episode)))
                {
                    SevkIslemleri.sevkTaniDVO sevkTaniDVO = new SevkIslemleri.sevkTaniDVO();
                    sevkTaniDVO.sevkTaniKodu = diagnose;
                    sevkTaniDVOList.Add(sevkTaniDVO);
                }
            }
            else
            {
                throw new Exception(type + " hastaya ait tanı girilmiş olmalıdır!");
            }
            return sevkTaniDVOList.ToArray();
        }

        public SevkIslemleri.sevkDoktorDVO[] GetSevkDoktorDVOList(string type)
        {
            List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
            if (DoctorsGrid != null && DoctorsGrid.Count > 0)
            {
                sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
                foreach (var doctor in DoctorsGrid)
                {
                    SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
                    // *doktorTescilNo
                    if (doctor.ResUser != null && doctor.ResUser.DiplomaRegisterNo != null)
                        sevkDoktorDVO.doktorTescilNo = doctor.ResUser.DiplomaRegisterNo;
                    else
                    {
                        throw new Exception(type + " sevk eden doktorun tescil numarası dolu olmalıdır!");
                    }
                    // *doktorTipi
                    if (doctor.ResUser != null && doctor.ResUser.Title != null)
                    {
                        if (doctor.ResUser.Title.Value.Equals(UserTitleEnum.DisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
                            sevkDoktorDVO.doktorTipi = "2";
                        else sevkDoktorDVO.doktorTipi = "1";
                    }
                    else
                    {
                        throw new Exception(type + " sevk eden doktorun tipi dolu olmalıdır!");
                    }
                    // *bransKodu
                    if (doctor.ResUser != null && doctor.ResUser.ResourceSpecialities != null)
                    {
                        string brans = getAnaUzmanlikBrans(doctor.ResUser, type);
                        if (brans != null)
                            sevkDoktorDVO.bransKodu = brans;
                    }
                    else throw new Exception(type + " sevk eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
                    sevkDoktorDVOList.Add(sevkDoktorDVO);
                }
            }
            else throw new Exception(type + " sevk eden doktor bilgisi girilmiş olmalıdır!");
            return sevkDoktorDVOList.ToArray();
        }

        public string getAnaUzmanlikBrans(ResUser user, string type)
        {
            bool ctrl = false;
            foreach (var resource in user.ResourceSpecialities)
            {
                if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
                {
                    if (resource.Speciality != null && resource.Speciality.Code != null)
                    {
                        ctrl = true;
                        return resource.Speciality.Code;
                    }
                }
            }
            if (!ctrl)
            {
                throw new Exception(type + " sevk eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
            }
            return null;
        }

        public bool MutatDisiAracRaporKaydetSync()
        {
            try
            {
                SevkIslemleri.mutatDisiRaporCevapDVO mutatDisiRaporCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporKaydetSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporDVO());
                if (mutatDisiRaporCevapDVO != null)
                {
                    if (String.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucKodu) == false)
                    {
                        if (mutatDisiRaporCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoMessageService.Instance.ShowMessage("Mutat dışı araç rapor bildirim işlemi başarı ile sonuçlandı. Rapor id: " + mutatDisiRaporCevapDVO.raporId);
                            MutatDisiAracRaporId = mutatDisiRaporCevapDVO.raporId;
                            return true;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
                                throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :" + mutatDisiRaporCevapDVO.sonucMesaji);
                            else throw new Exception("Mutat dışı araç rapor bildiriminde hata var.Sonuç mesajı alanı boş.");
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
                            throw new Exception(mutatDisiRaporCevapDVO.sonucMesaji);
                        throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılması sırasında hata oluştu! Sonuç Kodu alanı boş!");
                    }
                }
                else throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılamadı.Cevap dönmedi!");
            }
            catch (Exception e)
            {
                throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılması sırasında hata oluştu! " + e.Message);
            }

        }

        public SevkIslemleri.mutatDisiRaporDVO GetMutatDisiRaporDVO()
        {
            SevkIslemleri.mutatDisiRaporDVO mutatDisiRaporDVO = new SevkIslemleri.mutatDisiRaporDVO();
            // *haksahibiTCNO
            if (Episode != null && Episode.Patient != null && Episode.Patient.UniqueRefNo != null)
                mutatDisiRaporDVO.haksahibiTCNO = Convert.ToInt64(Episode.Patient.UniqueRefNo);
            else throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk edilen hasta TC kimlik no alanı dolu olmalıdır!");
            //XXXXXX tarafından verilen rapor no
            // *raporNo
            if (MutatDisiAracXXXXXXRaporID != null && MutatDisiAracXXXXXXRaporID.Value == null)
                MutatDisiAracXXXXXXRaporID.GetNextValueFromDatabase(null, 0);
            if (MutatDisiAracXXXXXXRaporID != null && MutatDisiAracXXXXXXRaporID.Value != null)
                mutatDisiRaporDVO.raporNo = MutatDisiAracXXXXXXRaporID.Value.ToString();
            else throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken XXXXXX tarafından verilen rapor ID alanı dolu olmalıdır!");
            // *protokolNo
            if (Episode != null && Episode.HospitalProtocolNo != null && Episode.HospitalProtocolNo.Value != null)
                mutatDisiRaporDVO.protokolNo = Episode.HospitalProtocolNo.Value.ToString();
            else throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken protokol numarası alanı dolu olmalıdır!");
            // *sevkVasitasi
            if (SevkVasitasi != null && SevkVasitasi.sevkVasitasiKodu != null)
                mutatDisiRaporDVO.sevkVasitasi = Convert.ToInt32(SevkVasitasi.sevkVasitasiKodu);
            else throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk vasıtası alanı dolu olmalıdır!");
            // raporTarihi
            if (MutatDisiAracRaporTarihi != null)
                mutatDisiRaporDVO.raporTarihi = MutatDisiAracRaporTarihi.Value.ToShortDateString().ToString();
            else throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken rapor tarihi alanı dolu olmalıdır!");
            // baslangicTarihi
            if (MutatDisiAracBaslangicTarihi != null)
                mutatDisiRaporDVO.baslangicTarihi = MutatDisiAracBaslangicTarihi.Value.ToShortDateString().ToString();
            else throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken başlangıç tarihi alanı dolu olmalıdır!");
            // bitisTarihi
            if (MutatDisiAracBitisTarihi != null)
                mutatDisiRaporDVO.bitisTarihi = MutatDisiAracBitisTarihi.Value.ToShortDateString().ToString();
            else throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken bitiş tarihi alanı dolu olmalıdır!");
            // refakatciGerekcesi
            if (CompanionReason != null)
                mutatDisiRaporDVO.refakatciGerekcesi = CompanionReason;
            // mutatDisiGerekcesi
            if (MutatDisiGerekcesi != null)
                mutatDisiRaporDVO.mutatDisiGerekcesi = MutatDisiGerekcesi;
            // *sevkTani
            List<SevkIslemleri.sevkTaniDVO> sevkTaniList = GetSevkTaniDVOList("Medulaya mutat dışı araç rapor bildiriminde").ToList<SevkIslemleri.sevkTaniDVO>();
            if (sevkTaniList != null)
                mutatDisiRaporDVO.sevkTani = sevkTaniList.ToArray();
            else throw new Exception("Medulaya mutat dışı araç rapor bildiriminde hastaya ait tanı girilmiş olmalıdır!");
            // sevkEdenDoktor
            List<SevkIslemleri.sevkDoktorDVO> sevkDoktorList = GetSevkDoktorDVOList("Medulaya mutat dışı araç rapor bildiriminde").ToList<SevkIslemleri.sevkDoktorDVO>();
            if (sevkDoktorList != null)
                mutatDisiRaporDVO.sevkEdenDoktor = sevkDoktorList.ToArray();
            else throw new Exception("Medulaya mutat dışı araç rapor bildiriminde sevk eden doktorların bilgileri girilmiş olmalıdır!");
            // *kullaniciTesisKodu
            mutatDisiRaporDVO.saglikTesisKodu = (TTObjectClasses.SystemParameter.GetSaglikTesisKodu());
            return mutatDisiRaporDVO;
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DispatchToOtherHospital).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if ((fromState == DispatchToOtherHospital.States.New && toState == DispatchToOtherHospital.States.SendMedula) || (fromState == DispatchToOtherHospital.States.DeleteDispatchProvision && toState == DispatchToOtherHospital.States.SendMedula))
                PostTransition_New2SendMedula();
            else if (fromState == DispatchToOtherHospital.States.New && toState == DispatchToOtherHospital.States.Dispatched)
                PostTransition_New2Dispatched();
            else if (fromState == DispatchToOtherHospital.States.SendMedula && toState == DispatchToOtherHospital.States.DeleteDispatchProvision)
                PostTransition_SendMedula2DeleteDispatchProvision();
            else if (fromState == DispatchToOtherHospital.States.SendMedula && toState == DispatchToOtherHospital.States.Cancel)
                PostTransition_SendMedula2Cancel();
            else if (fromState == DispatchToOtherHospital.States.DeleteDispatchProvision && toState == DispatchToOtherHospital.States.Cancel)
                PostTransition_DeleteDispatchProvision2Cancel();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DispatchToOtherHospital).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DispatchToOtherHospital.States.SendMedula && toState == DispatchToOtherHospital.States.Dispatched)
                UndoTransition_SendMedula2Dispatched(transDef);
            else if (fromState == DispatchToOtherHospital.States.New && toState == DispatchToOtherHospital.States.Dispatched)
                UndoTransition_New2Dispatched(transDef);
            else if (fromState == DispatchToOtherHospital.States.Dispatched && toState == DispatchToOtherHospital.States.Completed)
                UndoTransition_Dispatched2Completed(transDef);
        }

    }
}