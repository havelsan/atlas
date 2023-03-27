//$515BBB73
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ManipulationProcedure } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";

export class ManipulationProcedureRequestInfoViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ManipulationProcedureRequestInfoViewModel, Core';
    @Type(() => ManipulationProcedure)
    public _ManipulationProcedure: ManipulationProcedure = new ManipulationProcedure();
    public ProcedureName: string;
    public Description: string;
}
