//$5944EC89
import { DrugOrderIntroduction, HospitalTimeSchedule, HospitalTimeScheduleDetail, Episode, DrugOrderStatusEnum, DrugUsageTypeEnum, DrugOrderTypeEnum, PeriodUnitTypeEnum, DrugOrderDetail, DrugDrugInteraction, DrugFoodInteraction } from 'app/NebulaClient/Model/AtlasClientModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DrugInfo } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { Type } from 'app/NebulaClient/ClassTransformer';

export class DrugOrderIntroductionFormViewModel {
    @Type(() => DrugOrderIntroductionGridViewModel)
    public DrugOrderIntroductionGridViewModelDTO: Array<DrugOrderIntroductionGridViewModel> = new Array<DrugOrderIntroductionGridViewModel>();
    @Type(() => DrugOrderIntroductionGridViewModel)
    public DrugOrderIntroductionGridViewModel: Array<DrugOrderIntroductionGridViewModel> = new Array<DrugOrderIntroductionGridViewModel>();
    public DrugOrderIntroduction: DrugOrderIntroduction = new DrugOrderIntroduction();
}


export class DrugOrderIntroductionGridViewModel {
    public ID: string;
    @Type(() => DrugOrderTimceSchedule)
    public DrugOrderIntroDuctionTimeSchedule: Array<DrugOrderTimceSchedule> = new Array<DrugOrderTimceSchedule>();
    public UpdatedOnGrid: boolean;
    public EditOnGrid: boolean;
    //Etken madde ve doz kontrolü inputuna eklenip eklenmeyeceği
    public AddMaterialToInput: boolean = false;
    public SelectionCheck: boolean = false;
    public Status: DrugOrderStatusEnum;
    public ParentDrugOrderObjectID: Guid;
    public LastDrugOrderObjectID: Guid;

    @Type(() => Date)
    public PlannedStartTime: Date;
    @Type(() => Date)
    public PlannedEndTime: Date;
    @Type(() => Date)
    public CreationDate: Date;
    public HospitalTimeScheduleObjectID: Guid;
    @Type(() => Number)
    public DoseAmount: number;
    @Type(() => Number)
    public Day: number;
    public UsageNote: string;
    public IsImmediate: boolean;
    public PatientOwnDrug: boolean;
    public CaseOfNeed: boolean;
    public IsUpgraded: boolean;
    public DrugUsageType: DrugUsageTypeEnum;
    public DrugOrderType: DrugOrderTypeEnum;
    public Material: DrugInfo;
    public PeriodUnitType: PeriodUnitTypeEnum = PeriodUnitTypeEnum.DayPeriod;
    @Type(() => HospitalTimeSchedule)
    public HospitalTimeSchedule: HospitalTimeSchedule;
    public DoctorName: string;
    @Type(() => Date)
    public OrderStartTime: Date;
    public IsCV: boolean;
    public RepeatDayWarning: string;
    public IsTeleOrder: boolean;
    public DoctorGuid: Guid;
}

export class DrugOrderTimceSchedule {
    @Type(() => Date)
    public Time: Date;
    @Type(() => Number)
    public DetailNo: number;
    public UsageNote: string;
    @Type(() => Number)
    public DoseAmount: number;
    public MasterID: string;
    public UpgradeDetail: boolean;
}

export class DrugOrderIntroductionNewForm_Output {
    @Type(() => DrugOrderIntroduction)
    public drugOrderIntroduction: DrugOrderIntroduction;
    @Type(() => HospitalTimeSchedule)
    public hospitalTimeSchedule: Array<HospitalTimeSchedule>;
    @Type(() => HospitalTimeScheduleDetail)
    public hospitalTimeScheduleDetail: Array<HospitalTimeScheduleDetail>;
    @Type(() => PatientDTO)
    public patientDTO: PatientDTO;
    @Type(() => DrugOrderIntroductionGridViewModel)
    public DrugOrderGirdViewModelList: Array<DrugOrderIntroductionGridViewModel>;
    @Type(() => Number)
    public DrugOrderQueryDate: number;
    @Type(() => Number)
    public DrugOrderTimeOffset: number;
    public IsHimssRequired: boolean;
    public isVademecumEntegrasyon: boolean;
    public checkDrugAmount: boolean;
    public OrderRestDayCount: number;
    public OrderRestDayDescription: string;
    public isVisible: boolean;
    public isCV: boolean;
}
export class SaveDrugOrder_Output {
    public IsSuccess: boolean = false;
    public ErrorMessage: string;
    public GridViewModel: Array<DrugOrderIntroductionGridViewModel>;
}

export class DrugOrderIntroductionNewForm_Input {
    public episodeObjectID: Guid;
    public masterResourceObjectID: Guid;
    public subEpisodeObjectID: Guid;
    public allDate: boolean;
    public activeInPatientPhysicianApp: Guid;
}

export class PatientDTO {
    public Age: number;
    public Sex: string;
    public PatientAllergicIngredient: Array<Guid> = new Array<Guid>();
    public IsSGK: boolean;
    public IsLiverTransplant: boolean;
    public IsRequestAlbuminExamination: boolean;
    public ResultAlbuminExamination: number;
    public ActiveInfectionCommiteeApproves: Array<ActiveInfectionCommiteeApprove> = new Array<ActiveInfectionCommiteeApprove>();
}
export class ActiveInfectionCommiteeApprove {
    public MaterialID: Guid;
    public StartDate: Date;
    public EndDate: Date;
}


export class ControlOfActiveIngredientMaterialModel {
    public Amount?: number;
    public ObjectID: Guid;
    public Day: number;
    public PlannedStartTime: Date;
    public PlannedEndTime: Date;
}

export class ControlOfActiveIngredient_Input {
    public episode: Episode;
    //Eklenen malzemenin ObjectID si ve Amount'u
    public materialModelList: Array<ControlOfActiveIngredientMaterialModel> = new Array<ControlOfActiveIngredientMaterialModel>();
    public PlannedStartTime: Date;
    public PlannedEndTime: Date;
}

export class DrugOrderRequirement_Output {
    public OverDoseMessage: string;
    public ActiveIngredientMessage: string;
}

export class StopDrugOrders_Input {
    public DrugOrderObjectIDList: Array<Guid> = new Array<Guid>();
}

export class StopDrugOrders_Output {
    public Result: boolean;
    public ResultMessage: string;
    public details: Array<StopDrugOrderDetails>;
}

export class StopDrugOrderDetails {
    public objectId: Guid;
    public status: DrugOrderStatusEnum;
}

export class DrugOrderInfoDetail_Output {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Date)
    public OrderPlannedDate: Date;
    @Type(() => Date)
    public ActionDate: Date;
    public DoctorName: string;
    public Status: string;
    public EHUCancelReason: string;
}

export class DrugOrderInfo_Output {
    public DrugName: string;
    public DrugOrderInfoDetails: Array<DrugOrderInfoDetail_Output>;
}

export class DrugOrderInfo_Input {
    public DrugOrderObjectID: Guid;
    public ParentDrugOrderObjectID: Guid;
}

export class UpgradeDrugOrderDVO {
    public oldDrugOrderIntroductionGridViewModel: DrugOrderIntroductionGridViewModel;
    @Type(() => HospitalTimeSchedule)
    public newHospitalTimeSchedule: HospitalTimeSchedule;
    @Type(() => Number)
    public newDoseAmount: number;
    public newUsageNote: string;
    public newIsCV: boolean;
    public timeScheduleDataSource: Array<HospitalTimeSchedule>;
    public drugOrderDetails: Array<DrugOrderDetail>;
}

export class PrepareInteraction_Input {
    @Type(() => Guid)
    public drugList: Array<Guid>;
    @Type(() => Guid)
    public episodeID: Guid;
}

export class PrepareInteraction_Output {
    public drugDrugInteractions: Array<InteractionDTO>;
    public drugFoodInteractions: Array<InteractionDTO>;
}

export class InteractionDTO {
    public Header: string;
    public Color: any;
    public Message: string;
}

export class GetAllDrugOrderGridViewModel_Input {
    public episodeObjectID: Guid;
}

export class UpgradeDrugOrder_Output {
    public result: boolean;
    public errorMessage: string;
}
