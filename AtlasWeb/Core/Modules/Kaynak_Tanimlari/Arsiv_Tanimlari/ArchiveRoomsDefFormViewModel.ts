//$0E88E0C0
import { BaseViewModel } from "app/NebulaClient/Model/BaseViewModel";
import { ResArchiveRoom, ResCabinet, ResShelf } from "NebulaClient/Model/AtlasClientModel";
import { ResFloor } from "NebulaClient/Model/AtlasClientModel";
import { ResBuildingWing } from "NebulaClient/Model/AtlasClientModel";
import { ResBuilding } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { Type } from "app/NebulaClient/ClassTransformer";

export class ArchiveRoomsDefFormViewModel extends BaseViewModel {
    @Type(() => ResArchiveRoom)
    public _ResArchiveRoom: ResArchiveRoom = new ResArchiveRoom();
    @Type(() => ResFloor)
    public ResFloors: Array<ResFloor> = new Array<ResFloor>();
    @Type(() => ResBuildingWing)
    public ResBuildingWings: Array<ResBuildingWing> = new Array<ResBuildingWing>();
    @Type(() => ResBuilding)
    public ResBuildings: Array<ResBuilding> = new Array<ResBuilding>();
    @Type(() => ResCabinet)
    public CabinetList: Array<ResCabinet> = new Array<ResCabinet>();
    @Type(() => RoomModel)
    public RoomList: Array<RoomModel> = new Array<RoomModel>();
    @Type(() => ResShelf)
    public ShelfList: Array<ResShelf> = new Array<ResShelf>();
    @Type(() => CabinetShelf)
    public CabinetShelf: Array<CabinetShelf> = new Array<CabinetShelf>();

}

export class RoomModel {
    public ObjectID: Guid;
    public RoomName: string;
    public BuildingName: string;
    public WingName: string;
    public FloorName: string;
    public Active: boolean;
    public Room: ResArchiveRoom;
}

export class CabinetShelf{
    public ShelfObjectID: Guid;
    public CabinetObjectID: Guid;
}