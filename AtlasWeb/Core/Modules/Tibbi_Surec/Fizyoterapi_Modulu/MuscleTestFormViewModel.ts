//$60F3DB1C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MuscleTestForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class MuscleTestFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.MuscleTestFormViewModel, Core';
    @Type(() => MuscleTestForm)
    public _MuscleTestForm: MuscleTestForm = new MuscleTestForm();
}
