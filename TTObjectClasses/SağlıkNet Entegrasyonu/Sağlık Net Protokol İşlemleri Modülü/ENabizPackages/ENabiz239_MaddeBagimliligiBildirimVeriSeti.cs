using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz239_MaddeBagimliligiBildirimVeriSeti
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
                messageType.code = "239";
                messageType.value = "Madde Bagimliligi Bildirim Veri Seti";
            }

        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public MADDE_BAGIMLILIGI_BILDIRIM MADDE_BAGIMLILIGI_BILDIRIM = new MADDE_BAGIMLILIGI_BILDIRIM();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }

        public class MADDE_BAGIMLILIGI_BILDIRIM
        {
            public ALKOL_KULLANIMI ALKOL_KULLANIMI = new ALKOL_KULLANIMI();         //zorunlu
            public ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI;
            public ENJEKTOR_PAYLASIM_DURUMU ENJEKTOR_PAYLASIM_DURUMU;
            public GONDEREN_BIRIM GONDEREN_BIRIM = new GONDEREN_BIRIM();            //zorunlu
            public HASTA_KODU HASTA_KODU;
            public IS_DURUMU IS_DURUMU = new IS_DURUMU();                           //zorunlu
            public KULLANILAN_ESAS_MADDE KULLANILAN_ESAS_MADDE = new KULLANILAN_ESAS_MADDE();           //zorunlu
            public OGRENIM_DURUMU OGRENIM_DURUMU = new OGRENIM_DURUMU();            //zorunlu
            public SIGARA_ADEDI SIGARA_ADEDI;
            public SIGARA_KULLANIMI SIGARA_KULLANIMI = new SIGARA_KULLANIMI();              //zorunlu
            public TEDAVI_MERKEZI_TIPI TEDAVI_MERKEZI_TIPI = new TEDAVI_MERKEZI_TIPI();
            public TEDAVI_SONUCU_MADDE_BAGIMLILIGI TEDAVI_SONUCU_MADDE_BAGIMLILIGI;
            public UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI;
            public YASADIGI_BOLGE YASADIGI_BOLGE = new YASADIGI_BOLGE();                //zorunlu
            public YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU = new YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU();     //zorunlu
            public YASAM_BICIMI YASAM_BICIMI = new YASAM_BICIMI();              //zorunlu
            [System.Xml.Serialization.XmlElement("BULASICI_HASTALIK_DURUMU_BILGISI", Type = typeof(BULASICI_HASTALIK_DURUMU_BILGISI))]
            public List<BULASICI_HASTALIK_DURUMU_BILGISI> BULASICI_HASTALIK_DURUMU_BILGISI;
            [System.Xml.Serialization.XmlElement("KULLANILAN_MADDE_BILGISI", Type = typeof(KULLANILAN_MADDE_BILGISI))]
            public List<KULLANILAN_MADDE_BILGISI> KULLANILAN_MADDE_BILGISI; 
        }

        public class KULLANILAN_MADDE_BILGISI
        {
            public DUZENLI_MADDE_KULLANIM_SURESI DUZENLI_MADDE_KULLANIM_SURESI;
            public KULLANILAN_DIGER_MADDE KULLANILAN_DIGER_MADDE;
            public MADDE_ILK_KULLANIM_YASI MADDE_ILK_KULLANIM_YASI;
            public MADDE_KULLANIM_SIKLIGI MADDE_KULLANIM_SIKLIGI;
            public MADDE_KULLANIM_YOLU MADDE_KULLANIM_YOLU;
        }

        public class BULASICI_HASTALIK_DURUMU_BILGISI
        {
            public BULASICI_HASTALIK_DURUMU BULASICI_HASTALIK_DURUMU;
        }

        public static SYSMessage GetDummy()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MaddeBagimliligiVeriSeti maddeBagimliligiVeriSeti = objectContext.GetObject(new Guid("92a50319-0962-4203-92ef-bc31c171bf0c"), "MADDEBAGIMLILIGIVERISETI") as MaddeBagimliligiVeriSeti;
                if (maddeBagimliligiVeriSeti == null)
                    throw new Exception("'239' paketini göndermek için " + "92a50319-0962-4203-92ef-bc31c171bf0c" + " ObjectId'li MaddeBagimliligiVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (maddeBagimliligiVeriSeti.SKRSAlkolKullanimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ALKOL_KULLANIMI = new ALKOL_KULLANIMI(maddeBagimliligiVeriSeti.SKRSAlkolKullanimi.KODU, maddeBagimliligiVeriSeti.SKRSAlkolKullanimi.ADI);

                if (maddeBagimliligiVeriSeti.EnjeksiyonIleIlkMaddeKulYas != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI = new ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI();
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI.value = maddeBagimliligiVeriSeti.EnjeksiyonIleIlkMaddeKulYas.ToString();
                }
                if (maddeBagimliligiVeriSeti.HastaKodu != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.HASTA_KODU = new HASTA_KODU();
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.HASTA_KODU.value = maddeBagimliligiVeriSeti.HastaKodu.ToString();
                }
                if (maddeBagimliligiVeriSeti.SigaraAdedi != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.SIGARA_ADEDI = new SIGARA_ADEDI();
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.SIGARA_ADEDI.value = maddeBagimliligiVeriSeti.SigaraAdedi.ToString();
                }

                if (maddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ENJEKTOR_PAYLASIM_DURUMU = new ENJEKTOR_PAYLASIM_DURUMU(maddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu.KODU, maddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu.ADI);
                if (maddeBagimliligiVeriSeti.SKRSGonderenBirim != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.GONDEREN_BIRIM = new GONDEREN_BIRIM(maddeBagimliligiVeriSeti.SKRSGonderenBirim.KODU, maddeBagimliligiVeriSeti.SKRSGonderenBirim.ADI);
                if (maddeBagimliligiVeriSeti.SKRSIsDurumu != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.IS_DURUMU = new IS_DURUMU(maddeBagimliligiVeriSeti.SKRSIsDurumu.KODU, maddeBagimliligiVeriSeti.SKRSIsDurumu.ADI);
                if (maddeBagimliligiVeriSeti.SKRSKullanilanMadde != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.KULLANILAN_ESAS_MADDE = new KULLANILAN_ESAS_MADDE(maddeBagimliligiVeriSeti.SKRSKullanilanMadde.KODU, maddeBagimliligiVeriSeti.SKRSKullanilanMadde.ADI);
                if (maddeBagimliligiVeriSeti.SKRSOgrenimDurumu != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.OGRENIM_DURUMU = new OGRENIM_DURUMU(maddeBagimliligiVeriSeti.SKRSOgrenimDurumu.KODU, maddeBagimliligiVeriSeti.SKRSOgrenimDurumu.ADI);
                if (maddeBagimliligiVeriSeti.SKRSSigaraKullanimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.SIGARA_KULLANIMI = new SIGARA_KULLANIMI(maddeBagimliligiVeriSeti.SKRSSigaraKullanimi.KODU, maddeBagimliligiVeriSeti.SKRSSigaraKullanimi.ADI);
                if (maddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.TEDAVI_MERKEZI_TIPI = new TEDAVI_MERKEZI_TIPI(maddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi.KODU, maddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi.ADI);
                if (maddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.TEDAVI_SONUCU_MADDE_BAGIMLILIGI = new TEDAVI_SONUCU_MADDE_BAGIMLILIGI(maddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim.KODU, maddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim.ADI);
                if (maddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI = new UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI(maddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim.KODU, maddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim.ADI);
                if (maddeBagimliligiVeriSeti.SKRSYasadigiBolge != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.YASADIGI_BOLGE = new YASADIGI_BOLGE(maddeBagimliligiVeriSeti.SKRSYasadigiBolge.KODU, maddeBagimliligiVeriSeti.SKRSYasadigiBolge.ADI);
                if (maddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU = new YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU(maddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi.KODU, maddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi.ADI);
                if (maddeBagimliligiVeriSeti.SKRSYasamBicimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.YASAM_BICIMI= new YASAM_BICIMI(maddeBagimliligiVeriSeti.SKRSYasamBicimi.KODU, maddeBagimliligiVeriSeti.SKRSYasamBicimi.ADI);
                
                if(maddeBagimliligiVeriSeti.MaddeBagimBulasiciHastalik != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.BULASICI_HASTALIK_DURUMU_BILGISI = new List<BULASICI_HASTALIK_DURUMU_BILGISI>();
                    foreach (MaddeBagimBulasiciHastalik bulasiciHastalik in maddeBagimliligiVeriSeti.MaddeBagimBulasiciHastalik)
                    {
                        BULASICI_HASTALIK_DURUMU_BILGISI bulasiciHastalikBilgisi = new BULASICI_HASTALIK_DURUMU_BILGISI();
                        bulasiciHastalikBilgisi.BULASICI_HASTALIK_DURUMU = new BULASICI_HASTALIK_DURUMU(bulasiciHastalik.SKRSBulasiciHastalikDurumu.KODU, bulasiciHastalik.SKRSBulasiciHastalikDurumu.ADI);
                        _recordData.MADDE_BAGIMLILIGI_BILDIRIM.BULASICI_HASTALIK_DURUMU_BILGISI.Add(bulasiciHastalikBilgisi);
                    }
                }

                if (maddeBagimliligiVeriSeti.MaddeBagimliligiKulMadde != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.KULLANILAN_MADDE_BILGISI = new List<KULLANILAN_MADDE_BILGISI>();
                    foreach (MaddeBagimliligiKulMadde kullanilanMadde in maddeBagimliligiVeriSeti.MaddeBagimliligiKulMadde)
                    {
                        KULLANILAN_MADDE_BILGISI kullanilanMaddeBilgisi = new KULLANILAN_MADDE_BILGISI();
                        if (kullanilanMadde.SKRSKullanilanMadde != null)
                            kullanilanMaddeBilgisi.KULLANILAN_DIGER_MADDE = new KULLANILAN_DIGER_MADDE(kullanilanMadde.SKRSKullanilanMadde.KODU, kullanilanMadde.SKRSKullanilanMadde.ADI);
                        if (kullanilanMadde.SKRSMaddeKullanimSikligi != null)
                            kullanilanMaddeBilgisi.MADDE_KULLANIM_SIKLIGI = new MADDE_KULLANIM_SIKLIGI(kullanilanMadde.SKRSMaddeKullanimSikligi.KODU, kullanilanMadde.SKRSMaddeKullanimSikligi.ADI);
                        if (kullanilanMadde.SKRSMaddeKullanimYolu != null)
                            kullanilanMaddeBilgisi.MADDE_KULLANIM_YOLU = new MADDE_KULLANIM_YOLU(kullanilanMadde.SKRSMaddeKullanimYolu.KODU, kullanilanMadde.SKRSMaddeKullanimYolu.ADI);
                        if (kullanilanMadde.DuzenliMaddeKullanimSuresi != null)
                        {
                            kullanilanMaddeBilgisi.DUZENLI_MADDE_KULLANIM_SURESI = new DUZENLI_MADDE_KULLANIM_SURESI();
                            kullanilanMaddeBilgisi.DUZENLI_MADDE_KULLANIM_SURESI.value = kullanilanMadde.DuzenliMaddeKullanimSuresi.ToString();
                        }
                        if (kullanilanMadde.MaddeIlkKullanimYasi != null)
                        {
                            kullanilanMaddeBilgisi.MADDE_ILK_KULLANIM_YASI = new MADDE_ILK_KULLANIM_YASI();
                            kullanilanMaddeBilgisi.MADDE_ILK_KULLANIM_YASI.value = kullanilanMadde.MaddeIlkKullanimYasi.ToString();
                        }
                        _recordData.MADDE_BAGIMLILIGI_BILDIRIM.KULLANILAN_MADDE_BILGISI.Add(kullanilanMaddeBilgisi);
                    }
                }

                _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = "4M32SJU5D12L5HWG";// "55CYD1KKV4PPE6ZS";

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }


        public static SYSMessage Get(Guid InternalObjectId, string InternalObjectDefName)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MaddeBagimliligiVeriSeti maddeBagimliligiVeriSeti = objectContext.GetObject(InternalObjectId, InternalObjectDefName) as MaddeBagimliligiVeriSeti;
                if (maddeBagimliligiVeriSeti == null)
                    throw new Exception("'239' paketini göndermek için " + InternalObjectId + " ObjectId'li MaddeBagimliligiVeriSeti Objesi bulunamadı.");

                recordData _recordData = new recordData();

                if (maddeBagimliligiVeriSeti.SKRSAlkolKullanimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ALKOL_KULLANIMI = new ALKOL_KULLANIMI(maddeBagimliligiVeriSeti.SKRSAlkolKullanimi.KODU, maddeBagimliligiVeriSeti.SKRSAlkolKullanimi.ADI);

                if (maddeBagimliligiVeriSeti.EnjeksiyonIleIlkMaddeKulYas != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI = new ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI();
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ENJEKSIYON_ILE_ILK_MADDE_KULLANIM_YASI.value = maddeBagimliligiVeriSeti.EnjeksiyonIleIlkMaddeKulYas.ToString();
                }
                if (maddeBagimliligiVeriSeti.HastaKodu != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.HASTA_KODU = new HASTA_KODU();
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.HASTA_KODU.value = maddeBagimliligiVeriSeti.HastaKodu.ToString();
                }
                if (maddeBagimliligiVeriSeti.SigaraAdedi != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.SIGARA_ADEDI = new SIGARA_ADEDI();
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.SIGARA_ADEDI.value = maddeBagimliligiVeriSeti.SigaraAdedi.ToString();
                }

                if (maddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.ENJEKTOR_PAYLASIM_DURUMU = new ENJEKTOR_PAYLASIM_DURUMU(maddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu.KODU, maddeBagimliligiVeriSeti.SKRSEnjektorPaylasimDurumu.ADI);
                if (maddeBagimliligiVeriSeti.SKRSGonderenBirim != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.GONDEREN_BIRIM = new GONDEREN_BIRIM(maddeBagimliligiVeriSeti.SKRSGonderenBirim.KODU, maddeBagimliligiVeriSeti.SKRSGonderenBirim.ADI);
                if (maddeBagimliligiVeriSeti.SKRSIsDurumu != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.IS_DURUMU = new IS_DURUMU(maddeBagimliligiVeriSeti.SKRSIsDurumu.KODU, maddeBagimliligiVeriSeti.SKRSIsDurumu.ADI);
                if (maddeBagimliligiVeriSeti.SKRSKullanilanMadde != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.KULLANILAN_ESAS_MADDE = new KULLANILAN_ESAS_MADDE(maddeBagimliligiVeriSeti.SKRSKullanilanMadde.KODU, maddeBagimliligiVeriSeti.SKRSKullanilanMadde.ADI);
                if (maddeBagimliligiVeriSeti.SKRSOgrenimDurumu != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.OGRENIM_DURUMU = new OGRENIM_DURUMU(maddeBagimliligiVeriSeti.SKRSOgrenimDurumu.KODU, maddeBagimliligiVeriSeti.SKRSOgrenimDurumu.ADI);
                if (maddeBagimliligiVeriSeti.SKRSSigaraKullanimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.SIGARA_KULLANIMI = new SIGARA_KULLANIMI(maddeBagimliligiVeriSeti.SKRSSigaraKullanimi.KODU, maddeBagimliligiVeriSeti.SKRSSigaraKullanimi.ADI);
                if (maddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.TEDAVI_MERKEZI_TIPI = new TEDAVI_MERKEZI_TIPI(maddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi.KODU, maddeBagimliligiVeriSeti.SKRSTedaviMerkeziTipi.ADI);
                if (maddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.TEDAVI_SONUCU_MADDE_BAGIMLILIGI = new TEDAVI_SONUCU_MADDE_BAGIMLILIGI(maddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim.KODU, maddeBagimliligiVeriSeti.SKRSTedaviSonucuMaddeBagim.ADI);
                if (maddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI = new UYGULANAN_TEDAVI_TURU_MADDE_BAGIMLILIGI(maddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim.KODU, maddeBagimliligiVeriSeti.SKRSUygulananTedaviMaddeBagim.ADI);
                if (maddeBagimliligiVeriSeti.SKRSYasadigiBolge != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.YASADIGI_BOLGE = new YASADIGI_BOLGE(maddeBagimliligiVeriSeti.SKRSYasadigiBolge.KODU, maddeBagimliligiVeriSeti.SKRSYasadigiBolge.ADI);
                if (maddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU = new YASAMINDA_ENJEKSIYON_YOLU_ILE_MADDE_KULLANIM_DURUMU(maddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi.KODU, maddeBagimliligiVeriSeti.SKRSEnjeksiyonMaddeKullanimi.ADI);
                if (maddeBagimliligiVeriSeti.SKRSYasamBicimi != null)
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.YASAM_BICIMI = new YASAM_BICIMI(maddeBagimliligiVeriSeti.SKRSYasamBicimi.KODU, maddeBagimliligiVeriSeti.SKRSYasamBicimi.ADI);

                if (maddeBagimliligiVeriSeti.MaddeBagimBulasiciHastalik != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.BULASICI_HASTALIK_DURUMU_BILGISI = new List<BULASICI_HASTALIK_DURUMU_BILGISI>();
                    foreach (MaddeBagimBulasiciHastalik bulasiciHastalik in maddeBagimliligiVeriSeti.MaddeBagimBulasiciHastalik)
                    {
                        BULASICI_HASTALIK_DURUMU_BILGISI bulasiciHastalikBilgisi = new BULASICI_HASTALIK_DURUMU_BILGISI();
                        bulasiciHastalikBilgisi.BULASICI_HASTALIK_DURUMU = new BULASICI_HASTALIK_DURUMU(bulasiciHastalik.SKRSBulasiciHastalikDurumu.KODU, bulasiciHastalik.SKRSBulasiciHastalikDurumu.ADI);
                        _recordData.MADDE_BAGIMLILIGI_BILDIRIM.BULASICI_HASTALIK_DURUMU_BILGISI.Add(bulasiciHastalikBilgisi);
                    }
                }

                if (maddeBagimliligiVeriSeti.MaddeBagimliligiKulMadde != null)
                {
                    _recordData.MADDE_BAGIMLILIGI_BILDIRIM.KULLANILAN_MADDE_BILGISI = new List<KULLANILAN_MADDE_BILGISI>();
                    foreach (MaddeBagimliligiKulMadde kullanilanMadde in maddeBagimliligiVeriSeti.MaddeBagimliligiKulMadde)
                    {
                        KULLANILAN_MADDE_BILGISI kullanilanMaddeBilgisi = new KULLANILAN_MADDE_BILGISI();
                        if (kullanilanMadde.SKRSKullanilanMadde != null)
                            kullanilanMaddeBilgisi.KULLANILAN_DIGER_MADDE = new KULLANILAN_DIGER_MADDE(kullanilanMadde.SKRSKullanilanMadde.KODU, kullanilanMadde.SKRSKullanilanMadde.ADI);
                        if (kullanilanMadde.SKRSMaddeKullanimSikligi != null)
                            kullanilanMaddeBilgisi.MADDE_KULLANIM_SIKLIGI = new MADDE_KULLANIM_SIKLIGI(kullanilanMadde.SKRSMaddeKullanimSikligi.KODU, kullanilanMadde.SKRSMaddeKullanimSikligi.ADI);
                        if (kullanilanMadde.SKRSMaddeKullanimYolu != null)
                            kullanilanMaddeBilgisi.MADDE_KULLANIM_YOLU = new MADDE_KULLANIM_YOLU(kullanilanMadde.SKRSMaddeKullanimYolu.KODU, kullanilanMadde.SKRSMaddeKullanimYolu.ADI);
                        if (kullanilanMadde.DuzenliMaddeKullanimSuresi != null)
                        {
                            kullanilanMaddeBilgisi.DUZENLI_MADDE_KULLANIM_SURESI = new DUZENLI_MADDE_KULLANIM_SURESI();
                            kullanilanMaddeBilgisi.DUZENLI_MADDE_KULLANIM_SURESI.value = kullanilanMadde.DuzenliMaddeKullanimSuresi.ToString();
                        }
                        if (kullanilanMadde.MaddeIlkKullanimYasi != null)
                        {
                            kullanilanMaddeBilgisi.MADDE_ILK_KULLANIM_YASI = new MADDE_ILK_KULLANIM_YASI();
                            kullanilanMaddeBilgisi.MADDE_ILK_KULLANIM_YASI.value = kullanilanMadde.MaddeIlkKullanimYasi.ToString();
                        }
                        _recordData.MADDE_BAGIMLILIGI_BILDIRIM.KULLANILAN_MADDE_BILGISI.Add(kullanilanMaddeBilgisi);
                    }
                }

                if (maddeBagimliligiVeriSeti.SubEpisode.SYSTakipNo == null)
                    throw new Exception("Episode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = maddeBagimliligiVeriSeti.SubEpisode.SYSTakipNo;

                SYSMessage _sYSMessage = new SYSMessage();
                _sYSMessage.recordData = _recordData;
                return _sYSMessage;

            }
        }
    }
}
