//$7722CA52
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EvdeSaglikIzlemVeriSeti } from 'NebulaClient/Model/AtlasClientModel';
import { BirSonrakiHizmetIhtiyaci } from 'NebulaClient/Model/AtlasClientModel';
import { VerilenEgitimler } from 'NebulaClient/Model/AtlasClientModel';
import { PsikolojikDurum } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBirSonrakiHizmetIhtiyaci } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSVerilenEgitimler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSPsikolojikDurumDegerlendirmesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSILKodlari } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEvdeSaglikHizmetleriHastaNakli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEvdeSaglikHizmetininSonlandirilmasi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBeslenme } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSBasiDegerlendirmesi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAgri } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class EvdeSaglikIzlemFormViewModel extends BaseViewModel {
@Type(() => EvdeSaglikIzlemVeriSeti)
    public _EvdeSaglikIzlemVeriSeti: EvdeSaglikIzlemVeriSeti = new EvdeSaglikIzlemVeriSeti();
@Type(() => BirSonrakiHizmetIhtiyaci)
    public BirSonrakiHizmetIhtiyaciGridList: Array<BirSonrakiHizmetIhtiyaci> = new Array<BirSonrakiHizmetIhtiyaci>();
@Type(() => VerilenEgitimler)
    public VerilenEgitimlerGridList: Array<VerilenEgitimler> = new Array<VerilenEgitimler>();
@Type(() => PsikolojikDurum)
    public PsikolojikDurumGridList: Array<PsikolojikDurum> = new Array<PsikolojikDurum>();
@Type(() => SKRSBirSonrakiHizmetIhtiyaci)
    public SKRSBirSonrakiHizmetIhtiyacis: Array<SKRSBirSonrakiHizmetIhtiyaci> = new Array<SKRSBirSonrakiHizmetIhtiyaci>();
@Type(() => SKRSVerilenEgitimler)
    public SKRSVerilenEgitimlers: Array<SKRSVerilenEgitimler> = new Array<SKRSVerilenEgitimler>();
@Type(() => SKRSPsikolojikDurumDegerlendirmesi)
    public SKRSPsikolojikDurumDegerlendirmesis: Array<SKRSPsikolojikDurumDegerlendirmesi> = new Array<SKRSPsikolojikDurumDegerlendirmesi>();
@Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
@Type(() => SKRSEvdeSaglikHizmetleriHastaNakli)
    public SKRSEvdeSaglikHizmetleriHastaNaklis: Array<SKRSEvdeSaglikHizmetleriHastaNakli> = new Array<SKRSEvdeSaglikHizmetleriHastaNakli>();
@Type(() => SKRSEvdeSaglikHizmetininSonlandirilmasi)
    public SKRSEvdeSaglikHizmetininSonlandirilmasis: Array<SKRSEvdeSaglikHizmetininSonlandirilmasi> = new Array<SKRSEvdeSaglikHizmetininSonlandirilmasi>();
@Type(() => SKRSBeslenme)
    public SKRSBeslenmes: Array<SKRSBeslenme> = new Array<SKRSBeslenme>();
@Type(() => SKRSBasiDegerlendirmesi)
    public SKRSBasiDegerlendirmesis: Array<SKRSBasiDegerlendirmesi> = new Array<SKRSBasiDegerlendirmesi>();
@Type(() => SKRSAgri)
    public SKRSAgris: Array<SKRSAgri> = new Array<SKRSAgri>();
}
