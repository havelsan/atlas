//$43B39B65
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DailyActivityTestsForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class DailyActivityTestsFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.DailyActivityTestsFormViewModel, Core';
    @Type(() => DailyActivityTestsForm)
    public _DailyActivityTestsForm: DailyActivityTestsForm = new DailyActivityTestsForm();
}
