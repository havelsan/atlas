//$34A47C57
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { IsokineticTestForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class IsokineticTestFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.IsokineticTestFormViewModel, Core';
    @Type(() => IsokineticTestForm)
    public _IsokineticTestForm: IsokineticTestForm = new IsokineticTestForm();
}
