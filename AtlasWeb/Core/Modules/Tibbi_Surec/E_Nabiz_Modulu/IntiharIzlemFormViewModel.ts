//$07B023E0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { IntiharIzlemVeriSeti } from "NebulaClient/Model/AtlasClientModel";
import { IntiharIzlemYontemi } from "NebulaClient/Model/AtlasClientModel";
import { IntiharIzlemVakaSonucu } from "NebulaClient/Model/AtlasClientModel";
import { IntiharIzlemNedeni } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIntiharKrizVakaTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSICD } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIntiharKrizVakaSonucu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIntiharGirisimiyadaKrizNedenleri } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class IntiharIzlemFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.IntiharIzlemFormViewModel, Core';
    @Type(() => IntiharIzlemVeriSeti)
    public _IntiharIzlemVeriSeti: IntiharIzlemVeriSeti = new IntiharIzlemVeriSeti();
    @Type(() => IntiharIzlemYontemi)
    public IntiharIzlemYontemiGridList: Array<IntiharIzlemYontemi> = new Array<IntiharIzlemYontemi>();
    @Type(() => IntiharIzlemVakaSonucu)
    public IntiharIzlemVakaSonucuGridList: Array<IntiharIzlemVakaSonucu> = new Array<IntiharIzlemVakaSonucu>();
    @Type(() => IntiharIzlemNedeni)
    public IntiharIzlemNedeniGridList: Array<IntiharIzlemNedeni> = new Array<IntiharIzlemNedeni>();
    @Type(() => SKRSIntiharKrizVakaTuru)
    public SKRSIntiharKrizVakaTurus: Array<SKRSIntiharKrizVakaTuru> = new Array<SKRSIntiharKrizVakaTuru>();
    @Type(() => SKRSICD)
    public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();
    @Type(() => SKRSIntiharKrizVakaSonucu)
    public SKRSIntiharKrizVakaSonucus: Array<SKRSIntiharKrizVakaSonucu> = new Array<SKRSIntiharKrizVakaSonucu>();
    @Type(() => SKRSIntiharGirisimiyadaKrizNedenleri)
    public SKRSIntiharGirisimiyadaKrizNedenleris: Array<SKRSIntiharGirisimiyadaKrizNedenleri> = new Array<SKRSIntiharGirisimiyadaKrizNedenleri>();
}
