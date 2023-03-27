//$DA247B92
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseNursingFallingDownRisk } from 'NebulaClient/Model/AtlasClientModel';
import { NursingFallingDownRisk } from 'NebulaClient/Model/AtlasClientModel';
import { FallingDownRiskDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseNursingFallingDownRiskFormViewModel extends BaseViewModel {
    @Type(() => BaseNursingFallingDownRisk)
    public _BaseNursingFallingDownRisk: BaseNursingFallingDownRisk = new BaseNursingFallingDownRisk();
    @Type(() => NursingFallingDownRisk)
    public NursingFallingDownRisksGridList: Array<NursingFallingDownRisk> = new Array<NursingFallingDownRisk>();
    @Type(() => FallingDownRiskDefinition)
    public FallingDownRiskDefinitions: Array<FallingDownRiskDefinition> = new Array<FallingDownRiskDefinition>();

    //public FallingRiskReasonList: Array<EnumLookupItem> = new Array<EnumLookupItem>();
    @Type(() => FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class)
    public FallingDownRiskDefinitionList: Array<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class> = new Array<FallingDownRiskDefinition.GetFallingDownRiskDefinition_Class>();
}

export class EnumLookupItem {
    public Name: string;
    public Key: string;
    public Value: string;
}