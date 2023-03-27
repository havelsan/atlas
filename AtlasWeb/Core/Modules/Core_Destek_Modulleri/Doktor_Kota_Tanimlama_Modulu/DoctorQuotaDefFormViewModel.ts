//$C0A4A319
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DoctorQuotaDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResPoliclinic } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class DoctorQuotaDefFormViewModel extends BaseViewModel {
    @Type(() => DoctorQuotaDefinition)
    public _DoctorQuotaDefinition: DoctorQuotaDefinition = new DoctorQuotaDefinition();
    @Type(() => ResPoliclinic)
    public ResPoliclinics: Array<ResPoliclinic> = new Array<ResPoliclinic>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();

    @Type(() => Boolean)
    public isPersonnelDoctor: boolean;

    public PoliclinicObjectIDs: string = "";

}
