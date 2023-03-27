
//$10272D41
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { TreatmentDischarge } from 'NebulaClient/Model/AtlasClientModel';
import { DischargeTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser, SKRSCikisSekli } from 'NebulaClient/Model/AtlasClientModel';
import { ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';
import { MorgueExDischargeFormViewModel } from '../Morg_Modulu/MorgueExDischargeFormViewModel';
import { DispatchToOtherHospitalFormViewModel } from "Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalFormViewModel";
import { GetReturnableDrugOrders_Output } from "app/NebulaClient/Services/ObjectService/DrugReturnActionService";

export class TreatmentDischargeFormViewModel extends BaseViewModel {
    @Type(() => TreatmentDischarge)
    public _TreatmentDischarge: TreatmentDischarge = new TreatmentDischarge();
    @Type(() => ResClinic)
    public ResClinics: Array<ResClinic> = new Array<ResClinic>();
    @Type(() => DischargeTypeDefinition)
   public DischargeTypeDefinitions: Array<DischargeTypeDefinition> = new Array<DischargeTypeDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();

    @Type(() => TreatmentDischargeProblemViewModel)
    public TreatmentDischargeProblemList: Array<TreatmentDischargeProblemViewModel> = new Array<TreatmentDischargeProblemViewModel>();
    @Type(() => Boolean)
    public IsAllRequiredProblemsOk: boolean;
    @Type(() => Boolean)
    public isSGKSubEpisode: boolean;

    public ProcedureDoctorFilterExpression: string;
    @Type(() => DischargeTypeDefinition)
    public TransferToOtherClinicDischargeTypeDefinition: DischargeTypeDefinition;
    @Type(() => DischargeTypeDefinition)
    public TransferToOtherHospitalDischargeTypeDefinition: DischargeTypeDefinition;
    public DischargeTypeFilterExpression: string;
    //Eklendi
    @Type(() => Date)
    public ClinicInpatientDate: Date;
    public MasterActionObjectDefName: string;
    @Type(() => MorgueExDischargeFormViewModel)
    public _MorgueViewModel: MorgueExDischargeFormViewModel;
    @Type(() => SKRSCikisSekli)
    public SKRSCikisSeklis: Array<SKRSCikisSekli> = new Array<SKRSCikisSekli>();
    public HasMorgue: boolean;
    @Type(() => DischargeTypeDefinition)
    public DeathDefinition: DischargeTypeDefinition = new DischargeTypeDefinition();
    @Type(() => DispatchToOtherHospitalFormViewModel)
    public _DispatchToOtherHospitalFormViewModel: DispatchToOtherHospitalFormViewModel;

    public advanceToDischarge: boolean = false;
    public SubepisodeID: string;
    public ProcedureDoctorObjectIDForOBS: string;


}

export class TreatmentDischargeProblemViewModel {
    public ProblemString: string;
    @Type(() => Boolean)
    public IsOk: boolean;
    @Type(() => Boolean)
    public IsRequired: boolean;
    @Type(() => Guid)
    public ObjectId: Guid;
    public ObjectDefName: string;
    @Type(() => Guid)
    public FormDefId: Guid;
    public problemDrugOrders: Array<GetReturnableDrugOrders_Output> = new Array<GetReturnableDrugOrders_Output>();
}
export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
    @Type(() => Guid)
    public episodeObjectID: Guid;
    @Type(() => Guid)
    public patientObjectID: Guid;

}

export class TreatmentDischargeDefaultActionViewModel {

    @Type(() => Guid)
    public ObjectId: Guid;
    public ObjectDefName: string;
    public ApplicationName: string;
    @Type(() => Guid)
    public FormDefId: Guid;
    public InputParam: any;
}

