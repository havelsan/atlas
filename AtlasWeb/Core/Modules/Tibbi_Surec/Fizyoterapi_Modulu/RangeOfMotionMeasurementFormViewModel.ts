//$0C09CC0B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { RangeOfMotionMeasurementForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class RangeOfMotionMeasurementFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.RangeOfMotionMeasurementFormViewModel, Core';
    @Type(() => RangeOfMotionMeasurementForm)
    public _RangeOfMotionMeasurementForm: RangeOfMotionMeasurementForm = new RangeOfMotionMeasurementForm();
}
