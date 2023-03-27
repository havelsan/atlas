//$7A9BFE02
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { TraditionalMedicine } from "NebulaClient/Model/AtlasClientModel";
import { TraditionalMedAppRegion } from "NebulaClient/Model/AtlasClientModel";
import { TradititionalMedAppCases } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGETATUygulamaTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGETATUygulamaBolgesi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGETATUygulandigiDurumlar } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGETATUygulamaBirimi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGETATTedaviSonucu } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";

export class GetatExaminationFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.GetatExaminationFormViewModel, Core';

    
    @Type(() => TraditionalMedicine)
    public _TraditionalMedicine: TraditionalMedicine = new TraditionalMedicine();

    @Type(() => TraditionalMedAppRegion)
    public TraditionalMedAppRegionGridList: Array<TraditionalMedAppRegion> = new Array<TraditionalMedAppRegion>();
    
    @Type(() => TradititionalMedAppCases)
    public TraditionalMedAppCasesGridList: Array<TradititionalMedAppCases> = new Array<TradititionalMedAppCases>();

    @Type(() => SKRSGETATUygulamaTuru)
    public SKRSGETATUygulamaTurus: Array<SKRSGETATUygulamaTuru> = new Array<SKRSGETATUygulamaTuru>();

    @Type(() => SKRSGETATUygulamaBolgesi)
    public SKRSGETATUygulamaBolgesis: Array<SKRSGETATUygulamaBolgesi> = new Array<SKRSGETATUygulamaBolgesi>();

    @Type(() => SKRSGETATUygulandigiDurumlar)
    public SKRSGETATUygulandigiDurumlars: Array<SKRSGETATUygulandigiDurumlar> = new Array<SKRSGETATUygulandigiDurumlar>();

    @Type(() => SKRSGETATUygulamaBirimi)
    public SKRSGETATUygulamaBirimis: Array<SKRSGETATUygulamaBirimi> = new Array<SKRSGETATUygulamaBirimi>();

    @Type(() => SKRSGETATTedaviSonucu)
    public SKRSGETATTedaviSonucus: Array<SKRSGETATTedaviSonucu> = new Array<SKRSGETATTedaviSonucu>();
}
