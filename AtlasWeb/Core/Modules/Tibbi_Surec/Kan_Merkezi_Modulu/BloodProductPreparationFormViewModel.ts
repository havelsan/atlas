//$3244ECC2
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BloodProductRequest } from 'NebulaClient/Model/AtlasClientModel';
import { BloodBankBloodProducts } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class BloodProductPreparationFormViewModel extends BaseViewModel {
    public _BloodProductRequest: BloodProductRequest = new BloodProductRequest();
    public ttgrid1GridList: Array<BloodBankBloodProducts> = new Array<BloodBankBloodProducts>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
}
