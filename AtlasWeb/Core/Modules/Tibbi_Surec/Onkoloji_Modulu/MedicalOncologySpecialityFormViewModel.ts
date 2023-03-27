//$8B8C521B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MedicalOncology, Patient, ResUser, ChemotherapyRadiotherapy } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";

export class MedicalOncologySpecialityFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.MedicalOncologySpecialityFormViewModel, Core';

    @Type(() => MedicalOncology)
    public _MedicalOncology: MedicalOncology = new MedicalOncology();
    
    @Type(() => Patient)
    public _Patient: Patient = new Patient();

    public actionId: string;
    public BMIValue : number;
    public DiagnoseDate: Date;
    @Type(() => UserTemplateModel)
    public userTemplateList: Array<UserTemplateModel> = new Array<UserTemplateModel>();
    public hasDiagnosis: boolean;
    public hasChemoRadioRequest: boolean;
}

export class OncologyGridResultModel {
    @Type(() => MedicalOncology)
    public OncologyObject : MedicalOncology = new MedicalOncology();

    @Type(() => ResUser)
    public Doctor: ResUser = new ResUser();

    public Date : Date;
    public ObjectID : Guid;
    public BMIValue : number;
    public FirstLineTreatment 
    public  SecondLineTreatment : string;
    public  PreTreatmentStaging : string;
    public  InterimEvaluation : string;
    public  Story : string;
    public  Pathology : string;
    public  Description : string;
    public  PS : string;
    public  TA : string;
    public  NB : string;
    public  M2 : string;
    public  PhysicianApplicationId : string;
}

export class ChemotherapyRadiotherapyRequestResponse {
    @Type(() => ChemotherapyRadiotherapy)
    public chemotherapyRadiotherapy: ChemotherapyRadiotherapy;
    public IsSuccess: boolean;
}
