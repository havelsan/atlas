//$9431A5BA
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseNursingSystemInterrogation } from 'NebulaClient/Model/AtlasClientModel';
import { NursingSystemInterrogation } from 'NebulaClient/Model/AtlasClientModel';
import { SystemInterrogationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseNursingSystemInterrogationFormViewModel extends BaseViewModel {
    @Type(() => BaseNursingSystemInterrogation)
    public _BaseNursingSystemInterrogation: BaseNursingSystemInterrogation = new BaseNursingSystemInterrogation();
    @Type(() => NursingSystemInterrogation)
    public NursingSystemInterrogationsGridList: Array<NursingSystemInterrogation> = new Array<NursingSystemInterrogation>();
    @Type(() => SystemInterrogationDefinition)
    public SystemInterrogationDefinitions: Array<SystemInterrogationDefinition> = new Array<SystemInterrogationDefinition>();
    public SystemInterrogationDefinitionViewList: Array<SystemInterrogationDefinitionList_Class> = new Array<SystemInterrogationDefinitionList_Class>();
}

export class SystemInterrogationDefinitionList_Class {

    public GroupName: string;
    @Type(() => SystemInterrogationDefinition)
    public SystemInterrogationDefinitionList: Array<SystemInterrogationDefinition> = new Array<SystemInterrogationDefinition>();

    constructor() {
        this.SystemInterrogationDefinitionList = new Array<SystemInterrogationDefinition>();
    }

}
