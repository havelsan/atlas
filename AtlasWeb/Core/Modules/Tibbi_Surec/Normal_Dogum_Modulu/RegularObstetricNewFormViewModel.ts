//$629789E0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { RegularObstetric, PregnantInformation, IndicationReason, SKRSEndikasyonNedenleri } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { SubActionProcedure } from "NebulaClient/Model/AtlasClientModel";
import { RegularObstetricPersonel } from "NebulaClient/Model/AtlasClientModel";
import { BaseTreatmentMaterial } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { Pregnancy } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDogumunGerceklestigiYer } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGebelikAraligi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGebelikSonucu } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { MalzemeTuru } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';


import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { BabyInformationFormViewModel } from "Modules/Tibbi_Surec/Normal_Dogum_Modulu/BabyInformationFormViewModel";

export class RegularObstetricNewFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.RegularObstetricNewFormViewModel, Core';

    @Type(() => RegularObstetric)
    public _RegularObstetric: RegularObstetric = new RegularObstetric();


    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();


    @Type(() => SubActionProcedure)
    public GridManipulationsGridList: Array<SubActionProcedure> = new Array<SubActionProcedure>();


    @Type(() => RegularObstetricPersonel)
    public GridPersonnelGridList: Array<RegularObstetricPersonel> = new Array<RegularObstetricPersonel>();


    @Type(() => BaseTreatmentMaterial)
    public GridTreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();


    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();


    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();


    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();


    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();


    @Type(() => Pregnancy)
    public Pregnancys: Array<Pregnancy> = new Array<Pregnancy>();

    @Type(() => SKRSDogumunGerceklestigiYer)
    public SKRSDogumunGerceklestigiYers: Array<SKRSDogumunGerceklestigiYer> = new Array<SKRSDogumunGerceklestigiYer>();


    @Type(() => SKRSGebelikAraligi)
    public SKRSGebelikAraligis: Array<SKRSGebelikAraligi> = new Array<SKRSGebelikAraligi>();


    @Type(() => SKRSGebelikSonucu)
    public SKRSGebelikSonucus: Array<SKRSGebelikSonucu> = new Array<SKRSGebelikSonucu>();


    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();


    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();


    @Type(() => MalzemeTuru)
    public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();

    public IsPregnancyEnded: boolean;

    @Type(() => BabyInfo)
    public BabyInfoList: Array<BabyInfo>;

    @Type(() => PreviousPregnancyInfo)
    public PreviousPregnancyInfo: PreviousPregnancyInfo;

    @Type(() => PregnantInformation)
    public PregnantInfo: PregnantInformation;

    public NumberofNewborns: number;
    public NumberOfStillbornBabies: number;
    public MotherName: string;
    public InpatientDate: Date;
    public MaritalStatus: string;
    public MotherAge: number;
    public Address: string;
    @Type('IndicationReason')
    public IndicationReasons: Array<IndicationReason>;

    @Type(() => IndicationReason)
    public IndicationReasonsGridList: Array<IndicationReason> = new Array<IndicationReason>();


    @Type(() => SKRSEndikasyonNedenleri)
    public SKRSEndikasyonNedenleri: Array<SKRSEndikasyonNedenleri> = new Array<SKRSEndikasyonNedenleri>();
}

export class BabyInfo {
    @Type(() => Guid)
    public objectId: Guid;

    public objectDefName: string;

    public summary: string;

    @Type(() => BabyInformationFormViewModel)
    public _babyInformationFormViewModel: BabyInformationFormViewModel;
}

export class PreviousPregnancyInfo {
    public NumberOfPregnancy: number;
    public Parity: number;
    public Abortion: number;
    public LivingBabies: number;
    public DC: number;
}