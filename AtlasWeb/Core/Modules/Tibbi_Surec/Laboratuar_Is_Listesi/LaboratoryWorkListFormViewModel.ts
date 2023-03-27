import { BaseModel } from 'Fw/Models/BaseModel';
import { DateTime } from 'NebulaClient/System/Time/DateTime';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';

export class LaboratoryWorkListFormViewModel extends BaseModel {


    txtPatient: string;
    txtSEProtocolNo: string;
    @Type(() => Date)
    StartDate: Date;
    @Type(() => Date)
    EndDate: Date;
    ID: string;
    EpisodeID: string;
    @Type(() => Number)
    WorkListCount: number;
    StateType: string;
    PatientStatus: string;
    @Type(() => LaboratoryWorkListItem)
    LaboratoryWorkListItems: Array<LaboratoryWorkListItem>;
    @Type(() => LaboratoryWorkListStateItem)
    LaboratoryWorkListStateItems: Array<LaboratoryWorkListStateItem>;
    @Type(() => LaboratoryWorkListItem)
    SelectedLaboratoryWorkListItems: Array<LaboratoryWorkListItem>;
    @Type(() => LaboratoryWorkListStateItem)
    SelectedLaboratoryWorkListStateItems: Array<LaboratoryWorkListStateItem>;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    @Type(() => SpecialPanelListItem)
    private _specialPanelListItems: Array<SpecialPanelListItem>;
    @Type(() => SpecialPanelListItem)
    public get SpecialPanelListItems(): Array<SpecialPanelListItem> {
        return this._specialPanelListItems;
    }
    public set SpecialPanelListItems(value: Array<SpecialPanelListItem>) {
        this._specialPanelListItems = value;
    }
    @Type(() => SpecialPanelListItem)
    LastSelectedSpecialPanel: SpecialPanelListItem;
    LastSelectedSpecialPanelCaption: string;
    PriorityIcon: string;
    @Type(() => LaboratoryWorkListItemMasterModel)
    LaboratoryProcedureMasterList: Array<LaboratoryWorkListItemMasterModel>;
}

export class LaboratoryWorkListItemMasterModel {
    public ObjectID: string;
    public EpisodeID: string;
    public PatientObjectID: string;
    public PatientNameSurname: string;
    public ID: string;
    public FromResourceName: string;
    public LabRequestObjectID: string;
    @Type(() => LaboratoryWorkListItemDetailModel)
    public LaboratoryProcedureList: Array<LaboratoryWorkListItemDetailModel> = new Array<LaboratoryWorkListItemDetailModel>();
    @Type(() => TubeInformation)
    public TubeInformationList: Array<TubeInformation> = new Array<TubeInformation>();
    public SelectedLaboratoryStateItems: Array<string> = new Array<string>();
    @Type(() => Boolean)
    public isPregnant: boolean;
    @Type(() => Boolean)
    public isEmergency: boolean;
    @Type(() => Boolean)
    public isYoung: boolean;
    @Type(() => Boolean)
    public isOld: boolean;
    @Type(() => Boolean)
    public isVetera: boolean;
    @Type(() => Boolean)
    public isDisabled: boolean;
    @Type(() => Boolean)
    public hasMedicalInformation: boolean;

    //Barcode etiketi icin gerekli bilgiler
    public PatientID: string;
    public PatientTCNo: string;
    public PatientBirthDate: string;
    public PatientBirthCity: string;
    public PatientStatus: string;
    public InPatientDate: string;
    public DischargeDate: string;
    public PatientDoctor: string;
    public PatientGroup: string;
    public PatientSex: string;
    public DefNo: string;
    public ArsivNo: string;

}

export class LaboratoryWorkListItemDetailModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public ObjectDefName: string;
    public PatientNameSurname: string;
    public EpisodeActionName: string;
    public TestCode: string;
    public TestLoincCode: string;
    public LaboratoryTestName: string;
    public BarcodeID: string;
    public SpecimenID: string;
    public FromResourceName: string;
    @Type(() => Date)
    public WorkListDate: Date;
    public RequestDate: string;
    public RequestedByUser: string;
    public StateName: string;
    public StateDefID: string;
    @Type(() => Boolean)
    public isLabTestEmergency: boolean;
    @Type(() => Boolean)
    public isSelected: boolean;
    public LabRequestObjectID: string;
    @Type(() => TubeInformation)
    public TubeInfo: TubeInformation;
    public ResultDate: string;
    public SampleDate: string;
    public ApproveDate: string;
    public Result: string;
    public Unit: string;
    public Reference: string;
    @Type(() => Boolean)
    public isPanelTest: boolean;
    @Type(() => LaboratoryWorkListSubItemDetailModel)
    public LaboratorySubProcedureList: Array<LaboratoryWorkListSubItemDetailModel> = new Array<LaboratoryWorkListSubItemDetailModel>();
    public isExternalProcedureRequest: boolean;
    public EpisodeActionObjectId: Guid;
    public ProcedureRequestFormCategoryName: string;
    @Type(() => Boolean)
    public hasProcedureInstruction: boolean;
    public ProcedureInstructions: string;
    public ProcedureInstructionReportName: string;
    public SampleUser: string;
    public isMicroscopicExamination: boolean;
}

export class LaboratoryWorkListSubItemDetailModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public MasterSubactionProcedureID: Guid;
    public TestCode: string;
    public TestLoincCode: string;
    public LaboratoryTestName: string;
    public BarcodeID: string;
    public SpecimenID: string;
    @Type(() => DateTime)
    public ResultDate: DateTime;
    public Result: string;
    public Unit: string;
    public Reference: string;
    @Type(() => Boolean)
    public IsOutOfReference: boolean;
    public ResultDescription: string;

}

export class TubeInformation {
    public SpecimenID: string;
    public ContainerID: string;
    public SpecialHandlingCode: string;
    public OtherEnvFactor: string;
    public FromResourceName: string;
    public RequestAcceptionDate: string;
}

export class ProcedureInformation {
    public PlacerOrderNumber: string; //HBYS ObjectID
    public PlacerGroupNumber: string; //BarcodeID
}

export class ProcedureInfoInputDVO {
    public EpisodeID: string;
    public SpecimenID: string; //test ıcın kondu kaldırılacak
    public LabProcedures: Array<string> = new Array<string>();
    public LabRequestObjectID: string;

}

export class ProcedureInfoOutputDVO {
    public SpecimenID: string;
    @Type(() => TubeInformation)
    public TubeInformations: Array<TubeInformation> = new Array<TubeInformation>();
    @Type(() => ProcedureInformation)
    public LabProcedures: Array<ProcedureInformation> = new Array<ProcedureInformation>();
}

export class ProcedureResultInfoInputDVO {
    @Type(() => ProcedureResultInfo)
    public LabProceduresResultInfo: Array<ProcedureResultInfo>;
}
export class ProcedureResultInfo {
    public LaboratoryProcedureObjectID: string;
    @Type(() => DateTime)
    public ResultDate: DateTime;
    public Result: string;
    public Unit: string;
    public Reference: string;
}

export class QueryInputDVO {
    public txtPatient: string;
    public txtSEProtocolNo: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public StateType: string;
    public PatientStatus: string;
    public ID: string;
    @Type(() => Number)
    public WorkListCount: number;
    @Type(() => LaboratoryWorkListItem)
    public SelectedWorkListItems: Array<LaboratoryWorkListItem>;
    @Type(() => LaboratoryWorkListStateItem)
    public SelectedWorkListStateItems: Array<LaboratoryWorkListStateItem>;
    public activeResUserObjectID: string;
    @Type(() => UserResourceItem)
    UserResourceItems: Array<UserResourceItem>;
    @Type(() => UserResourceItem)
    SelectedUserResourceItems: Array<UserResourceItem>;
    public SelectedQueueObjectID: string;
    //public LastSelectedSpecialPanel: SpecialPanelListItem;
}

export class QueryInputDVOByEpisode {
    public PatientObjectID: string;
    public EpisodeID: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public PatientStatus: string;
    @Type(() => LaboratoryWorkListStateItem)
    public SelectedWorkListStateItems: Array<LaboratoryWorkListStateItem>;
    public LabRequestObjectID: string;
}

export class MenuOutputDVO {
    @Type(() => LaboratoryWorkListItem)
    public WorkListSearchItem: Array<LaboratoryWorkListItem>;
}

export class StateOutputDVO {
    @Type(() => LaboratoryWorkListStateItem)
    public WorkListSearchStateItem: Array<LaboratoryWorkListStateItem>;
}

export class UserResourceOutputDVO {
    public WorkListSearchUserResourceItem: Array<UserResourceItem>;
    public SelectedWorkListSearchUserResourceItem: Array<UserResourceItem>;
}

export class LaboratoryWorkListItem {
    public ObjectDefName: string;
    public ObjectDefID: string;
}

export class LaboratoryWorkListStateItem {
    public StateDefName: string;
    public StateDefID: string;
}

export class UserResourceItem {
    public ResourceName: string;
    public ResourceID: string;
}

export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
}

export class SpecialPanelListItem {
    public Name: string;
    public Caption: string;
    public ObjectID: string;
    public User: string;
    @Type(() => SpecialPanelCriteriaVal)
    public SpecialPanelCriteriaValues: Array<SpecialPanelCriteriaVal>;
}

export class SpecialPanelCriteriaVal {
    public Name: string;
    public ObjectID: string;
    public Value: string;
}
export class SpecialPanelOutputDVO {
    @Type(() => SpecialPanelListItem)
    public SpecialPanelList: Array<SpecialPanelListItem>;
    @Type(() => SpecialPanelListItem)
    public LastSelectedSpecialPanel: SpecialPanelListItem;
}
export class SpecialPanelInputDVO {
    @Type(() => LaboratoryWorkListItem)
    public SelectedWorkListItems: Array<LaboratoryWorkListItem>;
    @Type(() => LaboratoryWorkListStateItem)
    public SelectedWorkListStateItems: Array<LaboratoryWorkListStateItem>;
    @Type(() => SpecialPanelListItem)
    public SpecialPanelListItems: Array<SpecialPanelListItem>;
    @Type(() => SpecialPanelListItem)
    public LastSelectedSpecialPanel: SpecialPanelListItem;
    @Type(() => Boolean)
    public isNew: boolean;
    public SpecialPanelListItemCaption: string;
    public activeResUserObjectID: string;
}

export class ProcedureTreeObject {
    public ObjectID: string;
    public Name: string;
}