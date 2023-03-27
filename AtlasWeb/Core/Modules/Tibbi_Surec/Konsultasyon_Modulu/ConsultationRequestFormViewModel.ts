//$EB662DCE
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Consultation } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class ConsultationRequestFormViewModel extends BaseViewModel {
    public _Consultation: Consultation = new Consultation();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public Episodes: Array<Episode> = new Array<Episode>();
}

export class ConsultationRequestFormResourceInfo {
    public ResourceList: Array<Guid> = new Array<Guid>();
    public Resource: ResSection;
}


