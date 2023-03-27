using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz212_BebekCocukPsikososyalIzlemVeriSeti
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
                messageType.code = "212";
                messageType.value = TTUtils.CultureService.GetText("M25263", "Bebek / Cocuk Psikososyal Izlem Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM = new BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM
        {
            public GELISIM_TABLOSU_BILGILERININ_SORGULANMASI GELISIM_TABLOSU_BILGILERININ_SORGULANMASI = new GELISIM_TABLOSU_BILGILERININ_SORGULANMASI(); //Zorunlu
            [System.Xml.Serialization.XmlElement("BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER", Type = typeof(BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER))]
            public List<BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER> BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER = new List<BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER>(); //Zorunlu,Tekrarlı
            [System.Xml.Serialization.XmlElement("EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI", Type = typeof(EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI))]
            public List<EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI> EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI = new List<EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI>(); //Zorunlu,Tekrarlı
            [System.Xml.Serialization.XmlElement("BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER", Type = typeof(BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER))]
            public List<BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER> BEBEGIN_COCUGUN_PSIKOLOJIK_GELISIMINDEKI_RISKLERE_YONELIK_EGITIMLER; //Tekrarlı
            [System.Xml.Serialization.XmlElement("BEBEGIN_COCUGUN_RISK_FAKTORLERINE_YAPILAN_MUDAHALE", Type = typeof(BEBEGIN_COCUGUN_RISK_FAKTORLERINE_YAPILAN_MUDAHALE))]
            public List<BEBEGIN_COCUGUN_RISK_FAKTORLERINE_YAPILAN_MUDAHALE> BEBEGIN_COCUGUN_RISK_FAKTORLERINE_YAPILAN_MUDAHALE; //Tekrarlı
            [System.Xml.Serialization.XmlElement("BEBEK_COCUKTA_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI", Type = typeof(BEBEK_COCUKTA_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI))]
            public List<BEBEK_COCUKTA_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI> BEBEK_COCUKTA_SIK_IZLEME_ALINAN_RISK_ALTINDAKI_OLGUNUN_TAKIBI; //Tekrarlı
        }

        public static SYSMessage Get(Guid InternalObjectId, String InternalObjectDefName, Guid SubEpisodeObjectId)
        {
            //TODO Bebek ekranları yapıldıktan sonra eklenecek
            using (var objectContext = new TTObjectContext(false))
            {

                recordData _recordData = new recordData();

                ChildGrowthVisits childGrowth = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as ChildGrowthVisits;
                if (childGrowth != null)
                {
                    if (!childGrowth.IsCancelled)
                    {
                        SubEpisode se = (SubEpisode)objectContext.GetObject(SubEpisodeObjectId, "SUBEPISODE");
                        if (se != null)
                        {
                            if (se.SYSTakipNo == null)
                                throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                            else
                                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = se.SYSTakipNo;


                            BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM = new BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM();

                            if (childGrowth.InfantGrowthStatusInfo != null)
                            {
                                GELISIM_TABLOSU_BILGILERININ_SORGULANMASI gelisimBilgisi = new GELISIM_TABLOSU_BILGILERININ_SORGULANMASI(childGrowth.InfantGrowthStatusInfo.KODU, childGrowth.InfantGrowthStatusInfo.ADI);
                                BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM.GELISIM_TABLOSU_BILGILERININ_SORGULANMASI = gelisimBilgisi;
                            }

                           
                            foreach (ChildBrainDevelopmentRiskFactors riskFactor in childGrowth.ChildBrainDevelopmentRiskFactors)
                            {
                                BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER beyinGelisimiRiskler = new BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER(riskFactor.SKRSBebeginBeyinGlsEtkRiskler.KODU, riskFactor.SKRSBebeginBeyinGlsEtkRiskler.ADI);
                                BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM.BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER.Add(beyinGelisimiRiskler);
                            }

                            foreach (ParentalActivitiesForPsychologicalDevelopment parentalPsychDevelopment in childGrowth.ParentalActivitiesForPsychologicalDevelopment)
                            {
                                EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI ebeveynAktivite = new EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI(parentalPsychDevelopment.SKRSEbeveynPsikoGlsmDestkAktv.KODU, parentalPsychDevelopment.SKRSEbeveynPsikoGlsmDestkAktv.ADI);
                                BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM.EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI.Add(ebeveynAktivite);
                            }


                            _recordData.BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM = BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM;
                        }
                    }

                }

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }


        }

        public static SYSMessage GetDummy()
        {
            //TODO Bebek ekranları yapıldıktan sonra eklenecek
            using (var objectContext = new TTObjectContext(false))
            {

                recordData _recordData = new recordData();

                ChildGrowthVisits childGrowth = objectContext.GetObject(new Guid("693ef65e-9edb-4801-9d30-40bbb9edf234"), "CHILDGROWTHVISITS") as ChildGrowthVisits;
                if (childGrowth != null)
                {
                    if (!childGrowth.IsCancelled)
                    {
                        
                                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";


                        BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM = new BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM();

                            if (childGrowth.InfantGrowthStatusInfo != null)
                            {
                                GELISIM_TABLOSU_BILGILERININ_SORGULANMASI gelisimBilgisi = new GELISIM_TABLOSU_BILGILERININ_SORGULANMASI(childGrowth.InfantGrowthStatusInfo.KODU, childGrowth.InfantGrowthStatusInfo.ADI);
                                BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM.GELISIM_TABLOSU_BILGILERININ_SORGULANMASI = gelisimBilgisi;
                            }


                            foreach (ChildBrainDevelopmentRiskFactors riskFactor in childGrowth.ChildBrainDevelopmentRiskFactors)
                            {
                                BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER beyinGelisimiRiskler = new BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER(riskFactor.SKRSBebeginBeyinGlsEtkRiskler.KODU, riskFactor.SKRSBebeginBeyinGlsEtkRiskler.ADI);
                                BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM.BEBEGIN_COCUGUN_BEYIN_GELISIMINI_ETKILEYEBILECEK_RISKLER.Add(beyinGelisimiRiskler);
                            }

                            foreach (ParentalActivitiesForPsychologicalDevelopment parentalPsychDevelopment in childGrowth.ParentalActivitiesForPsychologicalDevelopment)
                            {
                                EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI ebeveynAktivite = new EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI(parentalPsychDevelopment.SKRSEbeveynPsikoGlsmDestkAktv.KODU, parentalPsychDevelopment.SKRSEbeveynPsikoGlsmDestkAktv.ADI);
                                BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM.EBEVEYNIN_PSIKOLOJIK_GELISIMI_DESTEKLEYICI_AKTIVITELERI.Add(ebeveynAktivite);
                            }


                            _recordData.BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM = BEBEK_COCUK_IZLEM_PSIKOSOSYAL_IZLEM;
                        
                    }

                }

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;
            }


        }
    }
}
