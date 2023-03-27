//$528230BC
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { BaseBedProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class InPatientAdmissionClinicProcedureViewModel extends BaseViewModel {
    @Type(() => InpatientAdmission)
    public _InpatientAdmission: InpatientAdmission = new InpatientAdmission();
    @Type(() => InPatientTreatmentClinicApplication)
    public TratmentClinicsGridGridList: Array<InPatientTreatmentClinicApplication> = new Array<InPatientTreatmentClinicApplication>();
    @Type(() => BaseBedProcedure)
    public BedsGridGridList: Array<BaseBedProcedure> = new Array<BaseBedProcedure>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => ResRoomGroup)
    public ResRoomGroups: Array<ResRoomGroup> = new Array<ResRoomGroup>();
    @Type(() => ResRoom)
    public ResRooms: Array<ResRoom> = new Array<ResRoom>();
    @Type(() => ResBed)
    public ResBeds: Array<ResBed> = new Array<ResBed>();
    @Type(() => ResWard)
    public ResWards: Array<ResWard> = new Array<ResWard>();
}
