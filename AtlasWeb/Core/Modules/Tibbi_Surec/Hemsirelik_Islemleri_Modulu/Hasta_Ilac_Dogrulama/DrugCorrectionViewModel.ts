//$DB89F690
import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class DrugCorrectionViewModel extends BaseModel {

}

export class PatientInfo {
    public patientObjectID: string;
    public patientRefNo: string;
    public patientName: string;
    public inpatientClinicName: string;
    public DrugOrderInfoList: DrugOrderInfo[];

    public physicalStateClinic: string;
    public roomGroup: string;
    public room: string;
    public bed: string;
    public admissionDoctor: string;

}

export class DrugOrderInfo {
    public objectID: string;
    public stateDefID: string;
    public MaterialName: string;
    public MaterialBarcode: string;
    public Amount: string;
    public DrugCounter: number;
    @Type(() => Date)
    public OrderPlannedDatetime: string;
    public DrugUsageType: string;
    public ExpirationDatetime: string;
    public IsItInTheTimeInterval: boolean;
    public drugType: boolean;
    public drugDone: boolean;
}


export class OutputFor_ApplyTheDrugOrderDetail {
    public processCompleted: boolean;
    public resultMessage: string;
    public updatedDrugOrder: DrugOrderInfo;
}