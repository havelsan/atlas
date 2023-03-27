
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class BedSelectionFormViewModel extends BaseViewModel {

    @Type(() => ResWard)
    public selectedPhysicalStateClinic: ResWard = new ResWard();
    @Type(() => ResRoomGroup)
    public selectedRoomGroup: ResRoomGroup = new ResRoomGroup();
    @Type(() => ResRoom)
    public selectedRoom: ResRoom = new ResRoom();
    @Type(() => ResBed)
    public selectedBed: ResBed = new ResBed();

    public BedsPropertysByResWardList: Array<ResBed.GetBedsPropertysByResWard_Class> = new Array<ResBed.GetBedsPropertysByResWard_Class>();
    @Type(() => Boolean)
    public isOnlyEmptyBeds: boolean;

    public physicalStateClinicList: Array<ResBed.GetResWardListWithEmtyBedCount_Class> = new Array<ResBed.GetResWardListWithEmtyBedCount_Class>();
    public emptyBeds: number = 0;
    public usedBedsWoman: number = 0;
    public usedBedsMan: number = 0;
    public cleaningStatusBeds:number = 0;
    public isolatedRoom: number = 0;
    public isolatedBed: number = 0;
    public reservedToUseMan: number = 0;
    public reservedToUseWoman:number = 0;

}

export class BedSelectionForm_InputParam {
    @Type(() => ResWard)
    public selectedPhysicalStateClinic: ResWard = new ResWard();
    @Type(() => Boolean)
    public isOnlyEmptyBeds: boolean = true;
}

export class SelectedBedViewModel {
    @Type(() => ResWard)
    public PhysicalStateClinic: ResWard;
    @Type(() => ResRoomGroup)
    public RoomGroup: ResRoomGroup;
    @Type(() => ResRoom)
    public Room: ResRoom;
    @Type(() => ResBed)
    public Bed: ResBed;
}
