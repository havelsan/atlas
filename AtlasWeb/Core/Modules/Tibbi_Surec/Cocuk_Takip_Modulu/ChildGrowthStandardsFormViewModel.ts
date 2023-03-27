//$7846D474
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChildGrowthStandards } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
export class ChildGrowthStandardsFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ChildGrowthStandardsFormViewModel, Core';
    @Type(() => ChildGrowthStandards)
    public _ChildGrowthStandards: ChildGrowthStandards = new ChildGrowthStandards();
    @Type(() => Guid)
    public _PatientID: Guid;
}
