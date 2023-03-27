import { ChildGrowthVisits, InfantRiskFactors, ChildBrainDevelopmentRiskFactors, ParentalActivitiesForPsychologicalDevelopment } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { SKRSBebekteRiskFaktorleri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler } from "NebulaClient/Model/AtlasClientModel";
import { SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSBebeginBeslenmeDurumu } from "NebulaClient/Model/AtlasClientModel";
import { SKRSGelisimTablosuBilgilerininSorgulanmasi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDVitaminiLojistigiveDestegi } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDemirLojistigiveDestegi } from "NebulaClient/Model/AtlasClientModel";

export class VisitDetailsFormViewModel extends BaseViewModel {
    //@Exclude()
    protected __type__: string = 'Core.Models.VisitDetailsFormViewModel, Core';
    @Type(() => ChildGrowthVisits)
    public _ChildGrowthVisits: ChildGrowthVisits = new ChildGrowthVisits();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Guid)
    public PatientID: Guid;
    @Type(() => SKRSCinsiyet)
    public PatientSex: SKRSCinsiyet = new SKRSCinsiyet();
    public InfantRiskFactorsGridList: Array<InfantRiskFactors> = new Array<InfantRiskFactors>();
    public ChildBrainDevelopmentRiskFactorsGridList: Array<ChildBrainDevelopmentRiskFactors> = new Array<ChildBrainDevelopmentRiskFactors>();
    public ParentalActivitiesForPsychologicalDevelopmentGridList: Array<ParentalActivitiesForPsychologicalDevelopment> = new Array<ParentalActivitiesForPsychologicalDevelopment>();
    public SKRSBebeginBeslenmeDurumus: Array<SKRSBebeginBeslenmeDurumu> = new Array<SKRSBebeginBeslenmeDurumu>();
    public SKRSGelisimTablosuBilgilerininSorgulanmasis: Array<SKRSGelisimTablosuBilgilerininSorgulanmasi> = new Array<SKRSGelisimTablosuBilgilerininSorgulanmasi>();
    public SKRSDVitaminiLojistigiveDestegis: Array<SKRSDVitaminiLojistigiveDestegi> = new Array<SKRSDVitaminiLojistigiveDestegi>();
    public SKRSDemirLojistigiveDestegis: Array<SKRSDemirLojistigiveDestegi> = new Array<SKRSDemirLojistigiveDestegi>();
    public SKRSBebekteRiskFaktorleris: Array<SKRSBebekteRiskFaktorleri> = new Array<SKRSBebekteRiskFaktorleri>();
    public SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklers: Array<SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler> = new Array<SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler>();
    public SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleris: Array<SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri> = new Array<SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri>();
    public SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleriList: Array<SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri> = new Array<SKRSEbeveyninPsikolojikGelisimiDestekleyiciAktiviteleri>();
    public SKRSBebekteRiskFaktorleriList: Array<SKRSBebekteRiskFaktorleri> = new Array<SKRSBebekteRiskFaktorleri>();
    public SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRisklerList: Array<SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler> = new Array<SKRSBebeginCocugunBeyinGelisiminiEtkileyebilecekRiskler>();
}

export class VisitDetailsComponentInfoViewModel {
    @Type(() => DynamicComponentInfo)
    public visitComponentInfo: DynamicComponentInfo;
    @Type(() => QueryParams)
    public visitQueryParameters: QueryParams;
}



