//$47B191F5
import { BaseViewModel } from "app/NebulaClient/Model/BaseViewModel";
import { ResCabinet } from "NebulaClient/Model/AtlasClientModel";
import { ResShelf } from "NebulaClient/Model/AtlasClientModel";
import { ResArchiveRoom } from "NebulaClient/Model/AtlasClientModel";

export class CabinetDefinitionFormViewModel extends BaseViewModel {
    public _ResCabinet: ResCabinet = new ResCabinet();
    public ResShelvesGridList: Array<ResShelf> = new Array<ResShelf>();
    public ResCabinets: Array<ResCabinet> = new Array<ResCabinet>();
    public ResArchiveRooms: Array<ResArchiveRoom> = new Array<ResArchiveRoom>();
}
