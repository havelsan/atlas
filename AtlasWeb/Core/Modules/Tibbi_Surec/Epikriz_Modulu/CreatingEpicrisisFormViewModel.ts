//$EF4B4A50
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { CreatingEpicrisis, EpisodeAction, ResSection, ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";


export class CreatingEpicrisisFormViewModel extends BaseViewModel {
    @Type(() => CreatingEpicrisis)
    public _CreatingEpicrisis: CreatingEpicrisis = new CreatingEpicrisis();
    @Type(() => Episode)
    public Episodes: Array <Episode> = new Array <Episode>();
    @Type(() => CreatingEpicrisis)
    public Epicrisises: Array <CreatingEpicrisis>  = new Array<CreatingEpicrisis>();
    public DoctorAuthority: boolean;
    @Type(() => ResSection)
    public Clinic: ResSection;
    @Type(() => ResUser)
    public Doctor: ResUser;
    @Type(() => ResSection)
    public ClinicList: Array<ResSection> = new Array <ResSection>();
    @Type(() => ResUser)
    public DoctorList: Array <ResUser> = new Array <ResUser>(); 
    public StayLength: number;
    public DayNumber: number;
    public isReportConfirmByDoctor: boolean;
    public isReportConfirmByOthers: boolean;
    @Type(() => ResSection)
    public InpatientClinicList: Array<ResSection> = new Array <ResSection>();
    @Type(() => ResUser)
    public RelatedDoctorList: Array <ResUser> = new Array <ResUser>(); 
    public DoctorName: string;
    public DepartmentName: string;
    public actionId: Guid;
    public NurseAuthority: boolean;
    public isRemoveConfirmation: boolean;
    public IsNew: boolean;
    @Type(() => UserTemplateModel)
    public userTemplateList : Array<UserTemplateModel> = new Array<UserTemplateModel>();
    @Type(() => UserTemplateModel)
    public selectedUserTemplate : UserTemplateModel;
    public WaitConfirmation: boolean;

}

export class EpicrisisGridResultModel
{
    public ObjectID: Guid;
    public Clinic: string;
    public Doctor: string;
    public Date: Date;
}
