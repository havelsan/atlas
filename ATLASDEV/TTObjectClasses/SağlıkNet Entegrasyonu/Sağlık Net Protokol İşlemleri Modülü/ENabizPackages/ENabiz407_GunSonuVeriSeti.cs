using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TTConnectionManager;
using TTDefinitionManagement;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz407_GunSonuVeriSeti
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
                messageType.code = "407";
                messageType.value = "Gün Sonu Veri Seti";
            }
        }
        public class recordData
        {
            public GUN_SONU_VERI_SETI GUN_SONU_VERI_SETI = new GUN_SONU_VERI_SETI();

        }
        public class GUN_SONU_VERI_SETI
        {
            public KAYIT_YERI KAYIT_YERI = new KAYIT_YERI();
            [XmlElement("GUN_SONU_BILGISI")]
            public List<GUN_SONU_BILGISI> GUN_SONU_BILGISI = new List<GUN_SONU_BILGISI>();
        }
        public class GUN_SONU_BILGISI
        {
            public GUN_SONU_TARIH GUN_SONU_TARIH = new GUN_SONU_TARIH();
            [XmlElement("KLINIK_KALITE_BILGISI")]
            public List<KLINIK_KALITE_BILGISI> KLINIK_KALITE_BILGISI = new List<KLINIK_KALITE_BILGISI>();
        }
        public class KLINIK_KALITE_BILGISI
        {
            public KLINIK_KALITE_TANIM KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM();
            public KLINIK_KALITE_SAYI KLINIK_KALITE_SAYI = new KLINIK_KALITE_SAYI();
        }
        public static SYSMessage Get(DateTime? endDateTime, int? dayLoopCount)
        {
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();
            _recordData.GUN_SONU_VERI_SETI = new GUN_SONU_VERI_SETI();

            _recordData.GUN_SONU_VERI_SETI.KAYIT_YERI = new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);

            //Gece 12den sonra gönderileceği için bitiş tarihi mevcut tarih başlangıç bir önceki gün
            DateTime endDate;
            if (endDateTime.HasValue)
            {
                endDate = Convert.ToDateTime(((DateTime)endDateTime).ToString("yyyy/MM/dd 00:00:00"));
            }
            else
            {
                endDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd 00:00:00")); //Convert.ToDateTime("2018/01/11 00:00:00");
            }
            DateTime startDate = endDate.AddDays(-1);

            int dayCount = 10;
            if (dayLoopCount.HasValue)
                dayCount = (int)dayLoopCount;

            using (var objectContext = new TTObjectContext(false))
            {
                // mevcut günden 10 gün öncesine kadar dönecek
                for (int i = 0; i < dayCount; i++)
                {

                    GUN_SONU_BILGISI GunSonuBilgisi = new GUN_SONU_BILGISI();
                    GunSonuBilgisi.GUN_SONU_TARIH.value = startDate.ToString("yyyyMMddHHmm");

                    //Mevcut gündeki gün sonu verileri 
                    BindingList<GunSonuVerileri> gunSonuList = GunSonuVerileri.GetGunSonuByDate(objectContext, Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00"));

                    KLINIK_KALITE_BILGISI[] kkBilgisi = new KLINIK_KALITE_BILGISI[0];

                    #region 1 Anjio sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 1);
                    var gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 1); //Seçili günde günsonukodu 1 olan var mı?
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                       
                        if(gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            
                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 1;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }

                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;
                       
                        }
                    }

                    #endregion

                    #region 2 A Grubu Ameliyat Sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSurgeriesByRequestDate(startDate, endDate, 2);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 2);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 2;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 3 B Grubu Ameliyat Sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSurgeriesByRequestDate(startDate, endDate, 3);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 3);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 3;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 4 C Grubu Ameliyat Sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSurgeriesByRequestDate(startDate, endDate, 4);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 4);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 4;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 5 D Grubu Ameliyat Sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSurgeriesByRequestDate(startDate, endDate, 5);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 5);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 5;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 6 E Grubu Ameliyat Sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSurgeriesByRequestDate(startDate, endDate, 6);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 6);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 6;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 7 Anjio Diğer işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 7);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 7);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 7;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 8 Anjio Periferik işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 8);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 8);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 8;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 9 Anjio Renal Arter işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 9);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 9);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 9;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 10 Anjio Göz işlemi sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 10);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 10);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 10;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 11 Anjio Koroner işlemi sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 11);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 11);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 11;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 12 Normal Doğum Sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 12);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 12);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 12;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 13 Müdahaleli Doğum Sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 13);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 13);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 13;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 14 Sezaryen Doğum Sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 14);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 14);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 14;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 15 Hasta kabulü olan tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodes(startDate, endDate, 15);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 15);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 15;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 16 Tanı bilgisi olan başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithDiagnosis(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 16);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 16;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 17 Hasta kabulü,tanısı,işlem bilgisi olan başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithDiagnosisAndSubAction(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 17);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 17;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 18 Yatış Sayısı (Günübirlik hariç Yatışı olan başvuru sayısı)

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodes(startDate, endDate, 18);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 18);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 18;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 19 Günübirlik sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodes(startDate, endDate, 19);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 19);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 19;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 20 Ayaktan Hasta Sayısı (Yatış kabul zamanı boş olan tekil başvuru sayısı)

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodes(startDate, endDate, 20);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 20);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 20;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 21 Taburcu Sayısı (Yatan hasta çıkış sayısı)

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodes(startDate, endDate, 21);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 21);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 21;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 22 Diyabet tanısı olan başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForDiagnosis(startDate, endDate, 22);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 22);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 22;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 23 HbA1c ölçümü yapılan tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWRequestDate(startDate, endDate, 23);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 23);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 23;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 24 HbA1c ölçümü işlem sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 24);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 24);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 24;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 25 HbA1c ölçümü tetkik sonucu 7 den küçük olanlar

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForHbA1c(startDate, endDate, 25);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 25);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 25;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 26  HbA1c ölçümü tetkik sonucu 7 - 9 arasında olanlar 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForHbA1c(startDate, endDate, 26);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 26);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 26;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 27  HbA1c ölçümü tetkik sonucu 9 dan büyük olanlar

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForHbA1c(startDate, endDate, 27);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 27);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 27;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 28 Laboratuvar işlemi sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 28);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 28);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 28;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 29 HbA1c ölçümü işlemine bağlı sonucu olan tetkik sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForHbA1c(startDate, endDate, 29);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 29);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 29;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 30 LDL ölçümü yapılan başvuru sayısı.

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWPerformedDate(startDate, endDate, 30);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 30);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 30;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 31 LDL ölçümü tetkik sonucu 100den küçük olanlar

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubactionsWLowValue(startDate, endDate, 31);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 31);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 31;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 32 Koroner kalp hastalığı tanısı olan başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForDiagnosis(startDate, endDate, 32);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 32);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 32;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 33 Koroner  kalp hastalığı tanısı ve anjiyografi işlemi olan başvuru sayısı.

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodeWDiagnosisAndSubactions(startDate, endDate, 33);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 33);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 33;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 34 Diz protezi işlemi olan başvuru sayısı.

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWRequestDate(startDate, endDate, 34);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 34);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 34;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 35 Hemogram işlem sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 35);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 35);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 35;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 36 Hemogram işlemine bağlı tetkik sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS36(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 36);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 36;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 37 Normal Muayene İşlemi olan Başvuru Sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWPerformedDate(startDate, endDate, 37);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 37);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 37;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 38 Acil Muayene İşlemi olan Başvuru Sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWPerformedDate(startDate, endDate, 38);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 38);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 38;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 39 Diş Muayene İşlemi olan Başvuru Sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWPerformedDate(startDate, endDate, 39);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 39);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 39;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 40 Görüntüleme EEG işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 40);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 40);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 40;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 41 Görüntüleme EKO işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 41);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 41);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 41;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 42 Görüntüleme EMG işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 42);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 42);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 42;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 43 Görüntüleme PETCTPET işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 43);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 43);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 43;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 44 Görüntüleme SINTIGRAFI işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 44);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 44);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 44;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 45 Görüntüleme Diş Görüntüleme işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 45);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 45);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 45;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 46 Görüntüleme Rontgen işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 46);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 46);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 46;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 47 Görüntüleme Doppler işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 47);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 47);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 47;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 48 Görüntüleme Mamografi işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 48);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 48);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 48;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 49 Görüntüleme BT işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 49);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 49);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 49;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 50 Görüntüleme MR işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 50);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 50);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 50;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 51 Görüntüleme USG işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 51);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 51);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 51;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 52 Tetkik bilgisi olan laboratuvar işlemlerinin sayısı  
                    /*
                    //Sonuç pakedini işlem sonuçlandığında gönderdiğimiz için bizde 52 ve 53 aynı
                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS53(startDate, endDate);
                    if (kkBilgisi.Length > 0)
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                    */
                    #endregion

                    #region 53 Tetkik sonuc bilgisi olan laboratuvar işlemlerinin sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS53(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 53);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 53;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 54 Reçete Sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForPrescription(startDate, endDate, 54);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 54);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 54;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 55 Reçete İlaç Sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForPrescriptionDrugs(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 55);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 55;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 56 İnme tanılı(18 yaş ve üstü) başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodesWDiagnosisAndAge(startDate, endDate, 56);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 56);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 56;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 57 Geçici istemik atak tanısı olan tekil sayısı (18 yaş ve üstü)

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodesWDiagnosisAndAge(startDate, endDate, 57);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 57);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 57;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 58 İstemik inme tanısı ile XXXXXXye yatırılan başvuru sayısı (18 yaş ve üstü)

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodesWDiagnosisAndAge(startDate, endDate, 58);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 58);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 58;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 59 Trombolitik tedavi alan tüm istemik inme tanısı ile XXXXXXye yatırılan sys

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS59(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 59);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 59;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 60 İskemik inme tanısı ile XXXXXXye yatırılarak   intraarteriel  girişimsel trombolitik tedavi veya trombektomi tedavi uygulanan 18 yaş üstü toplam hasta sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS60(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 60);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 60;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 61 İskemik  inme tanısı ile taburcu olan veya trombektomi tedavi uygulanan 18 yaş üstü toplam tekil hasta sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS61(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 61);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 61;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 62 İnme tanısı alan 18 yaş üstü toplam yatış yapılan hasta sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodesWDiagnosisAndAge(startDate, endDate, 62);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 62);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 62;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 63 KOAH Tanısı alan tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForDiagnosis(startDate, endDate, 63);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 63);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 63;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 64 Kolorektal kanser tanısı ile operasyon geçiren tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodeWDiagnosisAndSubactions(startDate, endDate, 64);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 64);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 64;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 65 Rektum kanser tanısı alan küretif rezeksiyon geçiren başvuru sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodeWDiagnosisAndSubactions(startDate, endDate, 65);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 65);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 65;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 66 Üriner sistem şikayetleri ile gelen 50 yaş ve 80 yaş aralığındaki erkek hasta tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS66(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 66);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 66;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 67 Üriner sistem şikayeti tanısı almış hastalarda Total PSA değeri 2.5 ng/ml ve üzerinde olan toplam tekil hasta sayısı	 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS67(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 67);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 67;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 68 Prostat Kanseri tanısı alan tüm tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForDiagnosis(startDate, endDate, 68);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 68);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 68;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 69 Prostat kanseri tanısı ile radyoterapi alan toplam tekil hasta sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForGS69(startDate, endDate);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 69);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 69;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 70 Radikal prostektomi yapılan tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWRequestDate(startDate, endDate, 70);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 70);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 70;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 73 KKH tanısı konulmuş koroner anjiyografi yapılan tekil başvuru sayısı 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodeWDiagnosisAndSubactions(startDate, endDate, 73);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 73);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 73;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 74 Anjio koroner işlemi olan tekil başvuru sayısı.

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWPerformedDate(startDate, endDate, 74);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 74);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 74;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 75 Tüm IM tanısı alan tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForDiagnosis(startDate, endDate, 75);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 75);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 75;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 76 By-pass olmuş Koroner kalp hastalığı tanısı almış tekil başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubepisodeWDiagnosisAndSubactions(startDate, endDate, 76);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 76);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 76;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 77 Kalça protezi olan başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWRequestDate(startDate, endDate, 77);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 77);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 77;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 78 Katarakt operasyonu yapılan göz başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWRequestDate(startDate, endDate, 78);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 78);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 78;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 79 İmplant tedavisi yapılan diş başvuru sayısı

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForSubEpisodesWithProceduresWRequestDate(startDate, endDate, 79);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 79);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 79;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 80 Cerrahi Diş Çekimi işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 80);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 80);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 80;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 81 Konservatif Tedavi işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 81);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 81);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 81;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 82 Entodontik Tedavi işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 82);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 82);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 82;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 83 Sabit Üye Sayisi işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 83);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 83);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 83;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 84 Hareketli Total Parça işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 84);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 84);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 84;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 85 Periodontoloji Detartraj işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 85);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 85);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 85;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 86 Periodontoloji Küretaj işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 86);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 86);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 86;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }
                    #endregion

                    #region 87 Röntgen Preapikal işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 87);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 87);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 87;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 88 Röntgen Panaromik işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 88);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 88);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 88;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 89 Röntgen Sefalometrik işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 89);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 89);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 89;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 90 Fissur Sealant Islemi işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByRequestDate(startDate, endDate, 90);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 90);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 90;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    #region 91 Dental Tomografi işlemi sayısı. 

                    kkBilgisi = new KLINIK_KALITE_BILGISI[0];
                    kkBilgisi = CreateClinicalQualityInfoForProceduresByPerformedDate(startDate, endDate, 91);
                    gunSonu = gunSonuList.FirstOrDefault(c => c.GunSonuKodu == 91);
                    if (kkBilgisi.Length > 0)
                    {
                        GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkBilgisi[0]);
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);

                        }
                        else
                        {
                            GunSonuVerileri gunSonuVerileri = new GunSonuVerileri(objectContext);
                            gunSonuVerileri.GunSonuKodu = 91;
                            gunSonuVerileri.GunSonuSayi = Convert.ToInt32(kkBilgisi[0].KLINIK_KALITE_SAYI.value);
                            gunSonuVerileri.GunSonuTarih = Convert.ToDateTime(startDate.ToShortDateString() + " " + "00:00:00");
                        }
                    }
                    else
                    {
                        if (gunSonu != null)
                        {
                            GunSonuVerileri gunSonuVerileri = (GunSonuVerileri)objectContext.GetObject(((GunSonuVerileri)gunSonu).ObjectID, TTObjectDefManager.Instance.GetObjectDef(typeof(GunSonuVerileri)));
                            gunSonuVerileri.GunSonuSayi = 0;

                        }
                    }

                    #endregion

                    if (GunSonuBilgisi.KLINIK_KALITE_BILGISI.Count > 0)
                        _recordData.GUN_SONU_VERI_SETI.GUN_SONU_BILGISI.Add(GunSonuBilgisi);
                    endDate = endDate.AddDays(-1);
                    startDate = startDate.AddDays(-1);
                }
                try
                {
                    objectContext.Save();
                    //save edilecek
                }
                catch { }
            }
            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
        //public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForProcedures(DateTime startDate, DateTime endDate, int gunSonuID) //İşlem sayıları için
        //{
        //    List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

        //    BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
        //    referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut kodları dönüyor
        //    List<string> paramList = new List<string>();
        //    for (int i = 0; i < referansKodList.Count; i++)
        //    {
        //        paramList.Add(referansKodList[i].REFERANSKOD);
        //    }

        //    //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
        //    var source = paramList.Select((x, i) => new { Index = i, Value = x })
        //                           .GroupBy(x => x.Index / 1000)
        //                           .Select(x => x.Select(v => v.Value).ToList())
        //                           .ToList();
        //    int count = 0;
        //    for (int i = 0; i < source.Count; i++)
        //    {
        //        BindingList<SubActionProcedure.GunSonu_HizmetSayisi_Class> resultList = SubActionProcedure.GunSonu_HizmetSayisi(startDate, endDate, source[i], null);
        //        List<Guid> nParamList = new List<Guid>();
        //        for (int j = 0; j < resultList.Count; j++)
        //        {
        //            nParamList.Add((Guid)resultList[j].ObjectID);
        //        }


        //        if (nParamList.Count > 0)
        //        {

        //            BindingList<SendToENabiz.HasSentToENabiz_Class> list = SendToENabiz.HasSentToENabiz(nParamList, 102,  null);
        //            count += Convert.ToInt32(list[0].Count);
        //        }
        //    }

        //     BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
        //     if (gunsonu.Count > 0)
        //     {
        //        if (count != 0)
        //        {
        //            KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
        //            kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
        //            kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
        //            result.Add(kkbilgisi);
        //        }
        //     }

        //     return result.ToArray();
        //}
        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForDiagnosis(DateTime startDate, DateTime endDate, int gunSonuID) //Tanı bazlı olan başvurular
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//ICD kodları dönüyor
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                paramList.Add(referansKodList[i].REFERANSKOD);
            }

            //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
            var source = paramList.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                BindingList<SubEpisode.GunSonu_TaniBazliBasvuruSayisi_Class> resultList = SubEpisode.GunSonu_TaniBazliBasvuruSayisi(source[i], startDate, endDate, null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }
        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubEpisodesWithProceduresWRequestDate(DateTime startDate, DateTime endDate, int gunSonuID) //İşlem bazlı başvurular (İşlem zamanına bakanlar)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut kodları dönüyor
            List<string> referansList = new List<string>();
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                referansList.Add(referansKodList[i].REFERANSKOD);
            }

            paramList = ParseList(referansList);


            //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
            var source = paramList.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                BindingList<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_IslemZamani_Class> resultList = SubActionProcedure.GunSonu_HizmetBasvuruSayisi_IslemZamani(startDate, endDate, source[i], null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubEpisodesWithProceduresWPerformedDate(DateTime startDate, DateTime endDate, int gunSonuID) //İşlem bazlı başvurular (Gerçekleşme zamanına bakanlar)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut kodları dönüyor
            List<string> referansList = new List<string>();
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                referansList.Add(referansKodList[i].REFERANSKOD);
            }

            paramList = ParseList(referansList);

            //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
            var source = paramList.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                BindingList<SubActionProcedure.GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani_Class> resultList = SubActionProcedure.GunSonu_HizmetBasvuruSayisi_GerceklesmeZamani(endDate, startDate, source[i], null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubEpisodes(DateTime startDate, DateTime endDate, int gunSonuID)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();


            int count = 0;

            if (gunSonuID == 15)
            {
                BindingList<SubEpisode.GunSonu_BasvuruSayisi_Class> resultList = SubEpisode.GunSonu_BasvuruSayisi(startDate, endDate, null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }
            else if (gunSonuID == 18)
            {
                BindingList<SubEpisode.GunSonu_YatisSayisi_Class> resultList = SubEpisode.GunSonu_YatisSayisi(startDate, endDate, null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }
            else if (gunSonuID == 19)
            {
                BindingList<SubEpisode.GunSonu_GunubirlikSayisi_Class> resultList = SubEpisode.GunSonu_GunubirlikSayisi(startDate, endDate, null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }
            else if (gunSonuID == 20)
            {
                BindingList<SubEpisode.GunSonu_AyaktanSayisi_Class> resultList = SubEpisode.GunSonu_AyaktanSayisi(startDate, endDate, null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }
            else if (gunSonuID == 21)
            {
                BindingList<InpatientAdmission.GunSonu_TaburcuSayisi_Class> resultList = InpatientAdmission.GunSonu_TaburcuSayisi(startDate, endDate, null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForPrescription(DateTime startDate, DateTime endDate, int gunSonuID)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();


            int count = 0;

            if (gunSonuID == 54)
            {
                BindingList<Prescription.GunSonu_ReceteSayisi_Class> resultList = Prescription.GunSonu_ReceteSayisi(startDate, endDate, null);
                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS53(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(53, null);//Sut kodları dönüyor
            List<string> referansList = new List<string>();
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                referansList.Add(referansKodList[i].REFERANSKOD);
            }

            paramList = ParseList(referansList);

            //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
            var source = paramList.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                BindingList<LaboratoryProcedure.GunSonu_GS53SonuclanmisLaboratuvarSayisi_Class> resultList = LaboratoryProcedure.GunSonu_GS53SonuclanmisLaboratuvarSayisi(startDate, endDate, source[i], null);

                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(53, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS67(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(67, null);//Sut ve ICD dönüyor
            List<string> sutList = new List<string>();
            List<string> icdList = new List<string>();
            List<string> referansList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
                else if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);

            int count = 0;
            count = LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi(sutList, icdList, 2.50, startDate, endDate);




            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(67, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForHbA1c(DateTime startDate, DateTime endDate, int gunSonuID)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut  dönüyor
            List<string> referansList = new List<string>();
            List<string> sutList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);



            int count = 0;
            string filterExpression = "";
            if (gunSonuID == 25)
                filterExpression = " AND RESULT < '7' ";
            else if (gunSonuID == 26)
                filterExpression = " AND RESULT >= '7' AND RESULT <= '9' ";
            else if (gunSonuID == 27)
                filterExpression = " AND RESULT > '9' ";
            else if (gunSonuID == 29)
                filterExpression = "";

            BindingList<LaboratoryProcedure.GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi_Class> resultList = LaboratoryProcedure.GunSonu_GS25HbA1cSonucDegerineGoreIslemSayisi(sutList, startDate, endDate, "901450.3", filterExpression); //subtestsutkodu XXXXXXye göre değişebilir

            if (Convert.ToInt32(resultList[0].Islemsayisi) > 0)
            {
                count += Convert.ToInt32(resultList[0].Islemsayisi);
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForPrescriptionDrugs(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();


            int count = 0;


            BindingList<InpatientDrugOrder.GunSonu_YatanReceteIlacSayisi_Class> resultList = InpatientDrugOrder.GunSonu_YatanReceteIlacSayisi(startDate, endDate, null);
            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList[0].Count);
            }

            BindingList<OutPatientDrugOrder.GunSonu_AyaktanReceteIlacSayisi_Class> resultList1 = OutPatientDrugOrder.GunSonu_AyaktanReceteIlacSayisi(endDate, startDate, null);
            if (Convert.ToInt32(resultList1[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList1[0].Count);
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(55, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForProceduresByRequestDate(DateTime startDate, DateTime endDate, int gunSonuID) //İşlem sayıları için
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut kodları dönüyor
            List<string> referansList = new List<string>();
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                referansList.Add(referansKodList[i].REFERANSKOD);
            }

            paramList = ParseList(referansList);

            //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
            var source = paramList.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                BindingList<SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani_Class> resultList = SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani(startDate, endDate, source[i], null);
                List<Guid> nParamList = new List<Guid>();
                for (int j = 0; j < resultList.Count; j++)
                {
                    nParamList.Add((Guid)resultList[j].ObjectID);
                }


                if (nParamList.Count > 0)
                {

                    BindingList<SendToENabiz.HasSentToENabiz_Class> list = SendToENabiz.HasSentToENabiz(nParamList, 102, null);
                    count += Convert.ToInt32(list[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForProceduresByPerformedDate(DateTime startDate, DateTime endDate, int gunSonuID) //İşlem sayıları için
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut kodları dönüyor
            List<string> referansList = new List<string>();
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                referansList.Add(referansKodList[i].REFERANSKOD);
            }

            paramList = ParseList(referansList);
            //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
            var source = paramList.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                BindingList<SubActionProcedure.GunSonu_HizmetSayisi_GerceklesmeZamani_Class> resultList = SubActionProcedure.GunSonu_HizmetSayisi_GerceklesmeZamani(endDate, startDate, source[i], null);
                List<Guid> nParamList = new List<Guid>();
                for (int j = 0; j < resultList.Count; j++)
                {
                    nParamList.Add((Guid)resultList[j].ObjectID);
                }


                if (nParamList.Count > 0)
                {

                    var source1 = nParamList.Select((x, z) => new { Index = z, Value = x })
                                .GroupBy(x => x.Index / 1000)
                                .Select(x => x.Select(v => v.Value).ToList())
                                .ToList();

                    for (int k = 0; k < source1.Count; k++)
                    {
                        BindingList<SendToENabiz.HasSentToENabiz_Class> list = SendToENabiz.HasSentToENabiz(source1[k], 102, null);
                        count += Convert.ToInt32(list[0].Count);
                    }
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubEpisodesWithDiagnosis(DateTime startDate, DateTime endDate) //Tanısı olan subepisodelar
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            int count = 0;
            BindingList<SubEpisode.GunSonu_TanisiOlanAltVakaSayisi_Class> resultList = SubEpisode.GunSonu_TanisiOlanAltVakaSayisi(startDate, endDate, null);
            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count = Convert.ToInt32(resultList[0].Count);
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(16, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubEpisodesWithDiagnosisAndSubAction(DateTime startDate, DateTime endDate) //Tanısı ve işlemi olan subepisodelar
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            int count = 0;
            BindingList<SubEpisode.GunSonu_TanisiVeIslemiOlanAltVakaSayisi_Class> resultList = SubEpisode.GunSonu_TanisiVeIslemiOlanAltVakaSayisi(startDate, endDate, null);
            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count = Convert.ToInt32(resultList[0].Count);
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(17, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubactionsWLowValue(DateTime startDate, DateTime endDate, int gunSonuID)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut kodları dönüyor
            List<string> referansList = new List<string>();
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                referansList.Add(referansKodList[i].REFERANSKOD);
            }

            paramList = ParseList(referansList);

            int count = 0;
            if (gunSonuID == 31)
                count = LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemSayisi(paramList, 100, startDate, endDate);

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubepisodeWDiagnosisAndSubactions(DateTime startDate, DateTime endDate, int gunsonuID)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunsonuID, null);//Sut ve ICD dönüyor
            List<string> sutList = new List<string>();
            List<string> icdList = new List<string>();
            List<string> referansList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
                else if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);

            int count = 0;

            BindingList<SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class> resultList = SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi(icdList, sutList, startDate, endDate, null);

            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList[0].Count);
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunsonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS36(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(36, null);//Sut ve ICD dönüyor
            List<string> referansList = new List<string>();
            List<string> sutList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);


            int count = 0;

            BindingList<LaboratorySubProcedure.GunSonu_GS36HemogramBagliTetkikSayisi_Class> resultList = LaboratorySubProcedure.GunSonu_GS36HemogramBagliTetkikSayisi(sutList, startDate, endDate, null);

            if (Convert.ToInt32(resultList[0].Alttekiksayisi) > 0)
            {
                count += Convert.ToInt32(resultList[0].Alttekiksayisi);
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(36, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSubepisodesWDiagnosisAndAge(DateTime startDate, DateTime endDate, int gunsonuID)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunsonuID, null);// ICD dönüyor

            List<string> icdList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }


            int count = 0;
            if (gunsonuID == 56 || gunsonuID == 57)
            {
                BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi_Class> resultList = SubEpisode.GunSonu_TaniBazliBelirliYasUstuAltVakaSayisi(icdList, 18, startDate, endDate, null);

                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }
            else if (gunsonuID == 58 || gunsonuID == 62)
            {
                BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi_Class> resultList = SubEpisode.GunSonu_TaniBazliBelirliYasUstuYatanHastaSayisi(icdList, 18, startDate, endDate, null);

                if (Convert.ToInt32(resultList[0].Count) > 0)
                {
                    count += Convert.ToInt32(resultList[0].Count);
                }
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunsonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS59(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(59, null);//Sut ve ICD dönüyor
            List<string> sutList = new List<string>();
            List<string> icdList = new List<string>();
            List<string> referansList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
                else if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);

            int count = 0;

            BindingList<SubEpisode.GunSonu_TaniveHizmetBazliYatanHastaSayisi_Class> resultList = SubEpisode.GunSonu_TaniveHizmetBazliYatanHastaSayisi(icdList, sutList, startDate, endDate, null);

            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList[0].Count);
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(59, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS60(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(60, null);//Sut ve ICD dönüyor
            List<string> sutList = new List<string>();
            List<string> icdList = new List<string>();
            List<string> referansList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
                else if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);
            int count = 0;

            BindingList<SubEpisode.GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi_Class> resultList = SubEpisode.GunSonu_TaniveHizmetBazliYasUstuYatanHastaSayisi(icdList, sutList, 18, startDate, endDate, null);

            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList[0].Count);
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(60, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS61(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(61, null);//Sut ve ICD dönüyor
            List<string> sutList = new List<string>();
            List<string> icdList = new List<string>();
            List<string> referansList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
                else if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);

            int count = 0;

            BindingList<SubEpisode.GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi_Class> resultList = SubEpisode.GunSonu_TaniBazliBelirliYasUstuTaburcuHastaSayisi(icdList, 18, startDate, endDate, null);

            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList[0].Count);
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(61, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS66(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(66, null);//ICD dönüyor
            List<string> sutList = new List<string>();
            List<string> icdList = new List<string>();
            List<string> referansList = new List<string>();

            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
                else if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);

            int count = 0;

            BindingList<SubEpisode.GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi_Class> resultList = SubEpisode.GunSonu_TaniVeCinsiyetBazliBelirliYasArasiAVSayisi(icdList, 1, 49, 81, startDate, endDate, null);

            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList[0].Count);
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(66, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForGS69(DateTime startDate, DateTime endDate)
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(69, null);//ICD dönüyor
            List<string> sutList = new List<string>();
            List<string> icdList = new List<string>();
            List<string> referansList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                if (referansKodList[i].REFERANSTUR == "SUT")
                    referansList.Add(referansKodList[i].REFERANSKOD);
                else if (referansKodList[i].REFERANSTUR == "ICD")
                    icdList.Add(referansKodList[i].REFERANSKOD);
            }

            sutList = ParseList(referansList);

            int count = 0;

            BindingList<SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi_Class> resultList = SubEpisode.GunSonu_TanilarVeHizmetlerBazliAltVakaSayisi(icdList, sutList, startDate, endDate, null);

            if (Convert.ToInt32(resultList[0].Count) > 0)
            {
                count += Convert.ToInt32(resultList[0].Count);
            }


            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(69, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static KLINIK_KALITE_BILGISI[] CreateClinicalQualityInfoForSurgeriesByRequestDate(DateTime startDate, DateTime endDate, int gunSonuID) //İşlem sayıları için
        {
            List<KLINIK_KALITE_BILGISI> result = new List<KLINIK_KALITE_BILGISI>();

            BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class> referansKodList = new BindingList<SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID_Class>();
            referansKodList = SKRSGUNSONUOZETREFERANS.GetSKRSGUNSONUREFERANSByGunSonuID(gunSonuID, null);//Sut kodları dönüyor
            List<string> referansList = new List<string>();
            List<string> paramList = new List<string>();
            for (int i = 0; i < referansKodList.Count; i++)
            {
                referansList.Add(referansKodList[i].REFERANSKOD);
                referansList.Add("P" + referansKodList[i].REFERANSKOD);

            }

            paramList = ParseList(referansList);






            //nqle parametre olarak verilen arrayin countı 1000den fazla olamayacağı için list 1000-1000 ayrıldı
            var source = paramList.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            int count = 0;
            for (int i = 0; i < source.Count; i++)
            {
                BindingList<SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani_Class> resultList = SubActionProcedure.GunSonu_HizmetSayisi_IslemZamani(startDate, endDate, source[i], null);
                List<Guid> nParamList = new List<Guid>();
                for (int j = 0; j < resultList.Count; j++)
                {
                        nParamList.Add((Guid)resultList[j].ObjectID);
                }


                if (nParamList.Count > 0)
                {

                    BindingList<SendToENabiz.HasSentToENabiz_Class> list = SendToENabiz.HasSentToENabiz(nParamList, 102, null);
                    count += Convert.ToInt32(list[0].Count);
                }
            }

            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(gunSonuID, null);
            if (gunsonu.Count > 0)
            {
                if (count != 0)
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString();
                    result.Add(kkbilgisi);
                }
                else
                {
                    KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                    kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                    kkbilgisi.KLINIK_KALITE_SAYI.value = "0";
                    result.Add(kkbilgisi);
                }
            }

            return result.ToArray();
        }

        public static List<string> ParseList(List<string> list)
        {
            List<string> paramList = new List<string>();
            var source = list.Select((x, i) => new { Index = i, Value = x })
                                   .GroupBy(x => x.Index / 1000)
                                   .Select(x => x.Select(v => v.Value).ToList())
                                   .ToList();
            for (int k = 0; k < source.Count; k++)
            {
                BindingList<ProcedureDefinition.GetAllRelatedProcedureDefCodes_Class> extendedReferansKodList = ProcedureDefinition.GetAllRelatedProcedureDefCodes(source[k], null);
                for (int i = 0; i < extendedReferansKodList.Count; i++)
                {
                    if (!paramList.Contains(extendedReferansKodList[i].Code))
                        paramList.Add(extendedReferansKodList[i].Code);
                }
            }
            return paramList;
        }


        public static SYSMessage GetPursaklarGunSonu(DateTime? endDateTime, int dayCount) // DateTime? endDateTime, int dayCount 01.01.2019 - 10 gün
        {
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();

            if (myTesisSKRSKurumlarDefinition == null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26900", "SKSR Kurum Bilgisi bulunamadı lütfen ilgili sitem parametresini düzeltin"));
            }

            recordData _recordData = new recordData();
            _recordData.GUN_SONU_VERI_SETI = new GUN_SONU_VERI_SETI();

            _recordData.GUN_SONU_VERI_SETI.KAYIT_YERI = new KAYIT_YERI(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
            _recordData.GUN_SONU_VERI_SETI.GUN_SONU_BILGISI = new List<GUN_SONU_BILGISI>();

            DateTime startDate = Convert.ToDateTime("2019/01/01 00:00:00");


            DbConnection dbConnection = ConnectionManager.CreateConnection();

            dbConnection.Open();
            try
            {

                for (int i = 0; i < dayCount; i++)
                {
                    GUN_SONU_BILGISI GunSonuBilgisi = new GUN_SONU_BILGISI();
                    GunSonuBilgisi.GUN_SONU_TARIH.value = startDate.ToString("yyyyMMddHHmm");
                    GunSonuBilgisi.KLINIK_KALITE_BILGISI = new List<KLINIK_KALITE_BILGISI>(); //O gündeki parametreler eklenecek

                    //O gündeki parametreler çekilecek startDate


                    string paramSql = "select GUNSONU_KODU,GUNSONU_ADET from  PURSAKLARGUNSONU " +
                                        " where gunsonu_tarıh = TO_DATE('" + Convert.ToDateTime(startDate).ToString("yyyy/MM/dd") + "', 'yyyy/MM/dd') ";


                    DbCommand cmd = ConnectionManager.CreateCommand(paramSql, dbConnection);
                    DbDataAdapter adap = ConnectionManager.CreateDataAdapter(cmd);
                    DataSet ds = new DataSet("DataSet");
                    adap.Fill(ds);
                    if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        continue;
                    }
                    else
                    {

                        foreach (DataRow row in ds.Tables[0].Rows) //Kodu ve Değeri gelecek
                        {
                            string gunSonuID = row.ItemArray[0].ToString();
                            string count = row.ItemArray[1].ToString();

                            BindingList<SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu_Class> gunsonu = SKRSGUNSONUOZETVERISI.GetSKRSGUNSONUOZETVERISIByKodu(Convert.ToInt32(gunSonuID), null); //Kodu verilecek
                            if (gunsonu.Count > 0)
                            {
                                KLINIK_KALITE_BILGISI kkbilgisi = new KLINIK_KALITE_BILGISI();
                                kkbilgisi.KLINIK_KALITE_TANIM = new KLINIK_KALITE_TANIM(gunsonu[0].KODU, gunsonu[0].ADI);
                                kkbilgisi.KLINIK_KALITE_SAYI.value = count.ToString(); //Dönen değer, 
                                GunSonuBilgisi.KLINIK_KALITE_BILGISI.Add(kkbilgisi);
                            }

                        }
                    }

                    _recordData.GUN_SONU_VERI_SETI.GUN_SONU_BILGISI.Add(GunSonuBilgisi);
                    startDate = startDate.AddDays(1);
                }
            }
                catch (Exception ex) { }
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
