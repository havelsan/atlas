//$75582980
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { TutunKullanimiVeriSeti } from "NebulaClient/Model/AtlasClientModel";
import { TutunKullanimiTedaviSonucu } from "NebulaClient/Model/AtlasClientModel";
import { TutunKullanimiTedaviSekli } from "NebulaClient/Model/AtlasClientModel";
import { TutunKullanimiBagimOldUrun } from "NebulaClient/Model/AtlasClientModel";
import { SKRSTutunDumaninaMaruzKalmaPasificicilik } from "NebulaClient/Model/AtlasClientModel";
import { SKRSSigaraKullanimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSTutunTedaviSonucu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSTedaviSekli } from "NebulaClient/Model/AtlasClientModel";
import { SKRSBagimliOlduguUrun } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';


export class TutunKullanimiVeriSetiFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.TutunKullanimiVeriSetiFormViewModel, Core';
    @Type(() => TutunKullanimiVeriSeti)
    public _TutunKullanimiVeriSeti: TutunKullanimiVeriSeti = new TutunKullanimiVeriSeti();
    @Type(() => TutunKullanimiTedaviSonucu)
    public TutunKullanimiTedaviSonucuGridList: Array<TutunKullanimiTedaviSonucu> = new Array<TutunKullanimiTedaviSonucu>();
    @Type(() => TutunKullanimiTedaviSekli)
    public TutunKullanimiTedaviSekliGridList: Array<TutunKullanimiTedaviSekli> = new Array<TutunKullanimiTedaviSekli>();
    @Type(() => TutunKullanimiBagimOldUrun)
    public TutunKullanimiBagimOldUrunGridList: Array<TutunKullanimiBagimOldUrun> = new Array<TutunKullanimiBagimOldUrun>();
    @Type(() => SKRSTutunDumaninaMaruzKalmaPasificicilik)
    public SKRSTutunDumaninaMaruzKalmaPasificiciliks: Array<SKRSTutunDumaninaMaruzKalmaPasificicilik> = new Array<SKRSTutunDumaninaMaruzKalmaPasificicilik>();
    @Type(() => SKRSSigaraKullanimi)
    public SKRSSigaraKullanimis: Array<SKRSSigaraKullanimi> = new Array<SKRSSigaraKullanimi>();
    @Type(() => SKRSTutunTedaviSonucu)
    public SKRSTutunTedaviSonucus: Array<SKRSTutunTedaviSonucu> = new Array<SKRSTutunTedaviSonucu>();
    @Type(() => SKRSTedaviSekli)
    public SKRSTedaviSeklis: Array<SKRSTedaviSekli> = new Array<SKRSTedaviSekli>();
    @Type(() => SKRSBagimliOlduguUrun)
    public SKRSBagimliOlduguUruns: Array<SKRSBagimliOlduguUrun> = new Array<SKRSBagimliOlduguUrun>();
}
