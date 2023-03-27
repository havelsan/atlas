//$5CB28E20
import { HealthCommittee } from 'NebulaClient/Model/AtlasClientModel';
import { BaseHealthCommittee_HospitalsUnitsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class HCCommitteeAcceptanceFormViewModel extends BaseViewModel {
    public _HealthCommittee: HealthCommittee = new HealthCommittee();
    public HospitalsUnitsGridList: Array<BaseHealthCommittee_HospitalsUnitsGrid> = new Array<BaseHealthCommittee_HospitalsUnitsGrid>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public HCRequestReasons: Array<HCRequestReason> = new Array<HCRequestReason>();
    public ReasonForExaminationDefinitions: Array<ReasonForExaminationDefinition> = new Array<ReasonForExaminationDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
}
