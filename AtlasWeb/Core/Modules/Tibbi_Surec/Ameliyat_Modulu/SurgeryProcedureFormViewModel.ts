//$16DF666F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { SurgeryResponsibleDoctor } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AyniFarkliKesi } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class SurgeryProcedureFormViewModel extends BaseViewModel {
    @Type(() => SurgeryProcedure)
    public _SurgeryProcedure: SurgeryProcedure = new SurgeryProcedure();
    @Type(() => SurgeryResponsibleDoctor)
    public SurgeryResponsibleDoctorsGridList: Array<SurgeryResponsibleDoctor> = new Array<SurgeryResponsibleDoctor>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => AyniFarkliKesi)
    public AyniFarkliKesis: Array<AyniFarkliKesi> = new Array<AyniFarkliKesi>();
    @Type(() => Boolean)
    public isNew: Boolean;
    @Type(() => ResUser)
    public ResponsibleDoctor_DataSource: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResUser)
    public SelectedResponsibleDoctorList: Array<ResUser> = new Array<ResUser>();
    @Type(() => Boolean)
    public OnlyOneProcedureDoctor: Boolean;
    @Type(() => Boolean)
    public IsRequiredPathology: Boolean;

    @Type(() => SurgeryResponsibleDoctor)
    public SurgeryResponsibleDoctorList: Array<SurgeryResponsibleDoctor> = new Array<SurgeryResponsibleDoctor>();
}
export class GetNewViewModelByProcedureObject {
    @Type(() => Guid)
    public surgeryDefinition: Guid; // SurgeryDefinition;
    @Type(() => EpisodeAction)
    public episodeAction: EpisodeAction;
}
