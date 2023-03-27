//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { ResUser, ResSection, UserOptionType, ResSterilizationDevice} from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';

export class TeletipWorkListViewModel extends BaseModel {
    @Type(() => OrderStatusForAccessionNumber_Output)
    teletipActionList: Array<OrderStatusForAccessionNumber_Output> = new Array<OrderStatusForAccessionNumber_Output>();
    _teletipWorkListSearchCriteria: TeletipWorkListSearchCriteria = new TeletipWorkListSearchCriteria();
}

export class TeletipWorkListSearchCriteria {

    public uniqueRefNo: string;

    public accessionno: string;
    @Type(()=> Date)
    public workListStartDate:Date;
    @Type(()=> Date)
    public workListEndDate:Date;    
    constructor() {
    }

}

export class OrderStatusForAccessionNumber_Output {
    public AccessionNumber: string;
    public CitizenId: string;
    public TeletipStatus: string;
    public TeletipStatusId: string;
    public WadoStatus: string;
    public WadoStatusId: string;
    public MedulaStatus: string;
    public MedulaStatusId: string;
    public MedulaInstitutionId: string;
    public SutCode: string;
    public LastMedulaSendDate: string;
    public MedulaResponseCode: string;
    public MedulaResponseMessage: string;
    public ReportStatus: string;
    public ReportStatusId: string;
    public ScheduleDate: string;
    public PerformedDate: string;
    public Error: string;
    public PatientHistorySearchStatus: string;
    public PatientHistorySearchStatusId: string;
}