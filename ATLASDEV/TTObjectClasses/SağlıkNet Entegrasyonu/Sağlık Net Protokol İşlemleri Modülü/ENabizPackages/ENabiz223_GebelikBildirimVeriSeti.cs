using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz223_GebelikBildirimVeriSeti
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
                messageType.code = "223";
                messageType.value = "Gebelik Bildirim Veri Seti";
            }
        }
        
        public class recordData
        {
            public GEBELIK_BILDIRIM_VERI_SETI GEBELIK_BILDIRIM_VERI_SETI = new GEBELIK_BILDIRIM_VERI_SETI();
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class GEBELIK_BILDIRIM_VERI_SETI
        {
            public BABANIN_KAN_GRUBU BABANIN_KAN_GRUBU /*= new BABANIN_KAN_GRUBU()*/;
            public CANLI_DOGAN_BEBEK_SAYISI CANLI_DOGAN_BEBEK_SAYISI ;
            public KACINCI_GEBELIK KACINCI_GEBELIK;
            public BIR_ONCEKI_DOGUM_DURUMU BIR_ONCEKI_DOGUM_DURUMU;
            public KAN_GRUBU KAN_GRUBU /*= new KAN_GRUBU()*/;
            public OLU_DOGAN_BEBEK_SAYISI OLU_DOGAN_BEBEK_SAYISI ;
            public ONCEKI_DOGUM_DURUMU ONCEKI_DOGUM_DURUMU ;
            public SON_ADET_TARIHI SON_ADET_TARIHI = new SON_ADET_TARIHI();
            public DUSUK_SAYISI DUSUK_SAYISI /*= new DUSUK_SAYISI()*/;

            [System.Xml.Serialization.XmlElement("DUSUK_BILGISI", Type = typeof(DUSUK_BILGISI))]
            public List<DUSUK_BILGISI> DUSUK_BILGISI /*= new List<DUSUK_BILGISI()>*/;
        }
        public class DUSUK_BILGISI
        {
            public DUSUK_TURU DUSUK_TURU /* = new DUSUK_TURU()*/;
        }

        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            recordData _recordData = new recordData();
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            if (myTesisSKRSKurumlarDefinition == null)
                throw new Exception(TTUtils.CultureService.GetText("M26897", "SKRS Kurum Bilgisi bulunamadı lütfen ilgili sistem parametresini düzeltin"));

            Pregnancy pregnancy = (Pregnancy)objectContext.GetObject(InternalObjectGuid, InternalObjectDefName);

            if (pregnancy.StarterWomanSpecialityObject.PhysicianApplication.SubEpisode.SYSTakipNo == null)      //SYSTakipNo
                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
            else
                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = pregnancy.StarterWomanSpecialityObject.PhysicianApplication.SubEpisode.SYSTakipNo;

            _recordData.GEBELIK_BILDIRIM_VERI_SETI = new GEBELIK_BILDIRIM_VERI_SETI();

            if(pregnancy.StarterWomanSpecialityObject.LivingBabies != null)
            {
                _recordData.GEBELIK_BILDIRIM_VERI_SETI.CANLI_DOGAN_BEBEK_SAYISI.value = pregnancy.StarterWomanSpecialityObject.LivingBabies.ToString();
            }
            if(pregnancy.StarterWomanSpecialityObject.NumberOfPregnancy != null)
            {
                _recordData.GEBELIK_BILDIRIM_VERI_SETI.KACINCI_GEBELIK.value = pregnancy.StarterWomanSpecialityObject.NumberOfPregnancy.ToString();
            }
            if(pregnancy.StarterWomanSpecialityObject.DC != null)
            {
                _recordData.GEBELIK_BILDIRIM_VERI_SETI.OLU_DOGAN_BEBEK_SAYISI.value = pregnancy.StarterWomanSpecialityObject.DC.ToString();
            }
            if(pregnancy.StarterWomanSpecialityObject.NumberOfPregnancy != null)
            {
                if(pregnancy.StarterWomanSpecialityObject.NumberOfPregnancy == 0)
                {
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.ONCEKI_DOGUM_DURUMU = new ONCEKI_DOGUM_DURUMU("2", "DAHA ÖNCE DOGUM YAPMAMİS");
                }else
                {
                    if(pregnancy.StarterWomanSpecialityObject.LivingBabies > 0)
                    {
                        _recordData.GEBELIK_BILDIRIM_VERI_SETI.ONCEKI_DOGUM_DURUMU = new ONCEKI_DOGUM_DURUMU("1", "DAHA ÖNCE DOGUM YAPMİS");
                    }
                }
            }
            if(pregnancy.StarterWomanSpecialityObject.HusbandBloodGroup != null)
            {
                int husbandBloodGroup = Int32.Parse(pregnancy.StarterWomanSpecialityObject.HusbandBloodGroup.ToString());

                if (husbandBloodGroup == 0)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("4", "A RH +");
                else if (husbandBloodGroup == 1)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("3", "A RH -");
                else if (husbandBloodGroup == 2)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("8", "B RH +");
                else if (husbandBloodGroup == 3)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("7", "B RH -");
                else if (husbandBloodGroup == 4)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("6", "AB RH +");
                else if (husbandBloodGroup == 5)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("5", "AB RH -");
                else if (husbandBloodGroup == 6)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("2", "0 RH +");
                else if (husbandBloodGroup == 7)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.BABANIN_KAN_GRUBU = new BABANIN_KAN_GRUBU("1", "0 RH -");
            }
            if (pregnancy.Patient.BloodGroupType != null)
            { 
                int patientBloodGroup = Int32.Parse(pregnancy.Patient.BloodGroupType.KODU.ToString());

                if (patientBloodGroup == 0)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("1", "A RH +");
                else if (patientBloodGroup == 1)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("6", "A RH -");
                else if (patientBloodGroup == 2)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("2", "B RH +");
                else if (patientBloodGroup == 3)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("7", "B RH -");
                else if (patientBloodGroup == 4)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("3", "AB RH +");
                else if (patientBloodGroup == 5)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("8", "AB RH -");
                else if (patientBloodGroup == 6)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("4", "0 RH +");
                else if (patientBloodGroup == 7)
                    _recordData.GEBELIK_BILDIRIM_VERI_SETI.KAN_GRUBU = new KAN_GRUBU("5", "0 RH -");
            }
            //TODO düşük bilgisi eklenecek

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage GetDummy()
        {
            recordData _recordData = new recordData();

            _recordData.GEBELIK_BILDIRIM_VERI_SETI.BIR_ONCEKI_DOGUM_DURUMU = new BIR_ONCEKI_DOGUM_DURUMU("2", "DAHA ÖNCE DOGUM YAPMAMİS");
            _recordData.GEBELIK_BILDIRIM_VERI_SETI.SON_ADET_TARIHI.value = "201801010000";
            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
