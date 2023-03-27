//$C2E90999
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MuscleStrengthMeasuringForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class MuscleStrengthMeasuringFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.MuscleStrengthMeasuringFormViewModel, Core';
    @Type(() => MuscleStrengthMeasuringForm)
    public _MuscleStrengthMeasuringForm: MuscleStrengthMeasuringForm = new MuscleStrengthMeasuringForm();
}
