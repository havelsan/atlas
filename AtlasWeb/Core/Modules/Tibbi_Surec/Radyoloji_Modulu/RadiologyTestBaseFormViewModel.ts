//$38C67E10
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class RadiologyTestBaseFormViewModel extends BaseViewModel {
    @Type(() => RadiologyTest)
    public _RadiologyTest: RadiologyTest = new RadiologyTest();

}

