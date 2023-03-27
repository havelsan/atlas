//$B5767488
import { PostpartumFollowUp, SKRSKonjenitalAnomaliliDogumVarligi } from "NebulaClient/Model/AtlasClientModel";
import { WomanHealthOperations } from "NebulaClient/Model/AtlasClientModel";
import { PostpartumDangerSigns } from "NebulaClient/Model/AtlasClientModel";
import { ComplicationDiagnosis } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKadinSagligiIslemleri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGebelikLohusalikSeyrindeTehlikeIsareti } from "NebulaClient/Model/AtlasClientModel";
import { SKRSICD } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKonjenitalAnomaliVarligi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSUterusInvolusyon } from "NebulaClient/Model/AtlasClientModel";
import { SKRSPostpartumDepresyon } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDVitaminiLojistigiveDestegi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDemirLojistigiveDestegi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKacinciLohusaIzlem } from "NebulaClient/Model/AtlasClientModel";
import { BaseViewModel } from "app/NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class PostpartumFollowUpFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PostpartumFollowUpFormViewModel, Core';

    @Type(() => PostpartumFollowUp)
    public _PostpartumFollowUp: PostpartumFollowUp = new PostpartumFollowUp();

    @Type(() => WomanHealthOperations)
    public WomanHealthOperationsGridList: Array<WomanHealthOperations> = new Array<WomanHealthOperations>();

    @Type(() => PostpartumDangerSigns)
    public DangerSignsGridList: Array<PostpartumDangerSigns> = new Array<PostpartumDangerSigns>();

    @Type(() => ComplicationDiagnosis)
    public ComplicationDiagnosisGridList: Array<ComplicationDiagnosis> = new Array<ComplicationDiagnosis>();

    @Type(() => SKRSKadinSagligiIslemleri)
    public SKRSKadinSagligiIslemleris: Array<SKRSKadinSagligiIslemleri> = new Array<SKRSKadinSagligiIslemleri>();

    @Type(() => SKRSGebelikLohusalikSeyrindeTehlikeIsareti)
    public SKRSGebelikLohusalikSeyrindeTehlikeIsaretis: Array<SKRSGebelikLohusalikSeyrindeTehlikeIsareti> = new Array<SKRSGebelikLohusalikSeyrindeTehlikeIsareti>();

    @Type(() => SKRSICD)
    public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();

    @Type(() => SKRSKonjenitalAnomaliliDogumVarligi)
    public SKRSKonjenitalAnomaliliDogumVarligis: Array<SKRSKonjenitalAnomaliliDogumVarligi> = new Array<SKRSKonjenitalAnomaliliDogumVarligi>();

    @Type(() => SKRSUterusInvolusyon)
    public SKRSUterusInvolusyons: Array<SKRSUterusInvolusyon> = new Array<SKRSUterusInvolusyon>();

    @Type(() => SKRSPostpartumDepresyon)
    public SKRSPostpartumDepresyons: Array<SKRSPostpartumDepresyon> = new Array<SKRSPostpartumDepresyon>();

    @Type(() => SKRSDVitaminiLojistigiveDestegi)
    public SKRSDVitaminiLojistigiveDestegis: Array<SKRSDVitaminiLojistigiveDestegi> = new Array<SKRSDVitaminiLojistigiveDestegi>();

    @Type(() => SKRSDemirLojistigiveDestegi)
    public SKRSDemirLojistigiveDestegis: Array<SKRSDemirLojistigiveDestegi> = new Array<SKRSDemirLojistigiveDestegi>();

    @Type(() => SKRSKacinciLohusaIzlem)
    public SKRSKacinciLohusaIzlems: Array<SKRSKacinciLohusaIzlem> = new Array<SKRSKacinciLohusaIzlem>();
}
