//$47E987D2
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class LaboratoryFormViewModel extends BaseViewModel {
    public _LaboratoryRequest: LaboratoryRequest = new LaboratoryRequest();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
