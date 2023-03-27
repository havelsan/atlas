

export namespace TibbiMalzemeERaporIslemleri {
    export class eRaporSorguCevapDVO {

        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
        public raporCevap: eRaporDVO;
    }
    export class eRaporDVO {

        public tcKimlikNo: number;
        public raporTarihi: string;
        public raporBitisTarihi: string;
        public tesisKodu: number;
        public protokolNo: string;
        public raporNo: string;
        public raporTakipNo: string;
        public takipNo: string;
        public raporDuzenlemeTuruKodu: number;
        public raporDuzenlemeTuruAdi: string;
        public aciklama: string;
        public raporOnayDurumu: string;
        public malzemeListesi: eRaporMalzemeDVO;
        public doktorListesi: eRaporDoktorDVO;
        public taniListesi: eRaporTaniDVO;
    }
    export class eRaporMalzemeDVO {
        public sutKodu: string;
        public malzemeGrubuKodu: string;
        public malzemeGrubuAdi: string;
        public kullanimYeri: string;
        public kullanimYeriAdi: string;
        public kullanimPeriyodu: string;
        public kullanimPeriyodBirim: number;
        public kullanimPeriyodBirimAdi: string;
        public kullanimSayisi: number;
        public degistirmeRaporu: string;
        public adet: number;
    }
    export class eRaporDoktorDVO {
        public tcKimlikNo: string;
        public bransKodu: string;
        public bransAdi: string;
        public adi: string;
        public soyadi: string;
    }
    export class eRaporTaniDVO {
        public taniKodu: string;
        public taniAdi: string;

    }
    export class eRaporCevapDVO {
        public sonucKodu: string;
        public sonucMesaji: string;
        public uyariMesaji: string;
    }
}