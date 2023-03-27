//$E44680D2
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class LaboratoryRequestRequestFormViewModel extends BaseViewModel {
    public _LaboratoryRequest: LaboratoryRequest = new LaboratoryRequest();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
