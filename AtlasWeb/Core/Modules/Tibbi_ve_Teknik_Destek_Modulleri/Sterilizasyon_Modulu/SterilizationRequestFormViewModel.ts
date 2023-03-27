//$2D4DE2DA
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SterilizationRequest } from "NebulaClient/Model/AtlasClientModel";
import { SterilizationHistory } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ResReusableMaterial } from "NebulaClient/Model/AtlasClientModel";

export class SterilizationRequestFormViewModel extends BaseViewModel {
    public _SterilizationRequest: SterilizationRequest = new SterilizationRequest();
    public SterilizationHistoriesGridList: Array<SterilizationHistory> = new Array<SterilizationHistory>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public ResReusableMaterials: Array<ResReusableMaterial> = new Array<ResReusableMaterial>();

    public RequestResourceFilterExpression: string;
}
