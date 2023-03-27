//$930DE7F7
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PregnancyResult } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDogumYontemi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonjenitalAnomaliliDogumVarligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikSonucu } from 'NebulaClient/Model/AtlasClientModel';
import { Pregnancy } from 'NebulaClient/Model/AtlasClientModel';

import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { Type } from 'NebulaClient/ClassTransformer';

export class PregnancyResultFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PregnancyResultFormViewModel, Core';

    @Type(() => PregnancyResult)
    public _PregnancyResult: PregnancyResult = new PregnancyResult();
    public SKRSDogumYontemis: Array<SKRSDogumYontemi> = new Array<SKRSDogumYontemi>();
    public SKRSKonjenitalAnomaliliDogumVarligis: Array<SKRSKonjenitalAnomaliliDogumVarligi> = new Array<SKRSKonjenitalAnomaliliDogumVarligi>();
    public SKRSGebelikSonucus: Array<SKRSGebelikSonucu> = new Array<SKRSGebelikSonucu>();

    @Type(() => Pregnancy)
    public Pregnancys: Array<Pregnancy> = new Array<Pregnancy>();
}

export class PregnancyResultComponentInfoViewModel {

    public pregnancyResultComponentInfo: DynamicComponentInfo;
    public pregnancyResultQueryParameters: QueryParams;
}
