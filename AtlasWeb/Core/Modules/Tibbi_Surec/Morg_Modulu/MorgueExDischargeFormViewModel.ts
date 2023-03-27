//$71912B36
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Morgue } from "NebulaClient/Model/AtlasClientModel";
import { MorgueDeathType } from "NebulaClient/Model/AtlasClientModel";
import { DeathReasonDiagnosis } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOlumSekli } from "NebulaClient/Model/AtlasClientModel";
import { SKRSICD } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOlumNedeniTuru } from "NebulaClient/Model/AtlasClientModel";
import { SKRSYaralanmaninYeri } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOlumYeri } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { MernisDeathReasonDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class MorgueExDischargeFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.MorgueExDischargeFormViewModel, Core';
    @Type(() => Morgue)
    public _Morgue: Morgue = new Morgue();
    @Type(() => MorgueDeathType)
    public MorgueDeathTypeGridList: Array<MorgueDeathType> = new Array<MorgueDeathType>();
    @Type(() => DeathReasonDiagnosis)
    public DeathReasonDiagnosisGridList: Array<DeathReasonDiagnosis> = new Array<DeathReasonDiagnosis>();
    @Type(() => SKRSOlumSekli)
    public SKRSOlumSeklis: Array<SKRSOlumSekli> = new Array<SKRSOlumSekli>();
    @Type(() => Morgue)
    public Morgues: Array<Morgue> = new Array<Morgue>();
    @Type(() => SKRSICD)
    public SKRSICDs: Array<SKRSICD> = new Array<SKRSICD>();
    @Type(() => SKRSOlumNedeniTuru)
    public SKRSOlumNedeniTurus: Array<SKRSOlumNedeniTuru> = new Array<SKRSOlumNedeniTuru>();
    @Type(() => SKRSYaralanmaninYeri)
    public SKRSYaralanmaninYeris: Array<SKRSYaralanmaninYeri> = new Array<SKRSYaralanmaninYeri>();
    @Type(() => SKRSOlumYeri)
    public SKRSOlumYeris: Array<SKRSOlumYeri> = new Array<SKRSOlumYeri>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => MernisDeathReasonDefinition)
    public MernisDeathReasonDefinitions: Array<MernisDeathReasonDefinition> = new Array<MernisDeathReasonDefinition>();
    public _selectedDeathType: Object;
    public _selectedDeathReason: Object;
}
