//$635E4C93
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";

export class RadiologyTestDentalToothSchemaViewModel extends BaseViewModel  {
    public _RadiologyTest: RadiologyTest = new RadiologyTest();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
}
