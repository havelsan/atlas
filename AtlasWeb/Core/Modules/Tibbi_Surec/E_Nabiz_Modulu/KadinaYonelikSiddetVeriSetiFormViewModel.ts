//$BDA46EB9
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { KadinaYonelikSiddetVeriSet } from "NebulaClient/Model/AtlasClientModel";
import { KadinaYonelikSiddetTuru } from "NebulaClient/Model/AtlasClientModel";
import { KadinaYonelikSiddetSonuc } from "NebulaClient/Model/AtlasClientModel";
import { SKRSSiddetTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class KadinaYonelikSiddetVeriSetiFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.KadinaYonelikSiddetVeriSetiFormViewModel, Core';
    @Type(() => KadinaYonelikSiddetVeriSet)
    public _KadinaYonelikSiddetVeriSet: KadinaYonelikSiddetVeriSet = new KadinaYonelikSiddetVeriSet();
    @Type(() => KadinaYonelikSiddetTuru)
    public KadinaYonelikSiddetTuruGridList: Array<KadinaYonelikSiddetTuru> = new Array<KadinaYonelikSiddetTuru>();
    @Type(() => KadinaYonelikSiddetSonuc)
    public KadinaYonelikSiddetSonucGridList: Array<KadinaYonelikSiddetSonuc> = new Array<KadinaYonelikSiddetSonuc>();
    @Type(() => SKRSSiddetTuru)
    public SKRSSiddetTurus: Array<SKRSSiddetTuru> = new Array<SKRSSiddetTuru>();
    @Type(() => SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme)
    public SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirmes: Array<SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme> = new Array<SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme>();
}
