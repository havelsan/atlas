//$C5106DB1
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseAdditionalInfoFormViewModel extends BaseViewModel {
    //public _BaseAdditionalInfoForm: BaseAdditionalInfoForm = new BaseAdditionalInfoForm();
    public _BaseAdditionalInfoForm: any;
    public patientName: string;
    public resDoctorName: string;
    public resUserName: string;
    @Type(() => Guid)
    public SubActionProcedureObjectId: Guid;
    public RequestDate: Date;
    public SubEpisodeOpeningDate: Date;
    public SubEpisodeClosingDate: Date;
    public ClosingDate: Date;

}
