//$262CB46A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingCare } from "NebulaClient/Model/AtlasClientModel";
import { NursingCareGrid } from "NebulaClient/Model/AtlasClientModel";
import { NursingReasonGrid } from "NebulaClient/Model/AtlasClientModel";
import { NursingTargetGrid } from "NebulaClient/Model/AtlasClientModel";
import { NursingProblemDefinition } from "NebulaClient/Model/AtlasClientModel";
import { NursingCareDefinition } from "NebulaClient/Model/AtlasClientModel";
import { NursingReasonDefinition } from "NebulaClient/Model/AtlasClientModel";
import { NursingTargetDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class NursingCareMainFormViewModel extends BaseViewModel {
    @Type(() => NursingCare)
    public _NursingCare: NursingCare = new NursingCare();
    @Type(() => NursingReasonDefinition)
    public NursingReasonDefinitions: Array<NursingReasonDefinition> = new Array<NursingReasonDefinition>();
    @Type(() => NursingTargetDefinition)
    public NursingTargetDefinitions: Array<NursingTargetDefinition> = new Array<NursingTargetDefinition>();
    @Type(() => NursingProblemDefinition)
    public NursingProblemDefinitions: Array<NursingProblemDefinition> = new Array<NursingProblemDefinition>();
    @Type(() => NursingCareDefinition)
    public NursingCareDefinitions: Array<NursingCareDefinition> = new Array<NursingCareDefinition>();

    public NursingCareGridsGridList: Array<NursingCareGrid> = new Array<NursingCareGrid>();
    public NursingReasonGridsGridList: Array<NursingReasonGrid> = new Array<NursingReasonGrid>();
    public NursingTargetGridsGridList: Array<NursingTargetGrid> = new Array<NursingTargetGrid>();

    ////t�m listeyi �ekmek i�in gerekiyor
    //public NursingReasonDefinitionsList: Array<NursingReasonDefinition> = new Array<NursingReasonDefinition>();
    //public NursingTargetDefinitionsList: Array<NursingTargetDefinition> = new Array<NursingTargetDefinition>();
    //public NursingProblemDefinitionsList: Array<NursingProblemDefinition> = new Array<NursingProblemDefinition>();
    //public NursingCareDefinitionsList: Array<NursingCareDefinition> = new Array<NursingCareDefinition>();

}


export class NursingDefinitionListsByProblemID  {


    public nursingCareDefinitionList: Array<NursingCareDefinition> = new Array<NursingCareDefinition>();
    public nursingTargetDefinitionList: Array<NursingTargetDefinition> = new Array<NursingTargetDefinition>();
    public nursingReasonDefinitionList: Array<NursingReasonDefinition> = new Array<NursingReasonDefinition>();



}