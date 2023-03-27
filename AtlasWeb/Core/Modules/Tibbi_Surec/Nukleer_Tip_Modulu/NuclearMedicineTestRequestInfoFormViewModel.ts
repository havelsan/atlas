//$D4ADC4E4
import { NuclearMedicineTest } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class NuclearMedicineTestRequestInfoFormViewModel extends BaseViewModel {
    @Type(() => NuclearMedicineTest)
    public _NuclearMedicineTest: NuclearMedicineTest = new NuclearMedicineTest();
    public ProcedureName: string;
    public ProcedureCode: string;
    public textDescription: string;
}
