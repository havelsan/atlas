//$1C50BAB6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BalanceCoordinationTestsForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class BalanceCoordinationTestsFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.BalanceCoordinationTestsFormViewModel, Core';
    @Type(() => BalanceCoordinationTestsForm)
    public _BalanceCoordinationTestsForm: BalanceCoordinationTestsForm = new BalanceCoordinationTestsForm();
}
