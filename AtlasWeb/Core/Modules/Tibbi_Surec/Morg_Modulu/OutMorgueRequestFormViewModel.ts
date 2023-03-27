//$56B48A80
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Morgue } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { MernisDeathReasonDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { SKRSCinsiyet } from "NebulaClient/Model/AtlasClientModel";
import { SKRSILKodlari } from "NebulaClient/Model/AtlasClientModel";
import { SKRSOlumYeri } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";

export class OutMorgueRequestFormViewModel extends BaseViewModel {
    @Type(() => Morgue)
    public _Morgue: Morgue = new Morgue();
    @Type(() => SKRSOlumYeri)
    public SKRSOlumYeris: Array<SKRSOlumYeri> = new Array<SKRSOlumYeri>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => MernisDeathReasonDefinition)
    public MernisDeathReasonDefinitions: Array<MernisDeathReasonDefinition> = new Array<MernisDeathReasonDefinition>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => SKRSCinsiyet)
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
}
