//$D4ADC4E4
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class RadiologyTestRequestInfoFormViewModel extends BaseViewModel {
    @Type(() => RadiologyTest)
    public _RadiologyTest: RadiologyTest = new RadiologyTest();
    public ProcedureName: string;
    public ProcedureCode: string;
    public textDescription: string;
}
