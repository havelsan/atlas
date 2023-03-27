//$92D04909
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { WomanSpecialityObject } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyComplications } from 'NebulaClient/Model/AtlasClientModel';
import { ObligedRiskFactors } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyDangerSign } from 'NebulaClient/Model/AtlasClientModel';
import { FetusFollow } from 'NebulaClient/Model/AtlasClientModel';
import { PregnancyFollow } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikteRiskFaktorleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikBildirimiZorunluRiskFaktorleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSGebelikLohusalikSeyrindeTehlikeIsareti } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKacinciGebeIzlem } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKadinSagligiIslemleri } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSKonjenitalAnomaliliDogumVarligi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSIdrardaProtein } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDVitaminiLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSDemirLojistigiveDestegi } from 'NebulaClient/Model/AtlasClientModel';
import { Infertility } from 'NebulaClient/Model/AtlasClientModel';
import { Gynecology } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

import { InfertilityPatientInformation } from 'NebulaClient/Model/AtlasClientModel';

export class OldWomanSpecialityFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldWomanSpecialityFormViewModel, Core';

    @Type(() => WomanSpecialityObject)
    public _WomanSpecialityObject: WomanSpecialityObject = new WomanSpecialityObject();

    @Type(() => PregnancyComplications)
    public PregnancyComplicationsGridList: Array<PregnancyComplications> = new Array<PregnancyComplications>();

    @Type(() => ObligedRiskFactors)
    public ObligedRiskFactorsGridList: Array<ObligedRiskFactors> = new Array<ObligedRiskFactors>();

    @Type(() => PregnancyDangerSign)
    public PregnancyDangerSignGridList: Array<PregnancyDangerSign> = new Array<PregnancyDangerSign>();

    @Type(() => FetusFollow)
    public FetusFollowGridList: Array<FetusFollow> = new Array<FetusFollow>();

    @Type(() => PregnancyFollow)
    public PregnancyFollows: Array<PregnancyFollow> = new Array<PregnancyFollow>();
    public SKRSGebelikteRiskFaktorleris: Array<SKRSGebelikteRiskFaktorleri> = new Array<SKRSGebelikteRiskFaktorleri>();
    public SKRSGebelikBildirimiZorunluRiskFaktorleris: Array<SKRSGebelikBildirimiZorunluRiskFaktorleri> = new Array<SKRSGebelikBildirimiZorunluRiskFaktorleri>();
    public SKRSGebelikLohusalikSeyrindeTehlikeIsaretis: Array<SKRSGebelikLohusalikSeyrindeTehlikeIsareti> = new Array<SKRSGebelikLohusalikSeyrindeTehlikeIsareti>();
    public SKRSKacinciGebeIzlems: Array<SKRSKacinciGebeIzlem> = new Array<SKRSKacinciGebeIzlem>();
    public SKRSKadinSagligiIslemleris: Array<SKRSKadinSagligiIslemleri> = new Array<SKRSKadinSagligiIslemleri>();
    public SKRSKonjenitalAnomaliliDogumVarligis: Array<SKRSKonjenitalAnomaliliDogumVarligi> = new Array<SKRSKonjenitalAnomaliliDogumVarligi>();
    public SKRSIdrardaProteins: Array<SKRSIdrardaProtein> = new Array<SKRSIdrardaProtein>();
    public SKRSDVitaminiLojistigiveDestegis: Array<SKRSDVitaminiLojistigiveDestegi> = new Array<SKRSDVitaminiLojistigiveDestegi>();
    public SKRSDemirLojistigiveDestegis: Array<SKRSDemirLojistigiveDestegi> = new Array<SKRSDemirLojistigiveDestegi>();

    @Type(() => Infertility)
    public Infertilitys: Array<Infertility> = new Array<Infertility>();

    @Type(() => Gynecology)
    public Gynecologys: Array<Gynecology> = new Array<Gynecology>();

    @Type(() => InfertilityPatientInformation)
    public _InfertilityPatientInformation: InfertilityPatientInformation = new InfertilityPatientInformation();

    public BloodGroup: string;
    public HusbandBloodGroup: string;
    public DegreeOfRelationship: string;
    public RhIncompatibility: string;
    public PreviousBirthControlMethod: string;
    public CurrentBirthControlMethod: string;
    public GenitalAbnormalities: string;
    public MenstrualCycleAbnormalities: string;
    public ReproductiveAbnormality: string;
    public Dysuria: string;
    public Dyspareunia: string;
    public Hirsutism: string;
    public VaginalDischarge: string;
    public PregnancyDiseases: string;
}

