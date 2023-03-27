//$9E77E85A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PersonnelIntegration } from 'NebulaClient/Model/AtlasClientModel';

export class PersonnelIntegrationFormViewModel extends BaseViewModel {

    public _PersonnelIntegration: PersonnelIntegration = new PersonnelIntegration();

}


export class PersonnelResultModel  {

    public ErrorMsg: string;
    public ErrorCode: number;
    public URL: string;
}