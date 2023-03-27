//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { OrderTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
export class NursingWorkListViewModel extends BaseModel {
    @Type(() => OutputResource)
    output: OutputResource;
    @Type(() => OutputDrugOrderDetail)
    output_drugOrderDetails: OutputDrugOrderDetail;
    @Type(() => PatientItem)
    patients: Array<PatientItem>;
    @Type(() => StatusItem)
    statusList: Array<StatusItem>;
    toolOption: boolean;

    @Type(() => OutputCaseOFNeedDrugOrder)
    output_caseOfNeedDrugOrder: OutputCaseOFNeedDrugOrder;

    ksMaterialNote: string;
    pharmcyOpen: boolean;
}

export class OutputResource {
    public resources: Array<Resource>;
    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
}

export class OutputDrugOrderDetail {
    @Type(() => DrugOrderDetailOutputItem)
    public drugOrderDetails: DrugOrderDetailOutputItem[];
}

export class OutputCaseOFNeedDrugOrder {
    @Type(() => CostomDrugOrder)
    public caseOfNeedDrugOrders: CostomDrugOrder[];
}

export class CostomDrugOrder {
    public objectId: string;
    public PatientName: string;
    public DrugName: string;
    public DrugBarcode: string;
    public MasterResourceName: string;
    public DoseAmount: string;
    @Type(() => Date)
    public PlannedDateTime: Date;
}


export class DrugOrderDetailOutputItem {
    @Type(() => Guid)
    public id: Guid;
    @Type(() => Guid)
    public stateDefID: Guid;
    public text: string;
    public typeId: OrderTypeEnum;
    public typeName: string;
    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
    public statusName: string;
    @Type(() => Date)
    public periodStartTime: Date;
    @Type(() => Boolean)
    public isChanged: boolean;
    public doctorDescription: string;
    @Type(() => Boolean)
    public allDay: boolean;
    public Result: string;
    public StateID: string;
    public PatientFullName: string;
    public MasterResourceName: string;
    public BackColorName: string;
}

export class InputFor_Get_DrugOrderDetails {
    @Type(() => Date)
    public start_Time: Date;
    @Type(() => Date)
    public end_Time: Date;
    @Type(() => Guid)
    public MasterResourcesList: Guid[];
    @Type(() => Number)
    public typeID: number;
    @Type(() => Boolean)
    public justMyPatient: boolean;
}
export class InputFor_StateUpdateForSelecetedItem {
    @Type(() => Guid)
    public DrugOrderDetails: Array<Guid>;
}

export class PatientItem {
    @Type(() => Guid)
    ObjectID: Guid;
    PatientFullName: string;
    PatientUniqueRefNo: string;
}
export class StatusItem {
    @Type(() => Guid)
    StateID: Guid;
    StatusItemName: string;
    TypeID: number;

}
