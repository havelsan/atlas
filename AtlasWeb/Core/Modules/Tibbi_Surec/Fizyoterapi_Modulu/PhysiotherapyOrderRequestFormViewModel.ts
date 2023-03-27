//$ACF23B7D
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyOrder } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResTreatmentDiagnosisUnit } from "NebulaClient/Model/AtlasClientModel";
import { FTRVucutBolgesi } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyReports } from "NebulaClient/Model/AtlasClientModel";

import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';

import { Type } from 'NebulaClient/ClassTransformer';
import { PhysiotherapyRequest, ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";

export class PhysiotherapyOrderRequestFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PhysiotherapyOrderRequestFormViewModel, Core';

    @Type(() => PhysiotherapyOrder)
    public _PhysiotherapyOrder: PhysiotherapyOrder = new PhysiotherapyOrder();

    @Type(() => PhysiotherapyReports)
    public PhysiotherapyReportss: Array<PhysiotherapyReports> = new Array<PhysiotherapyReports>();

    @Type(() => FTRVucutBolgesi)
    public FTRVucutBolgesis: Array<FTRVucutBolgesi> = new Array<FTRVucutBolgesi>();

    @Type(() => PhysiotherapyDefinition)
    public PhysiotherapyDefinitions: Array<PhysiotherapyDefinition> = new Array<PhysiotherapyDefinition>();

    @Type(() => ResTreatmentDiagnosisUnit)
    public ResTreatmentDiagnosisUnits: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();

    public MedicalInfo: string;
    public Message: string;

    @Type(() => ReportItem)
    public ReportItemList: Array<ReportItem>;

    @Type(() => PhysiotherapyRequest)
    public _physiotherapyRequestObj: PhysiotherapyRequest;

    public _physiotherapyRequestId: string;

    @Type(() => ResTreatmentDiagnosisUnit)
    public ResTreatmentDiagnosisUnitList: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();

    @Type(() => PhysiotherapyDefinition)
    public _PhysiotherapyDefinitionList: Array<PhysiotherapyDefinition> = new Array<PhysiotherapyDefinition>();

    @Type(() => FTRVucutBolgesi)
    public FTRVucutBolgesiList: Array<FTRVucutBolgesi> = new Array<FTRVucutBolgesi>();


    @Type(() => TreatmentDiagnosisInfo)
    public TreatmentDiagnosisInfoList: Array<TreatmentDiagnosisInfo> = new Array<TreatmentDiagnosisInfo>();

    @Type(() => PhysiotherapyOrderInfo)
    public PhysiotherapyOrderList: Array<PhysiotherapyOrderInfo> = new Array<PhysiotherapyOrderInfo>();

    @Type(() => Date)
    public _physiotherapyRequestDate: Date;

    public MetalImplant: boolean;
    public Pregnancy: boolean;
    public MetalImplantDescription: string;
    public createTemplate: boolean = false;
    @Type(() => UserTemplateModel)
    public savedUserTemplate: UserTemplateModel;
    @Type(() => UserTemplateModel)
    public userTemplateList : Array<UserTemplateModel> = new Array<UserTemplateModel>();
    @Type(() => UserTemplateModel)
    public selectedUserTemplate : UserTemplateModel;

}
export class TreatmentDiagnosisInfo {

    @Type(() => ResTreatmentDiagnosisUnit)
    public TreatmentDiagnosisUnit: ResTreatmentDiagnosisUnit;

    public TreatmentDiagnosisUnitName: string;

    @Type(() => Guid)
    public TreatmentDiagnosisUnitId: Guid;

    @Type(() => ProcedureDefinitionList)
    public ProcedureDefinitionList: Array<ProcedureDefinitionList> = new Array<ProcedureDefinitionList>();
}
export class ProcedureDefinitionList {

    @Type(() => ProcedureDefinition)
    public ProcedureDefinition: ProcedureDefinition;

    public ProcedureDefinitionName: string;
    public isRequested: boolean;
    public Color: any;
}

export class PhysiotherapyOrderComponentInfoViewModel {

    @Type(() => DynamicComponentInfo)
    public physiotherapyOrderComponentInfo: DynamicComponentInfo;

    @Type(() => QueryParams)
    public physiotherapyOrderQueryParameters: QueryParams;
}

export class ReportItem {

    @Type(() => PhysiotherapyReports)
    public ReportObj: PhysiotherapyReports;

    @Type(() => FTRVucutBolgesi)
    public FTRApplicationAreaDef: FTRVucutBolgesi;

    public ReportNo: string;
    public ReportDate: string;
    public ReportStartDate: string;
    public ReportEndDate: string;
    public ApplicationArea: string;
    public ReportType: string;
    public ReportInfo: string;
    public ReportTime: string;
    public TreatmentType: string;
    public DiagnosisGroup: string;
}

export class PhysiotherapyOrderInfo {

    public TreatmentDiagnosisUnit: string;
    public ApplicationArea: string;
    public ApplicationAreaInfo: string;
    public ProcedureObject: string;
    public SessionCount: string;
    public Duration: string;
    public Dose: string;
    public TreatmentProperties: string;
    public IsPlannedBefore: boolean;

    @Type(() => Guid)
    public CurrentStateDefID: Guid;

    @Type(() => Guid)
    public OrderObjectId: Guid;

    @Type(() => Guid)
    public OrderObjectDefId: Guid;

    public IsNewOrder: boolean;

    @Type(() => PhysiotherapyOrder)
    public PhysiotherapyOrderObj: PhysiotherapyOrder;

    public isTemplateOrder: boolean;
}