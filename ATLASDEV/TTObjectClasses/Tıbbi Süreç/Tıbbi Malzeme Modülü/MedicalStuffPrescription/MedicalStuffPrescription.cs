
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
    /// Tıbbi Malzeme Reçetesi
    /// </summary>
    public  partial class MedicalStuffPrescription : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public static string GetERaporSignedDeleteRequestEReceteTakipNo(string eReceteTakipNo)
        {
            TibbiMalzemeEReceteIslemleri.imzaliEReceteSilIstekDVO eReceteSil = new TibbiMalzemeEReceteIslemleri.imzaliEReceteSilIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eReceteSil.tesisKodu = Convert.ToString(saglikTesisKodu);
            eReceteSil.doktorTcKimlikNo = currentUser.UniqueNo;
            eReceteSil.surumNumarasi = "1";

            string imzalanacakXml = Common.SerializeObjectToXml(eReceteSil);
            imzalanacakXml = imzalanacakXml.Replace("imzaliEReceteSilIstekDVO", "imzaliEreceteSilBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }

        public static string GetEReceteRequestEReceteTakipNo(Guid eReceteObjectID, Guid? selectedEpisodeActionObjectID)
        {
            TibbiMalzemeEReceteIslemleri.eReceteGirisIstekDVO imzalanacakEReceteDVO = SetImzaliEReceteDVO(eReceteObjectID, selectedEpisodeActionObjectID);

            string imzalanacakXml = Common.SerializeObjectToXml(imzalanacakEReceteDVO);
            imzalanacakXml = imzalanacakXml.Replace("eReceteGirisIstekDVO", "imzaliEreceteBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }

        public static TibbiMalzemeEReceteIslemleri.eReceteGirisIstekDVO SetImzaliEReceteDVO(Guid eReceteObjectID, Guid? selectedEpisodeActionObjectID)
        {
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;

            var objectContext = new TTObjectContext(false);
            var medicalStuffPrescription = (MedicalStuffPrescription)objectContext.GetObject<MedicalStuffPrescription>(eReceteObjectID);

            TibbiMalzemeEReceteIslemleri.eReceteGirisIstekDVO _receteIstekDVO = new TibbiMalzemeEReceteIslemleri.eReceteGirisIstekDVO();
            ResUser tabip = medicalStuffPrescription.ProcedureDoctor;

            EpisodeAction episodeAction = medicalStuffPrescription.ObjectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
            SubEpisode se = episodeAction.SubEpisode;
            SubEpisodeProtocol sep = episodeAction.SubEpisode.LastActiveSubEpisodeProtocol;

            if (sep != null && (sep.MedulaTakipNo == null || sep.MedulaTakipNo == ""))
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25844", "Hastanın medula provizyon numarası bulunmamaktadır.Hastaya provizyon alınız."));
            }

            Episode e = episodeAction.Episode;


            _receteIstekDVO.doktorTcKimlikNo = tabip.UniqueNo;// Convert.ToInt64(e.Patient.UniqueRefNo);

            _receteIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu();// medicalStuffReport.Description.ToString();

            TibbiMalzemeEReceteIslemleri.eReceteDVO _receteDVO = new TibbiMalzemeEReceteIslemleri.eReceteDVO();
            //_receteDVO.doktorTCKimlikNo = Convert.ToInt64(tabip.UniqueNo);
            _receteDVO.protokolNo = medicalStuffPrescription.SubEpisode.ProtocolNo;
            _receteDVO.provizyonTipi = sep.MedulaProvizyonTipi.provizyonTipiKodu;
            if(medicalStuffPrescription.Description != null && medicalStuffPrescription.DescriptionType != null)
            {
                TibbiMalzemeEReceteIslemleri.eReceteAciklamaDVO _aciklamaDVO = new TibbiMalzemeEReceteIslemleri.eReceteAciklamaDVO();
                _aciklamaDVO.aciklamaTuru = (int)medicalStuffPrescription.DescriptionType;
                _aciklamaDVO.aciklama = Common.GetTextOfRTFString(medicalStuffPrescription.Description.ToString());
                _receteIstekDVO.eReceteDVO.receteAciklama = _aciklamaDVO;
            }

            _receteDVO.receteTarihi = ((DateTime)medicalStuffPrescription.PrescriptionDate).ToString("dd.mm.yyyy");

            if (sep.MedulaTedaviTuru.tedaviTuruKodu == "A")
            {
                _receteDVO.receteTuru = 1;
            }
            else if (sep.MedulaTedaviTuru.tedaviTuruKodu == "Y")
            {
                _receteDVO.receteTuru = 2;
            }
            else if (sep.MedulaTedaviTuru.tedaviTuruKodu == "G")
            {
                _receteDVO.receteTuru = 4;
            }

            _receteDVO.takipNo = sep.MedulaTakipNo;
                List<TibbiMalzemeEReceteIslemleri.eTaniDVO> diagnosisList = new List<TibbiMalzemeEReceteIslemleri.eTaniDVO>();

            if (medicalStuffPrescription.ReportDiagnosis.Count > 0)
            {
                foreach (ReportDiagnosis diagnosis in medicalStuffPrescription.ReportDiagnosis)
                {
                    TibbiMalzemeEReceteIslemleri.eTaniDVO _taniDVO = new TibbiMalzemeEReceteIslemleri.eTaniDVO();
                    _taniDVO.taniKodu = diagnosis.Diagnose.Code;
                    _taniDVO.taniAdi = diagnosis.Diagnose.Name;
                    diagnosisList.Add(_taniDVO);
                }
                _receteDVO.taniListesi = diagnosisList.ToArray();
            }
            else
            {
                foreach (ReportDiagnosis diagnosis in medicalStuffPrescription.MedicalStuffReport.ReportDiagnosis)
                {
                    TibbiMalzemeEReceteIslemleri.eTaniDVO _taniDVO = new TibbiMalzemeEReceteIslemleri.eTaniDVO();
                    _taniDVO.taniKodu = diagnosis.Diagnose.Code;
                    _taniDVO.taniAdi = diagnosis.Diagnose.Name;
                    diagnosisList.Add(_taniDVO);
                }
                _receteDVO.taniListesi = diagnosisList.ToArray();
            }
            
            if (medicalStuffPrescription.MedicalStuff.Count > 0)
            {
                List<TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO> medicalStuffList = new List<TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO>();
                foreach (MedicalStuff medicalStuff in medicalStuffPrescription.MedicalStuffReport.MedicalStuff)
                {
                    TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO _malzemeGirisDVO = new TibbiMalzemeEReceteIslemleri.eReceteMalzemeGirisDVO();
                    TibbiMalzemeEReceteIslemleri.eMalzemeGirisDVO  _malzemeDVO = new TibbiMalzemeEReceteIslemleri.eMalzemeGirisDVO();
                    _malzemeDVO.sutKodu = medicalStuff.MedicalStuffDef.Code;
                    _malzemeDVO.adet = (int)medicalStuff.StuffAmount;
                    _malzemeDVO.kullanimYeri = medicalStuff.MedicalStuffPlaceOfUsage != null ? medicalStuff.MedicalStuffPlaceOfUsage.Code : "F";
                    _malzemeDVO.kullanimPeriyodu = medicalStuff.PeriodUnit;
                    if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.DayPeriod)
                    {
                        _malzemeDVO.kullanimPeriyodBirim = 1;
                    }
                    else if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.WeekPeriod)
                    {
                        _malzemeDVO.kullanimPeriyodBirim = 2;
                    }
                    else if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.MonthPeriod)
                    {
                        _malzemeDVO.kullanimPeriyodBirim = 3;
                    }
                    else if (medicalStuff.PeriodUnitType == PeriodUnitTypeEnum.YearPeriod)
                    {
                        _malzemeDVO.kullanimPeriyodBirim = 4;
                    }
                    else
                    {
                        _malzemeDVO.kullanimPeriyodBirim = 0;
                    }
                    _malzemeDVO.degistirmeRaporu = "H";
                    _malzemeGirisDVO.receteMalzeme = _malzemeDVO;
                    _malzemeGirisDVO.raporId = Convert.ToInt32(medicalStuffPrescription.MedicalStuffReport.RaporTakipNo);
                    medicalStuffList.Add(_malzemeGirisDVO);
                }
                _receteDVO.malzemeListesi = medicalStuffList.ToArray();
            }
            _receteDVO.tcKimlikNo = Convert.ToInt64(medicalStuffPrescription.Episode.Patient.UniqueRefNo);

            _receteIstekDVO.eReceteDVO = _receteDVO;
            return _receteIstekDVO;
        }

        public static string GetERaporSignedRequestEReceteTakipNo(string eReceteTakipNo)
        {
            TibbiMalzemeEReceteIslemleri.imzaliEReceteGirisIstekDVO eRecete = new TibbiMalzemeEReceteIslemleri.imzaliEReceteGirisIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eRecete.tesisKodu = Convert.ToString(saglikTesisKodu);
            eRecete.doktorTcKimlikNo = currentUser.UniqueNo;
            eRecete.surumNumarasi = "1";
            
            string imzalanacakXml = Common.SerializeObjectToXml(eRecete);
            imzalanacakXml = imzalanacakXml.Replace("imzaliEReceteGirisIstekDVO", "imzaliEreceteBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }
        public static string GetERaporSignedSearchListRequestEReceteTakipNo(string eReceteTakipNo)
        {
            TibbiMalzemeEReceteIslemleri.imzaliEReceteListeSorguIstekDVO eReceteListeSorgu = new TibbiMalzemeEReceteIslemleri.imzaliEReceteListeSorguIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eReceteListeSorgu.tesisKodu = Convert.ToString(saglikTesisKodu);
            eReceteListeSorgu.doktorTcKimlikNo = currentUser.UniqueNo;
            eReceteListeSorgu.surumNumarasi = "1";
            
            string imzalanacakXml = Common.SerializeObjectToXml(eReceteListeSorgu);
            imzalanacakXml = imzalanacakXml.Replace("imzaliEReceteListeSorguIstekDVO", "imzaliEreceteListeSorguBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }
        public static string GetERaporSignedSearchRequestEReceteTakipNo(string eReceteTakipNo)
        {
            TibbiMalzemeEReceteIslemleri.imzaliEReceteSorguIstekDVO eReceteSorgu = new TibbiMalzemeEReceteIslemleri.imzaliEReceteSorguIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eReceteSorgu.tesisKodu = Convert.ToString(saglikTesisKodu);
            eReceteSorgu.doktorTcKimlikNo = currentUser.UniqueNo;
            eReceteSorgu.surumNumarasi = "1";

            string imzalanacakXml = Common.SerializeObjectToXml(eReceteSorgu);
            imzalanacakXml = imzalanacakXml.Replace("imzaliEReceteSorguIstekDVO", "imzaliEreceteSorguBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }
        public static string GetERaporSignedDiagRequestEReceteTakipNo(string eReceteTakipNo)
        {
            TibbiMalzemeEReceteIslemleri.imzaliEReceteTaniEkleIstekDVO eReceteTani = new TibbiMalzemeEReceteIslemleri.imzaliEReceteTaniEkleIstekDVO();
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            eReceteTani.tesisKodu = Convert.ToString(saglikTesisKodu);
            eReceteTani.doktorTcKimlikNo = currentUser.UniqueNo;
            eReceteTani.surumNumarasi = "1";

            string imzalanacakXml = Common.SerializeObjectToXml(eReceteTani);
            imzalanacakXml = imzalanacakXml.Replace("imzaliEReceteTaniEkleIstekDVO", "imzaliEreceteTaniEkleBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }
    }
}