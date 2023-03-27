//$46694929
import { WomanSpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { Gynecology } from 'NebulaClient/Model/AtlasClientModel';
import { ReproductiveAbnormalityDefinition } from 'NebulaClient/Model/AtlasClientModel';

import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';

import { InfertilityFormViewModel } from "./InfertilityFormViewModel";
import { InfertilityPatientInformationFormViewModel } from "./InfertilityPatientInformationFormViewModel";
import { PregnancyStartFormViewModel } from "./PregnancyStartFormViewModel";
import { PreviousPregnancyFormViewModel } from "./PreviousPregnancyFormViewModel";
import { PregnancyFollowFormViewModel } from "./PregnancyFollowFormViewModel";
import { PregnancyResultFormViewModel } from "./PregnancyResultFormViewModel";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';
import { GebelikBildirim } from '../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel';
import { PostpartumFollowUpFormViewModel } from './PostpartumFollowUpFormViewModel';

export class WomanSpecialityFormViewModel extends BaseModel {
    protected __type__: string = 'Core.Models.WomanSpecialityFormViewModel, Core';

    @Type(() => WomanSpecialityObject)
    public _WomanSpecialityObject: WomanSpecialityObject = new WomanSpecialityObject();

    @Type(() => Gynecology)
    public Gynecologys: Array<Gynecology> = new Array<Gynecology>();

    public ReproductiveAbnormalityDefinitions: Array<ReproductiveAbnormalityDefinition> = new Array<ReproductiveAbnormalityDefinition>();

    @Type(() => Patient)
    public _Patient: Patient = new Patient();

    @Type(() => InfertilityFormViewModel)
    public _InfertilityFormViewModel: InfertilityFormViewModel;

    @Type(() => InfertilityPatientInformationFormViewModel)
    public _InfertilityPatientInformationFormViewModel: InfertilityPatientInformationFormViewModel;

    @Type(() => PregnancyStartFormViewModel)
    public _PregnancyStartFormViewModel: PregnancyStartFormViewModel;

    @Type(() => PreviousPregnancyFormViewModel)
    public _PreviousPregnancyFormViewModel: PreviousPregnancyFormViewModel;

    @Type(() => PregnancyFollowFormViewModel)
    public _PregnancyFollowFormViewModel: PregnancyFollowFormViewModel;

    @Type(() => PregnancyResultFormViewModel)
    public _PregnancyResultFormViewModel: PregnancyResultFormViewModel;

    public _IsPregnancyStarted: boolean;
    public PregnancyCalendarDefList: Array<PregnancyCalendarDefinitionDVO>;
    public PregnancyWeek: number;
    public showPregnancyStartPopup:boolean;

    @Type(() => GebelikBildirim)
    public _GebelikBildirimViewModel: Array<GebelikBildirim>;

    @Type(() => PostpartumFollowUpFormViewModel)
    public _PostpartumFollowUpFormViewModel: PostpartumFollowUpFormViewModel;
}
export class PregnancyCalendarDefinitionDVO {
    public StartDate: number;
    public FinishDate: number;
    public PeriodName: string;
    public PregnancyType: PregnancyTypeEnum;
    public CalculatedStartDate: Date;
    public CalculatedFinishDate: Date;
}

export class WomanSpecialityObjectInfo {
    public WomanSpecialityObject: WomanSpecialityObject;
    public ActiveIDsModel: ActiveIDsModel;
}
