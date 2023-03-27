//$C35C4E9B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ForensicMedicalReport } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { MilitaryUnit } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";

export class ForensicMedicalReportFormViewModel extends BaseViewModel {
    @Type(() => ForensicMedicalReport)
    public _ForensicMedicalReport: ForensicMedicalReport = new ForensicMedicalReport();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => MilitaryUnit)
    public MilitaryUnits: Array<MilitaryUnit> = new Array<MilitaryUnit>();

    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
