//$19EE46B4
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { IntensiveCareSpecialityObj } from "NebulaClient/Model/AtlasClientModel";
import { PhysicianApplication } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { SKRSDurum } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { MultipleDataComponent_SummaryInfo } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseMultipleDataEntryFormViewModel";

export class IntensiveCareSpecialityObjFormViewModel extends BaseViewModel {//Uzmanl�k i�in Baseviewmodel
    protected __type__: string = 'Core.Models.IntensiveCareSpecialityObjFormViewModel, Core';
    @Type(() => IntensiveCareSpecialityObj)
    public _IntensiveCareSpecialityObj: IntensiveCareSpecialityObj = new IntensiveCareSpecialityObj();

    @Type(() => PhysicianApplication)
    public physicianApplication: PhysicianApplication;

    @Type(() => MultipleDataComponent_SummaryInfo)
    public ApacheScoreSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public SapScoreSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public GlaskowScoreSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public ApgarScoreSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public BallardNeuromuscularScoreSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public BallardPhysicalScoreSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public GeneralInformationSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public PhototherapySummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public SnappeIIScoreSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public WeightChartSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();
    @Type(() => MultipleDataComponent_SummaryInfo)
    public PrismSummaryInfoList: Array<MultipleDataComponent_SummaryInfo> = new Array<MultipleDataComponent_SummaryInfo>();


    @Type(() => SKRSDurum)
    public SKRSDurums: Array<SKRSDurum> = new Array<SKRSDurum>();

    @Type(() => Guid)
    public InPatientTreatmentClinicObjectId: Guid;
    public InPatientTreatmentClinicObjectDef: string;

    @Type(() => Guid)
    public episodeActionId: Guid;
    @Type(() => Guid)
    public episodeId: Guid;
    @Type(() => Guid)
    public patientId: Guid;

    public newbornIntensiveObjectId: string;
}
