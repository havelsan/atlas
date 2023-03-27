import { Type } from 'NebulaClient/ClassTransformer';
import { LaboratoryWorkListItemDetailModel } from './LaboratoryWorkListFormViewModel';

export class SampleAcceptBarcodeModel {
    @Type(() => LaboratoryWorkListItemDetailModel)
    public LaboratoryProcedureList: Array<LaboratoryWorkListItemDetailModel> = new Array<LaboratoryWorkListItemDetailModel>();
    public LabRequestObjectID: string;
    public LastReadedBarcode: string;
    public IsTransitionMade: boolean;
}