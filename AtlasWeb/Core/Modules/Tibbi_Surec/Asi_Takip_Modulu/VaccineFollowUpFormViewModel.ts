//$6403536C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { VaccineFollowUp } from 'NebulaClient/Model/AtlasClientModel';
import { VaccineDetails } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { SKRSAsiKodu } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

export class VaccineFollowUpFormViewModel extends BaseViewModel  {
    @Type(() => VaccineFollowUp)
    public _VaccineFollowUp: VaccineFollowUp = new VaccineFollowUp();
    public PatientID: Guid;
    @Type(() => VaccineDetails)
    public VaccineDetailsGridList: Array<VaccineDetails> = new Array<VaccineDetails>();
}

export class VaccineDefinitionsModel
{
    public ObjectID: Guid;
    public VaccineCode: string;
    public VaccineName: string;
    public StartDate: Date;
    public AsiKoduSKRS: SKRSAsiKodu;
    public VaccinePeriodList: Array<VaccinePeriodDefinitionsModel> = new Array<VaccinePeriodDefinitionsModel>();
    constructor() {
        this.VaccinePeriodList = new Array<VaccinePeriodDefinitionsModel>();
    }

}
export class VaccinePeriodDefinitionsModel
{
    public PeriodNo: number; //Ka��nc� Periyod oldu�u
    public PeriodName: string;
    public Period: number; //Periyod S�resi
    public PeriodUnit: PeriodUnitTypeEnum;
    public AppointmentDate: Date;

}

export class ConfirmObj {
    public Result: boolean = true;
    public Message: string = "";
}

export class LoginUserInfo
{
    public UserInfo: ResUser = new ResUser();
    public IsDoctor: boolean;
    public IsNurse: boolean;
}

