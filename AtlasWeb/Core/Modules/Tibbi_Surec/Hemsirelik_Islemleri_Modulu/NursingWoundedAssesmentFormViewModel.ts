//$B1192FA9
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingWoundedAssesment } from "NebulaClient/Model/AtlasClientModel";
import { WoundPhoto } from "NebulaClient/Model/AtlasClientModel";
import { WoundSideInfo } from "NebulaClient/Model/AtlasClientModel";
import { WoundLocalizationDef } from "NebulaClient/Model/AtlasClientModel";
import { WoundStageDef } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";

export class NursingWoundedAssesmentFormViewModel extends BaseViewModel {
    public _NursingWoundedAssesment: NursingWoundedAssesment = new NursingWoundedAssesment();
    @Type(() => WoundPhoto)
    public WoundPhotosGridList: Array<WoundPhoto> = new Array<WoundPhoto>();
    @Type(() => WoundStageDef)
    public WoundStageDefs: Array<WoundStageDef> = new Array<WoundStageDef>();
    @Type(() => WoundSideInfo)
    public WoundSideInfos: Array<WoundSideInfo> = new Array<WoundSideInfo>();
    @Type(() => WoundLocalizationDef)
    public WoundLocalizationDefs: Array<WoundLocalizationDef> = new Array<WoundLocalizationDef>();
    
    public PhotoString: string ;
}
