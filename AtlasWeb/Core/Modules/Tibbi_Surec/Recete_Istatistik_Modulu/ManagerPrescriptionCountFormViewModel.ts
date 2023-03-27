//$C41A6FAA
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ManagerPrescriptionCounts, ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';

export class ManagerPrescriptionCountFormViewModel extends BaseViewModel {
    public _ManagerPrescriptionCounts: ManagerPrescriptionCounts = new ManagerPrescriptionCounts();
    @Type(() => OldAddedCounts)
    public oldCounts: Array<OldAddedCounts> = new Array<OldAddedCounts>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}

export class OldAddedCounts {
    public ObjectId: Guid;
    public AddedUser: string;
    public ePrescriptionCount: string;
    public EmergencyPrescriptionCount: string;
    public PoliclinicPrescriptionCount: string;
    public PrescriptionCountRate: string;
    public TotalPrescriptionCounts: string;
    public StartDate: Date;
    public EndDate: Date;
    public LastUpdate: Date;
    public doctorName: string;
}