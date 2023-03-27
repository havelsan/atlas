//$B04B8786
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { GeneralInformation } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class GeneralInformationFormViewModel extends BaseViewModel {
    @Type(() => GeneralInformation)
    public _GeneralInformation: GeneralInformation = new GeneralInformation();
}
