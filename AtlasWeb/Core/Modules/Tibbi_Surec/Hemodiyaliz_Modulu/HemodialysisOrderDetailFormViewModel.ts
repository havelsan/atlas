//$C13F3C6C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HemodialysisOrderDetail } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAntihipertansifIlacKullanimDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSPeritonDiyaliziKomplikasyon } from "NebulaClient/Model/AtlasClientModel";
import { SKRSPeritonDiyalizTunelYonu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSPeritonDiyalizKateterYerlestirmeYontemi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSPeritonDiyaliziKateterTipi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKullanilanDiyalizTedavisi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKATATER } from "NebulaClient/Model/AtlasClientModel";
import { SKRSPeritonealGecirgenlikPET } from "NebulaClient/Model/AtlasClientModel";
import { SKRSSinekalset } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOncekiRRTYontemi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSFosforBaglayiciAjan } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDiyalizeGirmeSikligi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKanAkimHizi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDiyalizorAlani } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDiyalizorTipi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDamarErisimYolu } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDiyalizTedavisiYontemi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSTedavininSeyri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAktifVitaminDKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAnemiTedavisiYontemi } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class HemodialysisOrderDetailFormViewModel extends BaseViewModel {
    @Type(() => HemodialysisOrderDetail)
    public _HemodialysisOrderDetail: HemodialysisOrderDetail = new HemodialysisOrderDetail();

    @Type(() => SKRSAntihipertansifIlacKullanimDurumu)
    public SKRSAntihipertansifIlacKullanimDurumus: Array<SKRSAntihipertansifIlacKullanimDurumu> = new Array<SKRSAntihipertansifIlacKullanimDurumu>();
    @Type(() => SKRSPeritonDiyaliziKomplikasyon)
    public SKRSPeritonDiyaliziKomplikasyons: Array<SKRSPeritonDiyaliziKomplikasyon> = new Array<SKRSPeritonDiyaliziKomplikasyon>();
    @Type(() => SKRSPeritonDiyalizTunelYonu)
    public SKRSPeritonDiyalizTunelYonus: Array<SKRSPeritonDiyalizTunelYonu> = new Array<SKRSPeritonDiyalizTunelYonu>();
    @Type(() => SKRSPeritonDiyalizKateterYerlestirmeYontemi)
    public SKRSPeritonDiyalizKateterYerlestirmeYontemis: Array<SKRSPeritonDiyalizKateterYerlestirmeYontemi> = new Array<SKRSPeritonDiyalizKateterYerlestirmeYontemi>();
    @Type(() => SKRSPeritonDiyaliziKateterTipi)
    public SKRSPeritonDiyaliziKateterTipis: Array<SKRSPeritonDiyaliziKateterTipi> = new Array<SKRSPeritonDiyaliziKateterTipi>();
    @Type(() => SKRSKullanilanDiyalizTedavisi)
    public SKRSKullanilanDiyalizTedavisis: Array<SKRSKullanilanDiyalizTedavisi> = new Array<SKRSKullanilanDiyalizTedavisi>();
    @Type(() => SKRSKATATER)
    public SKRSKATATERs: Array<SKRSKATATER> = new Array<SKRSKATATER>();
    @Type(() => SKRSPeritonealGecirgenlikPET)
    public SKRSPeritonealGecirgenlikPETs: Array<SKRSPeritonealGecirgenlikPET> = new Array<SKRSPeritonealGecirgenlikPET>();
    @Type(() => SKRSSinekalset)
    public SKRSSinekalsets: Array<SKRSSinekalset> = new Array<SKRSSinekalset>();
    @Type(() => SKRSOncekiRRTYontemi)
    public SKRSOncekiRRTYontemis: Array<SKRSOncekiRRTYontemi> = new Array<SKRSOncekiRRTYontemi>();
    @Type(() => SKRSFosforBaglayiciAjan)
    public SKRSFosforBaglayiciAjans: Array<SKRSFosforBaglayiciAjan> = new Array<SKRSFosforBaglayiciAjan>();
    @Type(() => SKRSDiyalizeGirmeSikligi)
    public SKRSDiyalizeGirmeSikligis: Array<SKRSDiyalizeGirmeSikligi> = new Array<SKRSDiyalizeGirmeSikligi>();
    @Type(() => SKRSKanAkimHizi)
    public SKRSKanAkimHizis: Array<SKRSKanAkimHizi> = new Array<SKRSKanAkimHizi>();
    @Type(() => SKRSDiyalizorAlani)
    public SKRSDiyalizorAlanis: Array<SKRSDiyalizorAlani> = new Array<SKRSDiyalizorAlani>();
    @Type(() => SKRSDiyalizorTipi)
    public SKRSDiyalizorTipis: Array<SKRSDiyalizorTipi> = new Array<SKRSDiyalizorTipi>();
    @Type(() => SKRSDamarErisimYolu)
    public SKRSDamarErisimYolus: Array<SKRSDamarErisimYolu> = new Array<SKRSDamarErisimYolu>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSDiyalizTedavisiYontemi)
    public SKRSDiyalizTedavisiYontemis: Array<SKRSDiyalizTedavisiYontemi> = new Array<SKRSDiyalizTedavisiYontemi>();
    @Type(() => SKRSTedavininSeyri)
    public SKRSTedavininSeyris: Array<SKRSTedavininSeyri> = new Array<SKRSTedavininSeyri>();
    @Type(() => SKRSAktifVitaminDKullanimi)
    public SKRSAktifVitaminDKullanimis: Array<SKRSAktifVitaminDKullanimi> = new Array<SKRSAktifVitaminDKullanimi>();
    @Type(() => SKRSAnemiTedavisiYontemi)
    public SKRSAnemiTedavisiYontemis: Array<SKRSAnemiTedavisiYontemi> = new Array<SKRSAnemiTedavisiYontemi>();

    public IsCatheterCareDone: boolean ;
    public IsAVFCareCareDone: boolean ;
}
