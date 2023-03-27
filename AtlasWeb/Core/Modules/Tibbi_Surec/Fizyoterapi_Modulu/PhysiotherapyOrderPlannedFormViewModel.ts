//$D7498803
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyOrder, TreatmentQueryReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyOrderDetail } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyReports } from 'NebulaClient/Model/AtlasClientModel';
import { FTRVucutBolgesi } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyRequest } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResTreatmentDiagnosisRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResTreatmentDiagnosisUnit } from 'NebulaClient/Model/AtlasClientModel';

import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';

import { Type, Exclude } from 'NebulaClient/ClassTransformer';
import { PackageProcedureDefinition, ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class PhysiotherapyOrderPlannedFormViewModel extends BaseViewModel {

    @Type(() => PhysiotherapyOrder)
    public _PhysiotherapyOrder: PhysiotherapyOrder = new PhysiotherapyOrder();

    @Type(() => PhysiotherapyOrderDetail)
    public PhysiotherapyOrderDetailsGridList: Array<PhysiotherapyOrderDetail> = new Array<PhysiotherapyOrderDetail>();

    @Type(() => PackageProcedureDefinition)
    public PackageProcedureDefinitions: Array<PackageProcedureDefinition> = new Array<PackageProcedureDefinition>();

    @Type(() => PhysiotherapyReports)
    public PhysiotherapyReportss: Array<PhysiotherapyReports> = new Array<PhysiotherapyReports>();

    @Type(() => FTRVucutBolgesi)
    public FTRVucutBolgesis: Array<FTRVucutBolgesi> = new Array<FTRVucutBolgesi>();

    @Type(() => PhysiotherapyRequest)
    public PhysiotherapyRequests: Array<PhysiotherapyRequest> = new Array<PhysiotherapyRequest>();

    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();

    @Type(() => PhysiotherapyDefinition)
    public PhysiotherapyDefinitions: Array<PhysiotherapyDefinition> = new Array<PhysiotherapyDefinition>();

    @Type(() => ResTreatmentDiagnosisRoom)
    public ResTreatmentDiagnosisRooms: Array<ResTreatmentDiagnosisRoom> = new Array<ResTreatmentDiagnosisRoom>();

    @Type(() => ResTreatmentDiagnosisUnit)
    public ResTreatmentDiagnosisUnits: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();

    public daySelectionActive: boolean;

    public Message: string;

    @Type(() => ReportItem)
    public ReportItemList: Array<ReportItem>;

    public IsPhysiotherapyRequestFormUsing: boolean;
    public IsAdditionalProcess: boolean;

    public startDate: Date;
    public endDate: Date;
    public IsReadOnlyFields: boolean;
    public IsPaymentObject: boolean;

    // NOT: Burasi sunucudan gelmeyecek �stteki ViewModel'den geliyor
    @Exclude()
    public ProcedureObjectDataSource: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();

    public ProcedureObjectList: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();

    public IsReportExistsAndCalculateDetail: boolean;

    public IsSGKPatient: boolean; //�cretli hasta m�?

    public IsMedulaNotWorking: boolean; //Medulas�z Rapor Sorgulamak i�in! true ise medula �al��m�yor

    @Type(() => PhysiotherapyReports)
    public ReportList: Array<PhysiotherapyReports>;

    @Type(() => Date)
    public _physiotherapyRequestDate: Date;
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

    @Type(() => PackageProcedureDefinition)
    public PackageProcedureDefinition: PackageProcedureDefinition;
}
export class ReportTypeWithEpisodeId {
    public treatmentType: TreatmentQueryReportTypeEnum;
    @Type(() => Guid)
    public activeEpisodeObjectID: Guid;
}