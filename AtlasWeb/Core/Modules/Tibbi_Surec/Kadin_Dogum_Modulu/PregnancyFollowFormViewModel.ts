//$8F5C479B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PregnancyFollow } from "NebulaClient/Model/AtlasClientModel";
import { FetusFollow } from "NebulaClient/Model/AtlasClientModel";
import { PregnancyDangerSign } from "NebulaClient/Model/AtlasClientModel";
import { ObligedRiskFactors } from "NebulaClient/Model/AtlasClientModel";
import { PregnancyComplications } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGestasyonelDiyabetTaramasi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKadinSagligiIslemleri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKonjenitalAnomaliliDogumVarligi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSIdrardaProtein } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGebelikLohusalikSeyrindeTehlikeIsareti } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGebelikBildirimiZorunluRiskFaktorleri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGebelikteRiskFaktorleri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDVitaminiLojistigiveDestegi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDemirLojistigiveDestegi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKacinciGebeIzlem } from "NebulaClient/Model/AtlasClientModel";

import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class PregnancyFollowFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PregnancyFollowFormViewModel, Core';

    @Type(() => PregnancyFollow)
    public _PregnancyFollow: PregnancyFollow = new PregnancyFollow();

    @Type(() => FetusFollow)
    public FetusFollowGridList: Array<FetusFollow> = new Array<FetusFollow>();

    @Type(() => PregnancyDangerSign)
    public PregnancyDangerSignGridList: Array<PregnancyDangerSign> = new Array<PregnancyDangerSign>();

    @Type(() => ObligedRiskFactors)
    public ObligedRiskFactorsGridList: Array<ObligedRiskFactors> = new Array<ObligedRiskFactors>();

    @Type(() => PregnancyComplications)
    public PregnancyComplicationsGridList: Array<PregnancyComplications> = new Array<PregnancyComplications>();

    @Type(() => SKRSKadinSagligiIslemleri)
    public SKRSKadinSagligiIslemleris: Array<SKRSKadinSagligiIslemleri> = new Array<SKRSKadinSagligiIslemleri>();

    @Type(() => SKRSKonjenitalAnomaliliDogumVarligi)
    public SKRSKonjenitalAnomaliliDogumVarligis: Array<SKRSKonjenitalAnomaliliDogumVarligi> = new Array<SKRSKonjenitalAnomaliliDogumVarligi>();

    @Type(() => SKRSIdrardaProtein)
    public SKRSIdrardaProteins: Array<SKRSIdrardaProtein> = new Array<SKRSIdrardaProtein>();

    @Type(() => SKRSGebelikLohusalikSeyrindeTehlikeIsareti)
    public SKRSGebelikLohusalikSeyrindeTehlikeIsaretis: Array<SKRSGebelikLohusalikSeyrindeTehlikeIsareti> = new Array<SKRSGebelikLohusalikSeyrindeTehlikeIsareti>();

    @Type(() => SKRSGebelikBildirimiZorunluRiskFaktorleri)
    public SKRSGebelikBildirimiZorunluRiskFaktorleris: Array<SKRSGebelikBildirimiZorunluRiskFaktorleri> = new Array<SKRSGebelikBildirimiZorunluRiskFaktorleri>();

    @Type(() => SKRSGebelikteRiskFaktorleri)
    public SKRSGebelikteRiskFaktorleris: Array<SKRSGebelikteRiskFaktorleri> = new Array<SKRSGebelikteRiskFaktorleri>();

    @Type(() => SKRSDVitaminiLojistigiveDestegi)
    public SKRSDVitaminiLojistigiveDestegis: Array<SKRSDVitaminiLojistigiveDestegi> = new Array<SKRSDVitaminiLojistigiveDestegi>();

    @Type(() => SKRSDemirLojistigiveDestegi)
    public SKRSDemirLojistigiveDestegis: Array<SKRSDemirLojistigiveDestegi> = new Array<SKRSDemirLojistigiveDestegi>();

    @Type(() => SKRSKacinciGebeIzlem)
    public SKRSKacinciGebeIzlems: Array<SKRSKacinciGebeIzlem> = new Array<SKRSKacinciGebeIzlem>();

    @Type(() => FetusFollowDefinitionDVO)
    public FetusFollowDefList: Array<FetusFollowDefinitionDVO>;

    @Type(() => PregnancyFollowGrid)
    public OldPregnancyFollowGridList: Array<PregnancyFollowGrid>;

    @Type(() => Date)
    public LastMenstrualPeriod: Date;

    public InformerName: string;

    public InformerPhone: string;
    
    @Type(() => SKRSGestasyonelDiyabetTaramasi)
    public SKRSGestasyonelDiyabetTaramasis: Array<SKRSGestasyonelDiyabetTaramasi> = new Array<SKRSGestasyonelDiyabetTaramasi>();
}

export class FetusFollowDefinitionDVO {
    public PregnancyWeek: number;
    public Length: number;
    public Weight: number;
    public BiparietalDiameter: number;
    public HeadCircumference: number;
    public AbdominalCircumference: number;
    public FemurLength: number;
}

export class PregnancyFollowGrid {
    public ObjectId: Guid;
    public Defname: string;
    public RequestDate: string;
    public Doctor: string;
    public PretibialEdema: string;
    public MoherWeight: string;
    public BabyWeight: string;
    public FKA: string;
}