//$4F18D3AF
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ZDeneme1 } from "NebulaClient/Model/AtlasClientModel";
import { City } from "NebulaClient/Model/AtlasClientModel";

export class ZForm1ViewModel extends BaseViewModel {
    public _ZDeneme1: ZDeneme1 = new ZDeneme1();
    public Citys: Array<City> = new Array<City>();
}
