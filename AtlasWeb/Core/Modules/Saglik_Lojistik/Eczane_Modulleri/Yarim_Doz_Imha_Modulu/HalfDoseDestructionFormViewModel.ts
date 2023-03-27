//$E0F80B7B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HalfDoseDestruction } from "NebulaClient/Model/AtlasClientModel";
import { HalfDoseDestructionDetail } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { UnitDefinition } from "NebulaClient/Model/AtlasClientModel";

export class HalfDoseDestructionFormViewModel extends BaseViewModel {
    public _HalfDoseDestruction: HalfDoseDestruction = new HalfDoseDestruction();
    public HalfDoseDestructionDetailsGridList: Array<HalfDoseDestructionDetail> = new Array<HalfDoseDestructionDetail>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public Stores: Array<Store> = new Array<Store>();
    public UnitDefinitions: Array<UnitDefinition> = new Array<UnitDefinition>();
}
