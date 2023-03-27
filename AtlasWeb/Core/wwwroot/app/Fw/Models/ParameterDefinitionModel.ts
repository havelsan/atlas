import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ResSection, Consultation, EpisodeAction } from "NebulaClient/Model/AtlasClientModel";

export class ClickFunctionParams {
    constructor(parentInstanceParam: any, paramsParam: any) {
        this.ParentInstance = parentInstanceParam;
        this.Params = paramsParam;
    }
    public ParentInstance: any;
    public Params: any;
}

export class GiveAppointmentModel {
    constructor(transDefParam: TTObjectStateTransitionDef, objectParam: any) {
        this.transDef = transDefParam;
        this.ttObject = objectParam;
    }
    public transDef: TTObjectStateTransitionDef;
    public ttObject: any;
}

export class ActiveIDsModel {
    constructor(episodeActionIdParam: Guid, episodeIdParam: Guid, patientIdParam: Guid) {
        this.episodeActionId = episodeActionIdParam;
        this.episodeId = episodeIdParam;
        this.patientId = patientIdParam;
    }
    public episodeActionId: Guid;
    public episodeId: Guid;
    public patientId: Guid;
}

export class ConsultationRequestParametersModel {
    constructor(episodeIdParam: Guid, resourceParam: ResSection, resourceListParam: Guid[], consultationParam: Consultation, masterActionParam: EpisodeAction) {
        this.episodeId = episodeIdParam;
        this.resource = resourceParam;
        this.resourceList = resourceListParam;
        this.consultation = consultationParam;
        this.masterAction = masterActionParam;
    }
    
    public episodeId: Guid;
    public resource: ResSection;
    public resourceList: Guid[];
    public consultation: Consultation;
    public masterAction: EpisodeAction;
}

export class ActiveEmergencyOrderIDsModel {
    constructor(episodeActionIdParam: Guid, episodeIdParam: Guid, patientIdParam: Guid,masterResource:Guid) {
        this.episodeActionId = episodeActionIdParam;
        this.episodeId = episodeIdParam;
        this.patientId = patientIdParam;
        this.masterResource = masterResource;
    }
    public episodeActionId: Guid;
    public episodeId: Guid;
    public patientId: Guid;
    public masterResource: Guid;
}