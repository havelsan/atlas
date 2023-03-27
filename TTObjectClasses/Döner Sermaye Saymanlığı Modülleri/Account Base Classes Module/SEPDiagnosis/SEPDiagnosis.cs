
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
    /// SEP Tanıları
    /// </summary>
    public partial class SEPDiagnosis : TTObject
    {
        public string MedulaDiagnoseType
        {
            get
            {
                if (DiagnosisType != null)
                {
                    if (DiagnosisType == DiagnosisTypeEnum.Primer)
                        return "1";
                    else if (DiagnosisType == DiagnosisTypeEnum.Seconder)
                        return "2";
                    else if (DiagnosisType == DiagnosisTypeEnum.Pathological)
                        return "3";
                }

                return null;
            }
        }

        public string MedulaIsPrimaryDiagnose
        {
            get
            {
                if (IsMainDiagnose == true)
                    return "E";
                else
                    return "H";
            }
        }

        public string DiagnoseCode
        {
            get
            {
                if (Diagnose != null)
                {
                    if (!string.IsNullOrEmpty(Diagnose.Code))
                    {
                        // 5 karakterden uzun tanı kodlarını bazen kabul etmiyor Hiperbarik te falan, bü yüzden ilk 5 karakteri alındı )
                        if (Diagnose.Code.Length > 5)
                            return Diagnose.Code.Substring(0, 5);
                        else
                            return Diagnose.Code;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Medula Referans Numarası
        /// </summary>
        public string MedulaReferenceNumber
        {
            get
            {
                if (Id.Value != null)
                    return "T" + Id.Value.ToString();

                return null;
            }
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew == true)
            {
                Id.GetNextValue();
                CurrentStateDefID = SEPDiagnosis.States.New;
            }
        }

        public object GetDVO()
        {
            HizmetKayitIslemleri.taniBilgisiDVO taniBilgisiDVO = new HizmetKayitIslemleri.taniBilgisiDVO();

            //taniBilgisiDVO.islemSiraNo = MedulaProcessNo;
            taniBilgisiDVO.birincilTani = MedulaIsPrimaryDiagnose;
            taniBilgisiDVO.hizmetSunucuRefNo = MedulaReferenceNumber;
            taniBilgisiDVO.taniKodu = DiagnoseCode;
            taniBilgisiDVO.taniTipi = MedulaDiagnoseType;

            taniBilgisiDVO.ozelDurum = (OzelDurum != null) ? OzelDurum.ozelDurumKodu : null;

            if (CokluOzelDurum != null && CokluOzelDurum.Count > 0)
            {
                List<String> listCokluOzelDurum = new List<String>();
                foreach (CokluOzelDurum cod in CokluOzelDurum)
                    listCokluOzelDurum.Add(cod.OzelDurum.ozelDurumKodu);

                taniBilgisiDVO.cokluOzelDurum = listCokluOzelDurum.ToArray();
            }

            return taniBilgisiDVO;
        }

        public SEPDiagnosis CopySEPDiagnosis(SubEpisodeProtocol newSEP, bool copyInNewState = false)
        {
            SEPDiagnosis newSD = Clone() as SEPDiagnosis;
            newSD.SubEpisodeProtocol = newSEP;

            if (copyInNewState)
                newSD.CurrentStateDefID = SEPDiagnosis.States.New;
            else
                newSD.CurrentStateDefID = CurrentStateDefID;

            TTSequence.allowSetSequenceValue = true;
            newSD.Id.SetSequenceValue(0);
            newSD.Id.GetNextValue();

            return newSD;
        }

        protected override void PreInsert()
        {
            #region PreInsert
            // Yeni DiagnosisGrid oluştuğunda, Takip "Hizmet Kaydı Tamamlandı" durumunda ise "Hizmet Kaydı Tamamlanmadı" durumuna almak lazım
            if (DiagnosisGrid == null || DiagnosisGrid.EpisodeAction == null || DiagnosisGrid.EpisodeAction.IsOldAction != true)
            {
                if (CurrentStateDefID == SEPDiagnosis.States.New)
                {
                    if (SubEpisodeProtocol != null)
                    {
                        // Fatura Kayıt bekleyen veya Faturalandı durumundaki takibe tanı eklenememeli
                        if (  SubEpisodeProtocol.IsInvoiced)
                            throw new TTUtils.TTException("Fatura Kaydı Bekleyen veya Faturalandı durumundaki takip içerisine yeni tanı eklenemez. (Takip No: " + SubEpisodeProtocol.MedulaTakipNo + ")");

                        if (SubEpisodeProtocol.IsSGK)
                        {
                            if (SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProvisionNoNotExists && SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProcedureEntryWithError)
                                SubEpisodeProtocol.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                        }
                    }
                }
            }

            //Onkoloji tanısı girilirse tüm SEP lerin tedavi tipini Onkoloji yapar 
            /*
            if (SubEpisodeProtocol != null && SubEpisodeProtocol.Episode.IsMedulaEpisode() && DiagnoseCode.Substring(0, 1).Equals("C"))
            {
                foreach (SubEpisodeProtocol sep in SubEpisodeProtocol.Episode.SubEpisodeProtocols)
                {
                    if (!string.IsNullOrEmpty(sep.MedulaTakipNo))
                    {
                        if (sep.MedulaTedaviTipi != null && sep.MedulaTedaviTipi.tedaviTipiKodu != "14")
                        {
                            HastaKabulIslemleri.takipOkuGirisDVO takipOkuGirisDVO = new HastaKabulIslemleri.takipOkuGirisDVO();
                            takipOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                            takipOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
                            takipOkuGirisDVO.takipNo = sep.MedulaTakipNo;
                            takipOkuGirisDVO.yeniTedaviTipi = 14;

                            XXXXXXMedulaServices.HastaKabulOkuParam inputParam = new XXXXXXMedulaServices.HastaKabulOkuParam(takipOkuGirisDVO, sep.ObjectID.ToString(), "UpdateTedaviTipi");
                            HastaKabulIslemleri.WebMethods.updateTedaviTipiASync(TTObjectClasses.Sites.SiteLocalHost, inputParam, takipOkuGirisDVO);
                        }
                    }
                }
            }
            */
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate



            if (SubEpisodeProtocol != null && SubEpisodeProtocol.IsSGK) // Medula takibi varsa
            {
                // Tanının update ten önceki orjinal hali alınır
                TTObjectContext objContext = new TTObjectContext(true);
                SEPDiagnosis originalSEPDiagnosis = (SEPDiagnosis)objContext.GetObject(ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(SEPDiagnosis).Name], false);
                if (originalSEPDiagnosis != null)
                {
                    if (CurrentStateDefID == SEPDiagnosis.States.New)
                    {
                        if (originalSEPDiagnosis.CurrentStateDefID != SEPDiagnosis.States.New)
                        {
                            // Fatura Kayıt bekleyen veya Faturalandı durumundaki takip içinde Yeni durumunda tanı olmamalı
                            if ( SubEpisodeProtocol.IsInvoiced)
                                throw new TTUtils.TTException("Fatura Kaydı Bekleyen veya Faturalandı durumundaki takip içerisinde Yeni durumunda tanı olamaz. (Takip No: " + SubEpisodeProtocol.MedulaTakipNo + ")");
                        }

                        // Yeni durumuna geçilmiş ise Takibi "Hizmet Kaydı Tamamlanmadı" durumuna almak gerekir
                        if (originalSEPDiagnosis.CurrentStateDefID == SEPDiagnosis.States.MedulaDontSend || originalSEPDiagnosis.CurrentStateDefID == SEPDiagnosis.States.MedulaEntrySuccessful)
                        {
                            if (SubEpisodeProtocol.InvoiceStatus == MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted)
                                SubEpisodeProtocol.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                        }
                    }
                    else if (CurrentStateDefID == SEPDiagnosis.States.MedulaSentServer || CurrentStateDefID == SEPDiagnosis.States.MedulaEntrySuccessful)
                    {
                        if ((CurrentStateDefID == SEPDiagnosis.States.MedulaSentServer && originalSEPDiagnosis.CurrentStateDefID == SEPDiagnosis.States.MedulaSentServer) ||
                            (CurrentStateDefID == SEPDiagnosis.States.MedulaEntrySuccessful && originalSEPDiagnosis.CurrentStateDefID == SEPDiagnosis.States.MedulaEntrySuccessful))
                        {
                            if ((Diagnose == null && originalSEPDiagnosis.Diagnose != null) ||
                                (Diagnose != null && originalSEPDiagnosis.Diagnose == null) ||
                                (Diagnose != null && originalSEPDiagnosis.Diagnose != null && Diagnose.ObjectID != originalSEPDiagnosis.Diagnose.ObjectID) ||
                                (DiagnosisType == null && originalSEPDiagnosis.DiagnosisType != null) ||
                                (DiagnosisType != null && originalSEPDiagnosis.DiagnosisType == null) ||
                                (DiagnosisType != null && originalSEPDiagnosis.DiagnosisType != null && DiagnosisType.Value != originalSEPDiagnosis.DiagnosisType.Value) ||
                                (IsMainDiagnose == null && originalSEPDiagnosis.IsMainDiagnose != null) ||
                                (IsMainDiagnose != null && originalSEPDiagnosis.IsMainDiagnose == null) ||
                                (IsMainDiagnose != null && originalSEPDiagnosis.IsMainDiagnose != null && IsMainDiagnose.Value != originalSEPDiagnosis.IsMainDiagnose.Value) ||
                                (OzelDurum == null && originalSEPDiagnosis.OzelDurum != null) ||
                                (OzelDurum != null && originalSEPDiagnosis.OzelDurum == null) ||
                                (OzelDurum != null && originalSEPDiagnosis.OzelDurum != null && OzelDurum.ObjectID != originalSEPDiagnosis.OzelDurum.ObjectID))
                            {
                                string errorMsg = "Medula durumu 'Sunucuya Gönderildi' veya 'Tanı Kaydı Başarılı' olan tanıyı güncelleyebilmek için önce meduladan tanı bilgisi kaydı silinmelidir.";
                                if (originalSEPDiagnosis.Diagnose != null)
                                    errorMsg += " (Tanı: " + originalSEPDiagnosis.Diagnose.Code + " " + originalSEPDiagnosis.Diagnose.Name + ")";

                                throw new TTUtils.TTException(errorMsg);
                            }
                        }
                    }
                }
            }

            #endregion PreUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete

            base.PreDelete();
            if (CurrentStateDefID == SEPDiagnosis.States.MedulaSentServer || CurrentStateDefID == SEPDiagnosis.States.MedulaEntrySuccessful)
            {
                string errorMsg = "Medula durumu 'Sunucuya Gönderildi' veya 'Tanı Kaydı Başarılı' olan tanıyı silebilmek için önce meduladan tanı bilgisi kaydı silinmelidir.";
                if (Diagnose != null)
                    errorMsg += " (Tanı: " + Diagnose.Code + " " + Diagnose.Name + ")";

                throw new TTUtils.TTException(errorMsg);
            }

            #endregion PreDelete
        }
    }
}