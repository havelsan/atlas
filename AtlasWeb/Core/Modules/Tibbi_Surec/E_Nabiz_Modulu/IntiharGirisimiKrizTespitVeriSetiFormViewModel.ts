//$A38EF9FC
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { IntiharGirisimKrizVeriSeti } from "NebulaClient/Model/AtlasClientModel";
import { IntiharGirisimPsikiyatTani } from "NebulaClient/Model/AtlasClientModel";
import { IntiharGirisimiYontemi } from "NebulaClient/Model/AtlasClientModel";
import { IntiharGirisimiVakaSonucu } from "NebulaClient/Model/AtlasClientModel";
import { IntiharGirisimiKrizNedeni } from "NebulaClient/Model/AtlasClientModel";
import { SKRSICD } from "NebulaClient/Model/AtlasClientModel";
import { SKRSPsikiyatrikTedaviGecmisi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIntiharKrizVakaTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIntiharGirisimiGecmisi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAilesindePsikiyatrikVaka } from "NebulaClient/Model/AtlasClientModel";
import { SKRSAilesindeIntiharGirisimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIntiharKrizVakaSonucu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIntiharGirisimiyadaKrizNedenleri } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class IntiharGirisimiKrizTespitVeriSetiFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.IntiharGirisimiKrizTespitVeriSetiFormViewModel, Core';
    @Type(() => IntiharGirisimKrizVeriSeti)
    public _IntiharGirisimKrizVeriSeti: IntiharGirisimKrizVeriSeti = new IntiharGirisimKrizVeriSeti();
    @Type(() => IntiharGirisimPsikiyatTani)
    public IntiharGirisimPsikiyatTaniGridList: Array<IntiharGirisimPsikiyatTani> = new Array<IntiharGirisimPsikiyatTani>();
    @Type(() => IntiharGirisimiYontemi)
    public IntiharGirisimiYontemiGridList: Array<IntiharGirisimiYontemi> = new Array<IntiharGirisimiYontemi>();
    @Type(() => IntiharGirisimiVakaSonucu)
    public IntiharGirisimiVakaSonucuGridList: Array<IntiharGirisimiVakaSonucu> = new Array<IntiharGirisimiVakaSonucu>();
    @Type(() => IntiharGirisimiKrizNedeni)
    public IntiharGirisimiKrizNedeniGridList: Array<IntiharGirisimiKrizNedeni> = new Array<IntiharGirisimiKrizNedeni>();
    @Type(() => SKRSICD)
    public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();
    @Type(() => SKRSPsikiyatrikTedaviGecmisi)
    public SKRSPsikiyatrikTedaviGecmisis: Array<SKRSPsikiyatrikTedaviGecmisi> = new Array<SKRSPsikiyatrikTedaviGecmisi>();
    @Type(() => SKRSIntiharKrizVakaTuru)
    public SKRSIntiharKrizVakaTurus: Array<SKRSIntiharKrizVakaTuru> = new Array<SKRSIntiharKrizVakaTuru>();
    @Type(() => SKRSIntiharGirisimiGecmisi)
    public SKRSIntiharGirisimiGecmisis: Array<SKRSIntiharGirisimiGecmisi> = new Array<SKRSIntiharGirisimiGecmisi>();
    @Type(() => SKRSAilesindePsikiyatrikVaka)
    public SKRSAilesindePsikiyatrikVakas: Array<SKRSAilesindePsikiyatrikVaka> = new Array<SKRSAilesindePsikiyatrikVaka>();
    @Type(() => SKRSAilesindeIntiharGirisimi)
    public SKRSAilesindeIntiharGirisimis: Array<SKRSAilesindeIntiharGirisimi> = new Array<SKRSAilesindeIntiharGirisimi>();
    @Type(() => SKRSIntiharKrizVakaSonucu)
    public SKRSIntiharKrizVakaSonucus: Array<SKRSIntiharKrizVakaSonucu> = new Array<SKRSIntiharKrizVakaSonucu>();
    @Type(() => SKRSIntiharGirisimiyadaKrizNedenleri)
    public SKRSIntiharGirisimiyadaKrizNedenleris: Array<SKRSIntiharGirisimiyadaKrizNedenleri> = new Array<SKRSIntiharGirisimiyadaKrizNedenleri>();
}
