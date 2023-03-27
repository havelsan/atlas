using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;


namespace TTObjectClasses
{
    public class ENabiz210_BebekCocukBeslenmeVeriSeti
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
                messageType.code = "210";
                messageType.value = TTUtils.CultureService.GetText("M25261", "Bebek / Cocuk Beslenme Veri Seti");
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public BEBEK_COCUK_BESLENME BEBEK_COCUK_BESLENME = new BEBEK_COCUK_BESLENME();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class BEBEK_COCUK_BESLENME
        {
            public ANNE_SUTUNDEN_KESILDIGI_AY ANNE_SUTUNDEN_KESILDIGI_AY;
            public BEBEGIN_BESLENME_DURUMU BEBEGIN_BESLENME_DURUMU = new BEBEGIN_BESLENME_DURUMU(); //Zorunlu 
            public EK_GIDAYA_BASLADIGI_AY EK_GIDAYA_BASLADIGI_AY;
            public SADECE_ANNE_SUTU_ALDIGI_SURE SADECE_ANNE_SUTU_ALDIGI_SURE;
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



                            if (childGrowth.InfantNutritionalStatus != null)
                            {
                                BEBEK_COCUK_BESLENME BEBEK_COCUK_BESLENME = new BEBEK_COCUK_BESLENME();
                                BEBEGIN_BESLENME_DURUMU bebeginBeslenmeDurumu = new BEBEGIN_BESLENME_DURUMU(childGrowth.InfantNutritionalStatus.KODU, childGrowth.InfantNutritionalStatus.ADI);
                                BEBEK_COCUK_BESLENME.BEBEGIN_BESLENME_DURUMU = bebeginBeslenmeDurumu;
                                _recordData.BEBEK_COCUK_BESLENME = BEBEK_COCUK_BESLENME;
                            }
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



                        if (childGrowth.InfantNutritionalStatus != null)
                        {
                            BEBEK_COCUK_BESLENME BEBEK_COCUK_BESLENME = new BEBEK_COCUK_BESLENME();
                            BEBEGIN_BESLENME_DURUMU bebeginBeslenmeDurumu = new BEBEGIN_BESLENME_DURUMU(childGrowth.InfantNutritionalStatus.KODU, childGrowth.InfantNutritionalStatus.ADI);
                            BEBEK_COCUK_BESLENME.BEBEGIN_BESLENME_DURUMU = bebeginBeslenmeDurumu;
                            _recordData.BEBEK_COCUK_BESLENME = BEBEK_COCUK_BESLENME;
                        }


                    }

                }
                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }
    }
}
