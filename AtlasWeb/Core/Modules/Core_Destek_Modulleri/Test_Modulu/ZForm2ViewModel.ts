//$D83E11DB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ZDeneme1 } from "NebulaClient/Model/AtlasClientModel";
import { SKRSKanGrubu } from "NebulaClient/Model/AtlasClientModel";
import { City } from "NebulaClient/Model/AtlasClientModel";

export class ZForm2ViewModel extends BaseViewModel {
    public _ZDeneme1: ZDeneme1 = new ZDeneme1();
    public SKRSKanGrubus: Array<SKRSKanGrubu> = new Array<SKRSKanGrubu>();
    public Citys: Array<City> = new Array<City>();
}
