//$458511E3
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { VeremVeriSeti } from "NebulaClient/Model/AtlasClientModel";
import { VeremTedaviSonucBilgisi } from "NebulaClient/Model/AtlasClientModel";
import { VeremKlinikOrnegi } from "NebulaClient/Model/AtlasClientModel";
import { VeremIlacBilgisi } from "NebulaClient/Model/AtlasClientModel";
import { VeremHastalikTutumYeri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSYaymaSonucu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSVeremOlguTanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSVeremHastasiTedaviYontemi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKulturSonucu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSHastaninTedaviyeUyumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDGTUygulamasiniYapanKisi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDGTUygulamaYeri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSVeremTedaviSonucu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSVeremHastasiKlinikOrnegi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIlacAdiVerem } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIlacDirenciVerem } from "NebulaClient/Model/AtlasClientModel";
import { SKRSVeremHastaligininTutulumYeri } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class VeremVeriSetiFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.VeremVeriSetiFormViewModel, Core';
    @Type(() => VeremVeriSeti)
    public _VeremVeriSeti: VeremVeriSeti = new VeremVeriSeti();
    @Type(() => VeremTedaviSonucBilgisi)
    public VeremTedaviSonucBilgisiGridList: Array<VeremTedaviSonucBilgisi> = new Array<VeremTedaviSonucBilgisi>();
    @Type(() => VeremKlinikOrnegi)
    public VeremKlinikOrnegiGridList: Array<VeremKlinikOrnegi> = new Array<VeremKlinikOrnegi>();
    @Type(() => VeremIlacBilgisi)
    public VeremIlacBilgisiGridList: Array<VeremIlacBilgisi> = new Array<VeremIlacBilgisi>();
    @Type(() => VeremHastalikTutumYeri)
    public VeremHastalikTutumYeriGridList: Array<VeremHastalikTutumYeri> = new Array<VeremHastalikTutumYeri>();
    @Type(() => SKRSYaymaSonucu)
    public SKRSYaymaSonucus: Array<SKRSYaymaSonucu> = new Array<SKRSYaymaSonucu>();
    @Type(() => SKRSVeremOlguTanimi)
    public SKRSVeremOlguTanimis: Array<SKRSVeremOlguTanimi> = new Array<SKRSVeremOlguTanimi>();
    @Type(() => SKRSVeremHastasiTedaviYontemi)
    public SKRSVeremHastasiTedaviYontemis: Array<SKRSVeremHastasiTedaviYontemi> = new Array<SKRSVeremHastasiTedaviYontemi>();
    @Type(() => SKRSKulturSonucu)
    public SKRSKulturSonucus: Array<SKRSKulturSonucu> = new Array<SKRSKulturSonucu>();
    @Type(() => SKRSHastaninTedaviyeUyumu)
    public SKRSHastaninTedaviyeUyumus: Array<SKRSHastaninTedaviyeUyumu> = new Array<SKRSHastaninTedaviyeUyumu>();
    @Type(() => SKRSDGTUygulamasiniYapanKisi)
    public SKRSDGTUygulamasiniYapanKisis: Array<SKRSDGTUygulamasiniYapanKisi> = new Array<SKRSDGTUygulamasiniYapanKisi>();
    @Type(() => SKRSDGTUygulamaYeri)
    public SKRSDGTUygulamaYeris: Array<SKRSDGTUygulamaYeri> = new Array<SKRSDGTUygulamaYeri>();
    @Type(() => SKRSVeremTedaviSonucu)
    public SKRSVeremTedaviSonucus: Array<SKRSVeremTedaviSonucu> = new Array<SKRSVeremTedaviSonucu>();
    @Type(() => SKRSVeremHastasiKlinikOrnegi)
    public SKRSVeremHastasiKlinikOrnegis: Array<SKRSVeremHastasiKlinikOrnegi> = new Array<SKRSVeremHastasiKlinikOrnegi>();
    @Type(() => SKRSIlacAdiVerem)
    public SKRSIlacAdiVerems: Array<SKRSIlacAdiVerem> = new Array<SKRSIlacAdiVerem>();
    @Type(() => SKRSIlacDirenciVerem)
    public SKRSIlacDirenciVerems: Array<SKRSIlacDirenciVerem> = new Array<SKRSIlacDirenciVerem>();
    @Type(() => SKRSVeremHastaligininTutulumYeri)
    public SKRSVeremHastaligininTutulumYeris: Array<SKRSVeremHastaligininTutulumYeri> = new Array<SKRSVeremHastaligininTutulumYeri>();
}
