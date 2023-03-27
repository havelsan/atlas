//$AA7B42DD
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DispatchToOtherHospital } from "NebulaClient/Model/AtlasClientModel";
import { DoctorGrid } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { SevkTedaviTipi } from "NebulaClient/Model/AtlasClientModel";
import { SevkVasitasi } from "NebulaClient/Model/AtlasClientModel";
import { SevkNedeni } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ExternalHospitalDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SKRSILKodlari } from "NebulaClient/Model/AtlasClientModel";
import { ReferableHospital } from "NebulaClient/Model/AtlasClientModel";
import { Sites } from "NebulaClient/Model/AtlasClientModel";
import { ReferableResource } from "NebulaClient/Model/AtlasClientModel";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { Type } from 'NebulaClient/ClassTransformer';

export class DispatchToOtherHospitalFormViewModel extends BaseViewModel {
    public _DispatchToOtherHospital: DispatchToOtherHospital = new DispatchToOtherHospital();
    public ttgridSevkEdenDoktorlarGridList: Array<DoctorGrid> = new Array<DoctorGrid>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public SevkTedaviTipis: Array<SevkTedaviTipi> = new Array<SevkTedaviTipi>();
    public SevkVasitasis: Array<SevkVasitasi> = new Array<SevkVasitasi>();
    public SevkNedenis: Array<SevkNedeni> = new Array<SevkNedeni>();
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    public ExternalHospitalDefinitions: Array<ExternalHospitalDefinition> = new Array<ExternalHospitalDefinition>();
    public Citys: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    public ReferableHospitals: Array<ReferableHospital> = new Array<ReferableHospital>();
    public Sitess: Array<Sites> = new Array<Sites>();
    public ReferableResources: Array<ReferableResource> = new Array<ReferableResource>();


    public isSGK: boolean;
    public isStartedByTreatmentDischarge: boolean;


}

export class DispatchToOtherHospitalComponentInfoViewModel {
    @Type(() => DynamicComponentInfo)
    public dispatchComponentInfo: DynamicComponentInfo;
    @Type(() => QueryParams)
    public dispatchQueryParameters: QueryParams;
}