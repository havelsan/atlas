//$EBF439B4
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ResourceSpecialityGrid } from "NebulaClient/Model/AtlasClientModel";
import { ResUserUsableStore } from "NebulaClient/Model/AtlasClientModel";
import { UserResource } from "NebulaClient/Model/AtlasClientModel";
import { ResUserPatientGroupMatch } from "NebulaClient/Model/AtlasClientModel";
import { Person } from "NebulaClient/Model/AtlasClientModel";
import { TownDefinitions } from "NebulaClient/Model/AtlasClientModel";
import { SKRSCinsiyet } from "NebulaClient/Model/AtlasClientModel";
import { SKRSUlkeKodlari } from "NebulaClient/Model/AtlasClientModel";
import { SKRSILKodlari } from "NebulaClient/Model/AtlasClientModel";
import { ForcesCommand } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RankDefinitions } from "NebulaClient/Model/AtlasClientModel";
import { MilitaryClassDefinitions } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { PatientGroupDefinition } from "NebulaClient/Model/AtlasClientModel";

import { Type } from 'NebulaClient/ClassTransformer';

export class ResUserFormViewModel extends BaseViewModel {

    @Type(() => ResUser)
    public _ResUser: ResUser = new ResUser();

    @Type(() => ResourceSpecialityGrid)
    public ResourceSpecialitiesGridList: Array<ResourceSpecialityGrid> = new Array<ResourceSpecialityGrid>();

    @Type(() => ResUserUsableStore)
    public ResUserUsableStoresGridList: Array<ResUserUsableStore> = new Array<ResUserUsableStore>();

    @Type(() => UserResource)
    public UserResourcesGridList: Array<UserResource> = new Array<UserResource>();

    @Type(() => ResUserPatientGroupMatch)
    public ResUserPatientGroupMatchesGridList: Array<ResUserPatientGroupMatch> = new Array<ResUserPatientGroupMatch>();

    @Type(() => Person)
    public Persons: Array<Person> = new Array<Person>();

    @Type(() => TownDefinitions)
    public TownDefinitionss: Array<TownDefinitions> = new Array<TownDefinitions>();

    @Type(() => SKRSCinsiyet)
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();

    @Type(() => SKRSUlkeKodlari)
    public SKRSUlkeKodlaris: Array<SKRSUlkeKodlari> = new Array<SKRSUlkeKodlari>();

    @Type(() => SKRSILKodlari)
    public SKRSILKodlaris: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();

    @Type(() => ForcesCommand)
    public ForcesCommands: Array<ForcesCommand> = new Array<ForcesCommand>();

    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();

    @Type(() => RankDefinitions)
    public RankDefinitionss: Array<RankDefinitions> = new Array<RankDefinitions>();

    @Type(() => MilitaryClassDefinitions)
    public MilitaryClassDefinitionss: Array<MilitaryClassDefinitions> = new Array<MilitaryClassDefinitions>();

    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();

    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();

    @Type(() => PatientGroupDefinition)
    public PatientGroupDefinitions: Array<PatientGroupDefinition> = new Array<PatientGroupDefinition>();

    public txtUserName: string;//Kullan�c� Ad�
}
