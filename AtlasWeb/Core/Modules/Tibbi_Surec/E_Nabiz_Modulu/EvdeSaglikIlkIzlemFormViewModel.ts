//$7D0C19CC
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EvdeSaglikIlkIzlemVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { VerilenEgitimler } from 'NebulaClient/Model/AtlasClientModel';
import { PsikolojikDurum } from 'NebulaClient/Model/AtlasClientModel';
import { KullandigiYardimciAraclar } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSVerilenEgitimler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPsikolojikDurumDegerlendirmesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKullandigiYardimciAraclar } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSYatagaBagimlilik } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKullanilanHelaTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonutTipi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKisiselHijyen } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKisiselBakim } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIsinma } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGuvenlik } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEvHijyeni } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSICD } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBirSonrakiHizmetIhtiyaci } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBeslenme } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBasvuruTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBasiDegerlendirmesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBakimveDestekIhtiyaci } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAydinlatma } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAgri } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class EvdeSaglikIlkIzlemFormViewModel extends BaseViewModel {
    @Type(() => EvdeSaglikIlkIzlemVeriSeti)
    public _EvdeSaglikIlkIzlemVeriSeti: EvdeSaglikIlkIzlemVeriSeti = new EvdeSaglikIlkIzlemVeriSeti();
    @Type(() => VerilenEgitimler)
    public VerilenEgitimlerGridList: Array<VerilenEgitimler> = new Array<VerilenEgitimler>();
    @Type(() => PsikolojikDurum)
    public PsikolojikDurumGridList: Array<PsikolojikDurum> = new Array<PsikolojikDurum>();
    @Type(() => KullandigiYardimciAraclar)
    public KullandigiYardimciAraclarGridList: Array<KullandigiYardimciAraclar> = new Array<KullandigiYardimciAraclar>();
    @Type(() => SKRSVerilenEgitimler)
    public SKRSVerilenEgitimlers: Array<SKRSVerilenEgitimler> = new Array<SKRSVerilenEgitimler>();
    @Type(() => SKRSPsikolojikDurumDegerlendirmesi)
    public SKRSPsikolojikDurumDegerlendirmesis: Array<SKRSPsikolojikDurumDegerlendirmesi> = new Array<SKRSPsikolojikDurumDegerlendirmesi>();
    @Type(() => SKRSKullandigiYardimciAraclar)
    public SKRSKullandigiYardimciAraclars: Array<SKRSKullandigiYardimciAraclar> = new Array<SKRSKullandigiYardimciAraclar>();
    @Type(() => SKRSYatagaBagimlilik)
    public SKRSYatagaBagimliliks: Array<SKRSYatagaBagimlilik> = new Array<SKRSYatagaBagimlilik>();
    @Type(() => SKRSKullanilanHelaTipi)
    public SKRSKullanilanHelaTipis: Array<SKRSKullanilanHelaTipi> = new Array<SKRSKullanilanHelaTipi>();
    @Type(() => SKRSKonutTipi)
    public SKRSKonutTipis: Array<SKRSKonutTipi> = new Array<SKRSKonutTipi>();
    @Type(() => SKRSKisiselHijyen)
    public SKRSKisiselHijyens: Array<SKRSKisiselHijyen> = new Array<SKRSKisiselHijyen>();
    @Type(() => SKRSKisiselBakim)
    public SKRSKisiselBakims: Array<SKRSKisiselBakim> = new Array<SKRSKisiselBakim>();
    @Type(() => SKRSIsinma)
    public SKRSIsinmas: Array<SKRSIsinma> = new Array<SKRSIsinma>();
    @Type(() => SKRSGuvenlik)
    public SKRSGuvenliks: Array<SKRSGuvenlik> = new Array<SKRSGuvenlik>();
    @Type(() => SKRSEvHijyeni)
    public SKRSEvHijyenis: Array<SKRSEvHijyeni> = new Array<SKRSEvHijyeni>();
    @Type(() => SKRSICD)
    public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();
    @Type(() => SKRSBirSonrakiHizmetIhtiyaci)
    public SKRSBirSonrakiHizmetIhtiyacis: Array<SKRSBirSonrakiHizmetIhtiyaci> = new Array<SKRSBirSonrakiHizmetIhtiyaci>();
    @Type(() => SKRSBeslenme)
    public SKRSBeslenmes: Array<SKRSBeslenme> = new Array<SKRSBeslenme>();
    @Type(() => SKRSBasvuruTuru)
    public SKRSBasvuruTurus: Array<SKRSBasvuruTuru> = new Array<SKRSBasvuruTuru>();
    @Type(() => SKRSBasiDegerlendirmesi)
    public SKRSBasiDegerlendirmesis: Array<SKRSBasiDegerlendirmesi> = new Array<SKRSBasiDegerlendirmesi>();
    @Type(() => SKRSBakimveDestekIhtiyaci)
    public SKRSBakimveDestekIhtiyacis: Array<SKRSBakimveDestekIhtiyaci> = new Array<SKRSBakimveDestekIhtiyaci>();
    @Type(() => SKRSAydinlatma)
    public SKRSAydinlatmas: Array<SKRSAydinlatma> = new Array<SKRSAydinlatma>();
    @Type(() => SKRSAgri)
    public SKRSAgris: Array<SKRSAgri> = new Array<SKRSAgri>();
}
