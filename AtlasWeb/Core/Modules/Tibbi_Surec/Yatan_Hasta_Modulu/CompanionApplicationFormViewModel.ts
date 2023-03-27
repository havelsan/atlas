//$D2D00B78
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { CompanionApplication } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCinsiyet } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { DietDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class CompanionApplicationFormViewModel extends BaseViewModel {
    @Type(() => CompanionApplication)
    public _CompanionApplication: CompanionApplication = new CompanionApplication();
    @Type(() => SKRSCinsiyet)
    public SKRSCinsiyets: Array<SKRSCinsiyet> = new Array<SKRSCinsiyet>();
    @Type(() => DietDefinition)
    public DietDefinitions: Array<DietDefinition> = new Array<DietDefinition>();
    public minCompanionDate : string;
}

export class CompanionApplicationComponentInfoViewModel  {
    @Type(() => DynamicComponentInfo)
    public companionComponentInfo: DynamicComponentInfo;
    @Type(() => QueryParams)
    public companionQueryParameters: QueryParams;    
}
