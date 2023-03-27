//$DF27D370
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Phototherapy } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class PhototherapyFormViewModel extends BaseViewModel {
    @Type(() => Phototherapy)
    public _Phototherapy: Phototherapy = new Phototherapy();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => PhototherapyDefinitionDVO)
    public PhototherapyDefinitionList: Array<PhototherapyDefinitionDVO> = new Array<PhototherapyDefinitionDVO>();
}

export class PhototherapyDefinitionDVO {
    @Type(() => Number)
    ComplicatedExctrans: number;
    @Type(() => Number)
    UncomplicatedExctrans: number;
    @Type(() => Number)
    ComplicatedPhototherapy: number;
    @Type(() => Number)
    UncomplicatedPhototherapy: number;
    @Type(() => Number)
    StartTime: number;
    @Type(() => Number)
    FinishTime: number;
    @Type(() => Number)
    MaxWeight: number;
    @Type(() => Number)
    MinWeight: number;
}