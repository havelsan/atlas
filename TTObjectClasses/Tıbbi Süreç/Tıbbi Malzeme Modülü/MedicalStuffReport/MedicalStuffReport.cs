
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
    /// Tıbbi Malzeme Raporu
    /// </summary>
    public partial class MedicalStuffReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MedicalStuffReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MedicalStuffReport.States.New && (toState == MedicalStuffReport.States.SecondDoctorApproval || toState == MedicalStuffReport.States.HeadDoctorApproval))
                PostTransition_New2SecondDoctorApproval();
            else if (fromState == MedicalStuffReport.States.New && toState == MedicalStuffReport.States.HeadDoctorApproval)
                PostTransition_New2HeadDoctorApproval();
        }
        protected void PostTransition_New2SecondDoctorApproval()
        {
            // From State : New   To State : SecondDoctorApproval
            #region PostTransition_New2SecondDoctorApproval         
            //this.ReportNo.GetNextValue();
            #endregion PostTransition_New2SecondDoctorApproval
        }

        protected void PostTransition_New2HeadDoctorApproval()
        {
            // From State : New   To State : HeadDoctorApproval
            #region PostTransition_New2SecondDoctorApproval         
            //this.ReportNo.GetNextValue();
            #endregion PostTransition_New2SecondDoctorApproval
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObj = (ITTObject)this;
            if (theObj.IsNew)
            {
                ReportNo.GetNextValue();
            }
        }

        public static string GetERaporSignedDeleteRequestERaporTakipNo(string eRaporTakipNo)
        {
            TibbiMalzemeERaporIslemleri.imzaliERaporSilIstekDVO eRaporSil = new TibbiMalzemeERaporIslemleri.imzaliERaporSilIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eRaporSil.tesisKodu = Convert.ToString(saglikTesisKodu);
            eRaporSil.doktorTcKimlikNo = currentUser.UniqueNo;
            eRaporSil.surumNumarasi = "1";

            string imzalanacakXml = Common.SerializeObjectToXml(eRaporSil);
            imzalanacakXml = imzalanacakXml.Replace("imzaliERaporSilIstekDVO", "imzaliEraporSilBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }
        public static string GetERaporSignedSearchRequestERaporTakipNo(string eRaporTakipNo)
        {
            TibbiMalzemeERaporIslemleri.imzaliERaporSorguIstekDVO eRaporSorgu = new TibbiMalzemeERaporIslemleri.imzaliERaporSorguIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eRaporSorgu.tesisKodu = Convert.ToString(saglikTesisKodu);
            eRaporSorgu.doktorTcKimlikNo = currentUser.UniqueNo;
            eRaporSorgu.surumNumarasi = "1";

            string imzalanacakXml = Common.SerializeObjectToXml(eRaporSorgu);
            imzalanacakXml = imzalanacakXml.Replace("imzaliERaporSorguIstekDVO", "imzaliEraporSorguBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }
        public static string GetERaporSignedSearchListRequestERaporTakipNo(string eRaporTakipNo)
        {
            TibbiMalzemeERaporIslemleri.imzaliERaporListeSorguIstekDVO eRaporListeSorgu = new TibbiMalzemeERaporIslemleri.imzaliERaporListeSorguIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eRaporListeSorgu.tesisKodu = Convert.ToString(saglikTesisKodu);
            eRaporListeSorgu.doktorTcKimlikNo = currentUser.UniqueNo;
            eRaporListeSorgu.surumNumarasi = "1";

            string imzalanacakXml = Common.SerializeObjectToXml(eRaporListeSorgu);
            imzalanacakXml = imzalanacakXml.Replace("imzaliERaporListeSorguIstekDVO", "imzaliEraporListeSorguBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }
        public static string GetERaporSignedRequestERaporTakipNo(Guid eRaporObjectID, Guid? selectedEpisodeActionObjectID)
        {
            TibbiMalzemeERaporIslemleri.eRaporGirisDVO imzalanacakERaporDVO = SetImzaliERaporDVO(eRaporObjectID, selectedEpisodeActionObjectID);

            string imzalanacakXml = Common.SerializeObjectToXml(imzalanacakERaporDVO);
            imzalanacakXml = imzalanacakXml.Replace("eRaporGirisDVO", "imzaliEraporBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }

        public static TibbiMalzemeERaporIslemleri.eRaporGirisDVO SetImzaliERaporDVO(Guid eRaporObjectID, Guid? selectedEpisodeActionObjectID)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;

            var objectContext = new TTObjectContext(false);
            var medicalStuffReport = (MedicalStuffReport)objectContext.GetObject<MedicalStuffReport>(eRaporObjectID);

            TibbiMalzemeERaporIslemleri.eRaporGirisDVO _raporDVO = new TibbiMalzemeERaporIslemleri.eRaporGirisDVO();
            ResUser tabip = medicalStuffReport.ProcedureDoctor;

            EpisodeAction episodeAction = medicalStuffReport.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
            SubEpisode se = episodeAction.SubEpisode;

            if (se.LastActiveSubEpisodeProtocolByCloneType != null && (se.LastActiveSubEpisodeProtocolByCloneType.MedulaTakipNo == null || se.LastActiveSubEpisodeProtocolByCloneType.MedulaTakipNo == ""))
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25844", "Hastanın medula provizyon numarası bulunmamaktadır.Hastaya provizyon alınız."));
            }

            Episode e = episodeAction.Episode;


            _raporDVO.tcKimlikNo =  Convert.ToInt64(e.Patient.UniqueRefNo);
            if(medicalStuffReport.Description != null)
                _raporDVO.aciklama = medicalStuffReport.Description.ToString();

            TibbiMalzemeERaporIslemleri.doktorDVO _doktorBilgisiDVO = new TibbiMalzemeERaporIslemleri.doktorDVO();
            List<TibbiMalzemeERaporIslemleri.doktorDVO> _doktorBilgisiDVOList = new List<TibbiMalzemeERaporIslemleri.doktorDVO>();
            _doktorBilgisiDVO.adi = tabip.Person != null ? tabip.Person.Name : "";
            _doktorBilgisiDVO.bransAdi = tabip.GetSpeciality() != null ? tabip.GetSpeciality().Name : "";
            _doktorBilgisiDVO.bransKodu = tabip.GetSpeciality() != null ? tabip.GetSpeciality().Code : "";
            _doktorBilgisiDVO.soyadi = tabip.Person != null ? tabip.Person.Surname : "";
            _doktorBilgisiDVO.tcKimlikNo = currentUser.UniqueNo;// tabip.Person.UniqueRefNo.ToString();
            _doktorBilgisiDVOList.Add(_doktorBilgisiDVO);

            TibbiMalzemeERaporIslemleri.doktorDVO _doktorBilgisiDVO2 = new TibbiMalzemeERaporIslemleri.doktorDVO();
            ResUser tabip2 = medicalStuffReport.SecondDoctor;
            if (tabip2 != null)
            {
                _doktorBilgisiDVO2.adi = tabip2.Person != null ? tabip2.Person.Name : "";
                _doktorBilgisiDVO2.bransAdi = tabip2.GetSpeciality() != null ? tabip2.GetSpeciality().Name : "";
                _doktorBilgisiDVO2.bransKodu = tabip2.GetSpeciality() != null ? tabip2.GetSpeciality().Code : "";
                _doktorBilgisiDVO2.soyadi = tabip2.Person != null ? tabip2.Person.Surname : "";
                _doktorBilgisiDVO2.tcKimlikNo = tabip2.Person.UniqueRefNo.ToString();
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO2);
            }

            TibbiMalzemeERaporIslemleri.doktorDVO _doktorBilgisiDVO3 = new TibbiMalzemeERaporIslemleri.doktorDVO();
            ResUser tabip3 = medicalStuffReport.ThirdDoctor;
            if (tabip3 != null)
            {
                _doktorBilgisiDVO3.adi = tabip3.Person != null ? tabip3.Person.Name : "";
                _doktorBilgisiDVO3.bransAdi = tabip3.GetSpeciality() != null ? tabip3.GetSpeciality().Name : "";
                _doktorBilgisiDVO3.bransKodu = tabip3.GetSpeciality() != null ? tabip3.GetSpeciality().Code : "";
                _doktorBilgisiDVO3.soyadi = tabip3.Person != null ? tabip3.Person.Surname : "";
                _doktorBilgisiDVO3.tcKimlikNo = tabip3.Person.UniqueRefNo.ToString();
                _doktorBilgisiDVOList.Add(_doktorBilgisiDVO3);
            }
            _raporDVO.doktorListesi = _doktorBilgisiDVOList.ToArray();

            //todo bg

            List<TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO> _malzemeBilgisiDVOList = new List<TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO>();
            if (medicalStuffReport.MedicalStuff != null)
            {
                foreach (MedicalStuff item in medicalStuffReport.MedicalStuff)
                {
                    TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO _malzemeBilgisiDVO = new TibbiMalzemeERaporIslemleri.eMalzemeGirisDVO();
                    _malzemeBilgisiDVO.adet = item.StuffAmount.Value;
                    _malzemeBilgisiDVO.degistirmeRaporu = "H";
                    _malzemeBilgisiDVO.kullanimPeriyodu = item.PeriodUnit;
                    if(item.PeriodUnitType == PeriodUnitTypeEnum.DayPeriod)
                    {
                        _malzemeBilgisiDVO.kullanimPeriyodBirim = 1;
                    }else if (item.PeriodUnitType == PeriodUnitTypeEnum.WeekPeriod)
                    {
                        _malzemeBilgisiDVO.kullanimPeriyodBirim = 2;
                    }
                    else if (item.PeriodUnitType == PeriodUnitTypeEnum.MonthPeriod)
                    {
                        _malzemeBilgisiDVO.kullanimPeriyodBirim = 3;
                    }
                    else if (item.PeriodUnitType == PeriodUnitTypeEnum.YearPeriod)
                    {
                        _malzemeBilgisiDVO.kullanimPeriyodBirim = 4;
                    }
                    else
                    {
                        _malzemeBilgisiDVO.kullanimPeriyodBirim = 0;
                    }
                        _malzemeBilgisiDVO.kullanimYeri = item.MedicalStuffPlaceOfUsage.Code;
                    _malzemeBilgisiDVO.sutKodu = item.MedicalStuffDef.Code.ToString();
                    _malzemeBilgisiDVO.kullanimSekli = "";//???
                    _malzemeBilgisiDVOList.Add(_malzemeBilgisiDVO);
                }
            }
            _raporDVO.malzemeListesi = _malzemeBilgisiDVOList.ToArray();

            List<TibbiMalzemeERaporIslemleri.eTaniDVO> taniBilgisiDVOList = new List<TibbiMalzemeERaporIslemleri.eTaniDVO>();
            List<string> taniList = new List<string>();
            if (medicalStuffReport.ReportDiagnosis != null)
            {
                foreach (ReportDiagnosis item in medicalStuffReport.ReportDiagnosis)
                {
                    if (item.Diagnose != null)
                        taniList.Add(item.Diagnose.Code);
                    else
                        throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25854", "Hastanın tanılarını kontrol ediniz."));
                }
            }
            else
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25854", "Hastanın tanılarını kontrol ediniz."));

            taniList = Common.DiagnosesForMedula(taniList);
            if (taniList != null)
            {
                foreach (string taniItem in taniList)
                {
                    TibbiMalzemeERaporIslemleri.eTaniDVO taniBilgisiDVO = new TibbiMalzemeERaporIslemleri.eTaniDVO();
                    taniBilgisiDVO.taniKodu = taniItem;
                    taniBilgisiDVOList.Add(taniBilgisiDVO);
                }
            }
            else
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25854", "Hastanın tanılarını kontrol ediniz."));

            _raporDVO.taniListesi = taniBilgisiDVOList.ToArray();


            _raporDVO.raporTarihi = ((DateTime)medicalStuffReport.StartDate).ToString("dd.MM.yyyy");
            _raporDVO.raporBitisTarihi = ((DateTime)medicalStuffReport.EndDate).ToString("dd.MM.yyyy");
            if(medicalStuffReport.CommitteeReport != null && medicalStuffReport.CommitteeReport == true)
            {
                _raporDVO.raporDuzenlemeTuruKodu = 1;
            }
            else{
            _raporDVO.raporDuzenlemeTuruKodu = 2;

            }
            long value = Convert.ToInt64((TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["MedicalStuffSequence"], null, null)));
            _raporDVO.raporNo = (medicalStuffReport.ReportNo != null) ? medicalStuffReport.ReportNo.ToString() : value.ToString();
            _raporDVO.raporOnayDurumu = "";
            // _raporDVO.raporTakipNo = "";
            _raporDVO.protokolNo = e.HospitalProtocolNo.ToString();
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            _raporDVO.tesisKodu = Convert.ToInt32(saglikTesisKodu);
            //_raporDVO.takipNo = se.LastActiveSubEpisodeProtocolByCloneType.MedulaTakipNo;
            
            return _raporDVO;
        }

    }
}