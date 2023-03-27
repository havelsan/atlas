//$6877E81B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientAppointment, ResSection } from "NebulaClient/Model/AtlasClientModel";
import { ResBed } from "NebulaClient/Model/AtlasClientModel";
import { ResRoom } from "NebulaClient/Model/AtlasClientModel";
import { ResWard } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class InpatientAppInfoFormViewModel extends BaseViewModel {
    @Type(() => InpatientAppointment)
    public _InpatientAppointment: InpatientAppointment = new InpatientAppointment();

    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResBed)
    public ResBeds: Array<ResBed> = new Array<ResBed>();
    @Type(() => ResRoom)
    public ResRooms: Array<ResRoom> = new Array<ResRoom>();
    @Type(() => ResWard)
    public ResWards: Array<ResWard> = new Array<ResWard>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
