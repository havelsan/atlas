//$8FC66E3A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Pregnancy } from 'NebulaClient/Model/AtlasClientModel';
import { IndicationReason } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyComplications } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSEndikasyonNedenleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSezaryanEndikasyonlar } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumunGerceklestigiYer } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumaYardimEden } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikteRiskFaktorleri } from 'NebulaClient/Model/AtlasClientModel';

import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { Type } from 'NebulaClient/ClassTransformer';

export class PreviousPregnancyFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PreviousPregnancyFormViewModel, Core';

    @Type(() => Pregnancy)
    public _Pregnancy: Pregnancy = new Pregnancy();

    public IndicationReasonsGridList: Array<IndicationReason> = new Array<IndicationReason>();
    public PregnancyComplicationsGridList: Array<PregnancyComplications> = new Array<PregnancyComplications>();
    public SKRSEndikasyonNedenleris: Array<SKRSEndikasyonNedenleri> = new Array<SKRSEndikasyonNedenleri>();
    public SKRSSezaryanEndikasyonlars: Array<SKRSSezaryanEndikasyonlar> = new Array<SKRSSezaryanEndikasyonlar>();
    public SKRSDogumYontemis: Array<SKRSDogumYontemi> = new Array<SKRSDogumYontemi>();
    public SKRSDogumunGerceklestigiYers: Array<SKRSDogumunGerceklestigiYer> = new Array<SKRSDogumunGerceklestigiYer>();
    public SKRSDogumaYardimEdens: Array<SKRSDogumaYardimEden> = new Array<SKRSDogumaYardimEden>();
    public SKRSGebelikteRiskFaktorleris: Array<SKRSGebelikteRiskFaktorleri> = new Array<SKRSGebelikteRiskFaktorleri>();
}

export class PreviousPregnancyComponentInfoViewModel {

    public previousPregnancyComponentInfo: DynamicComponentInfo;
    public previousPregnancyQueryParameters: QueryParams;
}
