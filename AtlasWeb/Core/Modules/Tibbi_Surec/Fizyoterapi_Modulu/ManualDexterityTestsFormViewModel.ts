//$FBC749FB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ManualDexterityTestsForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ManualDexterityTestsFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ManualDexterityTestsFormViewModel, Core';
    @Type(() => ManualDexterityTestsForm)
    public _ManualDexterityTestsForm: ManualDexterityTestsForm = new ManualDexterityTestsForm();
}
