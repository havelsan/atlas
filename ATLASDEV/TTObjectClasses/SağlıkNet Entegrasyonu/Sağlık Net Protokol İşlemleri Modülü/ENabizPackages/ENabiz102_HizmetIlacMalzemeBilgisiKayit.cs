using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTConnectionManager;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz102_HizmetIlacMalzemeBilgisiKayit
    {
        public class SYSSendMessage
        {
            public input input = new input();
        }



        public class input
        {
            public SYSMessage SYSMessage = new SYSMessage();
        }
        public class SYSMessage
        {
            public messageGuid messageGuid = new messageGuid();
            public messageType messageType = new messageType();
            public documentGenerationTime documentGenerationTime = new documentGenerationTime();
            public author author = new author();
            public firmaKodu firmaKodu = new firmaKodu();
            public recordData recordData = new recordData();
            public SYSMessage()
            {
                messageType.code = "102";
                messageType.value = "Hizmet/Ilaç/Malzeme Bilgisi Kayıt";
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public HASTA_ISLEM_BILGILERI HASTA_ISLEM_BILGILERI;

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class HASTA_ISLEM_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("ISLEM_BILGISI", Type = typeof(ISLEM_BILGISI))]
            public List<ISLEM_BILGISI> ISLEM_BILGISI = new List<ISLEM_BILGISI>();
        }
        public class ISLEM_BILGISI
        {
            //public SGK_TAKIP_NUMARASI SGK_TAKIP_NUMARASI = new SGK_TAKIP_NUMARASI();
            //public SGK_BILDIRIM SGK_BILDIRIM = new SGK_BILDIRIM();
            //public SGK_HIZMET_REFERANS_NUMARASI SGK_HIZMET_REFERANS_NUMARASI = new SGK_HIZMET_REFERANS_NUMARASI();
            public TARAF_BILGISI TARAF_BILGISI;
            public KLINIK_KODU KLINIK_KODU = new KLINIK_KODU();
            public GERCEKLESME_ZAMANI GERCEKLESME_ZAMANI = new GERCEKLESME_ZAMANI();
            public ISLEM_TURU ISLEM_TURU = new ISLEM_TURU();
            public ISLEM_KODU ISLEM_KODU = new ISLEM_KODU();
            public ISLEM_ADI ISLEM_ADI = new ISLEM_ADI();
            public GIRISIMSEL_ISLEM_KODU GIRISIMSEL_ISLEM_KODU = new GIRISIMSEL_ISLEM_KODU();
            public ISLEM_ZAMANI ISLEM_ZAMANI = new ISLEM_ZAMANI();
            public ADET ADET = new ADET();
            public HASTA_TUTARI HASTA_TUTARI = new HASTA_TUTARI();
            public KURUM_TUTARI KURUM_TUTARI = new KURUM_TUTARI();
            public RANDEVU_ZAMANI RANDEVU_ZAMANI = new RANDEVU_ZAMANI();
            public KULLANICI_KIMLIK_NUMARASI KULLANICI_KIMLIK_NUMARASI = new KULLANICI_KIMLIK_NUMARASI();
            public CIHAZ_NUMARASI CIHAZ_NUMARASI = new CIHAZ_NUMARASI();
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();

            [System.Xml.Serialization.XmlElement("ISLEM_PUAN_BILGISI", Type = typeof(ISLEM_PUAN_BILGISI))]
            public List<ISLEM_PUAN_BILGISI> ISLEM_PUAN_BILGISI = new List<ISLEM_PUAN_BILGISI>();

        }
        public class ISLEM_PUAN_BILGISI
        {
            public HEKIM_KIMLIK_NUMARASI HEKIM_KIMLIK_NUMARASI = new HEKIM_KIMLIK_NUMARASI();
            public ISLEM_PUANI ISLEM_PUANI = new ISLEM_PUANI();
            public PUAN_HAKEDIS_ZAMANI PUAN_HAKEDIS_ZAMANI = new PUAN_HAKEDIS_ZAMANI();

        }
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName,bool? FromInvoice = null,string outherSysTakipNo = null)
        {
            //InternalObjectGuid bu object için SubEpisodeID olacak
            recordData _recordData = new recordData();

            //internalobjectguid e subactionprocedure veya subactionmaterial gelecek, onlar secilerek bilgileri doldurulacak
            TTObjectContext objectContext = new TTObjectContext(false);

            SubActionProcedure sp = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubActionProcedure;
            if (sp != null)
            {
                if (!sp.IsCancelled)
                {
                    if (!string.IsNullOrEmpty(outherSysTakipNo))
                        _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = outherSysTakipNo;
                    else
                    {
                        if (sp.SubEpisode.SYSTakipNo == null)
                            throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                        else
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SubEpisode.SYSTakipNo;
                    }
                    _recordData.HASTA_ISLEM_BILGILERI = new HASTA_ISLEM_BILGILERI();

                    ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
                    SpecialityDefinition Speciality;
                    string resBrans = "";


                    if(sp is LaboratoryProcedure)
                    {
                        resBrans = ((LaboratoryProcedure)sp).GetBranchCodeForLaboratoryProcedure();
                    }
                    else
                        resBrans = sp.EpisodeAction.GetBranchCodeForMedula();


                    if (resBrans != null)
                    {
                        IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                        if (specialtyList.Count > 0)
                            Speciality = (SpecialityDefinition)specialtyList[0];
                        else
                            throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                        if (Speciality.SKRSKlinik != null)
                            ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
                        else
                            throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");

                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;
                        ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ISLEM);

                        string Code;
                        if (sp.ProcedureObject != null && sp.ProcedureObject is BulletinProcedureDefinition)
                            Code = "P520030";
                        else
                            Code = sp.ProcedureObject.SUTPriceCode();

                        ISLEM_BILGISI.ISLEM_KODU.value = (Code != null ? Code.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty); //TODO: code un sut daki kod alanından gelecek.
                        ISLEM_BILGISI.ISLEM_ADI.value = (sp.ProcedureObject.Name != null ? sp.ProcedureObject.Name : string.Empty);  //TODO: ismi sut daki ısım alanından gelecek.
                        var tibbiIslem = SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu(objectContext, sp.ProcedureObject.GILCode);
                        if (tibbiIslem != null)
                        {
                            ISLEM_BILGISI.ISLEM_PUAN_BILGISI = new List<ISLEM_PUAN_BILGISI>();
                            foreach (SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu_Class islem in tibbiIslem)
                            {
                                ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = islem.KODU.ToString(); //TODO:code ile ayni olması kararlastırıldı
                                ISLEM_PUAN_BILGISI ISLEM_PUAN_BILGISI = new ISLEM_PUAN_BILGISI();
                                ISLEM_PUAN_BILGISI.HEKIM_KIMLIK_NUMARASI.value = sp.ProcedureByUser != null ? sp.ProcedureByUser.UniqueNo.ToString() : String.Empty;
                                ISLEM_PUAN_BILGISI.ISLEM_PUANI.value = islem.ISLEMPUANI.ToString();
                                ISLEM_PUAN_BILGISI.PUAN_HAKEDIS_ZAMANI.value = "";
                                ISLEM_BILGISI.ISLEM_PUAN_BILGISI.Add(ISLEM_PUAN_BILGISI);
                                break;
                            }
                        }
                        else
                        {
                            ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = String.Empty;
                        }

                        DateTime updatedDate = Convert.ToDateTime("01/01/1900");
                        if (sp.CreationDate != null)
                        {
                            updatedDate = (DateTime)sp.CreationDate;
                            if ((DateTime)sp.CreationDate < (DateTime)sp.SubEpisode.OpeningDate)
                            {
                                updatedDate = (DateTime)Convert.ToDateTime(sp.SubEpisode.OpeningDate).AddMinutes(1);
                                ISLEM_BILGISI.ISLEM_ZAMANI.value = updatedDate.ToString("yyyyMMddHHmm");
                            }
                            else
                                ISLEM_BILGISI.ISLEM_ZAMANI.value = sp.CreationDate.Value.ToString("yyyyMMddHHmm");

                        }
                        else
                            ISLEM_BILGISI.ISLEM_ZAMANI.value = string.Empty;

                        if (updatedDate < sp.PerformedDate)
                            ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (sp.PerformedDate != null ? sp.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                        else
                            ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (sp.PerformedDate != null ? updatedDate.AddMinutes(1).ToString("yyyyMMddHHmm") : string.Empty);


                        ISLEM_BILGISI.ADET.value = (sp.Amount != null ? sp.Amount.ToString() : "1");

                        double hastaTutar = 0;
                        double kurumTutar = 0;

                        foreach (AccountTransaction at in sp.AccountTransactions)
                        {
                            if (!at.IsCancelled)
                            {
                                if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PATIENT)
                                    hastaTutar = hastaTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PAYER)
                                {
                                    kurumTutar = kurumTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                    //if (at.SubEpisodeProtocol.IsSGK && !string.IsNullOrEmpty(at.SubEpisodeProtocol.MedulaTakipNo))
                                    //{
                                    //    ISLEM_BILGISI.SGK_TAKIP_NUMARASI.value = at.SubEpisodeProtocol.MedulaTakipNo;
                                    //    if(sp is PMAddingProcedure || (FromInvoice.HasValue && FromInvoice.Value) ) 
                                    //        ISLEM_BILGISI.SGK_BILDIRIM.value = "2";
                                    //    else
                                    //        ISLEM_BILGISI.SGK_BILDIRIM.value = "1";
                                    //    ISLEM_BILGISI.SGK_HIZMET_REFERANS_NUMARASI.value = at.MedulaReferenceNumber;
                                    //}
                                }
                            }
                        }

                        //Gerceklesme zamanı Subactionprocedure.PerformedDate den set edilecek, 15/01/2018 GNL

                        //ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (sp.PerformedDate != null ? sp.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                         
                        //if (hastaTutar > 0)
                        //{
                        ISLEM_BILGISI.HASTA_TUTARI.value = hastaTutar.ToString().Replace(",", ".");
                        //}
                        //if (kurumTutar > 0)
                        //{
                        ISLEM_BILGISI.KURUM_TUTARI.value = kurumTutar.ToString().Replace(",", ".");
                        //}
                        BindingList<Appointment> appList = new BindingList<Appointment>();
                        appList = SubActionProcedure.GetMyCompletedAppointments(sp.ObjectID);

                        if (appList.Count > 0)
                            ISLEM_BILGISI.RANDEVU_ZAMANI.value = (appList[0].AppDate != null ? appList[0].AppDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                        else
                            ISLEM_BILGISI.RANDEVU_ZAMANI.value = "";


                        if (sp.RequestedByUser != null)
                        {
                            if (sp.RequestedByUser.Person != null)
                                ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (sp.RequestedByUser.Person.UniqueRefNo != null ? sp.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
                            else
                                ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                        }
                        else
                            ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";

                        ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
                        ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = sp.ObjectID.ToString();

                        _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI = new List<ISLEM_BILGISI>();
                        _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
                    }
                    else
                        throw new Exception(TTUtils.CultureService.GetText("M25976", "Hizmetin verildiği bölümün branş kodu bulunamadı."));
                }
                else
                    throw new Exception("SubactionProcedure iptal edilmiş.");
            }
            else
            {
                SubActionMaterial sm = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubActionMaterial;
                if (sm != null)
                {
                    if (!sm.IsCancelled)
                    {
                        if (!string.IsNullOrEmpty(outherSysTakipNo))
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = outherSysTakipNo;
                        else
                        {
                            if (sm.SubEpisode.SYSTakipNo == null)
                                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                            else
                                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sm.SubEpisode.SYSTakipNo;
                        }
                        _recordData.HASTA_ISLEM_BILGILERI = new HASTA_ISLEM_BILGILERI();

                        ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
                        SpecialityDefinition Speciality;
                        string resBrans = "";

                        if (sm.EpisodeAction != null)
                            resBrans = sm.EpisodeAction.GetBranchCodeForMedula();
                        else
                            resBrans = sm.SubactionProcedureFlowable.GetBranchCodeForMedula();

                        if (resBrans != null)
                        {
                            IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                            if (specialtyList.Count > 0)
                                Speciality = (SpecialityDefinition)specialtyList[0];
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                            if (Speciality.SKRSKlinik != null)
                                ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
                            else
                                throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");


                            // SS

                            ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;

                            if (sm.Material is ConsumableMaterialDefinition)
                                ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.MALZEME);
                            else if (sm.Material is DrugDefinition)
                                ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ILAC);

                            ISLEM_BILGISI.ISLEM_KODU.value = (sm.Material.Barcode != null ? sm.Material.Barcode.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty);
                            ISLEM_BILGISI.ISLEM_ADI.value = (sm.Material.Name != null ? sm.Material.Name : string.Empty);

                            ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = "";

                            DateTime updatedDate = sm.CreationDate.Value;
                            if ((DateTime)sm.CreationDate <= (DateTime)sm.SubEpisode.OpeningDate)
                            {
                                updatedDate = (DateTime)Convert.ToDateTime(sm.SubEpisode.OpeningDate).AddMinutes(1);
                            }

                            double hastaTutar = 0;
                            double kurumTutar = 0;
                            foreach (AccountTransaction at in sm.AccountTransactions)
                            {
                                if (!at.IsCancelled)
                                {
                                    if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PATIENT)
                                        hastaTutar = hastaTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                    if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PAYER)
                                        kurumTutar = kurumTutar + Convert.ToDouble(at.UnitPrice * at.Amount);

                                    if ((DateTime)at.TransactionDate <= (DateTime)updatedDate)
                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = updatedDate.AddMinutes(1).ToString("yyyyMMddHHmm");
                                    else
                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (at.TransactionDate != null ? at.TransactionDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                                }
                            }

                            if (sm is DrugOrderDetail)
                            {
                                ISLEM_BILGISI.ISLEM_ZAMANI.value = ((DrugOrderDetail)sm).DrugOrder.PlannedStartTime.Value.ToString("yyyyMMddHHmm");
                                ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = ((DrugOrderDetail)sm).OrderPlannedDate.Value.ToString("yyyyMMddHHmm");

                            }
                            else
                            {
                                ISLEM_BILGISI.ISLEM_ZAMANI.value = sm.CreationDate.Value.ToString("yyyyMMddHHmm");
                            }

                            ISLEM_BILGISI.ADET.value = (sm.Amount != null ? sm.Amount.ToString() : "1");

                            ISLEM_BILGISI.HASTA_TUTARI.value = hastaTutar.ToString().Replace(",", ".");
                            ISLEM_BILGISI.KURUM_TUTARI.value = kurumTutar.ToString().Replace(",", ".");


                            ISLEM_BILGISI.RANDEVU_ZAMANI.value = "";

                            if (sm.RequestedByUser != null)
                            {
                                if (sm.RequestedByUser.Person != null)
                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (sm.RequestedByUser.Person.UniqueRefNo != null ? sm.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
                                else
                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                            }
                            else
                                ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";

                            ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
                            ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = sm.ObjectID.ToString();

                            _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI = new List<ISLEM_BILGISI>();
                            _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
                        }
                        else
                            throw new Exception(TTUtils.CultureService.GetText("M25976", "Hizmetin verildiği bölümün branş kodu bulunamadı."));
                    }
                    else
                        throw new Exception("SubactionMaterial iptal edilmiş.");
                }
                else
                {
                    ENabizMaterial eNabizMaterial = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as ENabizMaterial;
                    if (eNabizMaterial != null)
                    {
                        if (eNabizMaterial.CurrentStateDefID != ENabizMaterial.States.Cancelled)
                        {
                            if (!string.IsNullOrEmpty(outherSysTakipNo))
                                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = outherSysTakipNo;
                            else
                            {
                                if (eNabizMaterial.SubActionMaterial.SubEpisode.SYSTakipNo == null)
                                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                                else
                                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = eNabizMaterial.SubActionMaterial.SubEpisode.SYSTakipNo;
                            }
                            _recordData.HASTA_ISLEM_BILGILERI = new HASTA_ISLEM_BILGILERI();

                            ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
                            SpecialityDefinition Speciality;
                            string resBrans = "";

                            if (eNabizMaterial.SubActionMaterial.EpisodeAction != null)
                                resBrans = eNabizMaterial.SubActionMaterial.EpisodeAction.GetBranchCodeForMedula();
                            else
                                resBrans = eNabizMaterial.SubActionMaterial.SubactionProcedureFlowable.GetBranchCodeForMedula();

                            if (resBrans != null)
                            {
                                IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                                if (specialtyList.Count > 0)
                                    Speciality = (SpecialityDefinition)specialtyList[0];
                                else
                                    throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                                if (Speciality.SKRSKlinik != null)
                                    ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
                                else
                                    throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");

                                ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;

                                if (eNabizMaterial.SubActionMaterial.Material is ConsumableMaterialDefinition)
                                {
                                    ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.MALZEME);
                                    ISLEM_BILGISI.ISLEM_KODU.value = (eNabizMaterial.SubActionMaterial.Material.Code != null ? eNabizMaterial.SubActionMaterial.Material.Code.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty);
                                }
                                else if (eNabizMaterial.SubActionMaterial.Material is DrugDefinition)
                                {
                                    ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ILAC);
                                    ISLEM_BILGISI.ISLEM_KODU.value = (eNabizMaterial.SubActionMaterial.Material.Barcode != null ? eNabizMaterial.SubActionMaterial.Material.Barcode.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty);
                                }

                                ISLEM_BILGISI.ISLEM_ADI.value = (eNabizMaterial.SubActionMaterial.Material.Name != null ? eNabizMaterial.SubActionMaterial.Material.Name : string.Empty);
                                ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = "";
                                ISLEM_BILGISI.ISLEM_ZAMANI.value = eNabizMaterial.RequestDate.Value.ToString("yyyyMMddHHmm");
                                ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = eNabizMaterial.ApplicationDate.Value.ToString("yyyyMMddHHmm");
                                ISLEM_BILGISI.RANDEVU_ZAMANI.value = "";
                                ISLEM_BILGISI.ADET.value = "1";

                                double amount = 1;

                                if (eNabizMaterial.AccountTransaction != null)
                                {
                                    //if (eNabizMaterial.AccountTransaction.SubEpisodeProtocol.IsSGK && !String.IsNullOrEmpty(eNabizMaterial.AccountTransaction.SubEpisodeProtocol.MedulaTakipNo))
                                    //{
                                    //    ISLEM_BILGISI.SGK_TAKIP_NUMARASI.value = eNabizMaterial.AccountTransaction.SubEpisodeProtocol.MedulaTakipNo;

                                    //    if (FromInvoice.HasValue && FromInvoice.Value)
                                    //        ISLEM_BILGISI.SGK_BILDIRIM.value = "2";
                                    //    else
                                    //        ISLEM_BILGISI.SGK_BILDIRIM.value = "1";

                                    //    ISLEM_BILGISI.SGK_HIZMET_REFERANS_NUMARASI.value = eNabizMaterial.AccountTransaction.MedulaReferenceNumber;
                                    //}
                                    amount = eNabizMaterial.AccountTransaction.Amount.Value;
                                    ISLEM_BILGISI.ADET.value = amount.ToString();
                                }

                                ISLEM_BILGISI.HASTA_TUTARI.value = (eNabizMaterial.PatientPrice * amount).ToString().Replace(",", ".");
                                ISLEM_BILGISI.KURUM_TUTARI.value = (eNabizMaterial.PayerPrice * amount).ToString().Replace(",", ".");

                                if (eNabizMaterial.SubActionMaterial.RequestedByUser != null)
                                {
                                    if (eNabizMaterial.SubActionMaterial.RequestedByUser.Person != null)
                                        ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (eNabizMaterial.SubActionMaterial.RequestedByUser.Person.UniqueRefNo != null ? eNabizMaterial.SubActionMaterial.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
                                    else
                                        ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                                }
                                else
                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";

                                ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
                                ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = eNabizMaterial.ObjectID.ToString();

                                _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI = new List<ISLEM_BILGISI>();
                                _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
                            }
                            else
                                throw new Exception(TTUtils.CultureService.GetText("M25976", "Hizmetin verildiği bölümün branş kodu bulunamadı."));
                        }
                        else
                            throw new Exception("ENabizMaterial iptal edilmiş.");
                    }
                }

            }

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }



        public static SYSMessage Get_V2()
        {
            recordData _recordData = new recordData();
            DbConnection dbConnection = ConnectionManager.CreateConnection();

            dbConnection.Open();
            try
            {
             
                string paramSql = "Select distinct S.internalobjectid,S.internalobjectdefname from SENDTOENABIZ S left join ResponseOfENabiz R on R.Sendtoenabiz = S.ObjectID " +
                                " inner join Subepisode SB on S.Subepisode = SB.ObjectID " +
                                " inner join SubactionProcedure SP on SP.ObjectID = S.InternalObjectID " +
                                " INNER JOIN TTOBJECTSTATEDEF T ON T.STATEDEFID = SP.CURRENTSTATEDEFID " +
                                " inner join Accounttransaction AT on AT.Subactionprocedure = sp.ObjectID " +
                                " left join proceduredefinition pd on pd.objectID = SP.procedureobject " +
                                " where SB.ProtocolNo = '261556-1'" +
                                " and S.status <> 1" +
                                " and S.status <> 0" +
                                " and t.STATUS <> 4" +
                                " and S.packagecode = 102";


                DbCommand cmd = ConnectionManager.CreateCommand(paramSql, dbConnection);
                DbDataAdapter adap = ConnectionManager.CreateDataAdapter(cmd);
                DataSet ds = new DataSet("DataSet");
                adap.Fill(ds);
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    _recordData.HASTA_ISLEM_BILGILERI = new HASTA_ISLEM_BILGILERI();

                    _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI = new List<ISLEM_BILGISI>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string InternalObjectGuid = row.ItemArray[0].ToString();
                        string InternalObjectDefName = row.ItemArray[1].ToString();


                        TTObjectContext objectContext = new TTObjectContext(false);

                        SubActionProcedure sp = objectContext.GetObject(new Guid(InternalObjectGuid), InternalObjectDefName) as SubActionProcedure;
                        if (sp != null)
                        {
                            if (!sp.IsCancelled)
                            {

                                if (sp.SubEpisode.SYSTakipNo == null)
                                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                                else
                                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SubEpisode.SYSTakipNo;


                                ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
                                SpecialityDefinition Speciality;
                                string resBrans = "";


                                if (sp is LaboratoryProcedure)
                                {
                                    resBrans = ((LaboratoryProcedure)sp).GetBranchCodeForLaboratoryProcedure();
                                }
                                else
                                    resBrans = sp.EpisodeAction.GetBranchCodeForMedula();


                                if (resBrans != null)
                                {
                                    IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                                    if (specialtyList.Count > 0)
                                        Speciality = (SpecialityDefinition)specialtyList[0];
                                    else
                                        throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                                    if (Speciality.SKRSKlinik != null)
                                        ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
                                    else
                                        throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");

                                    ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;
                                    ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ISLEM);

                                    string Code;
                                    if (sp.ProcedureObject != null && sp.ProcedureObject is BulletinProcedureDefinition)
                                        Code = "P520030";
                                    else
                                        Code = sp.ProcedureObject.SUTPriceCode();

                                    ISLEM_BILGISI.ISLEM_KODU.value = (Code != null ? Code.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty); //TODO: code un sut daki kod alanından gelecek.
                                    ISLEM_BILGISI.ISLEM_ADI.value = (sp.ProcedureObject.Name != null ? sp.ProcedureObject.Name : string.Empty);  //TODO: ismi sut daki ısım alanından gelecek.
                                    var tibbiIslem = SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu(objectContext, sp.ProcedureObject.GILCode);
                                    if (tibbiIslem != null)
                                    {
                                        ISLEM_BILGISI.ISLEM_PUAN_BILGISI = new List<ISLEM_PUAN_BILGISI>();
                                        foreach (SKRSTibbiIslemPuanBilgisi.GetSKRSTibbiIslemPuanBilgisiByKodu_Class islem in tibbiIslem)
                                        {
                                            ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = islem.KODU.ToString(); //TODO:code ile ayni olması kararlastırıldı
                                            ISLEM_PUAN_BILGISI ISLEM_PUAN_BILGISI = new ISLEM_PUAN_BILGISI();
                                            ISLEM_PUAN_BILGISI.HEKIM_KIMLIK_NUMARASI.value = sp.ProcedureByUser != null ? sp.ProcedureByUser.UniqueNo.ToString() : String.Empty;
                                            ISLEM_PUAN_BILGISI.ISLEM_PUANI.value = islem.ISLEMPUANI.ToString();
                                            ISLEM_PUAN_BILGISI.PUAN_HAKEDIS_ZAMANI.value = "";
                                            ISLEM_BILGISI.ISLEM_PUAN_BILGISI.Add(ISLEM_PUAN_BILGISI);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = String.Empty;
                                    }

                                    DateTime updatedDate = Convert.ToDateTime("01/01/1900");
                                    if (sp.CreationDate != null)
                                    {
                                        updatedDate = (DateTime)sp.CreationDate;
                                        if ((DateTime)sp.CreationDate < (DateTime)sp.SubEpisode.OpeningDate)
                                        {
                                            updatedDate = (DateTime)Convert.ToDateTime(sp.SubEpisode.OpeningDate).AddMinutes(1);
                                            ISLEM_BILGISI.ISLEM_ZAMANI.value = updatedDate.ToString("yyyyMMddHHmm");
                                        }
                                        else
                                            ISLEM_BILGISI.ISLEM_ZAMANI.value = sp.CreationDate.Value.ToString("yyyyMMddHHmm");

                                    }
                                    else
                                        ISLEM_BILGISI.ISLEM_ZAMANI.value = string.Empty;

                                    if (updatedDate < sp.PerformedDate)
                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (sp.PerformedDate != null ? sp.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                                    else
                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (sp.PerformedDate != null ? updatedDate.AddMinutes(1).ToString("yyyyMMddHHmm") : string.Empty);


                                    ISLEM_BILGISI.ADET.value = (sp.Amount != null ? sp.Amount.ToString() : "1");

                                    double hastaTutar = 0;
                                    double kurumTutar = 0;

                                    foreach (AccountTransaction at in sp.AccountTransactions)
                                    {
                                        if (!at.IsCancelled)
                                        {
                                            if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PATIENT)
                                                hastaTutar = hastaTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                            if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PAYER)
                                            {
                                                kurumTutar = kurumTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                                //if (at.SubEpisodeProtocol.IsSGK && !string.IsNullOrEmpty(at.SubEpisodeProtocol.MedulaTakipNo))
                                                //{
                                                //    ISLEM_BILGISI.SGK_TAKIP_NUMARASI.value = at.SubEpisodeProtocol.MedulaTakipNo;
                                                //    if(sp is PMAddingProcedure || (FromInvoice.HasValue && FromInvoice.Value) ) 
                                                //        ISLEM_BILGISI.SGK_BILDIRIM.value = "2";
                                                //    else
                                                //        ISLEM_BILGISI.SGK_BILDIRIM.value = "1";
                                                //    ISLEM_BILGISI.SGK_HIZMET_REFERANS_NUMARASI.value = at.MedulaReferenceNumber;
                                                //}
                                            }
                                        }
                                    }

                                    //Gerceklesme zamanı Subactionprocedure.PerformedDate den set edilecek, 15/01/2018 GNL

                                    //ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (sp.PerformedDate != null ? sp.PerformedDate.Value.ToString("yyyyMMddHHmm") : string.Empty);

                                    //if (hastaTutar > 0)
                                    //{
                                    ISLEM_BILGISI.HASTA_TUTARI.value = hastaTutar.ToString().Replace(",", ".");
                                    //}
                                    //if (kurumTutar > 0)
                                    //{
                                    ISLEM_BILGISI.KURUM_TUTARI.value = kurumTutar.ToString().Replace(",", ".");
                                    //}
                                    BindingList<Appointment> appList = new BindingList<Appointment>();
                                    appList = SubActionProcedure.GetMyCompletedAppointments(sp.ObjectID);

                                    if (appList.Count > 0)
                                        ISLEM_BILGISI.RANDEVU_ZAMANI.value = (appList[0].AppDate != null ? appList[0].AppDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                                    else
                                        ISLEM_BILGISI.RANDEVU_ZAMANI.value = "";


                                    if (sp.RequestedByUser != null)
                                    {
                                        if (sp.RequestedByUser.Person != null)
                                            ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (sp.RequestedByUser.Person.UniqueRefNo != null ? sp.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
                                        else
                                            ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                                    }
                                    else
                                        ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";

                                    ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
                                    ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = sp.ObjectID.ToString();


                                    _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
                                }
                                else
                                    throw new Exception(TTUtils.CultureService.GetText("M25976", "Hizmetin verildiği bölümün branş kodu bulunamadı."));
                            }
                            else
                                throw new Exception("SubactionProcedure iptal edilmiş.");
                        }
                        else
                        {
                            SubActionMaterial sm = objectContext.GetObject(new Guid(InternalObjectGuid), InternalObjectDefName) as SubActionMaterial;
                            if (sm != null)
                            {
                                if (!sm.IsCancelled)
                                {

                                    if (sm.SubEpisode.SYSTakipNo == null)
                                        throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                                    else
                                        _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sm.SubEpisode.SYSTakipNo;


                                    ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
                                    SpecialityDefinition Speciality;
                                    string resBrans = "";

                                    if (sm.EpisodeAction != null)
                                        resBrans = sm.EpisodeAction.GetBranchCodeForMedula();
                                    else
                                        resBrans = sm.SubactionProcedureFlowable.GetBranchCodeForMedula();

                                    if (resBrans != null)
                                    {
                                        IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                                        if (specialtyList.Count > 0)
                                            Speciality = (SpecialityDefinition)specialtyList[0];
                                        else
                                            throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                                        if (Speciality.SKRSKlinik != null)
                                            ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
                                        else
                                            throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");


                                        // SS

                                        ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;

                                        if (sm.Material is ConsumableMaterialDefinition)
                                            ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.MALZEME);
                                        else if (sm.Material is DrugDefinition)
                                            ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ILAC);

                                        ISLEM_BILGISI.ISLEM_KODU.value = (sm.Material.Barcode != null ? sm.Material.Barcode.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty);
                                        ISLEM_BILGISI.ISLEM_ADI.value = (sm.Material.Name != null ? sm.Material.Name : string.Empty);

                                        ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = "";

                                        DateTime updatedDate = sm.CreationDate.Value;
                                        if ((DateTime)sm.CreationDate <= (DateTime)sm.SubEpisode.OpeningDate)
                                        {
                                            updatedDate = (DateTime)Convert.ToDateTime(sm.SubEpisode.OpeningDate).AddMinutes(1);
                                        }

                                        double hastaTutar = 0;
                                        double kurumTutar = 0;
                                        foreach (AccountTransaction at in sm.AccountTransactions)
                                        {
                                            if (!at.IsCancelled)
                                            {
                                                if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PATIENT)
                                                    hastaTutar = hastaTutar + Convert.ToDouble(at.UnitPrice * at.Amount);
                                                if (at.AccountPayableReceivable.Type.Value == APRTypeEnum.PAYER)
                                                    kurumTutar = kurumTutar + Convert.ToDouble(at.UnitPrice * at.Amount);

                                                if ((DateTime)at.TransactionDate <= (DateTime)updatedDate)
                                                    ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = updatedDate.AddMinutes(1).ToString("yyyyMMddHHmm");
                                                else
                                                    ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = (at.TransactionDate != null ? at.TransactionDate.Value.ToString("yyyyMMddHHmm") : string.Empty);
                                            }
                                        }

                                        if (sm is DrugOrderDetail)
                                        {
                                            ISLEM_BILGISI.ISLEM_ZAMANI.value = ((DrugOrderDetail)sm).DrugOrder.PlannedStartTime.Value.ToString("yyyyMMddHHmm");
                                            ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = ((DrugOrderDetail)sm).OrderPlannedDate.Value.ToString("yyyyMMddHHmm");

                                        }
                                        else
                                        {
                                            ISLEM_BILGISI.ISLEM_ZAMANI.value = sm.CreationDate.Value.ToString("yyyyMMddHHmm");
                                        }

                                        ISLEM_BILGISI.ADET.value = (sm.Amount != null ? sm.Amount.ToString() : "1");

                                        ISLEM_BILGISI.HASTA_TUTARI.value = hastaTutar.ToString().Replace(",", ".");
                                        ISLEM_BILGISI.KURUM_TUTARI.value = kurumTutar.ToString().Replace(",", ".");


                                        ISLEM_BILGISI.RANDEVU_ZAMANI.value = "";

                                        if (sm.RequestedByUser != null)
                                        {
                                            if (sm.RequestedByUser.Person != null)
                                                ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (sm.RequestedByUser.Person.UniqueRefNo != null ? sm.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
                                            else
                                                ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                                        }
                                        else
                                            ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";

                                        ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
                                        ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = sm.ObjectID.ToString();


                                        _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
                                    }
                                    else
                                        throw new Exception(TTUtils.CultureService.GetText("M25976", "Hizmetin verildiği bölümün branş kodu bulunamadı."));
                                }
                                else
                                    throw new Exception("SubactionMaterial iptal edilmiş.");
                            }
                            else
                            {
                                ENabizMaterial eNabizMaterial = objectContext.GetObject(new Guid(InternalObjectGuid), InternalObjectDefName) as ENabizMaterial;
                                if (eNabizMaterial != null)
                                {
                                    if (eNabizMaterial.CurrentStateDefID != ENabizMaterial.States.Cancelled)
                                    {

                                        if (eNabizMaterial.SubActionMaterial.SubEpisode.SYSTakipNo == null)
                                            throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                                        else
                                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = eNabizMaterial.SubActionMaterial.SubEpisode.SYSTakipNo;


                                        ISLEM_BILGISI ISLEM_BILGISI = new ISLEM_BILGISI();
                                        SpecialityDefinition Speciality;
                                        string resBrans = "";

                                        if (eNabizMaterial.SubActionMaterial.EpisodeAction != null)
                                            resBrans = eNabizMaterial.SubActionMaterial.EpisodeAction.GetBranchCodeForMedula();
                                        else
                                            resBrans = eNabizMaterial.SubActionMaterial.SubactionProcedureFlowable.GetBranchCodeForMedula();

                                        if (resBrans != null)
                                        {
                                            IBindingList specialtyList = SpecialityDefinition.GetSpecialityByCode(objectContext, resBrans);
                                            if (specialtyList.Count > 0)
                                                Speciality = (SpecialityDefinition)specialtyList[0];
                                            else
                                                throw new Exception(TTUtils.CultureService.GetText("M25977", "Hizmetin verildiği uzmanlık dalı kodu bulunamadı."));

                                            if (Speciality.SKRSKlinik != null)
                                                ISLEM_BILGISI.KLINIK_KODU = new KLINIK_KODU(Speciality.SKRSKlinik.KODU, Speciality.SKRSKlinik.ADI); //sp.ProcedureSpeciality.Code
                                            else
                                                throw new Exception("Hizmetin verildiği uzmanlık dalının SKRS Klinik kodu eşleşmesi bulunamadı.");

                                            ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = string.Empty;

                                            if (eNabizMaterial.SubActionMaterial.Material is ConsumableMaterialDefinition)
                                            {
                                                ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.MALZEME);
                                                ISLEM_BILGISI.ISLEM_KODU.value = (eNabizMaterial.SubActionMaterial.Material.Code != null ? eNabizMaterial.SubActionMaterial.Material.Code.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty);
                                            }
                                            else if (eNabizMaterial.SubActionMaterial.Material is DrugDefinition)
                                            {
                                                ISLEM_BILGISI.ISLEM_TURU = new ISLEM_TURU(ISLEMTURU.ILAC);
                                                ISLEM_BILGISI.ISLEM_KODU.value = (eNabizMaterial.SubActionMaterial.Material.Barcode != null ? eNabizMaterial.SubActionMaterial.Material.Barcode.ToString().Replace(".", "").ToString().Replace("-", "").ToString().Replace(",", "") : string.Empty);
                                            }

                                            ISLEM_BILGISI.ISLEM_ADI.value = (eNabizMaterial.SubActionMaterial.Material.Name != null ? eNabizMaterial.SubActionMaterial.Material.Name : string.Empty);
                                            ISLEM_BILGISI.GIRISIMSEL_ISLEM_KODU.value = "";
                                            ISLEM_BILGISI.ISLEM_ZAMANI.value = eNabizMaterial.RequestDate.Value.ToString("yyyyMMddHHmm");
                                            ISLEM_BILGISI.GERCEKLESME_ZAMANI.value = eNabizMaterial.ApplicationDate.Value.ToString("yyyyMMddHHmm");
                                            ISLEM_BILGISI.RANDEVU_ZAMANI.value = "";
                                            ISLEM_BILGISI.ADET.value = "1";

                                            double amount = 1;

                                            if (eNabizMaterial.AccountTransaction != null)
                                            {
                                                //if (eNabizMaterial.AccountTransaction.SubEpisodeProtocol.IsSGK && !String.IsNullOrEmpty(eNabizMaterial.AccountTransaction.SubEpisodeProtocol.MedulaTakipNo))
                                                //{
                                                //    ISLEM_BILGISI.SGK_TAKIP_NUMARASI.value = eNabizMaterial.AccountTransaction.SubEpisodeProtocol.MedulaTakipNo;

                                                //    if (FromInvoice.HasValue && FromInvoice.Value)
                                                //        ISLEM_BILGISI.SGK_BILDIRIM.value = "2";
                                                //    else
                                                //        ISLEM_BILGISI.SGK_BILDIRIM.value = "1";

                                                //    ISLEM_BILGISI.SGK_HIZMET_REFERANS_NUMARASI.value = eNabizMaterial.AccountTransaction.MedulaReferenceNumber;
                                                //}
                                                amount = eNabizMaterial.AccountTransaction.Amount.Value;
                                                ISLEM_BILGISI.ADET.value = amount.ToString();
                                            }

                                            ISLEM_BILGISI.HASTA_TUTARI.value = (eNabizMaterial.PatientPrice * amount).ToString().Replace(",", ".");
                                            ISLEM_BILGISI.KURUM_TUTARI.value = (eNabizMaterial.PayerPrice * amount).ToString().Replace(",", ".");

                                            if (eNabizMaterial.SubActionMaterial.RequestedByUser != null)
                                            {
                                                if (eNabizMaterial.SubActionMaterial.RequestedByUser.Person != null)
                                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = (eNabizMaterial.SubActionMaterial.RequestedByUser.Person.UniqueRefNo != null ? eNabizMaterial.SubActionMaterial.RequestedByUser.Person.UniqueRefNo.ToString() : string.Empty);
                                                else
                                                    ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";
                                            }
                                            else
                                                ISLEM_BILGISI.KULLANICI_KIMLIK_NUMARASI.value = "";

                                            ISLEM_BILGISI.CIHAZ_NUMARASI.value = "";
                                            ISLEM_BILGISI.ISLEM_REFERANS_NUMARASI.value = eNabizMaterial.ObjectID.ToString();


                                            _recordData.HASTA_ISLEM_BILGILERI.ISLEM_BILGISI.Add(ISLEM_BILGISI);
                                        }
                                        else
                                            throw new Exception(TTUtils.CultureService.GetText("M25976", "Hizmetin verildiği bölümün branş kodu bulunamadı."));
                                    }
                                    else
                                        throw new Exception("ENabizMaterial iptal edilmiş.");
                                }
                            }

                        }




                    }
                }

            }
            
            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;

        }


    }





}
