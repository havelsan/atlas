//$AE3476F5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ElectrodiagnosticTests } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ElectrodiagnosticTestsFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ElectrodiagnosticTestsFormViewModel, Core';
    @Type(() => ElectrodiagnosticTests)
    public _ElectrodiagnosticTests: ElectrodiagnosticTests = new ElectrodiagnosticTests();
}
